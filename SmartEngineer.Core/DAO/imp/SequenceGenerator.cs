using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEngineer.Core.Models;
using log4net;
using SmartEngineer.Framework.Logger;
using SmartEngineer.Core.Model.Common;
using System.Threading;

namespace SmartEngineer.Core.DAOs
{
    public class SequenceGenerator : ISequenceGenerator
    {
        private static Dictionary<string, SeqCacheEntry> m_seqCache = new Dictionary<string, SeqCacheEntry>();
        private int SEQ_CACHE_SIZE = 1000;

        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(SequenceGenerator));

        public int getNextValue(string sSeqName)
        {
            // Use oSeqEntry as a key: Guarantees
            SeqCacheEntry oSeqEntry = new SeqCacheEntry(sSeqName);

            lock (oSeqEntry.SeqName)
            {
                try
                {
                    if (!m_seqCache.ContainsKey(oSeqEntry.SeqName))
                    {
                        m_seqCache.Add(oSeqEntry.SeqName, oSeqEntry);
                    }

                    oSeqEntry = m_seqCache[oSeqEntry.SeqName];

                    if (oSeqEntry.SeqRemaining < 1)
                    {
                        bool isUpdateSuccess = true;
                        int iCountLoops = 0;

                        IDStore seqGenModel = null;
                        do
                        {
                            ++iCountLoops; // increments the count
                            if (iCountLoops > 1) // logs # retries
                            {
                                Logger.Info("Sequence #" + iCountLoops + " Retry for seqName: " + oSeqEntry.SeqName);
                                Thread.Sleep(50); // sleep for 50 ms to give retries a chance.
                            }

                            seqGenModel = GetSequenceModel(oSeqEntry.SeqName);

                            if (seqGenModel != null)
                            {

                                long lOldLastNumber = seqGenModel.LastNumber; // saves the old Last_Number for comparison in the SQL statement
                                long lNewLastNumber = oSeqEntry.resetSequences(seqGenModel.CacheSize, seqGenModel.LastNumber, seqGenModel.Increment);

                                seqGenModel.LastNumber = lNewLastNumber;
                                isUpdateSuccess = UpdateSequenceModel(seqGenModel, lOldLastNumber);
                            }
                            else
                            {
                                throw new Exception("Not found the sequence setting.");
                            }

                        } while (!isUpdateSuccess && iCountLoops < 10);

                        if (!isUpdateSuccess)
                        {
                            throw new Exception("Cannot retrieve sequence " + sSeqName + ": Operation timed out. ");
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (oSeqEntry != null)
                    {
                        m_seqCache.Remove(oSeqEntry.SeqName); // clean up after big error.
                    }

                    throw new Exception("Cannot retrieve sequence " + sSeqName + ":" + ex.Message, ex);
                }
            }

            return (int)oSeqEntry.nextVal();
        }        

        private IDStore GetSequenceModel(String sSeqName)
        {
            IDStore entity = new IDStore();
            entity.SeqName = sSeqName;

            IIDStoreDAO<IDStore> IDStoreDAO = new IDStoreDAO<IDStore>();
            
            return IDStoreDAO.GetEntity(entity);
        }

        private bool UpdateSequenceModel(IDStore entity, long lastNumber)
        {            
            IIDStoreDAO<IDStore> IDStoreDAO = new IDStoreDAO<IDStore>();

            return IDStoreDAO.Update(entity, lastNumber, DateTime.Now) > 0;
        }

        public SequenceModel getNextValueForBigCache(string sSeqName, long seqSize)
        {
            // Use oSeqEntry as a key: Guarantees
            SeqCacheEntry oSeqEntry = new SeqCacheEntry(sSeqName + "_BIG_CACHE");

            bool isPart1Filled = false; // judge whether part1 of sequenceModel was filled

            lock (oSeqEntry.SeqName)
            {
                SequenceModel sequence = new SequenceModel();

                try
                {
                    if (!m_seqCache.ContainsKey(oSeqEntry.SeqName))
                    {
                        m_seqCache.Add(oSeqEntry.SeqName, oSeqEntry);
                    }

                    oSeqEntry = m_seqCache[oSeqEntry.SeqName];

                    //if cache's size large than seqSize ,get sequence Number range from cache directly
                    if (oSeqEntry.SeqRemaining > seqSize)
                    {
                        oSeqEntry.nextVal(seqSize, sequence, true);
                        return sequence;
                    }
                    else if (oSeqEntry.SeqRemaining > 0)
                    {
                        //if cache's size less than seqSize ,get all remaining sequences from cache
                        // put this sequence number range to Part1
                        seqSize = seqSize - oSeqEntry.SeqRemaining;
                        oSeqEntry.nextVal(oSeqEntry.SeqRemaining, sequence, true);
                        isPart1Filled = true;
                    }

                    // if cache's size is less than 1, get remaining seqSize from DB
                    if (oSeqEntry.SeqRemaining < 1)
                    {
                        bool bUpdateSuccess = true; // will indicate whether the update sequence was successful
                        int iCountLoops = 0; // will count the loops
                        IDStore seqGenModel = null;

                        do
                        {
                            ++iCountLoops; // increments the count

                            if (iCountLoops > 1) // logs # retries
                            {
                                Logger.Info("Sequence #" + iCountLoops + " Retry for seqName: " + oSeqEntry.SeqName);
                                Thread.Sleep(50); // sleep for 50 ms to give retries a chance.
                            }

                            seqGenModel = GetSequenceModel(sSeqName.ToUpper());
                            if (seqGenModel != null)
                            {
                                long lOldLastNumber = seqGenModel.LastNumber;
                                long lNewLastNumber = oSeqEntry.resetSequences(SEQ_CACHE_SIZE + seqSize, seqGenModel.LastNumber, seqGenModel.Increment);
                                seqGenModel.LastNumber = lNewLastNumber;
                            }
                            else
                            {
                                throw new Exception("InvalidSequenceName");
                            }

                        } while (!bUpdateSuccess && iCountLoops < 10);

                        if (!bUpdateSuccess)
                        {
                            throw new Exception("Cannot retrieve sequence " + sSeqName + ": Operation timed out. ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (oSeqEntry == null)
                    {
                        m_seqCache.Remove(oSeqEntry.SeqName);
                    }
                    throw new Exception("Cannot retrieve sequence " + sSeqName + ":" + ex.Message, ex);
                }

                if (seqSize > 0)
                {
                    if (isPart1Filled)
                    {
                        // if Part1 of SequenceModel was filled , fill Part2 
                        oSeqEntry.nextVal(seqSize, sequence, false);
                    }
                    else
                    {
                        // if Part1 of SequenceModel wasn't filled , fill Part1 
                        oSeqEntry.nextVal(seqSize, sequence, false);
                    }
                }

                return sequence;
            }
        }

        private class SeqCacheEntry
        {
            public string SeqName { get; private set; }
            public long MaxSeq { get; private set; }
            public long SeqRemaining { get; private set; }
            public long LastSeq { get; private set; }
            public long SeqInc { get; private set; }
            public long Time { get; private set; }
            public long Count { get; private set; }
            public long AvgInterval { get; private set; }

            public SeqCacheEntry(string sSeqName)
            {
                if (sSeqName == null)
                {
                    this.SeqName = null;
                }
                else
                {
                    // https://msdn.microsoft.com/zh-cn/library/system.string.intern(VS.80).aspx
                    // 如果 str 的值已经留用，则返回系统的引用；否则返回对带有 str 值的字符串的新引用。
                    this.SeqName = String.Intern(sSeqName); // store the cannonical value
                }
                this.MaxSeq = 0;
                this.SeqRemaining = 0;
                this.LastSeq = 0;
                this.SeqInc = 0;

                this.Time = 0;
                this.Count = 0;
                this.AvgInterval = 0;
            }

            public long resetSequences(long lMaxSeq, long lLastSeq, long lSeqInc)
            {
                if (lMaxSeq < 1)
                {
                    // don't allow cache size of 0 or a negative number
                    lMaxSeq = 1;
                }
                if (lSeqInc == 0)
                {
                    // don't allow increment of 0
                    lSeqInc = 1;
                }

                this.SeqRemaining = lMaxSeq;
                this.MaxSeq = lMaxSeq;
                this.LastSeq = lLastSeq;
                this.SeqInc = lSeqInc;
                
                return lLastSeq + (lMaxSeq * lSeqInc); // allocate based on number of increments we are grabbing.
            }

            public long nextVal()
            {
                long lLastTime = Time;
                Time = DateTime.Now.Millisecond;
                if (lLastTime != 0)
                {
                    // calculate average interval in milliseconds
                    // this calculation will never exceed the size of a long
                    AvgInterval = (AvgInterval * Count + (Time - lLastTime)) / (Count + 1);
                }

                LastSeq += SeqInc;
                SeqRemaining--;
                Count++;

                return LastSeq;
            }

            public SequenceModel nextVal(long nextCount, SequenceModel sequence, bool fillPart1)
            {
                long lLastTime = Time;
                Time = DateTime.Now.Millisecond;

                if (lLastTime != 0)
                {
                    AvgInterval = (AvgInterval * Count + Time - lLastTime)/(Count + 1);
                }

                if (fillPart1)
                {
                    sequence.Increment1 = SeqInc;
                    sequence.LastNumber1 = LastSeq;
                    sequence.SeqSize1 = nextCount;
                }
                else
                {
                    sequence.Increment2 = SeqInc;
                    sequence.LastNumber2 = LastSeq;
                    sequence.SeqSize2 = nextCount;
                }

                LastSeq += LastSeq * nextCount;

                if (fillPart1)
                {
                    sequence.NewLastNumber1 = LastSeq;
                }
                else
                {
                    sequence.NewLastNumber2 = LastSeq;
                }

                SeqRemaining -= nextCount;
                Count += nextCount;

                return sequence;
            }
        }
    }
}
