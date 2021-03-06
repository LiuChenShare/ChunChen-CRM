﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 消费以及销售额报表模型
    /// </summary>
    public class SpendReportModel
    {
        /// <summary>
        /// 消费总金额
        /// </summary>
        public double Spend { get; set; }

        /// <summary>
        /// 该月消费额
        /// </summary>
        public double MonthSpend { get; set; }

        /// <summary>
        /// 上月消费额
        /// </summary>
        public double MonthSpendOld { get; set; }

        /// <summary>
        /// 该年消费额
        /// </summary>
        public double YearSpend { get; set; }

        /// <summary>
        /// 上年消费额
        /// </summary>
        public double YearSpendOld { get; set; }

        /// <summary>
        /// 总成交的单数
        /// </summary>
        public int TotalOrder { get; set; }

        /// <summary>
        /// 悔单数
        /// </summary>
        public int RegretOrder { get; set; }
    }
}
