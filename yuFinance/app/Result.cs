using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.context;

namespace yuFinance.app
{
    public abstract class Result
    {
        public abstract bool IsFailed { get; }
        protected Context Ctx { get;  set; }
        public Result(Context ctx)
        {
            this.Ctx = ctx;
        }

        internal Context GetContext()
        {
            return this.Ctx;
        }
    }

    public class StartProcess : Result
    {
        public override bool IsFailed => false;
        public StartProcess(Context ctx) : base(ctx) { }
    }

    public class Success<T> : Result
    {
        public override bool IsFailed => false;

        public T Result { get; private set; }
        public Success(Context ctx, T x) : base(ctx)
        {
            this.Result = x;
        }
    }

    public class Faild : Result
    {
        public override bool IsFailed => true;

        public string Error { get; private set; }
        public Faild(Context ctx, string x) : base(ctx)
        {
            this.Error = x;
        }
    }
}
