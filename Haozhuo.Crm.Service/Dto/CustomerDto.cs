using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class CustomerDto
    {
        public String id { get; set; }
        private String name;
        private String mobile;
        private Int32 type;
        private Int32 status;
        private Int32 source;
        private String provinceId;
        private String provinceName;
        private String cityId;
        private String cityName;
        private String countyId;
        private String countyName;
        private DateTime previousFollowTime;
        private long previousFollowUserId;
        private DateTime lastFollowTime;
        private long lastFollowUserId;
        private DateTime nextFollowTime;
    }
}
