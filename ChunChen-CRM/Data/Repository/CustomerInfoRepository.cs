using ChunChen_CRM.Model;
using System;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 客户信息的仓储服务
    /// </summary>
    public class CustomerInfoRepository
    {
        ConnectConfig storeDB = new ConnectConfig();

        /// <summary>
        /// 根据Id获取客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerInfo GetById(Guid id)
        {
            return storeDB.CustomerInfo.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        /// <summary>
        /// 根据EmployeeId获取账号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPagedList<CustomerDetailModel> Query(CustomerSearch search)
        {
            var query = storeDB.CustomerInfo.Where(x => !x.Deleted);
            if (search.CustomerNo != 0)
            {
                query = query.Where(x => x.CustomerNo == search.CustomerNo);
            }
            if (!string.IsNullOrEmpty(search.CustomerName))
            {
                query = query.Where(x => x.Name.Contains(search.CustomerName));
            }
            if (!string.IsNullOrEmpty(search.CustomerMobile))
            {
                query = query.Where(x => x.Mobile == search.CustomerMobile);
            }
            if (search.Gender.HasValue)
            {
                query = query.Where(x => x.Gender == search.Gender.Value);
            }
            if (search.CustomerId.HasValue && search.CustomerId != Guid.Empty)
            {
                query = query.Where(x => x.Id == search.CustomerId);
            }
            if (search.EmployeeId.HasValue && search.EmployeeId != Guid.Empty)
            {
                query = query.Where(x => x.WaiterId == search.EmployeeId);
            }
            if (!string.IsNullOrEmpty(search.EmployeeName))
            {
                query = query.Where(x => x.WaiterName.Contains(search.EmployeeName));
            }
            query = query.OrderBy(x => x.LastUpdatedOn);
            var pageResult = new PagedList<CustomerInfo>(query, search.PageIndex, search.PageSize);
            var pageList = pageResult.Data.Select(x => x.InfoToModel());
            return new PagedList<CustomerDetailModel>(pageList, pageResult.PageIndex, pageResult.PageSize, pageResult.TotalCount);
        }

        /// <summary>
        /// 检测手机号重复
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="id">检测重复的客户</param>
        /// <returns></returns>
        public bool CheckMobile(string mobile, Guid id)
        {
            return storeDB.CustomerInfo.Where(x => x.Mobile == mobile && x.Id != id && !x.Deleted).Count() == 0;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(CustomerInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.LastUpdatedOn = DateTime.Now;
            info.Deleted = false;
            storeDB.CustomerInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(CustomerInfo info)
        {
            //storeDB.EmployeeInfo.Create(info);
            info.LastUpdatedOn = DateTime.Now;
            storeDB.CustomerInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }
        
    }


    /// <summary>
    /// 临时使用的扩展方法
    /// </summary>
    public static class Extensions
    {
        public static CustomerDetailModel InfoToModel(this CustomerInfo info)
        {
            if (info == null) { return null; }
            var model = new CustomerDetailModel
            {
                Id = info.Id,
                CustomerNo = info.CustomerNo,
                Name = info.Name,
                Mobile = info.Mobile,
                Address = info.Address,
                Gender = info.Gender,
                Birthday = info.Birthday,
                WaiterId = info.WaiterId,
                WaiterName = info.WaiterName,
                Spend = info.Spend,
                CreateDate = info.CreateDate,
                LastUpdatedOn = info.LastUpdatedOn
            };
            if (info.Gender == 0)
            {
                model.GenderString = "女";
            }
            else
            {
                model.GenderString = "男";
            }

            return model;
        }
    }
}
