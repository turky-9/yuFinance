using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;

namespace yuFinance
{
    public interface IContextStorer
    {
        void StoreKmkMaster(IList<DatKmk> kmk);
        void StoreTrMaster(IList<DatTr> tr);
        void StoreJournal(IList<DatJournal> jnl);
    }

    public class ToFileStorer : IContextStorer
    {
        private string KmkFile;
        private string TrFile;
        private string JnlFile;
        private string CurrDir;

        public ToFileStorer(string kmkfile, string trfile, string jnlfile)
        {
            this.KmkFile = kmkfile;
            this.TrFile = trfile;
            this.JnlFile = jnlfile;

            this.CurrDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public void StoreJournal(IList<DatJournal> jnl)
        {
            var fnm = System.IO.Path.Combine(this.CurrDir, this.JnlFile);
            using (var stream = new FileStream(fnm, FileMode.Create, FileAccess.Write))
            {
                var se = new DataContractSerializer(typeof(List<DatJournal>));
                se.WriteObject(stream, jnl);
            }
        }

        public void StoreKmkMaster(IList<DatKmk> kmk)
        {
            var fnm = System.IO.Path.Combine(this.CurrDir, this.KmkFile);
            using (var stream = new FileStream(fnm, FileMode.Create, FileAccess.Write))
            {
                var se = new DataContractSerializer(typeof(List<DatKmk>));
                se.WriteObject(stream, kmk);
            }
        }

        public void StoreTrMaster(IList<DatTr> tr)
        {
            var fnm = System.IO.Path.Combine(this.CurrDir, this.TrFile);
            using (var stream = new FileStream(fnm, FileMode.Create, FileAccess.Write))
            {
                var se = new DataContractSerializer(typeof(List<DatTr>));
                se.WriteObject(stream, tr);
            }
        }
    }
}
