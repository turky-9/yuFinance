using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.app;
using yuFinance.context;

namespace yuFinance.util
{
    internal class UtilApp
    {
        internal static (Context, Faild, Success<T>) PreProcess<T>(Result arg)
        {
            var ctx = arg.GetContext();
            var succ = arg as Success<T>;
            Faild f = arg as Faild;

            if(f != null)
            {
                return (ctx, f, succ);
            }
            if(succ == null)
            {
                f = new Faild(ctx, $"arg type is not {typeof(Success<T>).Name}. arg type is {arg.GetType().Name}");
            }
            return (ctx, f, succ);
        }
    }
}
