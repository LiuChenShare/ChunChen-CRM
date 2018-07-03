using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// 记录信息的仓储服务
    /// </summary>
    public class RecordInfoRepository
    {
        ConnectConfig storeDB = new ConnectConfig();

        /// <summary>
        /// 根据Id获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RecordInfo GetById(Guid id)
        {
            return storeDB.RecordInfo.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 获取客户的前20条记录信息(升序)
        /// </summary>
        /// <param name="customerId">客户id</param>
        /// <returns></returns>
        public List<RecordInfo> GetTop20ByCustomerId(Guid customerId)
        {
            return storeDB.RecordInfo.Where(x => x.CustomerId == customerId).OrderByDescending(x => x.CreateDate).Take(20).ToList();
        }

        /// <summary>
        /// 获取客户的所有记录信息(降序)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<RecordInfo> GetAllByCustomerId(Guid customerId)
        {
            return storeDB.RecordInfo.Where(x => x.CustomerId == customerId).OrderBy(x => x.CreateDate).ToList();
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public void Insert(RecordInfo info)
        {
            info.CreateDate = DateTime.Now;
            if (info.Id == Guid.Empty) info.Id = Guid.NewGuid();
            storeDB.RecordInfo.Add(info);
            storeDB.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        public void Update(RecordInfo info)
        {
            storeDB.RecordInfo.Attach(info);
            storeDB.Entry(info).State = System.Data.Entity.EntityState.Modified;
            storeDB.SaveChanges();
        }
        
    }
}
