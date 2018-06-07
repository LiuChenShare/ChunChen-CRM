using System.Web.Mvc;
using System.Web.Routing;


namespace ChunChen_CRM.Controllers
{
    /// <summary>
    /// 取消验证登录认证特性
    /// </summary>
    public class NoAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }
    }
}