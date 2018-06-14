using ChunChen_CRM.Model;

namespace ChunChen_CRM.IServices
{
    public interface ICustomerService
    {
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IPagedList<CustomerDetailModel> Query(CustomerSearch search);
    }
}
