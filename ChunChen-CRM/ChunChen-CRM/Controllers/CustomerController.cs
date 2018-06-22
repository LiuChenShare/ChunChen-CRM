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

        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Query(CustomerSearch search)
        {
            //System.Threading.Thread.Sleep(3000);
            var result = _customerService.Query(search);
            return PartialView("_SingersSearch", result);
        }

        /// <summary>
        /// 删除客户信息（经理可操作）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var result = _customerService.Delete(id);
            return Json(new { Success = result, });
        }

    }
}