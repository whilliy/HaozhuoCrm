using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haozhuo.Crm.Service.Utils
{
    public class ResultsWithCount<T>
    {
        private IList<T> results = new List<T>();
        private long count = 0;

        public ResultsWithCount(IList<T> results, long count)
        {
            this.results = results;
            this.count = count;
        }

        public ResultsWithCount()
        {
        }

        public IList<T> getResults()
        {
            return results;
        }

        public void setResults(IList<T> results)
        {
            this.results = results;
        }

        public long getCount()
        {
            return count;
        }

        public void setCount(long count)
        {
            this.count = count;
        }

        public static ResultsWithCount<T> of(IList<T> results, long count)
        {
            return new ResultsWithCount<T>(results, count);
        }
    }
}
