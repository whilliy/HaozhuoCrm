using System;

namespace Haozhuo.Crm.Service.vo
{
    public class CustomerData
    {
        public String Sequence { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public int? gender { get; set; }
        public DateTime? leaveWordsTime { get; set; }
        public String Region { get; set; }
        public String provinceId;
        public String provinceName;
        public String cityId;
        public String cityName;
        public String remark { get; set; }
    }
}
