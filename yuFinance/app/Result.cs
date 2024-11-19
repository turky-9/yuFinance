using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.context;

namespace yuFinance.app
{
    /// <summary>
    /// 処理を表す親クラス
    /// </summary>
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

    /// <summary>
    /// 処理開始
    /// </summary>
    public class StartProcess<T>: Result where T : AbstractApp
    {
        public override bool IsFailed => false;
        private AbstractApp App;

        public StartProcess(Context ctx, T app) : base(ctx)
        {
            this.App = app;
        }
    }

    /// <summary>
    /// 成功
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Success<T> : Result
    {
        public override bool IsFailed => false;

        public T Result { get; private set; }
        public Success(Context ctx, T x) : base(ctx)
        {
            this.Result = x;
        }
    }

    /// <summary>
    /// 失敗
    /// </summary>
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
