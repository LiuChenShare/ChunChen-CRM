namespace WPF_ChunChen_CRM
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

        public virtual DbSet<CustomerInfo> Customer { get; set; }
        public virtual DbSet<EmployeeInfo> Employee { get; set; }
        public virtual DbSet<OrderInfo> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
