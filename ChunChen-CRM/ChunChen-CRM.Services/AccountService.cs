using ChunChen_CRM.IServices;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Services
{
    public class AccountService : IAccountService
    {
        #region 依赖注入
        protected readonly EmployeeInfoRepository _employeeInfoRepository;

        public AccountService(EmployeeInfoRepository employeeInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
        }
        #endregion



    }
}
