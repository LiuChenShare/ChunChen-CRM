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

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateEmployeeDetail(EmployeeDetailModel model);
    }
}
