using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class ProvinceDto
    {
        public string provinceId { get; set; }
        public String provinceName { get; set; }

        public ProvinceDto(String id, String name)
        {
            provinceId = id;
            provinceName = name;
        }

        public ProvinceDto() { }
    }
}
