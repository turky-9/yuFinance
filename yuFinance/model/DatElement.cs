using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using yuFinance.util;

namespace yuFinance.model
{
    [DataContract]
    public class DatElement
    {
        [DataMember]
        public decimal Amount { get; private set; } = UtlInit.Amount();
        [DataMember]
        public string KmkCd { get; private set; } = UtlInit.String();
        [DataMember]
        public String TrCd { get; private set; } = UtlInit.String();
        [DataMember]
        public string Tekiyo { get; private set; } = UtlInit.String();
        [DataMember]
        public DateTime InsDate { get; private set; } = UtlInit.DateTime();

        internal DatElement()
        {
        }
    }
}
