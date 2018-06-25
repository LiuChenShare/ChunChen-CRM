namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Record")]
    public partial class RecordInfo
    {
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
        public Guid EmployeeName { get; set; }

        /// <summary>
        /// 记录
        /// </summary>
        [Required]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
