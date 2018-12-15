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
    /// 账户信息表
    /// </summary>
    [Table("Account")]
    public partial class AccountInfo
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Account")]
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid EmployeeId { get; set; }

        public bool Deleted { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
