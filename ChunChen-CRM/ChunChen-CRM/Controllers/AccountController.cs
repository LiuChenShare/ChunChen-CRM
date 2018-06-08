using ChunChen_CRM.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChunChen_CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录HttpPost
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CheckLogin(string userNamea, string userPas)
        {
            if (userNamea == null || userPas == null)
            {
                return Json(new { Success = false, Messages = "输入错误" });
            }
            //验证用户登录
            var login = _service.Login(userNamea.Trim(), userPas);
            if (!login)
            {
                return Json(new { Success = false, Messages = "用户名或密码错误" });
            }
            return Json(new { Success = true });
        }
    }
}