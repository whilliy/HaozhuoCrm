using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class OrganizationDto
    {
        public String id { get; set; }
        public string name { get; set; }
        public DateTime createdTime { get; set; }
        public OrganizationDto()
        {

        }
        public OrganizationDto(String id, String name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
