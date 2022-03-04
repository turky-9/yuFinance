using System;
using System.Linq;
using yuFinance.model;
using yuFinance.util;

namespace yuFinance.app
{
    public static class TrMasterApp
    {

        public static Result CreateEntity(this Result process, string cd, string nm)
        {
            if(process.IsFailed)
            {
                return process;
            }

            var ctx = process.GetContext();
            var d = new DatTr(cd, nm, DateTime.Now);
            return new Success<DatTr>(ctx, d);
        }

        public static Result CheckCd(this Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatTr>(process);
            if (failed != null)
            {
                return failed;
            }

            if(string.IsNullOrEmpty(success.Result.TrCd))
            {
                return new Faild(ctx, "tr cd is null");
            }

            return new Success<DatTr>(ctx, success.Result);
        }

        public static Result CheckNm(this Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatTr>(process);
            if (failed != null)
            {
                return failed;
            }

            if(string.IsNullOrEmpty(success.Result.TrNm))
            {
                return new Faild(ctx, "tr nm is null");
            }

            return new Success<DatTr>(ctx, success.Result);
        }

        public static Result IsExist(this Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatTr>(process);
            if (failed != null)
            {
                return failed;
            }

            var d = process.GetContext().TrMaster.Where(x => x.TrCd == success.Result.TrCd).FirstOrDefault();
            if(d == null)
            {
                return new Success<DatTr>(ctx, success.Result);
            }
            else
            {
                return new Faild(ctx, $"tr cd({success.Result.TrCd}) is already exist");
            }
        }

        public static Result AddTr(this Result process)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatTr>(process);
            if (failed != null)
            {
                return failed;
            }

            ctx.TrMaster.Add(success.Result);
            ctx.IsDirty = true;

            return new Success<DatTr>(ctx, success.Result);
        }

        public static Result GetTr(this Result process, string cd)
        {
            var (ctx, failed, success) = UtilApp.PreProcess<DatTr>(process);
            if (failed != null)
            {
                return failed;
            }

            var d = process.GetContext().TrMaster.Where(x => x.TrCd == cd).FirstOrDefault();
            if(d == null)
            {
                return new Faild(ctx, "tr cd is not exists");
            }

            return new Success<DatTr>(ctx, d);
        }
    }
}
