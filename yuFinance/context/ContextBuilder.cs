using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using yuFinance.model;
using yuFinance.util;

namespace yuFinance.context
{
    public interface IContextBuilder
    {
         Context Build();
    }

    public class FromFileBuilder : IContextBuilder
    {
        private string KmkFile;
        private string TrFile;
        private string JnlFile;

        public FromFileBuilder(string kmkfile, string trfile, string jnlfile)
        {
            this.KmkFile = kmkfile;
            this.TrFile = trfile;
            this.JnlFile = jnlfile;
        }

        public Context Build()
        {
            var curr = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fnm = System.IO.Path.Combine(curr, this.KmkFile);
            IList<DatKmk> kmkMaster = null;
            if(File.Exists(fnm))
            {
                using(var stream = new FileStream(fnm, FileMode.Open))
                {
                    var se = new DataContractSerializer(typeof(List<DatKmk>));
                    kmkMaster = (IList<DatKmk>)se.ReadObject(stream);
                }
            }
            else
            {
                kmkMaster = UtlInit.DatList<DatKmk>();
            }

            fnm = System.IO.Path.Combine(curr, this.TrFile);
            IList<DatTr> trMaster = null;
            if(File.Exists(fnm))
            {
                using(var stream = new FileStream(fnm, FileMode.Open))
                {
                    var se = new DataContractSerializer(typeof(List<DatTr>));
                    trMaster = (IList<DatTr>)se.ReadObject(stream);
                }
            }
            else
            {
                trMaster = UtlInit.DatList<DatTr>();
            }

            fnm = System.IO.Path.Combine(curr, this.JnlFile);
            IList<DatJournal> jnl = null;
            if(File.Exists(fnm))
            {
                using(var stream = new FileStream(fnm, FileMode.Open))
                {
                    var se = new DataContractSerializer(typeof(List<DatJournal>));
                    jnl = (IList<DatJournal>)se.ReadObject(stream);
                }
            }
            else
            {
                jnl = UtlInit.DatList<DatJournal>();
            }

            return new Context(kmkMaster, trMaster, jnl);
        }
    }
}
