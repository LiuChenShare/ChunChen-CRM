using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class HRController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public HRController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// 员工列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 离职员工列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult QuitIndex()
        {
            return View();
        }

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Query(EmployeeSearch search)
        {
            //System.Threading.Thread.Sleep(3000);
            try
            {
                var result = _employeeService.Query(search);
                return PartialView("_SingersSearch", result);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Messages = ex.Message });
            }
        }

        ///// <summary>
        ///// 个人资料页面
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index2()
        //{
        //    var model = _employeeService.GetEmployeeBySession();
        //    ViewBag.Authority = model.Authority;
        //    return View(model);
        //}

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


        [HttpGet]
        [AllowAnonymous]
        public ActionResult XXX()
        {
            var a = Request.QueryString["xxx"];
            return View();
        }

    }
}