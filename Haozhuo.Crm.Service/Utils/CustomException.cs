using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Utils
{
    public class CustomException : Exception
    {
        public int CustomCode { get; set; }

        public CustomException(int code):base()
        {
            CustomCode = code;
        }

        public CustomException(String message) : base(message)
        {

        }
    }
}
