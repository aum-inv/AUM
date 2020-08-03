using System.Collections.Generic;
using System.Linq;
namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // RELATIVE STRENGTH INDEX
        public static IEnumerable<RsiResult> GetRsi(IEnumerable<Quote> history, int lookbackPeriod = 14)
        {
            // convert history to basic format
            IEnumerable<BasicData> bd = Cleaners.ConvertHistoryToBasic(history, "C");
            // calculate
            return CalcRsi(bd, lookbackPeriod);
        }

        private static IEnumerable<RsiResult> CalcRsi(IEnumerable<BasicData> basicData, int lookbackPeriod = 14)
        {

            // initialize
            decimal lastValue = basicData.First().Value;
            List<RsiResult> results = new List<RsiResult>();

            // load gain data
            foreach (BasicData h in basicData)
            {

                RsiResult result = new RsiResult
                {
                    Index = (int)h.Index,
                    Date = h.Date,
                    Gain = (h.Value > lastValue) ? h.Value - lastValue : 0,
                    Loss = (h.Value < lastValue) ? lastValue - h.Value : 0
                };
                results.Add(result);

                lastValue = h.Value;
            }

            // initialize average gain
            decimal avgGain = results.Where(x => x.Index <= lookbackPeriod).Select(g => g.Gain).Average();
            decimal avgLoss = results.Where(x => x.Index <= lookbackPeriod).Select(g => g.Loss).Average();

            // initial first record
            decimal lastRSI = (avgLoss > 0) ? 100 - (100 / (1 + (avgGain / avgLoss))) : 100;
            bool? lastIsIncreasing = null;

            RsiResult first = results.Where(x => x.Index == lookbackPeriod + 1).FirstOrDefault();
            first.Rsi = lastRSI;

            // calculate RSI
            foreach (RsiResult r in results.Where(x => x.Index > (lookbackPeriod + 1)).OrderBy(d => d.Index))
            {
                avgGain = (avgGain * (lookbackPeriod - 1) + r.Gain) / lookbackPeriod;
                avgLoss = (avgLoss * (lookbackPeriod - 1) + r.Loss) / lookbackPeriod;

                if (avgLoss > 0)
                {
                    decimal rs = avgGain / avgLoss;
                    r.Rsi = 100 - (100 / (1 + rs));
                }
                else
                {
                    r.Rsi = 100;
                }

                if (r.Rsi > lastRSI)
                {
                    r.IsIncreasing = true;
                }
                else if (r.Rsi < lastRSI)
                {
                    r.IsIncreasing = false;
                }
                else
                {
                    // no change, keep trend
                    r.IsIncreasing = lastIsIncreasing;
                }

                lastRSI = (decimal)r.Rsi;
                lastIsIncreasing = r.IsIncreasing;
            }

            return results;
        }

    }
}
