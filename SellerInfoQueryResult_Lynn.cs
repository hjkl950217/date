using NE.MPS.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NE.MPS.Domain.Model.Seller
{
    /// <summary>
    /// 卖家信息-Out
    /// </summary>
   public class SellerInfoQueryResult_Lynn
    {
        //这个类是查询后返回给前端的实体类

        /// <summary>
        /// 响应-卖家信息-Out
        /// </summary>
        public List<SellerInfo_Lynn> SellerInfoList { get; set; }

        /// <summary>
        /// 响应-分页信息-Out
        /// </summary>
        public int TotalCount { get; set; }

     

    }


}
