using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Indicators
{
    public static partial class Indicator
    {
        public static List<Quote> ConverterCandleQuote(List<S_CandleItemData> sourceData)
        {
            List<Quote> results = new List<Quote>();
            int idx = 0;
            foreach (var c in sourceData)
            {
                results.Add(
                    new Quote() {
                        Index = ++idx
                        , 
                        Date = c.DTime
                        ,
                        Open = Convert.ToDecimal(c.OpenPrice)
                        ,
                        High = Convert.ToDecimal(c.HighPrice)
                        ,
                        Low = Convert.ToDecimal(c.LowPrice)
                        ,
                        Close = Convert.ToDecimal(c.ClosePrice)
                        ,
                        Volume = Convert.ToInt64(c.Volume)
                    }
                    );
            }

            return results;
        }
    }
}
