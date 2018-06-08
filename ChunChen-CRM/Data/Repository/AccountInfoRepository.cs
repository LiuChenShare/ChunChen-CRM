using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    /// <summary>
    /// 账户信息的仓储服务
    /// </summary>
    public class AccountInfoRepository
    {
        ConnectConfig storeDB = new ConnectConfig();

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AccountInfo GetLoginAccount(string account, string password)
        {
            var infos = storeDB.AccountInfo.Where(x => x.Account == account || x.Account == account);
            return infos.Where(x => x.Password == password && !x.Deleted).FirstOrDefault();
        }
    }
}
