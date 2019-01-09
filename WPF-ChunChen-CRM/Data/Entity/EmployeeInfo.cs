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
    /// 员工信息表
    /// </summary>
    [Table("Employee")]
    public partial class EmployeeInfo
    {
        [Key]
        public Guid Id { get; set; }
        
        public int EmployeeNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }

        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int Gender { get; set; }

        //[Column(TypeName = "date")]
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        public int Authority { get; set; }

        /// <summary>
        /// 销售总金额
        /// </summary>
        public double Spend { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 是否离职
        /// </summary>

        public bool Quit { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// 上一次修改日期
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// 删除状态
        /// </summary>
        public bool Deleted { get; set; }
    }
}
