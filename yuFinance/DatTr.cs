using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance
{
    [DataContract]
    public class DatTr
    {
        [DataMember]
        public string TrCd { get; private set; } = UtlInit.String();
        [DataMember]
        public string TrNm { get; private set; } = UtlInit.String();
        [DataMember]
        public DateTime InsDate { get; private set; } = UtlInit.DateTime();

        internal DatTr() { }
        internal DatTr(string cd, string nm, DateTime now)
        {
            this.TrCd = cd;
            this.TrNm = nm;
            this.InsDate = now;
        }

        public override bool Equals(object obj)
        {
            var tr = obj as DatTr;
            return tr != null &&
                   TrCd == tr.TrCd;
        }

        public override int GetHashCode()
        {
            return 1203444716 + EqualityComparer<string>.Default.GetHashCode(TrCd);
        }
    }
}
