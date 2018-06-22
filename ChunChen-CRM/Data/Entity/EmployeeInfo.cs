namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class EmployeeInfo
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        public int Authority { get; set; }
        
        /// <summary>
        /// 销售总金额
        /// </summary>
        public int Spend { get; set; }

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

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool Deleted { get; set; }
    }
}
