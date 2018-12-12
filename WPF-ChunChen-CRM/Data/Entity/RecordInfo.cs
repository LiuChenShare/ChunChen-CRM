using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    /// <summary>
    /// 信息记录表
    /// </summary>
    [Table("Record")]
    public partial class RecordInfo
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 客户id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 员工id
        /// </summary>

        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 记录
        /// </summary>
        [Required]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
