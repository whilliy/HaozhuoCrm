using System;

namespace Haozhuo.Crm.Service.Dto
{
    public class AddFollowRecord
    {
        public String remark { get; set; }
        public DateTime communicationTime { get; set; }
        public String name { get; set; }
        //public String mobile { get; set; }
        public Int32 type { get; set; }
        public Int32 status { get; set; }
        //public Int32 source { get; set; }
        public Int32 gender { get; set; }
        public String provinceId { get; set; }
        public String cityId { get; set; }
        public String countyId { get; set; }
        //public DateTime lastFollowTime { get; set; }
        public DateTime nextFollowTime { get; set; }

        public Int32 projectId { get; set; }

    }
}
