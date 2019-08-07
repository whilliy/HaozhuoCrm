using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class UserProjectDto
    {
        public Int64 id { get; set; }
        public Int64 userId { get; set; }
        public Int32 projectId { get; set; }
        public String projectName { get; set; }
    }
}
