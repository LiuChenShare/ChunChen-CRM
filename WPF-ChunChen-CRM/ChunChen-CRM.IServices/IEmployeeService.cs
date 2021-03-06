﻿using ChunChen_CRM.Model;
using ChunChen_CRM.Model.Search;
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

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        IPageList<UserViewModel> SearchEmployeeList(EmployeeSearch search);

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <returns></returns>
        UserViewModel GetEmployeeData(Guid employeeId);

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        bool SaveEmployeeData(UserViewModel userViewModel);

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        bool UpdateEmployeeData(UserViewModel userViewModel);
    }
}
