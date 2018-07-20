using ChunChen_CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    /// <summary>
    /// 员工信息的仓储服务
    /// </summary>
    public class EmployeeInfoRepository
    {
        ConnectConfig storeDB = new ConnectConfig();

        /// <summary>
        /// 根据Id获取员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeInfo GetById(Guid id)
        {
            return storeDB.EmployeeInfo.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        /// <summary>
        /// 检测手机号重复
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="id">检测重复的用户</param>
        /// <returns></returns>
        public bool CheckMobile(string mobile, Guid id)
        {
            return storeDB.EmployeeInfo.Where(x => x.Mobile == mobile && x.Id != id && !x.Deleted).Count() == 0;
        }

        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeInfo> GetAll()
        {
            return storeDB.EmployeeInfo.Where(x => !x.Deleted && !x.Quit).ToList();
        }

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPagedList<EmployeeDetailModel> Query(EmployeeSearch search)
        {
            var query = storeDB.EmployeeInfo.Where(x => !x.Deleted);
            if (search.EmployeeNo != 0)
            {
                query = query.Where(x => x.EmployeeNo == search.EmployeeNo);
            }
            if (!string.IsNullOrEmpty(search.EmployeeName))
            {
                query = query.Where(x => x.Name.Contains(search.EmployeeName));
            }
            if (!string.IsNullOrEmpty(search.EmployeeMobile))
            {
                query = query.Where(x => x.Mobile == search.EmployeeMobile);
            }
            if (search.Gender.HasValue)
            {
                query = query.Where(x => x.Gender == search.Gender.Value);
            }
            if (search.EmployeeId.HasValue && search.EmployeeId != Guid.Empty)
            {
                query = query.Where(x => x.Id == search.EmployeeId);
            }
            if (search.Quit.HasValue)
            {
                query = query.Where(x => x.Quit == search.Quit);
            }
            query = query.OrderByDescending(x => x.LastUpdatedOn);
            var pageResult = new PagedList<EmployeeInfo>(query, search.PageIndex, search.PageSize);
            var pageList = pageResult.Data.Select(x => x.InfoToModel());
            return new PagedList<EmployeeDetailModel>(pageList, pageResult.PageIndex, pageResult.PageSize, pageResult.TotalCount);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(EmployeeInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.LastUpdatedOn = DateTime.Now;
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
            info.LastUpdatedOn = DateTime.Now; 
            storeDB.EmployeeInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }
        
    }

    /// <summary>
    /// 临时使用的扩展方法
    /// </summary>
    public static class EmployeeExtensions
    {
        public static EmployeeDetailModel InfoToModel(this EmployeeInfo info)
        {
            if (info == null) { return null; }
            var model = new EmployeeDetailModel
            {
                Id = info.Id,
                EmployeeNo = info.EmployeeNo,
                Name = info.Name,
                Mobile = info.Mobile,
                Gender = info.Gender,
                Birthday = info.Birthday,
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
