﻿using ChunChen_CRM.IServices;
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
            var employeeId = _session["EmployeeId"]?.ToString();
            var employeeInfo = _employeeInfoRepository.GetById(Guid.Parse(employeeId));
            return employeeInfo.ToModel();
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeDetail(EmployeeDetailModel model)
        {
            if(model.Id == Guid.Empty || model.Mobile == null || model.Mobile == "")
            {
                return false;
            }
            var employeeInfo = _employeeInfoRepository.GetById(model.Id);
            if (employeeInfo != null)
            {
                if (employeeInfo.Mobile != model.Mobile)
                {
                    if (_employeeInfoRepository.CheckMobile(model.Mobile, employeeInfo.Id))
                    {
                        employeeInfo.Mobile = model.Mobile;
                        var accountInfo = _accountInfoRepository.GetByEmployeeId(employeeInfo.Id);
                        accountInfo.Account = model.Mobile;
                        _accountInfoRepository.Update(accountInfo);
                        _employeeInfoRepository.Update(employeeInfo);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 入职离职
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeJoinStatus(EmployeeDetailModel model)
        {
            var _session = HttpContext.Current.Session;
            if (model.Id == Guid.Empty && int.Parse(_session["Authority"].ToString()) > 0)
            {
                return false;
            }
            var employeeInfo = _employeeInfoRepository.GetById(model.Id);
            if (employeeInfo != null && employeeInfo.Quit != model.Quit)
            {
                employeeInfo.Quit = model.Quit;
                if (model.Quit)
                {
                    employeeInfo.QuitDate = DateTime.Now;
                }
                else
                {
                    employeeInfo.JoinDate = DateTime.Now;
                }
            }
            _employeeInfoRepository.Update(employeeInfo);
            return true;
        }
    }
}