using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// SQlite数据基础(EF)
    /// </summary>
    public static class SQLiteBaseForEF
    {
        private static string path = System.Environment.CurrentDirectory + @"\Data\";
        private static string dbName = "ChunChenBase.db";

        /// <summary>
        /// 查找并创建SQLite数据文件
        /// </summary>
        /// <returns></returns>
        public static bool ExistsDBFile(string connectionString = null, string dbNameString = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    path = connectionString;
                }
                if (!string.IsNullOrEmpty(dbNameString))
                {
                    dbName = dbNameString;
                }
                if (!Directory.Exists(path + dbName))
                {
                    return CreateDBFile();
                }
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 创建数据库文件(直接覆盖)
        /// </summary>
        /// <param name="fileName"></param>
        public static bool CreateDBFile()
        {
            try
            {
                using (SQLiteConnectConfig context = new SQLiteConnectConfig())
                {
                    Directory.CreateDirectory(path);
                    //SQLiteConnection.CreateFile(path + dbName);

                    //创建账户信息表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Account] (
                    [Id] BLOB  UNIQUE NOT NULL PRIMARY KEY,
                    [Account] TEXT  NOT NULL,
                    [Password] TEXT  NOT NULL,
                    [EmployeeId] BLOB  NULL,
                    [Deleted] BOOLEAN DEFAULT '0' NOT NULL
                    )");

                    //创建自增字段记录表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Autoincrement] (
                    [Key] TEXT  NOT NULL,
                    [Value] TEXT  NOT NULL
                    )");

                    //创建客户信息表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Customer] (
                    [Id] BLOB  NOT NULL,
                    [CustomerNo] INTEGER  NOT NULL,
                    [Name] TEXT  NOT NULL,
                    [Gender] INTEGER  NULL,
                    [Mobile] TEXT  NOT NULL,
                    [Address] TEXT  NULL,
                    [Birthday] BLOB  NULL,
                    [WaiterId] BLOB  NULL,
                    [WaiterName] TEXT  NULL,
                    [Spend] FLOAT  NULL,
                    [CreateDate] BLOB  NULL,
                    [LastUpdatedOn] BLOB  NULL,
                    [Deleted] BLOB  NULL
                    )");

                    //创建员工信息表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Employee] (
                    [Id] BLOB  UNIQUE NOT NULL,
                    [EmployeeNo] INTEGER  NOT NULL,
                    [Name] TEXT  NOT NULL,
                    [Mobile] TEXT  NOT NULL,
                    [Gender] INTEGER  NOT NULL,
                    [Birthday] BLOB  NULL,
                    [Authority] INTEGER  NULL,
                    [Spend] FLOAT  NULL,
                    [JoinDate] BLOB  NOT NULL,
                    [Quit] BLOB  NULL,
                    [QuitDate] BLOB  NULL,
                    [CreateDate] BLOB  NOT NULL,
                    [LastUpdatedOn] BLOB  NOT NULL,
                    [Deleted] BLOB  NULL
                    )");

                    //创建订单表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Order] (
                    [Id] BLOB  UNIQUE NOT NULL PRIMARY KEY,
                    [OrderNo] INTEGER  NOT NULL,
                    [Title] TEXT  NOT NULL,
                    [Details] TEXT  NULL,
                    [Price] FLOAT  NULL,
                    [CustomerId] BLOB  NULL,
                    [CustomerName] TEXT  NULL,
                    [EmployeeId] BLOB  NULL,
                    [EmployeeName] TEXT  NULL,
                    [Status] INTEGER  NULL,
                    [DealDate] BLOB  NULL,
                    [CreateDate] BLOB  NULL,
                    [LastUpdatedOn] BLOB  NULL,
                    [Deleted] BOOLEAN  NULL
                    )");

                    //创建信息记录表
                    context.Database.ExecuteSqlCommand(@"CREATE TABLE [Record] (
                    [Id] BLOB  NULL PRIMARY KEY,
                    [CustomerId] BLOB  NULL,
                    [EmployeeId] BLOB  NULL,
                    [EmployeeName] TEXT  NULL,
                    [Message] TEXT  NULL,
                    [CreateDate] BLOB  NULL
                    )");
                    
                    return true;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }
    }
}
