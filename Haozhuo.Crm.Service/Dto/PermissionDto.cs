using System;
using System.Collections.Generic;

namespace Haozhuo.Crm.Service.Dto
{
    public class PermissionDto
    {
        public string id { get; set; }
        public String name { get; set; }
        public IList<PermissionDto> children { get; set; }
    }
}
