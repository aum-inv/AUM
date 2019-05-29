using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Strategy
{
    public class TradeForecastInfo
    {
        public TradeForecastInfo(string item, TimeIntervalEnum time, string position)
        {
            this.Item = item;
            this.TimeInterval = time;
            this.Position = position;
        }
        public string Item { get; set; }
        public TimeIntervalEnum TimeInterval { get; set; }
        public string Position { get; set; }

        //추세
        public UpDownEnum Trend { get; set; } = UpDownEnum.None;        
        public UpDownEnum Volatility { get; set; } = UpDownEnum.None;
        //지저저항
        public UpDownEnum BaseLine { get; set; } = UpDownEnum.None;
        //추세강도
        public int TrendOfStrength { get; set; } = 0;

        //보조지표1
        //public int SecondaryIndicator_
        public int ForcastOfStrength
        {
            get
            {
                return 0;
            }
        }
    }
}
