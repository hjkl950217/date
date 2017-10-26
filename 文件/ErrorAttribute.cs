using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Security;

namespace Filter
{
    /// <summary>
    /// 动作方法前-错误纪录
    /// </summary>
    public class ErrorAttribute : ActionFilterAttribute, IExceptionFilter
    {

        /// <summary>
        /// 发生错误时纪录信息
        /// </summary>
        /// <param name="filterContext"></param>
        void IExceptionFilter.OnException( ExceptionContext filterContext )
        {
            //获取异常信息，入库保存
            Exception Error = filterContext.Exception;

            string errorName = Error.TargetSite.Name;
            string errorUrl = HttpContext.Current.Request.RawUrl;//错误发生地址
            string errorText = Error.Message;
            string errorNum = Error.StackTrace;//代码调用信息

            //Models.ErrorLog error = new Models.ErrorLog( )
            //{
            //    AccessTime = DateTime.Now ,
            //    ErrorText = $"发生错误的方法:{errorName}\r\n发生错误的地址:{errorUrl}\r\n错误信息:{errorText} 调用堆栈:{errorNum}" ,
            //    Publisher = filterContext.HttpContext.Session[ "Name" ].ToString( ) ,
            //    AccessSystemInfo = filterContext.HttpContext.Request.Params[ "HTTP_USER_AGENT" ] 
            //};


            Models.ErrorLog error = new Models.ErrorLog( );

            error.AccessTime = DateTime.Now;
            error.ErrorText = $"发生错误的方法:{errorName}\r\n发生错误的地址:{errorUrl}\r\n错误信息:{errorText} 调用堆栈:{errorNum}";
            error.Publisher = ( filterContext.HttpContext.Session[ "Name" ] ?? "" ).ToString();
            error.AccessSystemInfo = filterContext.HttpContext.Request.Params[ "HTTP_USER_AGENT" ];



            using( Models.CkBlog ckBlog = new Models.CkBlog( ) )
            {
                ckBlog.ErrorLog.Add( error );
                ckBlog.SaveChanges( );
            }
           

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult( "~/error.html" );//跳转至错误提示页面
        }


    }


}