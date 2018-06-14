using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChunChen_CRM.Services
{
    public class CustomerService : ICustomerService
    {
        #region 依赖注入
        protected readonly EmployeeInfoRepository _employeeInfoRepository;
        protected readonly AccountInfoRepository _accountInfoRepository;
        protected readonly CustomerInfoRepository _customerInfoRepository;

        public CustomerService(EmployeeInfoRepository employeeInfoRepository
            , AccountInfoRepository accountInfoRepository
            , CustomerInfoRepository customerInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
            _accountInfoRepository = accountInfoRepository;
            _customerInfoRepository = customerInfoRepository;
        }

        #endregion
        
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IPagedList<CustomerDetailModel> Query(CustomerSearch search)
        {
            var _session = HttpContext.Current.Session;
            if (int.Parse(_session["Authority"].ToString()) > 0)
            {
                var employeeId = _session["EmployeeId"]?.ToString();
                search.EmployeeId = Guid.Parse(employeeId);
            }
            return _customerInfoRepository.Query(search); ;
        }
    }
}
