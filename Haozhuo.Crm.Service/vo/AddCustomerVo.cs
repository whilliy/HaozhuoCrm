using System;

namespace Haozhuo.Crm.Service.vo
{
    public class AddCustomerVo
    {
        public String name { get; set; }
        public String mobile { get; set; }
        public Int32 projectId { get; set; }
        public Int32 gender { get; set; }
        public Int32 source { get; set; }
        public String provinceId { get; set; }
        public String cityId { get; set; }
        public String countyId { get; set; }
    }
}
