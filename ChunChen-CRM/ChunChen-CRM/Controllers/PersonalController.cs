using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
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

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateEmployeeDetail(EmployeeDetailModel model)
        {
            if (_employeeService.UpdateEmployeeDetail(model))
            {
                return Json(new { Success = true, Messages = "更新成功" });
            }
            return Json(new { Success = false, Messages = "更新失败，请刷新后重新操作" });
        }
    }
}