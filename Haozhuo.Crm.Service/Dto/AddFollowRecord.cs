using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Dto
{
    public class AddFollowRecord
    {
        private String remark { get; set; }
        private DateTime communicationTime { get; set; }

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
