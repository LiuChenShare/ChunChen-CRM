using ChunChen_CRM.Model;

namespace ChunChen_CRM.IServices
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        EmployeeDetailModel GetEmployeeBySession();
    }
}
