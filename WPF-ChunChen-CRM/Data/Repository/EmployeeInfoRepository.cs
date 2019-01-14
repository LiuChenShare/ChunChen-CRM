using Data.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 员工信息的仓储服务
    /// </summary>
    public class EmployeeInfoRepository
    {
        SQLiteConnectConfig storeDB = new SQLiteConnectConfig();

        /// <summary>
        /// 根据员工id获取员工信息
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <param name="deleted">是否删除</param>
        /// <returns></returns>
        public EmployeeInfo GetEmployeeInfo(Guid employeeId, bool deleted = false)
        {
            var infos = storeDB.EmployeeInfo.Where(x => x.Id == employeeId && x.Deleted == deleted);
            return infos.FirstOrDefault();
        }
        

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(EmployeeInfo info)
        {
            info.Deleted = false;
            if (info.Id == Guid.Empty) info.Id = Guid.NewGuid();
            storeDB.EmployeeInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(EmployeeInfo info)
        {
            //storeDB.EmployeeInfo.Create(info);
            RemoveHoldingEntityInContext(info);
            storeDB.EmployeeInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }



        //用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        private bool RemoveHoldingEntityInContext(EmployeeInfo entity)
        {
            var objContext = ((IObjectContextAdapter)storeDB).ObjectContext;
            var objSet = objContext.CreateObjectSet<EmployeeInfo>();
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
