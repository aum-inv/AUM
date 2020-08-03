using System;
using System.Collections.Generic;
using System.Linq;

namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // EXPONENTIAL MOVING AVERAGE
        public static IEnumerable<EmaResult> GetEma(IEnumerable<Quote> history, int lookbackPeriod)
        {
            // convert history to basic format
            IEnumerable<BasicData> bd = Cleaners.ConvertHistoryToBasic(history, "C");
            // calculate
            return CalcEma(bd, lookbackPeriod);
        }


        private static IEnumerable<EmaResult> CalcEma(IEnumerable<BasicData> basicData, int lookbackPeriod)
        {
            // initialize
            List<EmaResult> results = new List<EmaResult>();

            // initialize EMA
            decimal k = 2 / (decimal)(lookbackPeriod + 1);
            decimal lastEma = basicData
                .Where(x => x.Index < lookbackPeriod)
                .Select(x => x.Value)
                .Average();

            // roll through history
            foreach (BasicData h in basicData)
            {

                EmaResult result = new EmaResult
                {
                    Index = (int)h.Index,
                    Date = h.Date
                };

                if (h.Index >= lookbackPeriod)
                {
                    result.Ema = lastEma + k * (h.Value - lastEma);
                    lastEma = (decimal)result.Ema;
                }

                results.Add(result);
            }

            return results;
        }
    }
}