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
            var now = DateTime.Now;
            var monthOld = new DateTime(now.Year, now.Month - 1, 1);
            var monthStart = new DateTime(now.Year, now.Month, 1);
            var monthEnd = new DateTime(now.Year, now.Month + 1, 1);
            var yearOld = new DateTime(now.Year - 1, 1, 1);
            var yearStart = new DateTime(now.Year, 1, 1);
            var yearEnd = new DateTime(now.Year + 1, 1, 1);
            var query = storeDB.OrderInfo.Where(x => x.CustomerId == customerId && !x.Deleted);
            var model = new SpendReportModel
            {
                Spend = Math.Round(query.Where(x => x.Status == 1).Sum(x => x.Price), 2),
                MonthSpend = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < monthEnd && x.DealDate.Value >= monthStart).Sum(x => x.Price), 2),
                MonthSpendOld = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < monthStart && x.DealDate.Value >= monthOld).Sum(x => x.Price), 2),
                YearSpend = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < yearEnd && x.DealDate.Value >= yearStart).Sum(x => x.Price), 2),
                YearSpendOld = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < yearStart && x.DealDate.Value >= yearOld).Sum(x => x.Price), 2),
                TotalOrder = query.Where(x => x.Status == 1).Count(),
                RegretOrder = query.Where(x => x.Status == 2).Count()
            };
            return model;
        }

        /// <summary>
        /// 获取员工销售额报表数据
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public SpendReportModel GetSpendReportByEmployeeId(Guid employeeId)
        {
            var now = DateTime.Now;
            var monthOld = new DateTime(now.Year, now.Month - 1, 1);
            var monthStart = new DateTime(now.Year, now.Month, 1);
            var monthEnd = new DateTime(now.Year, now.Month + 1, 1);
            var yearOld = new DateTime(now.Year - 1, 1, 1);
            var yearStart = new DateTime(now.Year, 1, 1);
            var yearEnd = new DateTime(now.Year + 1, 1, 1);
            var query = storeDB.OrderInfo.Where(x => x.EmployeeId == employeeId && !x.Deleted);
            var model = new SpendReportModel
            {
                Spend = Math.Round(query.Where(x => x.Status == 1).ToList()?.Sum(x => x.Price) ?? 0, 2),
                MonthSpend = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < monthEnd && x.DealDate.Value >= monthStart).ToList()?.Sum(x => x.Price) ?? 0, 2),
                MonthSpendOld = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < monthStart && x.DealDate.Value >= monthOld).ToList()?.Sum(x => x.Price) ?? 0, 2),
                YearSpend = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < yearEnd && x.DealDate.Value >= yearStart).ToList()?.Sum(x => x.Price) ?? 0, 2),
                YearSpendOld = Math.Round(query.Where(x => x.Status == 1 && x.DealDate.Value < yearStart && x.DealDate.Value >= yearOld).ToList()?.Sum(x => x.Price) ?? 0, 2),
                TotalOrder = query.Where(x => x.Status == 1).Count(),
                RegretOrder = query.Where(x => x.Status == 2).Count()
            };
            return model;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(OrderInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.LastUpdatedOn = DateTime.Now;
            info.Deleted = false;
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
