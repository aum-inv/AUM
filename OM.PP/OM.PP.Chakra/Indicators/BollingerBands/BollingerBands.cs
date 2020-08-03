using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // BOLLINGER BANDS
        public static IEnumerable<BollingerBandsResult> GetBollingerBands(
            IEnumerable<Quote> history, int lookbackPeriod = 20, decimal standardDeviations = 2)
        {
            // initialize
            List<BollingerBandsResult> results = new List<BollingerBandsResult>();
            decimal? prevWidth = null;

            // roll through history
            foreach (Quote h in history)
            {
                BollingerBandsResult result = new BollingerBandsResult
                {
                    Index = (int)h.Index,
                    Date = h.Date
                };

                if (h.Index >= lookbackPeriod)
                {
                    IEnumerable<double> periodClose = history
                        .Where(x => x.Index > (h.Index - lookbackPeriod) && x.Index <= h.Index)
                        .Select(x => (double)x.Close);

                    double stdDev = Functions.StdDev(periodClose);

                    result.Sma = (decimal)periodClose.Average();
                    result.UpperBand = result.Sma + standardDeviations * (decimal)stdDev;
                    result.LowerBand = result.Sma - standardDeviations * (decimal)stdDev;

                    result.ZScore = (stdDev == 0) ? null : (h.Close - result.Sma) / (decimal)stdDev;
                    result.Width = (result.Sma == 0) ? null : (result.UpperBand - result.LowerBand) / result.Sma;

                    if (prevWidth != null)
                    {
                        result.IsDiverging = (result.Width > prevWidth);
                    }

                    // for next iteration
                    prevWidth = result.Width;
                }

                results.Add(result);
            }

            return results;
        }
    }
}