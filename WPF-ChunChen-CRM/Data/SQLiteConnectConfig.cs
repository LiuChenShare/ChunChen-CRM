using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 连接SQLite数据库
    /// </summary>
    public partial class SQLiteConnectConfig : DbContext
    {
        public SQLiteConnectConfig()
            : base("SQLiteConfig")
        {
        }

        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<AccountInfo> AccountInfo { get; set; }

        public virtual DbSet<RecordInfo> RecordInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
