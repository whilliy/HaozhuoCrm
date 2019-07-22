using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service
{
    public class BaseService
    {
        public static Int64 GetTotalCountFromResponseHeaders(IRestResponse response)
        {
            var header = response.Headers.Where(x => x.Name == GlobalConfig.X_TOTAL_COUNT).First();
            if (header != null)
            {
                return  Convert.ToInt32(header.Value);
            }
            return 0;
        }
    }
}
