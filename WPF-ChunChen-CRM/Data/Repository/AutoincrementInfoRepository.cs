using Data.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 自增字段记录表的仓储服务
    /// </summary>
    public class AutoincrementInfoRepository
    {
        SQLiteConnectConfig storeDB = new SQLiteConnectConfig();

        /// <summary>
        /// 获取自增字段数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AutoincrementInfo GetAutoincrement(string key)
        {
            return storeDB.AutoincrementInfo.Where(x => x.Key == key).FirstOrDefault();
        }

        /// <summary>
        /// 自增数据
        /// </summary>
        /// <param name="key"></param>
        public AutoincrementInfo UpdateAutoincrement(string key)
        {
            var info = storeDB.AutoincrementInfo.Where(x => x.Key == key).FirstOrDefault();
            if (info == null)
            {
                info = new AutoincrementInfo() { Key = key, Value = 0 };
                Insert(info);
            }
            info.Value++;
            Update(info);
            return info;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(AutoincrementInfo info)
        {
            storeDB.AutoincrementInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(AutoincrementInfo info)
        {
            //storeDB.EmployeeInfo.Create(info);
            storeDB.AutoincrementInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }



        //用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        private bool RemoveHoldingEntityInContext(AutoincrementInfo entity)
        {
            var objContext = ((IObjectContextAdapter)storeDB).ObjectContext;
            var objSet = objContext.CreateObjectSet<AutoincrementInfo>();
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
