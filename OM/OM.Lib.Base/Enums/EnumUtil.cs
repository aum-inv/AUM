using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Enums
{
    public static class EnumUtil
    {
        public static string GetFinancialClassificationName(FinancialClassificationEnum financialClassification)
        {
            string name = string.Empty;

            switch (financialClassification)
            {
                case FinancialClassificationEnum.Commodities:
                    name = "COMMODITIES";
                    break;
                case FinancialClassificationEnum.Crypto:
                    name = "CRYPTO";
                    break;
                case FinancialClassificationEnum.Forex:
                    name = "FOREX";
                    break;
                case FinancialClassificationEnum.Indices:
                    name = "INDICES";
                    break;
                case FinancialClassificationEnum.Stocks:
                    name = "STOCKS";
                    break;
            }

            return name;
        }

        public static TimeIntervalEnum GetTimeIntervalValue(string gubun, string ncnt)
        {

            if (gubun == "1" && ncnt == "60") return TimeIntervalEnum.Minute_60;
            else if (gubun == "1" && ncnt == "120") return TimeIntervalEnum.Minute_120;
            else if (gubun == "1" && ncnt == "180") return TimeIntervalEnum.Minute_180;
            else if (gubun == "1" && ncnt == "300") return TimeIntervalEnum.Minute_300;
            else if (gubun == "1" && ncnt == "420") return TimeIntervalEnum.Minute_420;
            else if (gubun == "1" && ncnt == "540") return TimeIntervalEnum.Minute_540;

            else if (gubun == "2") return TimeIntervalEnum.Day;
            else if (gubun == "3") return TimeIntervalEnum.Week;
            else if (gubun == "4") return TimeIntervalEnum.Month;
            else if (gubun == "0" && ncnt == "180") return TimeIntervalEnum.Tick_180;
            else if (gubun == "0" && ncnt == "360") return TimeIntervalEnum.Tick_360;
            else if (gubun == "0" && ncnt == "720") return TimeIntervalEnum.Tick_720;
            else if (gubun == "0" && ncnt == "1080") return TimeIntervalEnum.Tick_1080;
            else if (gubun == "0" && ncnt == "1440") return TimeIntervalEnum.Tick_1440;

            return TimeIntervalEnum.Tick;
        }

        public static TimeIntervalEnum GetTimeIntervalValue(string timeType)
        {

            if (timeType == "60분") return TimeIntervalEnum.Minute_60;
            else if (timeType == "120분") return TimeIntervalEnum.Minute_120;
            else if (timeType == "180분") return TimeIntervalEnum.Minute_180;
            else if (timeType == "300분") return TimeIntervalEnum.Minute_300;
            else if (timeType == "420분") return TimeIntervalEnum.Minute_420;
            else if (timeType == "540분") return TimeIntervalEnum.Minute_540;
            else if (timeType == "일") return TimeIntervalEnum.Day;
            else if (timeType == "주") return TimeIntervalEnum.Week;
            else if (timeType == "월") return TimeIntervalEnum.Month;

            else if (timeType == "180틱") return TimeIntervalEnum.Tick_180;
            else if (timeType == "360틱") return TimeIntervalEnum.Tick_360;
            else if (timeType == "720틱") return TimeIntervalEnum.Tick_720;
            else if (timeType == "1080틱") return TimeIntervalEnum.Tick_1080;
            else if (timeType == "1440틱") return TimeIntervalEnum.Tick_1440;
            return TimeIntervalEnum.Tick;
        }
        public static string GetTimeIntervalText(TimeIntervalEnum timeType)
        {

            if (timeType == TimeIntervalEnum.Minute_60) return "60분";
            else if (timeType == TimeIntervalEnum.Minute_120) return "120분";
            else if (timeType == TimeIntervalEnum.Minute_180) return "180분";
            else if (timeType == TimeIntervalEnum.Minute_300) return "300분";
            else if (timeType == TimeIntervalEnum.Minute_420) return "420분";
            else if (timeType == TimeIntervalEnum.Minute_540) return "540분";
            else if (timeType == TimeIntervalEnum.Day) return "일";
            else if (timeType == TimeIntervalEnum.Week) return "주";
            else if (timeType == TimeIntervalEnum.Month) return "월";

            else if (timeType == TimeIntervalEnum.Tick_180) return "180틱";
            else if (timeType == TimeIntervalEnum.Tick_360) return "360틱";
            else if (timeType == TimeIntervalEnum.Tick_720) return "720틱";
            else if (timeType == TimeIntervalEnum.Tick_1080) return "1080틱";
            else if (timeType == TimeIntervalEnum.Tick_1440) return "1440틱";

            return "1분";
        }


        public static int GetIntervalValueToMinutes(string timeType)
        {

            if (timeType == "60분") return 60;
            else if (timeType == "120분") return 120;
            else if (timeType == "180분") return 180;
            else if (timeType == "300분") return 300;
            else if (timeType == "420분") return 420;
            else if (timeType == "540분") return 540;            

            return 1;
        }

        public static int GetIntervalValueToTicks(string timeType)
        {

            if (timeType == "180틱") return 180;
            else if (timeType == "360틱") return 360;
            else if (timeType == "720틱") return 720;
            else if (timeType == "1080틱") return 1080;
            else if (timeType == "1440틱") return 1440;

            return 180;
        }

        public static string GetUpDownPatternToChars(UpDownPatternEnum upDownPattern)
        {
            string result = "";
            if (upDownPattern == UpDownPatternEnum.UpDownUpDownUpDownUp) result = "UDUDUDU";
            else if (upDownPattern == UpDownPatternEnum.DownUpDownUpDownUpDown) result = "DUDUDUD";
            else if (upDownPattern == UpDownPatternEnum.UpDownUpDownUpDown) result = "UDUDUD";
            else if (upDownPattern == UpDownPatternEnum.DownUpDownUpDownUp) result = "DUDUDU";
            else if (upDownPattern == UpDownPatternEnum.UpDownUpDownUp) result = "UDUDU";
            else if (upDownPattern == UpDownPatternEnum.DownUpDownUpDown) result = "DUDUD";
            else if (upDownPattern == UpDownPatternEnum.UpDownUpDown) result = "UDUD";
            else if (upDownPattern == UpDownPatternEnum.DownUpDownUp) result = "DUDU";
            else if (upDownPattern == UpDownPatternEnum.UpDownUp) result = "UDU";
            else if (upDownPattern == UpDownPatternEnum.DownUpDown) result = "DUD";
            else if (upDownPattern == UpDownPatternEnum.UpDown) result = "UD";
            else if (upDownPattern == UpDownPatternEnum.DownUp) result = "DU";
            else if (upDownPattern == UpDownPatternEnum.Up) result = "U";
            else if (upDownPattern == UpDownPatternEnum.Down) result = "D";

            return result;
        }
    }
}
