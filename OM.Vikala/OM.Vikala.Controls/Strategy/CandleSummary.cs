using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Strategy
{
    public class CandleSummary
    {
        private CandleSummary() { }

        private static CandleSummary instance = new CandleSummary();
        public static CandleSummary Instance
        {
            get
            {
                return instance;
            }
        }

        private List<TradeForecastInfo> forecastInfos = new List<TradeForecastInfo>();
        public List<TradeForecastInfo> ForecastInfos
        {
            get
            {
                if (forecastInfos.Count == 0) createSummary();

                return forecastInfos;
            }
        }
        private void createSummary()
        {
            foreach (var item in ItemCodeSet.Items)
            {
                if (item.Code == "") continue;
                foreach (var p in new string[] { "매수", "매도" })
                {
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_60, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_120, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_120, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_300, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_360, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_480, p));
                    ForecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Day, p));
                }
            }            
        }

        public void UpdateSummaryTrend(string item, TimeIntervalEnum time, string position, UpDownEnum trend)
        {
            var info = ForecastInfos.Where(t => t.Item == item && t.TimeInterval == time && t.Position == position).First();
            
            info.Trend = trend;
        }
        public void UpdateSummaryBaseLine(string item, TimeIntervalEnum time, string position, UpDownEnum baseLine)
        {
            var info = ForecastInfos.Where(t => t.Item == item && t.TimeInterval == time && t.Position == position).First();

            info.BaseLine = baseLine;
        }
        public void UpdateSummaryVolatility(string item, TimeIntervalEnum time, string position, UpDownEnum volatility)
        {
            var info = ForecastInfos.Where(t => t.Item == item && t.TimeInterval == time && t.Position == position).First();

            info.Volatility = volatility;
        }
        public void UpdateSummaryTrendOfStrength(string item, TimeIntervalEnum time, string position, int trendOfStrength)
        {
            var info = ForecastInfos.Where(t => t.Item == item && t.TimeInterval == time && t.Position == position).First();

            info.TrendOfStrength = trendOfStrength;
        }    
    }
}
