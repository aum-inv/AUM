using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Chakra.App.Chakra
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
                foreach (var p in new string[] { "매수", "매도", "매수평균", "매도평균" })
                {
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_05, p));
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_10, p));
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_30, p));
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_60, p));
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Minute_120, p));
                    forecastInfos.Add(new TradeForecastInfo(item.Code, TimeIntervalEnum.Day, p));
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
