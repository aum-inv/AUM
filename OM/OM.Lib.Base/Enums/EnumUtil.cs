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

            if (gubun == "1" && ncnt == "01") return TimeIntervalEnum.Minute_01;
            else if (gubun == "1" && ncnt == "05") return TimeIntervalEnum.Minute_05;
            else if (gubun == "1" && ncnt == "10") return TimeIntervalEnum.Minute_10;
            else if (gubun == "1" && ncnt == "30") return TimeIntervalEnum.Minute_30;
            else if (gubun == "1" && ncnt == "60") return TimeIntervalEnum.Hour_01;
            else if (gubun == "1" && ncnt == "120") return TimeIntervalEnum.Hour_02;
            else if (gubun == "1" && ncnt == "180") return TimeIntervalEnum.Hour_03;
            else if (gubun == "1" && ncnt == "240") return TimeIntervalEnum.Hour_04;
            else if (gubun == "1" && ncnt == "300") return TimeIntervalEnum.Hour_05;
            else if (gubun == "1" && ncnt == "360") return TimeIntervalEnum.Hour_06;
            else if (gubun == "1" && ncnt == "480") return TimeIntervalEnum.Hour_08;
            else if (gubun == "1" && ncnt == "720") return TimeIntervalEnum.Hour_12;
            else if (gubun == "2") return TimeIntervalEnum.Day;
            else if (gubun == "3") return TimeIntervalEnum.Week;
            else if (gubun == "4") return TimeIntervalEnum.Month;

            return TimeIntervalEnum.None;
        }

        public static TimeIntervalEnum GetTimeIntervalValue(string timeType)
        {
            if (timeType == "01m") return TimeIntervalEnum.Minute_01;
            else if (timeType == "05m") return TimeIntervalEnum.Minute_05;
            else if (timeType == "10m") return TimeIntervalEnum.Minute_10;
            else if (timeType == "30m") return TimeIntervalEnum.Minute_30;
            else if (timeType == "01h") return TimeIntervalEnum.Hour_01;
            else if (timeType == "02h") return TimeIntervalEnum.Hour_02;
            else if (timeType == "03h") return TimeIntervalEnum.Hour_03;
            else if (timeType == "04h") return TimeIntervalEnum.Hour_04;
            else if (timeType == "05h") return TimeIntervalEnum.Hour_05;
            else if (timeType == "06h") return TimeIntervalEnum.Hour_06;
            else if (timeType == "08h") return TimeIntervalEnum.Hour_08;
            else if (timeType == "12h") return TimeIntervalEnum.Hour_12;
            else if (timeType == "D") return TimeIntervalEnum.Day;
            else if (timeType == "W") return TimeIntervalEnum.Week;
            else if (timeType == "M") return TimeIntervalEnum.Month;

            return TimeIntervalEnum.None;
        }
        public static string GetTimeIntervalText(TimeIntervalEnum timeType)
        {

            if (timeType == TimeIntervalEnum.Minute_01) return "01m";
            else if (timeType == TimeIntervalEnum.Minute_05) return "05m";
            else if (timeType == TimeIntervalEnum.Minute_10) return "10m";
            else if (timeType == TimeIntervalEnum.Minute_30) return "30m";
            else if (timeType == TimeIntervalEnum.Hour_01) return "01h";
            else if (timeType == TimeIntervalEnum.Hour_02) return "02h";
            else if (timeType == TimeIntervalEnum.Hour_03) return "03h";
            else if (timeType == TimeIntervalEnum.Hour_04) return "04h";
            else if (timeType == TimeIntervalEnum.Hour_05) return "05h";
            else if (timeType == TimeIntervalEnum.Hour_06) return "06h";
            else if (timeType == TimeIntervalEnum.Hour_08) return "08h";
            else if (timeType == TimeIntervalEnum.Hour_12) return "12h";
            else if (timeType == TimeIntervalEnum.Day) return "D";
            else if (timeType == TimeIntervalEnum.Week) return "W";
            else if (timeType == TimeIntervalEnum.Month) return "M";

            return "1분";
        }


        public static int GetIntervalValueToMinutes(string timeType)
        {

            return Convert.ToInt32(timeType.Replace("분", ""));
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
