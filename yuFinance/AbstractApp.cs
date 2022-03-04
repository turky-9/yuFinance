using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuFinance
{
    public abstract class AbstractApp
    {
        public bool IsFaild(Result result)
        {
            return result == null || result is Faild;
        }
    }
}
