using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Services.Extensions;
using Data;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace ChunChen_CRM.Services
{
    public class CustomerService : ICustomerService
    {
        #region 依赖注入
        protected readonly EmployeeInfoRepository _employeeInfoRepository;
        protected readonly AccountInfoRepository _accountInfoRepository;
        protected readonly CustomerInfoRepository _customerInfoRepository;
        protected readonly OrderInfoRepository _orderInfoRepository;
        protected readonly RecordInfoRepository _recordInfoRepository;

        public CustomerService(EmployeeInfoRepository employeeInfoRepository
            , AccountInfoRepository accountInfoRepository
            , CustomerInfoRepository customerInfoRepository
            , OrderInfoRepository orderInfoRepository
            , RecordInfoRepository recordInfoRepository)
        {
            _employeeInfoRepository = employeeInfoRepository;
            _accountInfoRepository = accountInfoRepository;
            _customerInfoRepository = customerInfoRepository;
            _orderInfoRepository = orderInfoRepository;
            _recordInfoRepository = recordInfoRepository;
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

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var _session = HttpContext.Current.Session;
            if (int.Parse(_session["Authority"].ToString()) == 0)
            {
                var info = _customerInfoRepository.GetById(id);
                if (info != null)
                {
                    info.Deleted = true;
                    _customerInfoRepository.Update(info);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取客户详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDetailModel GetCustomerById(Guid id)
        {
            var _session = HttpContext.Current.Session;
            var customerInfo = _customerInfoRepository.GetById(id);
            var model = customerInfo.ToModel();
            if (int.Parse(_session["Authority"].ToString()) == 0 || Guid.Parse(_session["EmployeeId"]?.ToString()) == model.WaiterId)
            {
                model.SpendReport = _orderInfoRepository.GetSpendReportByCustomerId(id);
            }
            return model;
        }



        /// <summary>
        /// 更新客户电话号码并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool UpdateMobile(Guid customerId, string mobile)
        {
            if (customerId == Guid.Empty && !string.IsNullOrEmpty(mobile))
            {
                throw new Exception("参数错误！");
            }
            var _session = HttpContext.Current.Session;
            var employeeId = Guid.Parse(_session["EmployeeId"]?.ToString());
            var customerInfo = _customerInfoRepository.GetById(customerId);
            if (customerInfo.Mobile == mobile)
            {
                throw new Exception("数据未修改！");
            }
            if (int.Parse(_session["Authority"].ToString()) > 0 && employeeId != customerInfo.WaiterId)
            {
                throw new Exception("无操作权限！");
            }
            var employeeInfo = _employeeInfoRepository.GetById(employeeId);
            if (employeeInfo == null)
            {
                throw new Exception("登录信息有误，请重新登录！");
            }
            var recordInfo = new RecordInfo
            {
                CustomerId = customerInfo.Id,
                EmployeeId = employeeId,
                EmployeeName = employeeInfo.Name,
                Message = "修改客户联系电话： " + customerInfo.Mobile + " --> " + mobile
            };
            _recordInfoRepository.Insert(recordInfo);
            customerInfo.Mobile = mobile;
            _customerInfoRepository.Update(customerInfo);
            return true;
        }

        /// <summary>
        /// 更新客户地址信息并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool UpdateAddress(Guid customerId, string address)
        {
            if (customerId == Guid.Empty && !string.IsNullOrEmpty(address))
            {
                throw new Exception("参数错误！");
            }
            var _session = HttpContext.Current.Session;
            var employeeId = Guid.Parse(_session["EmployeeId"]?.ToString());
            var customerInfo = _customerInfoRepository.GetById(customerId);
            if (customerInfo.Address == address)
            {
                throw new Exception("数据未修改！");
            }
            if (int.Parse(_session["Authority"].ToString()) > 0 && employeeId != customerInfo.WaiterId)
            {
                throw new Exception("无操作权限！");
            }
            var employeeInfo = _employeeInfoRepository.GetById(employeeId);
            if(employeeInfo == null)
            {
                throw new Exception("登录信息有误，请重新登录！");
            }
            var recordInfo = new RecordInfo
            {
                CustomerId = customerInfo.Id,
                EmployeeId = employeeId,
                EmployeeName = employeeInfo.Name,
                Message = "修改客户联系地址： " + customerInfo.Address + " --> " + address
            };
            _recordInfoRepository.Insert(recordInfo);
            customerInfo.Address = address;
            _customerInfoRepository.Update(customerInfo);
            return true;
        }

        /// <summary>
        /// 更新客户的服务人员并记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="waiterId"></param>
        /// <returns></returns>
        public bool UpdateWaiter(Guid customerId, Guid waiterId)
        {
            if (customerId == Guid.Empty || waiterId == Guid.Empty)
            {
                throw new Exception("参数错误！");
            }
            var _session = HttpContext.Current.Session;
            var employeeId = Guid.Parse(_session["EmployeeId"]?.ToString());
            var customerInfo = _customerInfoRepository.GetById(customerId);
            if (customerInfo.WaiterId == waiterId)
            {
                throw new Exception("数据未修改！");
            }
            if (int.Parse(_session["Authority"].ToString()) > 0 && employeeId != customerInfo.WaiterId)
            {
                throw new Exception("无操作权限！");
            }
            var employeeInfo = _employeeInfoRepository.GetById(employeeId);
            var waiterInfo = _employeeInfoRepository.GetById(waiterId);
            if (waiterInfo == null || employeeId == null)
            {
                throw new Exception("登录信息有误，请重新登录！");
            }
            var recordInfo = new RecordInfo
            {
                CustomerId = customerInfo.Id,
                EmployeeId = employeeId,
                EmployeeName = employeeInfo.Name,
                Message = "修改客户服务人员： " + customerInfo.WaiterName + " --> " + waiterInfo.Name
            };
            _recordInfoRepository.Insert(recordInfo);
            customerInfo.WaiterId = waiterInfo.Id;
            _customerInfoRepository.Update(customerInfo);
            return true;
        }

        /// <summary>
        /// 添加客户的信息记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SaveRecord(Guid customerId, string message)
        {
            if (customerId == Guid.Empty && !string.IsNullOrEmpty(message))
            {
                throw new Exception("参数错误！");
            }
            var _session = HttpContext.Current.Session;
            var employeeId = Guid.Parse(_session["EmployeeId"]?.ToString());
            var customerInfo = _customerInfoRepository.GetById(customerId);
            if (int.Parse(_session["Authority"].ToString()) > 0 && employeeId != customerInfo.WaiterId)
            {
                throw new Exception("无操作权限！");
            }
            var employeeInfo = _employeeInfoRepository.GetById(employeeId);
            if (employeeInfo == null)
            {
                throw new Exception("登录信息有误，请重新登录！");
            }
            var recordInfo = new RecordInfo
            {
                CustomerId = customerInfo.Id,
                EmployeeId = employeeId,
                EmployeeName = employeeInfo.Name,
                Message = message
            };
            _recordInfoRepository.Insert(recordInfo);
            customerInfo.LastUpdatedOn = DateTime.Now;
            _customerInfoRepository.Update(customerInfo);
            return true;
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCustomer(CustomerDetailModel model)
        {
            var _session = HttpContext.Current.Session;
            var employeeId = Guid.Parse(_session["EmployeeId"]?.ToString());
            var employeeInfo = _employeeInfoRepository.GetById(employeeId);
            if (employeeInfo == null)
            {
                throw new Exception("登录信息有误，请重新登录！");
            }
            Assert.IsNotNullOrEmpty(model.Name,"客户姓名不可为空");
            Assert.IsTrue((model.Gender == 1 || model.Gender == 0), "用户性别设置错误！");
            Assert.IsNotNullOrEmpty(model.Mobile, "客户联系电话不可为空！");
            Assert.IsTrue(_customerInfoRepository.CheckMobile(model.Mobile, Guid.Empty), "客户联系电话重复！");
            var info = new CustomerInfo
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Gender = model.Gender,
                Mobile = model.Mobile,
                Address = model.Address,
                Birthday = model.Birthday,
                //info.WaiterId
                //info.WaiterName
                Spend = 0
            };
            if (model.WaiterId.HasValue)
            {
                var waiterInfo = _employeeInfoRepository.GetById(model.WaiterId.Value);
                Assert.IsNotNull(waiterInfo, "服务人员设置错误！");
                info.WaiterId = waiterInfo.Id;
                info.WaiterName = waiterInfo.Name;
            }
            _customerInfoRepository.Insert(info);
            var recordInfo = new RecordInfo
            {
                CustomerId = info.Id,
                EmployeeId = employeeInfo.Id,
                EmployeeName = employeeInfo.Name,
                Message = "添加新客户"
            };
            _recordInfoRepository.Insert(recordInfo);
            return true;
        }
    }
}
