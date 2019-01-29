using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model.Search
{
    public class PageList<T> : IPageList<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public IList<T> Data { get; set; }
    }
}
