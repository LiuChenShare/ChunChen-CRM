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

        /// <summary>
        /// 获取客户详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerDetailModel GetCustomerById(Guid id);

        /// <summary>
        /// 更新客户电话号码并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        bool UpdateMobile(Guid customerId, string mobile);

        /// <summary>
        /// 更新客户地址信息并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        bool UpdateAddress(Guid customerId, string address);

        /// <summary>
        /// 更新客户的服务人员并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="waiterId"></param>
        /// <returns></returns>
        bool UpdateWaiter(Guid customerId, Guid waiterId);

        /// <summary>
        /// 添加客户的信息记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool SaveRecord(Guid customerId, string message);

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddCustomer(CustomerDetailModel model);
    }
}
