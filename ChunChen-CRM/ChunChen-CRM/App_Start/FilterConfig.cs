using ChunChen_CRM.Controllers;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationAttribute());             //注册登录验证过滤器
        }
    }
}
