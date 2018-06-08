using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// 账户名
        /// </summary>
        [DisplayName("账户名")]
        [Required(ErrorMessage = "不能为空")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}
