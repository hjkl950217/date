using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NE.MPS.Domain.Model.Seller
{
    /// <summary>
    /// 卖家信息-In
    /// </summary>
    public class SellerInfoQueryCriteria_Lynn
    {
        //这个类是查询条件

        /// <summary>
        /// 请求-卖家ID列表-In
        /// </summary>
        public List<string> SellerIdList { get; set; }

        /// <summary>
        /// 请求-卖家类型（内部还是外部-In
        /// </summary>
        public string SellerType { get; set; }

        /// <summary>
        /// 请求-卖家账户状态-In
        /// </summary>
        public string SellerStatus { get; set; }

        /// <summary>
        /// 请求-分页信息-In
        /// </summary>
        public PagingInfo PagingInfo { get; set; }


        /// <summary>
        /// 获取此对象的XML格式元素
        /// </summary>
        /// <returns></returns>
        public XElement ToXml( )
        {
            //根节点
            XElement root = new XElement( "QueryCondition" );

            //卖家列表
            if( this.SellerIdList != null )//不为空
            {
                XElement sellerIDXml = new XElement( "SellerIDList" );
                foreach( var item in this.SellerIdList )
                {
                    sellerIDXml.Add( new XElement( "SellerID" , item ) );
                }
                root.Add( sellerIDXml );

            }

            //卖家其他信息
            if( string.IsNullOrWhiteSpace( this.SellerType )==false )          
                root.Add( new XElement( "SellerType" , this.SellerType ) );
            if( string.IsNullOrWhiteSpace( this.SellerStatus ) == false )
                root.Add( new XElement( "SellerStatus" , this.SellerStatus ) );




            //分页数据
            if( this.PagingInfo != null )
            {
                //页面大小
                if( this.PagingInfo.PageSize.HasValue == true )
                    root.Add( new XElement( "PageSize" , this.PagingInfo.PageSize.Value ) );

                //页面索引
                if( this.PagingInfo.PageIndex.HasValue==true )
                    root.Add( new XElement( "PageIndex" , this.PagingInfo.PageIndex.Value ) );
               
                //开始行的索引
                if( this.PagingInfo.StartRowIndex.HasValue == true )
                    root.Add( new XElement( "StartRowIndex" , this.PagingInfo.StartRowIndex.Value ) );
            }

            return root;
        }


    }
}
