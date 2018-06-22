using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    public interface IPagedList<T>
    {
        /// <summary>
        /// 第几页（基于0）
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 每页的个数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 总个数
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; }

        List<T> Data { get; set; }
    }
}
