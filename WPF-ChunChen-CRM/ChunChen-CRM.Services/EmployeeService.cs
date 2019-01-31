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
        private AutoincrementInfoRepository _autoincrementInfoRepository = new AutoincrementInfoRepository();

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
                userViewModel.AccountId = UserStorage.Instance.AccountId;
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
        public IPageList<UserViewModel> SearchEmployeeList(EmployeeSearch search)
        {
            IPageList<UserViewModel> userViews = new PageList<UserViewModel>();
            userViews.Data = new List<UserViewModel>();
            try
            {
                if (UserStorage.Instance.Authority <= 1)
                {
                    var employees = _employeeInfoRepository.SearchEmployeeList(search);
                    if (employees?.Data != null)
                    {
                        userViews.Data = employees.Data.Select(x => x.ToUserViewModel()).ToList();
                        userViews.PageIndex = employees.PageIndex;
                        userViews.PageSize = employees.PageSize;
                        userViews.TotalCount = employees.TotalCount;
                        userViews.TotalPage = employees.TotalPage;
                        if (employees.TotalPage == 0)
                        {
                            userViews.TotalPage = 1;
                        }
                        return userViews;
                    }
                }
                return userViews;
            }
            catch(Exception ex)
            {
                return userViews;
            }
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <returns></returns>
        public UserViewModel GetEmployeeData(Guid employeeId)
        {
            UserViewModel userViewModel = new UserViewModel();
            EmployeeInfo employeeInfo = _employeeInfoRepository.GetEmployeeInfo(employeeId);
            userViewModel = employeeInfo.ToUserViewModel();
            return userViewModel;
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public bool SaveEmployeeData(UserViewModel userViewModel)
        {
            try
            {
                if (_accountInfoRepository.CheckAccount(userViewModel.Account))
                {
                    throw new Exception("账号重复");
                }
                if (_employeeInfoRepository.CheckMobile(userViewModel.Mobile))
                {
                    throw new Exception("手机号重复");
                }
                //创建账号
                AccountInfo accountInfo = new AccountInfo();
                accountInfo.Id = Guid.NewGuid();
                accountInfo.Account = userViewModel.Account;
                accountInfo.Password = userViewModel.Password;
                accountInfo.EmployeeId = Guid.NewGuid();
                _accountInfoRepository.Insert(accountInfo);
                //创建员工信息
                EmployeeInfo employeeInfo = new EmployeeInfo();
                employeeInfo.Id = accountInfo.EmployeeId;
                employeeInfo.CreateDate = DateTime.Now;
                employeeInfo.EmployeeNo = _autoincrementInfoRepository.UpdateAutoincrement("EmployeeNo").Value;
                employeeInfo = employeeInfo.SetEntity(userViewModel);
                _employeeInfoRepository.Insert(employeeInfo);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public bool UpdateEmployeeData(UserViewModel userViewModel)
        {
            try
            {
                EmployeeInfo employeeInfo = _employeeInfoRepository.GetEmployeeInfo(userViewModel.Id);
                if (employeeInfo == null) { return false; }
                employeeInfo.Name = userViewModel.Name;
                employeeInfo.Mobile = userViewModel.Mobile;
                employeeInfo.Gender = userViewModel.Gender;
                employeeInfo.Birthday = userViewModel.Birthday;
                employeeInfo.JoinDate = userViewModel.JoinDate;
                employeeInfo.Quit = userViewModel.Quit;
                employeeInfo.QuitDate = userViewModel.QuitDate;
                _employeeInfoRepository.Update(employeeInfo);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
