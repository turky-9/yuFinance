using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yuFinance.context;
using yuFinance.model;
using yuFinance.util;

namespace yuFinance.app
{
    public class KmkMasterApp : AbstractApp
    {
        public KmkMasterApp(Context ctx) : base(ctx)
        {
        }

        public Result InsKmk(string cd, string nm, EKmkKbn kkbn, EDrCrKbn dckbn, string order)
        {
            var result = this.ParamCheck(cd, nm, kkbn, dckbn, order);

            result = this.IsExistCheck(result);

            result = this.KmkAdd(result);

            return result;
        }

        private Result ParamCheck(string cd, string nm, EKmkKbn kkbn, EDrCrKbn dckbn, string order)
        {
            if (string.IsNullOrEmpty(cd))
            {
                return new Faild(this.Ctx, "kmk cd is null");
            }

            if (string.IsNullOrEmpty(nm))
            {
                return new Faild(this.Ctx, "kmk nm is null");
            }

            if (string.IsNullOrEmpty(order))
            {
                return new Faild(this.Ctx, "kmk order is null");
            }

            int o = UtlInit.Number();
            if (int.TryParse(order, out o))
            {
                if (o <= 0)
                {
                    return new Faild(this.Ctx, "kmk order must be plus number");
                }
            }
            else
            {
                return new Faild(this.Ctx, "kmk order is not number");
            }

            if (kkbn == EKmkKbn.None)
            {
                return new Faild(this.Ctx, "kmk kmkkbn is none");
            }

            if (dckbn == EDrCrKbn.None)
            {
                return new Faild(this.Ctx, "kmk dckbn is none");
            }

            var obj = new DatKmk(cd, nm, kkbn, dckbn, o, DateTime.Now);

            return new Success<DatKmk>(this.Ctx, obj);
        }

        private Result IsExistCheck(Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatKmk>(process);
            if (failed != null)
            {
                return failed;
            }

            var d = process.GetContext().KmkMaster.Where(x => x.KmkCd == success.Result.KmkCd).FirstOrDefault();
            if (d == null)
            {
                return new Success<DatKmk>(ctx, success.Result);
            }
            else
            {
                return new Faild(ctx, $"kmk cd({success.Result.KmkCd}) is already exist");
            }
        }

        private Result KmkAdd(Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatKmk>(process);
            if (failed != null)
            {
                return failed;
            }

            ctx.KmkMaster.Add(success.Result);
            ctx.IsDirty = true;

            return new Success<DatKmk>(ctx, success.Result);
        }

        public ImmutableList<DatKmk> GetList()
        {
            return this.Ctx.KmkMaster.ToImmutableList();
        }
    }
}

