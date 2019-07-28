using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class ProjectDto
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public DateTime createdTime { get; set; }
        public ProjectDto()
        {

        }
        public ProjectDto(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
