using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 员工SelectItem模型
    /// </summary>
    public class EmployeeSelectItem
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmployeeNo { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        
    }
}
