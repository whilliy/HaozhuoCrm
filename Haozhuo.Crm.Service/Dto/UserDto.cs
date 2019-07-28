using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class UserDto
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public String mobile { get; set; }
        public Int32? gender { get; set; }
        public Boolean active { get; set; }
        public String accountNo { get; set; }
        public DateTime createdTime { get; set; }
        public String organizationId { get; set; }
    }
}
