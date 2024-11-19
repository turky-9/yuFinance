using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance.model
{
    [DataContract]
    public enum EJournalStat
    {
        /// <summary>
        /// 通常
        /// </summary>
        [EnumMember]
        Normal,

        /// <summary>
        /// 決算
        /// </summary>
        [EnumMember]
        Settlement,

        /// <summary>
        /// 削除
        /// </summary>
        [EnumMember]
        Delete
    }
}
