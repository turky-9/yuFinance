using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using yuFinance.util;

namespace yuFinance.model
{
    /// <summary>
    /// TODO: 親子関係(集計科目と入力科目)l
    /// </summary>
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
        public int Order { get; private set; } = UtlInit.Number();
        [DataMember]
        public DateTime InsDate { get; private set; } = UtlInit.DateTime();

        internal DatKmk()
        {
        }

        internal DatKmk(string cd, string nm, EKmkKbn kkbn, EDrCrKbn dckbn, int order, DateTime now)
        {
            this.KmkCd = cd;
            this.KmkNm = nm;
            this.KmkKbn = kkbn;
            this.DrCrKbn = dckbn;
            this.Order = order;
            this.InsDate = now;
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
