using System;
using System.Collections.Generic;

namespace Haozhuo.Crm.Service.vo
{
    public class TransterCustomerVo
    {
        public IList<String> customerIds { get; set; }
        public Int64 targetUserId { get; set; }
        public Boolean reDispatch { get; set; }
        public Int32? currentProjectId { get; set; }
    }
}
