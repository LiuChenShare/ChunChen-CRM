namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Record")]
    public partial class RecordInfo
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Ա������
        /// </summary>
        [Required]
        public Guid EmployeeName { get; set; }

        /// <summary>
        /// ��¼
        /// </summary>
        [Required]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
