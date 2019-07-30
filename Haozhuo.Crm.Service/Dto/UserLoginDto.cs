using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class UserLoginDto
    {
        public String Name { get; set; }
        public String Token { get; set; }
        public long Id { get; set; }
        public String organizationId { get; set; }
        public String organizationName { get; set; }
    }
}
