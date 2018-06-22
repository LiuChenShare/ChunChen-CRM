namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class OrderInfo
    {
        public Guid Id { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNo { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// �۸�
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// �ͻ�id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        [Required]
        public Guid CustomerName { get; set; }

        /// <summary>
        /// Ա��id
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Ա������
        /// </summary>
        [Required]
        public Guid EmployeeName { get; set; }

        /// <summary>
        /// ״̬��0.�½�  1.���   2.�ٵ���
        /// </summary>
        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool Deleted { get; set; }
    }
}
