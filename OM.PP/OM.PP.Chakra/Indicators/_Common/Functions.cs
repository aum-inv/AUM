using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Indicators
{
    public static class Functions
    {
        public static double StdDev(IEnumerable<double> values)
        {
            // 출처: https://stackoverflow.com/questions/2253874/standard-deviation-in-linq

            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                double avg = values.Average();

                double sum = values.Sum(d => (d - avg) * (d - avg));

                ret = Math.Sqrt(sum / count);
            }
            return ret;
        }
    }
}
