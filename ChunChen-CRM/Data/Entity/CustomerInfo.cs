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

        public int CustomerNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public Guid? WaiterId { get; set; }
    }
}
