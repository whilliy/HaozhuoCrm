using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class CityDto
    {
        public String cityId { get; set; }
        public String cityName { get; set; }
        public CityDto() { }
        public CityDto(String id, String name)
        {
            cityId = id;
            cityName = name;
        }
    }

}
