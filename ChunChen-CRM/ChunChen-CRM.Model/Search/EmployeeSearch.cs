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
    public class EmployeeSearch : BaseSearch
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmployeeNo { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 员工手机号
        /// </summary>
        public string EmployeeMobile { get; set; }

        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// 是否离职
        /// </summary>

        public bool? Quit { get; set; }
    }
}
