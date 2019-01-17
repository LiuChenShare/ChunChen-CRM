using ChunChen_CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.IServices
{
    /// <summary>
    /// 员工相关业务接口
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        UserViewModel GetPersonalData();

        /// <summary>
        /// 修改当前用户信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        bool SavePersonalData(UserViewModel userViewModel);
    }
}
