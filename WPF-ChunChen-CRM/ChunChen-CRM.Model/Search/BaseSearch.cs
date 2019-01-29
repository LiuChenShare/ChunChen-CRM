using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model.Search
{
    public class BaseSearch
    {
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// 页码
        /// </summary>
        public int Index { get; set; } = 0;
    }
}
