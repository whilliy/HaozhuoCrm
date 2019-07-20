using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class CountyDto
    {
        public String CountyName { get; set; }
        public String CountyId { get; set; }

        public CountyDto()
        {

        }
        public CountyDto(string id, string name)
        {
            CountyId = id;
            CountyName = name;
        }
    }
}
