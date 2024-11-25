﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace yuFinance.model
{
    [DataContract]
    public enum EDrCrKbn
    {
        /// <summary>
        /// 初期値
        /// </summary>
        [EnumMember]
        None,

        /// <summary>
        /// 借方
        /// </summary>
        [EnumMember]
        Debtor,

        /// <summary>
        /// 貸方
        /// </summary>
        [EnumMember]
        Creditor
    }
}
