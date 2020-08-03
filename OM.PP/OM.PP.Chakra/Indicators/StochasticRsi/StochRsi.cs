using System.Collections.Generic;
using System.Linq;

namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // STOCHASTIC RSI
        public static IEnumerable<StochRsiResult> GetStochRsi(IEnumerable<Quote> history,
            int rsiPeriod, int stochPeriod, int signalPeriod, int smoothPeriod = 1)
        {
            // initialize
            List<StochRsiResult> results = new List<StochRsiResult>();

            // get RSI
            IEnumerable<RsiResult> rsiResults = GetRsi(history, rsiPeriod);

            // convert rsi to quote format
            List<Quote> rsiQuotes = rsiResults
                .Where(x => x.Rsi != null)
                .Select(x => new Quote
                {
                    Index = null,
                    Date = x.Date,
                    High = (decimal)x.Rsi,
                    Low = (decimal)x.Rsi,
                    Close = (decimal)x.Rsi
                })
                .ToList();

            // get Stochastic of RSI
            IEnumerable<StochResult> stoResults = GetStoch(rsiQuotes, stochPeriod, signalPeriod, smoothPeriod);

            // compose
            foreach (RsiResult r in rsiResults)
            {

                StochRsiResult result = new StochRsiResult
                {
                    Index = r.Index,
                    Date = r.Date
                };

                if (r.Index >= rsiPeriod + stochPeriod)
                {
                    StochResult sto = stoResults
                        .Where(x => x.Index == r.Index - stochPeriod)
                        .FirstOrDefault();

                    result.StochRsi = sto.Oscillator;
                    result.Signal = sto.Signal;
                    result.IsIncreasing = sto.IsIncreasing;
                }

                results.Add(result);
            }

            return results;
        }
    }
}
