using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.IServices
{
    /// <summary>
    /// 账户相关业务接口
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string account, string password);

        /// <summary>
        /// 系统登出
        /// </summary>
        void Logout();
    }
}
