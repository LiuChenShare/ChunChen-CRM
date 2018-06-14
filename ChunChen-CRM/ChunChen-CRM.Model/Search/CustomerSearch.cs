using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 客户搜索类
    /// </summary>
    public class CustomerSearch : BaseSearch
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerNo { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerMobile { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// 服务人id
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// 服务人姓名
        /// </summary>
        public string EmployeeName { get; set; }
    }
}
