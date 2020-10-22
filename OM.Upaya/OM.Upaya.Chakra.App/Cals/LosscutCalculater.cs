using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra.App.Cals
{
    public static class LosscutCalculater
    {
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public static string Calculator(string itemCode, string strategyType, string position, double buyPrice, double currrentPrice, double highPrice, double lowPrice)
        {
            string losscutPrice = "0";
            int losscutTick = 0;
            try
            {
                int roundNum = ItemCodeUtil.GetItemCodeRoundNum(itemCode);
                //매도
                if (position == "1")
                {
                    //손실
                    if (buyPrice < currrentPrice)
                    {
                        if (strategyType == "1") losscutTick = Config.LosscutConfig.LOSS_LOW_LIMIT_TICKS;
                        else if (strategyType == "2") losscutTick = Config.LosscutConfig.LOSS_MIDDLE_LIMIT_TICKS;
                        else if (strategyType == "3") losscutTick = Config.LosscutConfig.LOSS_HIGH_LIMIT_TICKS;

                        losscutPrice = Math.Round(PriceTick.GetUpPriceOfTick(itemCode, buyPrice, losscutTick), roundNum).ToString();
                    }
                    //수익
                    else
                    {
                        if (strategyType == "1") losscutTick = Config.LosscutConfig.REVENUE_LOW_LIMIT_TICKS;
                        else if (strategyType == "2") losscutTick = Config.LosscutConfig.REVENUE_MIDDLE_LIMIT_TICKS;
                        else if (strategyType == "3") losscutTick = Config.LosscutConfig.REVENUE_HIGH_LIMIT_TICKS;

                        losscutPrice = Math.Round(PriceTick.GetUpPriceOfTick(itemCode, lowPrice, losscutTick), roundNum).ToString();
                    }
                }
                //매수
                else if (position == "2")
                {
                    //손실
                    if (buyPrice > currrentPrice)
                    {
                        if (strategyType == "1") losscutTick = Config.LosscutConfig.LOSS_LOW_LIMIT_TICKS;
                        else if (strategyType == "2") losscutTick = Config.LosscutConfig.LOSS_MIDDLE_LIMIT_TICKS;
                        else if (strategyType == "3") losscutTick = Config.LosscutConfig.LOSS_HIGH_LIMIT_TICKS;

                        losscutPrice = Math.Round(PriceTick.GetDownPriceOfTick(itemCode, buyPrice, losscutTick), roundNum).ToString();
                    }
                    //수익
                    else
                    {
                        if (strategyType == "1") losscutTick = Config.LosscutConfig.REVENUE_LOW_LIMIT_TICKS;
                        else if (strategyType == "2") losscutTick = Config.LosscutConfig.REVENUE_MIDDLE_LIMIT_TICKS;
                        else if (strategyType == "3") losscutTick = Config.LosscutConfig.REVENUE_HIGH_LIMIT_TICKS;

                        losscutPrice = Math.Round(PriceTick.GetDownPriceOfTick(itemCode, highPrice, losscutTick), roundNum).ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
            return losscutPrice;
        }

        public static string Calculator(BaseTradeRule rule)
        {
            return Calculator(rule.ItemCode, rule.StrategyType, rule.Position, rule.BuyPrice, rule.RPrice, rule.HPrice, rule.LPrice);
        }
    }
}
