using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.vo
{
    public class ProjectVo
    {
        public String name { get; set; }

        public ProjectVo()
        {

        }

        public ProjectVo(String name)
        {
            this.name = name;
        }
    }
}
