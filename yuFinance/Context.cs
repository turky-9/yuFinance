using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuFinance
{
    public class Context
    {
        private IList<DatKmk> KmkMaster = UtlInit.DatList<DatKmk>();
        private IList<DatTr> TrMaster = UtlInit.DatList<DatTr>();
        private IList<DatJournal> Journal = UtlInit.DatList<DatJournal>();

        public bool IsDirty { get; private set; } = false;

        public Context(IList<DatKmk> kmk, IList<DatTr> tr, IList<DatJournal> jnl)
        {
            this.KmkMaster = kmk;
            this.TrMaster = tr;
            this.Journal = jnl;
        }

        public void Store(IContextStorer storer)
        {
            if (this.IsDirty)
            {
                storer.StoreJournal(this.Journal);
                storer.StoreKmkMaster(this.KmkMaster);
                storer.StoreTrMaster(this.TrMaster);
                this.IsDirty = false;
            }
        }

        internal DatKmk GetKmk(string cd)
        {
            return this.KmkMaster.Where(x => x.KmkCd == cd).FirstOrDefault();
        }

        internal void AddKmk(DatKmk d)
        {
            this.IsDirty = true;
            this.KmkMaster.Add(d);
        }

        internal DatTr GetTr(string cd)
        {
            return this.TrMaster.Where(x => x.TrCd == cd).FirstOrDefault();
        }

        internal void AddTr(DatTr d)
        {
            this.IsDirty = true;
            this.TrMaster.Add(d);
        }
    }
}
