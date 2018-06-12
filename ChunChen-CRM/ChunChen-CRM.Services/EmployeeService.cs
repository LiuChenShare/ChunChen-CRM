using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Services.Extensions;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChunChen_CRM.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region 依赖注入
        protected readonly EmployeeInfoRepository _employeeInfoRepository;
        protected readonly AccountInfoRepository _accountInfoRepository;

        public EmployeeService(EmployeeInfoRepository employeeInfoRepository
            , AccountInfoRepository accountInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
            _accountInfoRepository = accountInfoRepository;
        }

        #endregion
        
        /// <summary>
        /// 获取当前登录用户的员工信息
        /// </summary>
        /// <returns></returns>
        public EmployeeDetailModel GetEmployeeBySession()
        {
            var _session = HttpContext.Current.Session;
            var employeeId = _session["EmployeeId"].ToString();
            var employeeInfo = _employeeInfoRepository.GetById(Guid.Parse(employeeId));
            return employeeInfo.ToModel();
        }

    }
}
