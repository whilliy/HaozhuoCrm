using System;
using System.Collections.Generic;

namespace Haozhuo.Crm.Service.vo
{
    public class AddUserVo
    {
        public String organizationId { get; set; }
        public string accountNo { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public Int32 gender { get; set; }
        public IList<String> permissionIds { get; set; }
    }
}
