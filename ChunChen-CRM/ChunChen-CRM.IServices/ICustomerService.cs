using ChunChen_CRM.Model;
using System;

namespace ChunChen_CRM.IServices
{
    public interface ICustomerService
    {
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IPagedList<CustomerDetailModel> Query(CustomerSearch search);

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);
    }
}
