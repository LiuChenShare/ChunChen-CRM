using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 初始化SQLite数据库
    /// </summary>
    public class SQLiteInit
    {
        public static Guid adminAccountId = Guid.Parse("de39121f-c917-434c-a224-49e6d48cbdb7");
        public static Guid adminEmployeeId = Guid.Parse("fe49c59a-654c-4c19-b68d-f06b7b5d3649");

        /// <summary>
        /// 初始化ChunChenBase库，类型为SQLite数据库
        /// </summary>
        public static void InitBase()
        {
            string connectionString = AppDomain.CurrentDomain.BaseDirectory + @"Data\";
            //string connectionString = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", connectionString);

            SQLiteBaseForEF.ExistsDBFile(connectionString, "ChunChenBase.db");

            //初始一个admin账户
            using (SQLiteConnectConfig context = new SQLiteConnectConfig())
            {
                var employeeInfo = context.EmployeeInfo.Where(x => x.Id == adminEmployeeId).FirstOrDefault();
                if (employeeInfo == null)
                {
                    employeeInfo = new Entity.EmployeeInfo
                    {
                        Id = adminEmployeeId,
                        EmployeeNo = 0,
                        Name = "Admin",
                        Mobile = "15665699774",
                        Gender = 1,
                        Birthday = new DateTime(1996, 7, 1),
                        Authority = 0,
                        Spend = 0,
                        JoinDate = new DateTime(1996, 7, 1),
                        Quit = false,
                        QuitDate = null,
                        CreateDate = DateTime.Now,
                        LastUpdatedOn = DateTime.Now,
                        Deleted = false
                    };
                    context.EmployeeInfo.Add(employeeInfo);
                }

                var accountInfo = context.AccountInfo.Where(x => x.Id == adminAccountId).FirstOrDefault();
                if (accountInfo == null)
                {
                    accountInfo = new Entity.AccountInfo
                    {
                        Id = adminAccountId,
                        Account = "admin",
                        Password = "19960701",
                        EmployeeId = adminEmployeeId,
                        Deleted = false
                    };
                    context.AccountInfo.Add(accountInfo);
                }

                context.SaveChanges();
            }
        }
    }
}
