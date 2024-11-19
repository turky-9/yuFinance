using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance.model
{
    [DataContract]
    public enum EKmkKbn
    {
        /// <summary>
        /// 初期値
        /// </summary>
        [EnumMember]
        None,

        /// <summary>
        /// 資産
        /// </summary>
        [EnumMember]
        Assets,

        /// <summary>
        /// 負債
        /// </summary>
        [EnumMember]
        Liabilities,

        /// <summary>
        /// 資本
        /// </summary>
        [EnumMember]
        Equity,

        /// <summary>
        /// 収益
        /// </summary>
        [EnumMember]
        Revenue,

        /// <summary>
        /// 費用
        /// </summary>
        [EnumMember]
        Expenses
    }
}
