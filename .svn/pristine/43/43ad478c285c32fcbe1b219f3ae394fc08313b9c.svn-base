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
    public delegate void TickLineChartPatternDelegate(string itemCode, TimeIntervalEnum timeInterval, TickLineChartPatternEnum updown, string type);
    public delegate void TickLineUpDownPatternDelegate(string itemCode, TimeIntervalEnum timeInterval, UpDownPatternEnum updown, string type);
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

        public event TickLineChartPatternDelegate TickLineChartPatternHandler;

        public void OnTickLineChartPatternHandler(string itemCode, TimeIntervalEnum timeInterval, TickLineChartPatternEnum updown, string type)
        {
            if (TickLineChartPatternHandler != null)
                TickLineChartPatternHandler(itemCode, timeInterval, updown, type);
        }

        public event TickLineUpDownPatternDelegate TickLineUpDownPatternHandler;

        public void OnTickLineUpDownPatternHandler(string itemCode, TimeIntervalEnum timeInterval, UpDownPatternEnum updown, string type)
        {
            if (TickLineUpDownPatternHandler != null)
                TickLineUpDownPatternHandler(itemCode, timeInterval, updown, type);
        }
    }
}
