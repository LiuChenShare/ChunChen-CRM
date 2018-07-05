using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class RecordDetailModel
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 记录
        /// </summary>
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
