using ChunChen_CRM.IServices;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChunChen_CRM.Services
{
    public class AccountService : IAccountService
    {
        #region 依赖注入
        protected readonly EmployeeInfoRepository _employeeInfoRepository;
        protected readonly AccountInfoRepository _accountInfoRepository;

        public AccountService(EmployeeInfoRepository employeeInfoRepository
            , AccountInfoRepository accountInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
            _accountInfoRepository = accountInfoRepository;
        }

        #endregion

        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string account, string password)
        {
            var accountInfo = _accountInfoRepository.GetLoginAccount(account, password);
            if (accountInfo != null)
            {
                //存储Session
                var _session = HttpContext.Current.Session;
                _session["AccountId"] = accountInfo.Id.ToString();  //把用户id保存到session中
                var employeeInfo = _employeeInfoRepository.GetById(accountInfo.EmployeeId);
                _session["Authority"] = employeeInfo.Authority;     //把用户权限等级保存到session中
                return true;
            }
            return false;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void Logout()
        {
            var _session = HttpContext.Current.Session;
            _session.Clear();//直接清除Session
        }
    }
}
