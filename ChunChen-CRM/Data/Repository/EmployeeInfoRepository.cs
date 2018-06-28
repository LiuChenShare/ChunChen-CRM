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
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(EmployeeInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.LastUpdatedOn = DateTime.Now;
            info.Deleted = false;
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
}
