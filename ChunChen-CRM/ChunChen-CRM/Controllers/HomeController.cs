using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class HomeController : Controller
    {
        [NoAuthentication]
        public ActionResult Index()
        {
            return View();
        }

        [NoAuthentication]
        public ActionResult About()
        {
            ViewBag.Message = "您的应用程序描述页.";

            return View();
        }

        [NoAuthentication]
        public ActionResult Contact()
        {
            ViewBag.Message = "联系页面.";

            return View();
        }

    }
}