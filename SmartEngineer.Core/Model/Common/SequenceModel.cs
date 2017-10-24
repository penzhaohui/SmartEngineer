using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Models
{
    public class SequenceModel
    {
        public long LastNumber1 { get; set; }
        public long LastNumber2 { get; set; }
        public long Increment1 { get; set; }
        public long Increment2 { get; set; }
        public long NewLastNumber1 { get; set; }
        public long NewLastNumber2 { get; set; }
        public long SeqSize1 { get; set; }
        public long SeqSize2 { get; set; }

        /// <summary>
        /// get next sequence value from two part section of sequenceModel
        /// </summary>
        /// <returns></returns>
        public long getNextVal()
        {
            long lLastSeq = 0l;

            if (this.SeqSize1 > 0)
            {
                lLastSeq = this.LastNumber1 + this.Increment1;
                this.SeqSize1--;
                this.LastNumber1 = lLastSeq;
            }
            else
            {
                if (SeqSize2 > 0)
                {
                    lLastSeq = this.LastNumber2 + this.Increment2;
                    this.SeqSize2--;
                    this.LastNumber2 = lLastSeq;
                }
            }

            return lLastSeq;
        }
    }
}
