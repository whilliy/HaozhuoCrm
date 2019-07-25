using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerFollowRecord
    {
        public Int64 id { get; set; }
        public String remark { get; set; }
        public String followUserName { get; set; }
        public DateTime communicationTime { get; set; }
        public DateTime createdTime { get; set; }
    }
}
