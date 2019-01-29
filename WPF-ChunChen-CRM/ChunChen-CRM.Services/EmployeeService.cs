using System.Collections.Generic;
using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Model.Search;
using ChunChen_CRM.Services.Extensions;
using Data.Entity;
using Data.Repository;
using Storage;
using System.Linq;
using System;
using System.Windows;

namespace ChunChen_CRM.Services
{
    /// <summary>
    /// 账户相关业务服务
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private AccountInfoRepository _accountInfoRepository = new AccountInfoRepository();
        private EmployeeInfoRepository _employeeInfoRepository = new EmployeeInfoRepository();

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public UserViewModel GetPersonalData()
        {
            UserViewModel userViewModel = new UserViewModel();
            EmployeeInfo employeeInfo = _employeeInfoRepository.GetEmployeeInfo(UserStorage.Instance.EmployeeId);
            userViewModel = employeeInfo.ToUserViewModel();
            if (userViewModel != null)
            {
                userViewModel.Account = UserStorage.Instance.AccountId;
                return userViewModel;
            }
            return null;
        }

        /// <summary>
        /// 修改当前用户信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public bool SavePersonalData(UserViewModel userViewModel)
        {
            EmployeeInfo employeeInfo = _employeeInfoRepository.GetEmployeeInfo(UserStorage.Instance.EmployeeId);
            if(employeeInfo == null) { return false; } 
            employeeInfo.Mobile = userViewModel.Mobile;
            employeeInfo.Gender = userViewModel.Gender;
            employeeInfo.Birthday = userViewModel.Birthday;
            _employeeInfoRepository.Update(employeeInfo);
            return true;
        }

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<UserViewModel> SearchEmployeeList(EmployeeSearch search)
        {
            try
            {
                List<UserViewModel> userViews = new List<UserViewModel>();
                if (UserStorage.Instance.Authority <= 1)
                {
                    var employees = _employeeInfoRepository.SearchEmployeeList(search);
                    if (employees != null)
                    {
                        return employees.Select(x => x.ToUserViewModel()).ToList();
                    }
                }
                return userViews;
            }
            catch(Exception ex)
            {
                return new List<UserViewModel>();
            }
        }
    }
}
