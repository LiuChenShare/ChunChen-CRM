using ChunChen_CRM.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class PersonalController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public PersonalController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        /// <summary>
        /// 个人资料页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _employeeService.GetEmployeeBySession();
            ViewBag.Authority = model.Authority;
            return View(model);
        }
    }
}