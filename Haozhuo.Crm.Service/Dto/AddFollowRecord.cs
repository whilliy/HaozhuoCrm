using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class AddFollowRecord
    {
        public String remark { get; set; }
        public DateTime communicationTime { get; set; }

        public AddFollowRecord()
        {

        }
        public AddFollowRecord(String remark, DateTime communicationTime)
        {
            this.remark = remark;
            this.communicationTime = communicationTime;
        }
    }
}
