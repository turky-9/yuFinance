using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance
{
    [DataContract]
    public class DatKmk
    {
        [DataMember]
        public string KmkCd { get; private set; } = UtlInit.String();
        [DataMember]
        public string KmkNm { get; private set; } = UtlInit.String();
        [DataMember]
        public EKmkKbn KmkKbn { get; private set; } = UtlInit.KmkKbn();
        [DataMember]
        public EDrCrKbn DrCrKbn { get; private set; } = UtlInit.DrCrKbn();
        [DataMember]
        public DateTime InsDate { get; private set; } = UtlInit.DateTime();

        internal DatKmk()
        {
        }

        public override bool Equals(object obj)
        {
            var kmk = obj as DatKmk;
            return kmk != null &&
                   KmkCd == kmk.KmkCd;
        }

        public override int GetHashCode()
        {
            return -1393524507 + EqualityComparer<string>.Default.GetHashCode(KmkCd);
        }
    }
}
