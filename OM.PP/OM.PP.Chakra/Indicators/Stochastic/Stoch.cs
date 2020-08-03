using System.Collections.Generic;
using System.Linq;
namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        // STOCHASTIC OSCILLATOR
        public static IEnumerable<StochResult> GetStoch(IEnumerable<Quote> history, int lookbackPeriod = 14, int signalPeriod = 3, int smoothPeriod = 3)
        {
            // initialize
            List<StochResult> results = new List<StochResult>();

            // oscillator
            foreach (Quote h in history)
            {
                StochResult result = new StochResult
                {
                    Index = (int)h.Index,
                    Date = h.Date
                };

                if (h.Index >= lookbackPeriod)
                {

                    decimal lowLow = history.Where(x => x.Index > (h.Index - lookbackPeriod) && x.Index <= h.Index)
                                        .Select(v => v.Low)
                                        .Min();

                    decimal highHigh = history.Where(x => x.Index > (h.Index - lookbackPeriod) && x.Index <= h.Index)
                                        .Select(v => v.High)
                                        .Max();

                    if (lowLow != highHigh)
                    {
                        result.Oscillator = 100 * ((h.Close - lowLow) / (highHigh - lowLow));
                    }
                    else
                    {
                        result.Oscillator = 0;
                    }
                }
                results.Add(result);
            }


            // smooth the oscillator
            if (smoothPeriod > 1)
            {
                results = SmoothOscillator(results, lookbackPeriod, smoothPeriod);
            }


            // signal and period direction info
            decimal? lastOsc = null;
            bool? lastIsIncreasing = null;
            foreach (StochResult r in results
                .Where(x => x.Index >= (lookbackPeriod + smoothPeriod - 1))
                .OrderBy(x => x.Index))
            {
                // add signal
                if (r.Index >= lookbackPeriod + smoothPeriod + signalPeriod - 2)
                {
                    r.Signal = results.Where(x => x.Index > (r.Index - signalPeriod) && x.Index <= r.Index)
                                     .Select(v => v.Oscillator)
                                     .Average();
                }

                // add direction
                if (lastOsc != null)
                {
                    if (r.Oscillator > lastOsc)
                    {
                        r.IsIncreasing = true;
                    }
                    else if (r.Oscillator < lastOsc)
                    {
                        r.IsIncreasing = false;
                    }
                    else
                    {
                        // no change, keep trend
                        r.IsIncreasing = lastIsIncreasing;
                    }
                }

                lastOsc = (decimal)r.Oscillator;
                lastIsIncreasing = r.IsIncreasing;
            }

            return results;
        }


        private static List<StochResult> SmoothOscillator(List<StochResult> results, int lookbackPeriod, int smoothPeriod)
        {

            // temporarily store interim smoothed oscillator
            foreach (StochResult r in results.Where(x => x.Index >= (lookbackPeriod + smoothPeriod - 1)))
            {
                r.Smooth = results.Where(x => x.Index > (r.Index - smoothPeriod) && x.Index <= r.Index)
                                 .Select(v => v.Oscillator)
                                 .Average();
            }

            // replace oscillator
            foreach (StochResult r in results)
            {
                if (r.Smooth != null)
                {
                    r.Oscillator = (decimal)r.Smooth;
                }
                else
                {
                    r.Oscillator = null;  // erase unsmoothed
                }
            }

            return results;
        }
    }
}
