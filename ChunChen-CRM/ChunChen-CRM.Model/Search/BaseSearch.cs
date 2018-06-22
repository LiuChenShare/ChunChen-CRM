using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Model
{
    public class BaseSearch
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 关键词搜索
        /// </summary>
        public string Keywords { get; set; }
    }
}
