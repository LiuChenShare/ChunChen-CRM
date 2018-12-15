using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class UserStorage
    {
        /// <summary>
        /// 用户缓存
        /// </summary>
        #region
        private static volatile UserStorage instance;
        private static readonly object obj = new object();
        public static UserStorage Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new UserStorage();
                        }
                    }

                }
                return instance;
            }
        }
        public static void Clear()
        {
            instance = null;
        }

        #endregion

        /// <summary>
        /// 账户id
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// 员工id
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public int Authority { get; set; }
    }
}
