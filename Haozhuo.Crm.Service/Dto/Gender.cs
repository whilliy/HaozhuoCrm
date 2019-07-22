using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class Gender
    {
        public Int32 id { get; set; }
        public String name { get; set; }

        public Gender(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Gender()
        {

        }

    }
}
