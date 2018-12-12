using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    /// <summary>
    /// 自增字段记录表
    /// </summary>
    [Table("Autoincrement")]
    public partial class AutoincrementInfo
    {
        /// <summary>
        /// 表名或字段名
        /// </summary>
        [Key]
        public string Key { get; set; }             //.GetType().Name
        /// <summary>
        /// 当前的自增基数
        /// </summary>
        public int Value { get; set; }
    }
}
