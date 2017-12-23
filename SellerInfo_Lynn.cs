using NE.MPS.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NE.MPS.Domain.Model.Seller
{
    /// <summary>
    /// 卖家信息-普通实体
    /// </summary>
   public class SellerInfo_Lynn
    {
        /// <summary>
        /// 卖家ID
        /// </summary>
        public string SellerID { get; set; }
        /// <summary>
        /// 卖家存储的姓名
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        ///  卖家状态
        /// </summary>
        public eSellerStatus Status { get; set; }


    }
}
