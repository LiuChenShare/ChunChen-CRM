namespace WPF_ChunChen_CRM
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
        
        public int EmployeeNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
    }
}
