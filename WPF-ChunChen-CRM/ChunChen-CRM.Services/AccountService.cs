using ChunChen_CRM.IServices;
using Data.Repository;
using Storage;

namespace ChunChen_CRM.Services
{
    /// <summary>
    /// 账户相关业务服务
    /// </summary>
    public class AccountService : IAccountService
    {
        private AccountInfoRepository _accountInfoRepository = new AccountInfoRepository();

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
                UserStorage.Instance.AccountId = accountInfo.Id;              //把用户id保存到session中
                UserStorage.Instance.EmployeeId = accountInfo.EmployeeId;     //把用户员工id保存到session中
                //var employeeInfo = _employeeInfoRepository.GetById(accountInfo.EmployeeId);
                UserStorage.Instance.Authority = accountInfo.EmployeeInfo.Authority;                 //把用户权限等级保存到session中
                return true;
            }
            return false;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void Logout()
        {
            UserStorage.Clear();//直接清除Session
        }
    }
}
