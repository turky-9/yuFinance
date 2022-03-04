using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.model;
using yuFinance.util;

namespace yuFinance.context
{
    public class Context
    {
        internal IList<DatKmk> KmkMaster = UtlInit.DatList<DatKmk>();
        internal IList<DatTr> TrMaster = UtlInit.DatList<DatTr>();
        internal IList<DatJournal> Journal = UtlInit.DatList<DatJournal>();

        public bool IsDirty { get; internal set; } = false;

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

        //internal DatKmk GetKmk(string cd)
        //{
        //    return this.KmkMaster.Where(x => x.KmkCd == cd).FirstOrDefault();
        //}

        //internal void AddKmk(DatKmk d)
        //{
        //    this.IsDirty = true;
        //    this.KmkMaster.Add(d);
        //}

    }
}
