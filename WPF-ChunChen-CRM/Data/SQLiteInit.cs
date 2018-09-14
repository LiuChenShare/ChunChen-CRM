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
        /// <summary>
        /// 初始化ChenChenBase库，类型为SQLite数据库
        /// </summary>
        public void InitBase()
        {
            string connectionString = AppDomain.CurrentDomain.BaseDirectory + @"Data\";
            //string connectionString = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", connectionString);

            SQLiteBaseForEF.ExistsDBFile(connectionString, "ChenChenBase.s3db");

            //初始一个admin账户
            using (SQLiteConnectConfig context = new SQLiteConnectConfig())
            {
                //var info = context.VaultInfo.Where(x => x.Account == "admin").FirstOrDefault();

                //if (info == null)
                //{
                //    info = new VaultInfo
                //    {
                //        Id = Guid.NewGuid(),
                //        Account = "admin",
                //        Password = "123",
                //        Name = "管理员",
                //        Balance = 10000
                //    };
                //    context.VaultInfo.Add(info);
                //    context.SaveChanges();
                //}
            }
        }
    }
}
