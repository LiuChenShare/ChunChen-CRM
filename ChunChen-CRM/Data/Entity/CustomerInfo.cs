namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class CustomerInfo
    {
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 服务人id
        /// </summary>
        public Guid? WaiterId { get; set; }

        /// <summary>
        /// 服务人名称
        /// </summary>
        public string WaiterName { get; set; }

        /// <summary>
        /// 消费总金额
        /// </summary>
        public double Spend { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool Deleted { get; set; }


    }
}
