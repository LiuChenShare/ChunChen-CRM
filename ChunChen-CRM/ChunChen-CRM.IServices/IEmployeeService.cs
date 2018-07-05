using ChunChen_CRM.Model;
using System.Collections.Generic;

namespace ChunChen_CRM.IServices
{
    /// <summary>
    /// 员工相关业务接口
    /// </summary>
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

        /// <summary>
        /// 获取员工单选框列表
        /// </summary>
        /// <returns></returns>
        List<EmployeeSelectItem> GetSelectlist();
    }
}
