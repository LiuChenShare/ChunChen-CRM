namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConnectConfig : DbContext
    {
        public ConnectConfig()
            : base("name=ConnectConfig")
        {
        }

        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
