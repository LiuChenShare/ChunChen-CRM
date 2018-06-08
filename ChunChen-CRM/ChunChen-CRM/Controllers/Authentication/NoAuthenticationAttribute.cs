using System;
using System.Web.Mvc;
using System.Web.Routing;


namespace ChunChen_CRM.Controllers
{
    /// <summary>
    /// 取消验证登录认证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class NoAuthenticationAttribute : AuthenticationAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    base.OnActionExecuting(filterContext);
        //}
    }
}