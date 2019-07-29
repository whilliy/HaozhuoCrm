using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerFollowRecord
    {
        public Int64 id { get; set; }
        public Int32? customerType { get; set; }
        public Int32? customerStatus { get; set; }
        public DateTime? nextFollowTime { get; set; }
        public String remark { get; set; }
        public String followUserName { get; set; }
        public DateTime communicationTime { get; set; }
        public DateTime createdTime { get; set; }
    }
}
