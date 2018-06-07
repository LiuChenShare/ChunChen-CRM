using System.Web.Mvc;
using System.Web.Routing;

namespace ChunChen_CRM.Controllers
{
    // 登录认证特性
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["AccountId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Account" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}