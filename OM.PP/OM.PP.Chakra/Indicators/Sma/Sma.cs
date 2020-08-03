using System;
using System.Collections.Generic;
using System.Linq;
namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // SIMPLE MOVING AVERAGE
        public static IEnumerable<SmaResult> GetSma(IEnumerable<Quote> history, int lookbackPeriod)
        {
            // initialize
            List<SmaResult> results = new List<SmaResult>();

            // roll through history
            foreach (Quote h in history)
            {

                SmaResult result = new SmaResult
                {
                    Index = (int)h.Index,
                    Date = h.Date
                };

                if (h.Index >= lookbackPeriod)
                {
                    IEnumerable<Quote> period = history
                        .Where(x => x.Index <= h.Index && x.Index > (h.Index - lookbackPeriod));

                    // simple moving average
                    result.Sma = period
                        .Select(x => x.Close)
                        .Average();

                    // mean absolute deviation
                    result.Mad = period
                        .Select(x => Math.Abs(x.Close - (decimal)result.Sma))
                        .Average();

                    // mean squared error
                    result.Mse = period
                        .Select(x => (x.Close - (decimal)result.Sma) * (x.Close - (decimal)result.Sma))
                        .Average();

                    // mean absolute percent error
                    result.Mape = period
                        .Where(x => x.Close != 0)
                        .Select(x => Math.Abs(x.Close - (decimal)result.Sma) / x.Close)
                        .Average();
                }

                results.Add(result);
            }

            return results;
        }
    }
}
