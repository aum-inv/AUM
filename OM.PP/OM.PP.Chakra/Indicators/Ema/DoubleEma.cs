using System;
using System.Collections.Generic;
using System.Linq;

namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // DOUBLE EXPONENTIAL MOVING AVERAGE
        public static IEnumerable<EmaResult> GetDoubleEma(IEnumerable<Quote> history, int lookbackPeriod)
        {

            // convert history to basic format
            IEnumerable<BasicData> bd = Cleaners.ConvertHistoryToBasic(history, "C");

            // initialize
            List<EmaResult> results = new List<EmaResult>();
            IEnumerable<EmaResult> emaN = CalcEma(bd, lookbackPeriod);

            List<BasicData> bd2 = emaN
                .Where(x => x.Ema != null)
                .Select(x => new BasicData { Index = null, Date = x.Date, Value = (decimal)x.Ema })
                .ToList();  // note: ToList seems to be required when changing data

            IEnumerable<EmaResult> emaN2 = CalcEma(bd2, lookbackPeriod);

            // compose final results
            foreach (EmaResult h in emaN)
            {
                EmaResult result = new EmaResult
                {
                    Index = h.Index,
                    Date = h.Date
                };

                if (h.Index >= 2 * lookbackPeriod)
                {
                    EmaResult emaEma = emaN2.Where(x => x.Index == h.Index - lookbackPeriod + 1).FirstOrDefault();
                    result.Ema = 2 * h.Ema - emaEma.Ema;
                }

                results.Add(result);
            }

            return results;
        }
    }    
}
