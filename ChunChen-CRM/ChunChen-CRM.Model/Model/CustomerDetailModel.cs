using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    /// <summary>
    /// 客户信息详情数据模型
    /// </summary>
    public class CustomerDetailModel
    {
        public Guid Id { get; set; }
        
        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerNo { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 性别 0女 1男
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string GenderString { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 服务人id
        /// </summary>
        public Guid? WaiterId { get; set; }

        /// <summary>
        /// 服务人名称
        /// </summary>
        public string WaiterName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// 消费总金额
        /// </summary>
        public int Spend { get; set; }

        /// <summary>
        /// 消费报表信息
        /// </summary>
        public SpendReportModel SpendReport { get; set; }
    }
}
