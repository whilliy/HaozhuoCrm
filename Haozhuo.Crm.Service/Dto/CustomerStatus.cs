using System;
using System.Collections.Generic;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerStatus
    {
        public Int32 id { get; set; }
        public String name { get; set; }

        public CustomerStatus(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public CustomerStatus()
        {

        }
    }
}
