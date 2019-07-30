using System.Collections.Generic;

namespace Haozhuo.Crm.Service.vo
{
    public class ImportCustomerVo
    {
        public int projectId { get; set; }
        public int source { get; set; }
        public IList<CustomerData> customers { get; set; }
    }
}
