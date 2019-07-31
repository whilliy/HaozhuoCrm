using System;

namespace Haozhuo.Crm.Service.vo
{
    public class CustomerVo
    {
        public String name { get; set; }
        public Int32 projectId { get; set; }
        public String mobile { get; set; }
        public Int32 type { get; set; }
        public Int32 status { get; set; }
        public Int32 source { get; set; }
        public Int32 gender { get; set; }
        public String provinceId { get; set; }
        public String cityId { get; set; }
        public String countyId { get; set; }
        public DateTime lastFollowTime { get; set; }
        public DateTime nextFollowTime { get; set; }
    }
}
