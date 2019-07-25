using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerSourceDto
    {
        public Int32 id { get; set; }
        public String name { get; set; }

        public CustomerSourceDto()
        {

        }

        public CustomerSourceDto(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
