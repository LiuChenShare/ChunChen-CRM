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
        private readonly IEmployeeService _employeeService;
        public CustomerController(ICustomerService customerService
            ,IEmployeeService employeeService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
        }


        /// <summary>
        /// 我的客户列表页面
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

        /// <summary>
        /// 客户详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            CustomerDetailModel model = null;
            if (id != Guid.Empty)
            {
                model = _customerService.GetCustomerById(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateMobile(Guid customerId, string mobile)
        {
            try
            {
                return Json(new { Success = _customerService.UpdateMobile(customerId, mobile), });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UpdateAddress(Guid customerId, string address)
        {
            try
            {
                return Json(new { Success = _customerService.UpdateAddress(customerId, address), });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UpdateWaiter(Guid customerId, Guid waiterId)
        {
            try
            {
                return Json(new { Success = _customerService.UpdateWaiter(customerId, waiterId), });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SaveRecord(Guid customerId, string message)
        {
            //var a = Session["Authority"].ToString();
            try
            {
                return Json(new { Success = _customerService.SaveRecord(customerId, message), });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }

        /// <summary>
        /// 添加客户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDetail()
        {
            var Selectlist = _employeeService.GetSelectlist();
            return View(Selectlist);
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCustomer(CustomerDetailModel model)
        {
            try
            {
                return Json(new { Success = _customerService.AddCustomer(model), });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }
    }
}