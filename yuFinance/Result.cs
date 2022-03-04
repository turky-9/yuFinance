using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuFinance
{
    public abstract class Result
    {
    }

    public class First : Result
    {
    }

    public class Success<T> : Result
    {
        public T Result { get; private set; }
        public Success(T x)
        {
            this.Result = x;
        }
    }

    public class Faild : Result
    {
        public string Error { get; private set; }
        public Faild(string x)
        {
            this.Error = x;
        }
    }
}
