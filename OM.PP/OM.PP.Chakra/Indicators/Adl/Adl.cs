using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Indicators
{ 
    public static partial class Indicator
    {
        // ON-BALANCE VOLUME
        public static IEnumerable<AdlResult> GetAdl(IEnumerable<Quote> history)
        {          
            // initialize
            List<AdlResult> results = new List<AdlResult>();
            decimal prevAdl = 0;

            // get money flow multiplier
            foreach (Quote h in history)
            {
                decimal mfm = (h.High == h.Low) ? 0 : ((h.Close - h.Low) - (h.High - h.Close)) / (h.High - h.Low);
                decimal mfv = mfm * h.Volume;
                decimal adl = mfv + prevAdl;

                AdlResult result = new AdlResult
                {
                    Index = (int)h.Index,
                    Date = h.Date,
                    MoneyFlowMultiplier = mfm,
                    MoneyFlowVolume = mfv,
                    Adl = adl
                };
                results.Add(result);

                prevAdl = adl;
            }

            return results;
        }
    }
}
