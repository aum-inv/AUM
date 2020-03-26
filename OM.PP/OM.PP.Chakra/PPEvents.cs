using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public delegate void CandleOccurDelegate(string itemCode, TimeIntervalEnum timeInterval, int occurCount, PlusMinusTypeEnum pmType);
    public delegate void CandleChartPatternDelegate(string itemCode, TimeIntervalEnum timeInterval, CandleChartPatternEnum updown);
    public delegate void CandleMassPatternDelegate(string itemCode, TimeIntervalEnum timeInterval, CandleMassPatternEnum mass);
    
    public class PPEvents
    {
        private static PPEvents instance = new PPEvents();

        public static PPEvents Instance
        {
            get
            {
                return instance;
            }
        }

        public event CandleOccurDelegate CandleOccurHandler;
        
        public void OnCandleOccurHandler(string itemCode, TimeIntervalEnum timeInterval, int occurCount, PlusMinusTypeEnum pmType)
        {
            if (CandleOccurHandler != null)
                CandleOccurHandler(itemCode, timeInterval, occurCount, pmType);
        }

        public event CandleChartPatternDelegate CandleChartPatternHandler;

        public void OnCandleChartPatternHandler(string itemCode, TimeIntervalEnum timeInterval, CandleChartPatternEnum updown)
        {
            if (CandleChartPatternHandler != null)
                CandleChartPatternHandler(itemCode, timeInterval, updown);
        }

        public event CandleMassPatternDelegate CandleMassPatternHandler;

        public void OnCandleMassPatternHandler(string itemCode, TimeIntervalEnum timeInterval, CandleMassPatternEnum mass)
        {
            if (CandleMassPatternHandler != null)
                CandleMassPatternHandler(itemCode, timeInterval, mass);
        }
    }
}
