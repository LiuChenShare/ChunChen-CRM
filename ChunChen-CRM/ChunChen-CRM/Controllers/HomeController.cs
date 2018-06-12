using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "您的应用程序描述页.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "联系页面.";

            return View();
        }
        
        public ActionResult Default()
        {
            ViewBag.Message = "首页.";

            return View();
        }
    }
}