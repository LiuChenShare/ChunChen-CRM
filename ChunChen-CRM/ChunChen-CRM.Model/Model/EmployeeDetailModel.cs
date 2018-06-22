﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 员工信息详情数据模型
    /// </summary>
    public class EmployeeDetailModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EmployeeNo { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string GenderString { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        public int Authority { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 是否离职
        /// </summary>

        public bool Quit { get; set; }

        /// <summary>
        /// 是否离职
        /// </summary>

        public string JoinStatus { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>

        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }


        #region 报表相关

        /// <summary>
        /// 销售总金额
        /// </summary>
        public int Spend { get; set; }

        /// <summary>
        /// 该月销售额
        /// </summary>
        public int MonthSpend { get; set; }

        /// <summary>
        /// 上月销售额
        /// </summary>
        public int MonthSpendOld { get; set; }

        /// <summary>
        /// 该年销售额
        /// </summary>
        public int YearSpend { get; set; }

        /// <summary>
        /// 上年销售额
        /// </summary>
        public int YearSpendOld { get; set; }
        #endregion
    }
}
