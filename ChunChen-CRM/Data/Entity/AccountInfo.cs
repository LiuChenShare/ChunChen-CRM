namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class AccountInfo
    {
        public Guid Id { get; set; }

        [Column("Account")]
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid EmployeeId { get; set; }

        public bool Deleted { get; set; }
    }
}
