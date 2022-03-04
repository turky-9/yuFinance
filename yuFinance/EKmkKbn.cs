using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance
{
    [DataContract]
    public enum EKmkKbn
    {
        // 初期値
        [EnumMember]
        None,

        // 資産
        [EnumMember]
        Assets,

        // 負債
        [EnumMember]
        Liabilities,

        // 資本
        [EnumMember]
        Equity,

        // 収益
        [EnumMember]
        Revenue,

        // 費用
        [EnumMember]
        Expenses
    }
}
