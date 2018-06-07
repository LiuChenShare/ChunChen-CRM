namespace WPF_ChunChen_CRM
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

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Details { get; set; }

        public double Price { get; set; }

        public Guid CustomerId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
