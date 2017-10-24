using SmartEngineer.Core.Model.Common;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.DAOs
{
    public interface ISequenceGenerator
    {
        /// <summary>
        /// return the next, unique sequence value 
        /// </summary>
        /// <param name="sSeqName">the name of the sequence</param>
        /// <returns></returns>
        int getNextValue(String sSeqName);

        /// <summary>
        /// return the next seqSize, unique sequence value
        /// </summary>
        /// <param name="sSeqName">the name of the sequence</param>
        /// <param name="seqSize">the size of the seqNumber</param>
        /// <returns></returns>
        SequenceModel getNextValueForBigCache(String sSeqName, long seqSize);
    }
}
