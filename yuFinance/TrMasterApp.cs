using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuFinance
{
    public class TrMasterApp : AbstractApp
    {
        private Context Ctx { get; set; }

        public TrMasterApp(Context ctx)
        {
            this.Ctx = ctx;
        }

        public Result AddTr(Result result, string cd, string nm)
        {
            if(this.IsFaild(result))
            {
                return result;
            }

            if(string.IsNullOrEmpty(cd))
            {
                return new Faild("tr cd is null");
            }
            if(string.IsNullOrEmpty(nm))
            {
                return new Faild("tr nm is null");
            }

            var tr = new DatTr(cd, nm, DateTime.Now);
            this.Ctx.AddTr(tr);

            return new Success<bool>(true);
        }
    }
}
