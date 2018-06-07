using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ChunChen_CRM
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public int EmployeeNo { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        public int Gender { get; set; }
        
        public DateTime? Birthday { get; set; }
    }
}
