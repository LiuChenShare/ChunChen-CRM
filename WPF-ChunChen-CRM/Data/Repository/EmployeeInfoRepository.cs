using ChunChen_CRM.Model.Search;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return infos.AsNoTracking().FirstOrDefault();
        }
        
        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IPageList<EmployeeInfo> SearchEmployeeList(EmployeeSearch search)
        {
            IPageList<EmployeeInfo> pageList= new PageList<EmployeeInfo>();
            var infos = storeDB.EmployeeInfo.Where(x => x.Deleted == false);
            if (search.Id.HasValue)
            {
                infos = infos.Where(x => x.Id == search.Id.Value);
            }
            if (search.EmployeeNo.HasValue)
            {
                infos = infos.Where(x => x.EmployeeNo.ToString().Contains(search.EmployeeNo.Value.ToString()));
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                infos = infos.Where(x => x.Name.Contains(search.Name));
            }
            if (!string.IsNullOrWhiteSpace(search.Mobile))
            {
                infos = infos.Where(x => x.Mobile.Contains(search.Mobile));
            }
            if (search.Gender.HasValue)
            {
                infos = infos.Where(x => x.Gender == search.Gender.Value);
            }
            if (search.Birthday.HasValue)
            {
                infos = infos.Where(x => x.Birthday.HasValue && x.Birthday.Value.Month == search.Birthday.Value.Month && x.Birthday.Value.Day == search.Birthday.Value.Day);
            }
            if (search.MinSpend.HasValue)
            {
                infos = infos.Where(x => x.Spend >= search.MinSpend.Value);
            }
            if (search.MaxSpend.HasValue)
            {
                infos = infos.Where(x => x.Spend <= search.MaxSpend.Value);
            }
            if (search.Quit.HasValue)
            {
                infos = infos.Where(x => x.Quit == search.Quit.Value);
            }
            infos = infos.OrderBy(x => x.JoinDate);
            pageList.TotalCount = infos.Count();
            infos = infos.Skip(search.Index * search.PageSize).Take(search.PageSize);
            pageList.Data = infos.AsNoTracking().ToList();
            pageList.PageIndex = search.Index;
            pageList.PageSize = search.PageSize;
            pageList.TotalPage = (int)Math.Ceiling((double)pageList.TotalCount / (double)pageList.PageSize);
            return pageList;
        }

        /// <summary>
        /// 检验手机号是否重复
        /// </summary>
        /// <param name="mobile">待检验手机号</param>
        /// <param name="employeeId">忽略掉的员工id</param>
        /// <returns></returns>
        public bool CheckMobile(string mobile, Guid? employeeId = null)
        {
            var infos = storeDB.EmployeeInfo.Where(x => x.Mobile == mobile && !x.Deleted);
            if (employeeId.HasValue)
            {
                infos = infos.Where(x => x.Id != employeeId);
            }
            return infos.Count() > 0;
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
