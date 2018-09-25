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
    /// 订单表
    /// </summary>
    [Table("Order")]
    public partial class OrderInfo
    {
        public Guid Id { get; set; }


        public int OrderNo { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 客户id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Required]
        public Guid CustomerName { get; set; }

        /// <summary>
        /// 员工id
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required]
        public Guid EmployeeName { get; set; }

        /// <summary>
        /// 状态（0.新建  1.完成   2.毁单）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 成交/毁单时间
        /// </summary>
        public DateTime? DealDate { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool Deleted { get; set; }
    }
}
