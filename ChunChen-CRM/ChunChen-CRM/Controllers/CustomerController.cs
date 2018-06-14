using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        /// <summary>
        /// 我的客户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Query(CustomerSearch search)
        {
            var result = _customerService.Query(search);
            return PartialView("_SingersSearch", result);
        }

    }
}