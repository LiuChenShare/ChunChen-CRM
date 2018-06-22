using ChunChen_CRM.Model;
using System;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 订单信息的仓储服务
    /// </summary>
    public class OrderInfoRepository
    {
        ConnectConfig storeDB = new ConnectConfig();

        /// <summary>
        /// 根据Id获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderInfo GetById(Guid id)
        {
            return storeDB.OrderInfo.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        /// <summary>
        /// 获取客户消费报表数据
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public SpendReportModel GetSpendReportByCustomerId(Guid customerId)
        {
            var spend = storeDB.OrderInfo.Where(x => x.CustomerId == customerId && !x.Deleted).Sum(x => x.Price);
            return null;
        }

        /// <summary>
        /// 获取员工消费报表数据
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public SpendReportModel GetSpendReportByEmployeeId(Guid employeeId)
        {
            return null;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(OrderInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.LastUpdatedOn = DateTime.Now;
            storeDB.OrderInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(OrderInfo info)
        {
            //storeDB.EmployeeInfo.Create(info);
            info.LastUpdatedOn = DateTime.Now;
            storeDB.OrderInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }
        
    }
}
