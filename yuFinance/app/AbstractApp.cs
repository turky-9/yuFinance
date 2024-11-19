using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.context;

namespace yuFinance.app
{
    public abstract class AbstractApp
    {
        protected Context Ctx { get; set; }

        public AbstractApp(Context ctx)
        {
            this.Ctx = ctx;
        }
        //public bool IsFaild(Result result)
        //{
        //    return result == null || result is Faild;
        //}
    }
}
