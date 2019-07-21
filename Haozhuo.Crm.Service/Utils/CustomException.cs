using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Utils
{
    public class CustomException
    {
        public int customCode { get; set; }

        public string message { get; set; }

        public CustomException(int code)
        {
            customCode = code;
        }

        public CustomException(String message)
        {

        }

        public CustomException(){ }
    }
}
