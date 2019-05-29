using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.App.Cals
{
    public static class RevenueCalculater
    {
        public static string Calculator(string itemCode, string strategyType, string position, double buyPrice, double currrentPrice)
        {
            string revenuePrice = "0";
            int revenueTick = 0;
            try
            {
                if (strategyType == "1") revenueTick = Config.RevenueConfig.LOW_LIMIT_TICKS;
                else if (strategyType == "2") revenueTick = Config.RevenueConfig.MIDDLE_LIMIT_TICKS;
                else if (strategyType == "3") revenueTick = Config.RevenueConfig.HIGH_LIMIT_TICKS;
                int roundNum = ItemCodeUtil.GetItemCodeRoundNum(itemCode);
                //매도
                if (position == "1")
                {
                    //손실
                    if (buyPrice < currrentPrice)
                    {
                        revenuePrice = Math.Round(PriceTick.GetDownPriceOfTick(itemCode, buyPrice, revenueTick), roundNum).ToString();
                    }
                    //수익
                    else
                    {
                        revenuePrice = Math.Round(PriceTick.GetDownPriceOfTick(itemCode, buyPrice, revenueTick), roundNum).ToString();
                    }
                }
                //매수
                else if (position == "2")
                {
                    //손실
                    if (buyPrice > currrentPrice)
                    {
                        revenuePrice = Math.Round(PriceTick.GetUpPriceOfTick(itemCode, buyPrice, revenueTick), roundNum).ToString();
                    }
                    //수익
                    else
                    {
                        revenuePrice = Math.Round(PriceTick.GetUpPriceOfTick(itemCode, buyPrice, revenueTick), roundNum).ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
            return revenuePrice;
        }
        public static string Calculator(BaseTradeRule rule)
        {
            return Calculator(rule.ItemCode, rule.StrategyType, rule.Position, rule.BuyPrice, rule.RPrice);
        }
    }
}
