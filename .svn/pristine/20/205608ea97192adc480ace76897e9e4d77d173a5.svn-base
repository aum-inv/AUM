using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Utils
{
    public static class PriceTick
    {
        //Console.WriteLine(PriceTick.GetTickDiff("CL", 50.0, 55.0));

        //    Console.WriteLine(PriceTick.GetDownPriceOfRate("CL", 46.23, 6.64));

        //    Console.WriteLine(PriceTick.GetRate("CL", 46.23, 43.16));

        //    Console.WriteLine(PriceTick.GetDownPriceOfTick("CL", 50.0, 10));

        //    Console.WriteLine(PriceTick.GetUpPriceOfRatek("CL", 50.0, 10.0));

        //    Console.WriteLine(PriceTick.GetUpPriceOfTick("CL", 50.0, 10));
        public static int GetTickDiff(string itemCode, double p1, double p2)
        {
            double tick = ItemCodeSet.GetTick(itemCode);

            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            p2 = Math.Round(p2, round);

            double diff = Math.Round(Math.Abs(p1 - p2), round);

            return (int)(diff / tick);
        }

        public static double GetRate(string itemCode, double p1, double p2)
        {           
            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            p2 = Math.Round(p2, round);

            double rate = (p1 - p2) / p1 * 100.0;

            return Math.Round(rate, 2);
        }

        public static double GetUpPriceOfTick(string itemCode, double p1, int tickNum)
        {
            double tick = ItemCodeSet.GetTick(itemCode);

            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            double p2 = Math.Round((tick  * tickNum), round);

            double newPrice = Math.Round(p1 + p2, round);

            return newPrice;
        }

        public static double GetDownPriceOfTick(string itemCode, double p1, int tickNum)
        {
            double tick = ItemCodeSet.GetTick(itemCode);

            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            double p2 = Math.Round((tick * tickNum), round);

            double newPrice = Math.Round(p1 - p2, round);

            return newPrice;
        }

        public static double GetUpPriceOfRate(string itemCode, double p1, double rate)
        {
            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            double p2 = Math.Round((p1 * rate / 100.0), round);

            double newPrice = Math.Round(p1 + p2, round);

            return newPrice;
        }

        public static double GetDownPriceOfRate(string itemCode, double p1, double rate)
        {
            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            p1 = Math.Round(p1, round);

            double p2 = Math.Round((p1 * rate / 100.0), round);

            double newPrice = Math.Round(p1 - p2, round);

            return newPrice;
        }
    }
}
