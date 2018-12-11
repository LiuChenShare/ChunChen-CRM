using Data.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 账户信息的仓储服务
    /// </summary>
    public class AccountInfoRepository
    {
        SQLiteConnectConfig storeDB = new SQLiteConnectConfig();

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

        /// <summary>
        /// 根据EmployeeId获取账号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountInfo GetByEmployeeId(Guid employeeId)
        {
            return storeDB.AccountInfo.Where(x => x.EmployeeId == employeeId && !x.Deleted).FirstOrDefault();
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(AccountInfo info)
        {
            info.Deleted = false;
            if (info.Id == Guid.Empty) info.Id = Guid.NewGuid();
            storeDB.AccountInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(AccountInfo info)
        {
            //storeDB.EmployeeInfo.Create(info);
            storeDB.AccountInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }



        //用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        private bool RemoveHoldingEntityInContext(AccountInfo entity)
        {
            var objContext = ((IObjectContextAdapter)storeDB).ObjectContext;
            var objSet = objContext.CreateObjectSet<AccountInfo>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }

    }
}
