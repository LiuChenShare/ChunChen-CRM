using System.Web.Mvc;
using System.Web.Routing;

namespace ChunChen_CRM.Controllers
{
    // 登录认证特性
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //没有定义AllowAnonymousAttribute过滤，进行登录验证
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //登录验证
                if (filterContext.HttpContext.Session["AccountId"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Account" }));
                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}