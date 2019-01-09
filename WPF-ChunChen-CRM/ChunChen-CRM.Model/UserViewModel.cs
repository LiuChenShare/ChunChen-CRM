using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 用户/员工展示模型
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 账号id
        /// </summary>
        public Guid Account { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public int EmployeeNo { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int Gender { get; set; }
        
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        public int Authority { get; set; }

        /// <summary>
        /// 销售总金额
        /// </summary>
        public double Spend { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 是否离职
        /// </summary>

        public bool Quit { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 上一次修改日期
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }
    }
}
