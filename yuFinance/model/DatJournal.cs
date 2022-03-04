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
    public class DatJournal
    {
        [DataMember]
        public int JnlNo { get; private set; } = UtlInit.Number();
        [DataMember]
        public DateTime Accrual { get; private set; } = UtlInit.DateTime();
        [DataMember]
        public List<DatElement> Debtor { get; private set; } = UtlInit.DatList<DatElement>();
        [DataMember]
        public List<DatElement> Creditor { get; private set; } = UtlInit.DatList<DatElement>();
        [DataMember]
        public string Tekiyo { get; private set; } = UtlInit.String();
        [DataMember]
        public bool IsDeleted { get; private set; } = UtlInit.False();
        [DataMember]
        public DateTime InsDate { get; private set; } = UtlInit.DateTime();
        [DataMember]
        public DateTime UpdDate { get; private set; } = UtlInit.DateTime();

        public decimal Amount
        {
            get
            {
                return this.Debtor.Sum(x => x.Amount);
            }
        }
        public bool IsValid
        {
            get
            {
                return this.Debtor != null
                    && this.Debtor.Count >= 1
                    && this.Creditor != null
                    && this.Creditor.Count >= 1
                    && this.Debtor.Sum(x => x.Amount) == this.Creditor.Sum(x => x.Amount);
            }
        }

        internal DatJournal()
        {
        }

        public override bool Equals(object obj)
        {
            var journal = obj as DatJournal;
            return journal != null &&
                   JnlNo == journal.JnlNo;
        }

        public override int GetHashCode()
        {
            return -101303868 + JnlNo.GetHashCode();
        }
    }
}
