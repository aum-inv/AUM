using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.Lib.Framework.Db;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra
{
    public class TwoLineTradeRule : BaseTradeRule
    {
        int limitTicks = 10;
        AtmanRule ruleInfo = null;
        S_CandleItemData candle = null;
        protected override string AtmanName => "TWOLINE";
        public AtmanRule RuleInfo
        {
            get { return ruleInfo; }
        }
        public TwoLineTradeRule(AtmanRule ruleInfo)
        {
            ItemCode = ruleInfo.Item;
            this.ruleInfo = ruleInfo;
        }
        public TwoLineTradeRule(AtmanRule ruleInfo, int limitTicks = 10)
        {
            this.limitTicks = limitTicks;
            ItemCode = ruleInfo.Item;
            this.ruleInfo = ruleInfo;
        }
        public override void InitRule()
        {
            //ruleInfo.IsUse = "N";
            ruleInfo.IsBuyDone = false;            
            ruleInfo.IsTouchedBasePrice = false;
            ruleInfo.Position = "";
            ruleInfo.BasePrice = "0";
            ruleInfo.BuyPrice = "0";
            ruleInfo.LossPrice = "0";
            ruleInfo.RevenuePrice = "0";
            ruleInfo.IsCanRevenue = false;
        }
        public override void Close()
        {
            ruleInfo.IsUse = "N";
        }
        public override void AnalysisAsync(CurrentPrice price)
        {  
            Task.Factory.StartNew(() =>
            {
                Analysis(price);
            });
        }
        public override void Analysis(CurrentPrice price)
        {
            try
            {
                GetSise(price);

                switch (ruleInfo.PriceType)
                {
                    case "0":
                        CPrice = Math.Round(Convert.ToDouble(price.price), RoundNum);
                        break;
                    case "1":
                        CPrice = Math.Round(price.price3, RoundNum);
                        break;
                    case "2":
                        CPrice = Math.Round(price.price5, RoundNum);
                        break;
                    case "3":
                        CPrice = Math.Round(price.price7, RoundNum);
                        break;
                    default:
                        CPrice = Math.Round(Convert.ToDouble(price.price), RoundNum);
                        break;
                }

                if (BPrice == CPrice) return;
                if (HPrice < CPrice) HPrice = Math.Round(CPrice, RoundNum);
                if (LPrice > CPrice) LPrice = Math.Round(CPrice, RoundNum);

                PriceList.Insert(CPrice);

                double touchPrice매도 = Math.Round(GetTouchPrice("매도"), RoundNum);
                double touchPrice매수 = Math.Round(GetTouchPrice("매수"), RoundNum);
            
                if (ruleInfo.IsUse == "N") return;
                if (touchPrice매도 == 0) return;
                if (touchPrice매수 == 0) return;

                // 진입
                if (!ruleInfo.IsBuyDone)
                {
                    //기준가 터치여부 체크
                    if (!ruleInfo.IsTouchedBasePrice)
                    {
                        if (PointsUtil.IsBreakThroughUp(touchPrice매수, PriceList))
                        {
                            ruleInfo.BasePrice = ruleInfo.BuyPrice = Math.Round(touchPrice매수, RoundNum).ToString();
                            ruleInfo.Position = "매수";
                            ruleInfo.IsTouchedBasePrice = true;
                            ruleInfo.BasePriceTouchTime = DateTime.Now;
                            TradeEvents.Instance.OnTradeRuleHandler(AtmanName, ItemCode, $"매수라인터치::{ruleInfo.TimeType}::{touchPrice매수}::{CPrice}");
                        }

                        if (PointsUtil.IsBreakThroughDown(touchPrice매도, PriceList))
                        {
                            ruleInfo.BasePrice = ruleInfo.BuyPrice = Math.Round(touchPrice매도, RoundNum).ToString();
                            ruleInfo.Position = "매도";
                            ruleInfo.IsTouchedBasePrice = true;
                            ruleInfo.BasePriceTouchTime = DateTime.Now;                            
                            TradeEvents.Instance.OnTradeRuleHandler(AtmanName, ItemCode, $"매도라인터치::{ruleInfo.TimeType}::{touchPrice매도}::{CPrice}");
                        }
                    }

                    //매입여부 체크
                    if (ruleInfo.IsTouchedBasePrice)
                    {
                        double basePrice = Math.Round(Convert.ToDouble(ruleInfo.BasePrice), RoundNum);
                        double buyPrice = Math.Round(GetBuyPrice(ruleInfo.Position), RoundNum);
                        //기준가 터치후 제약시간이상 넘었을 경우 
                        
                        if (ruleInfo.Position == "매수")
                        {
                            if (PointsUtil.IsBreakThroughDownUp(buyPrice, PriceList))
                            {
                                //매수진입
                                ruleInfo.IsBuyDone = true;
                                ruleInfo.BuyedTime = DateTime.Now;
                                ruleInfo.LossPrice = Math.Round(touchPrice매도, RoundNum).ToString();
                                ruleInfo.BuyPrice = Math.Round(buyPrice, RoundNum).ToString();
                                SellBuy("신규매입", "매수");
                            }
                        }
                        else if (ruleInfo.Position == "매도")
                        {
                            if (PointsUtil.IsBreakThroughUpDown(buyPrice, PriceList))
                            {
                                //매도진입
                                ruleInfo.IsBuyDone = true;
                                ruleInfo.BuyedTime = DateTime.Now;
                                ruleInfo.LossPrice = Math.Round(touchPrice매수, RoundNum).ToString();
                                ruleInfo.BuyPrice = Math.Round(buyPrice, RoundNum).ToString();
                                SellBuy("신규매입", "매도");
                            }
                        }
                    }
                }
                if (!ruleInfo.IsBuyDone) return;
                double lossPrice = GetLossPrice();
                //손실체크
                if (lossPrice > 0 && ruleInfo.IsBuyDone)
                {
                    if (ruleInfo.Position == "매수")
                    {
                        if (PointsUtil.IsBreakThroughDown(lossPrice, PriceList))
                        {
                            //매도진입
                            InitRule();
                            SellBuy("손실청산", "매도");
                        }
                    }
                    else if (ruleInfo.Position == "매도")
                    {
                        if (PointsUtil.IsBreakThroughUp(lossPrice, PriceList))
                        {
                            //매수진입
                            InitRule();
                            SellBuy("손실청산", "매수");
                        }
                    }
                }
                double revenuePrice = GetRevenuePrice();
                //수익체크
                if (revenuePrice > 0 && ruleInfo.IsBuyDone && ruleInfo.IsCanRevenue)
                {                    
                    if (ruleInfo.Position == "매수")
                    {
                        if (PointsUtil.IsBreakThroughUpDown(revenuePrice, PriceList))
                        {
                            //매도진입
                            InitRule();
                            SellBuy("수익청산", "매도");
                        }
                    }
                    else if (ruleInfo.Position == "매도")
                    {
                        if (PointsUtil.IsBreakThroughDownUp(revenuePrice, PriceList))
                        {
                            //매수진입
                            InitRule();
                            SellBuy("수익청산", "매수");
                        }
                    }                    
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                BPrice = CPrice;
            }
        }
        public double GetLossPrice()
        {
            double lossPrice = 0;
            try
            {
                lossPrice = Convert.ToDouble(ruleInfo.LossPrice);
                if (ruleInfo.Position == "매수" && lossPrice < CPrice) lossPrice = 0;
                if (ruleInfo.Position == "매도" && lossPrice > CPrice) lossPrice = 0;
            }
            catch (Exception ex) { }

            return lossPrice;
        }
        public double GetRevenuePrice()
        {   
            double revenuePrice = 0;
            try
            {
                revenuePrice = GetTouchPrice(ruleInfo.Position);
                double  buyPrice = Convert.ToDouble(ruleInfo.BuyPrice);
                if (ruleInfo.Position == "매수" && CPrice > revenuePrice) revenuePrice = 0;
                if (ruleInfo.Position == "매도" && CPrice < revenuePrice) revenuePrice = 0;
                if (ruleInfo.Position == "매수" && CPrice < buyPrice) revenuePrice = 0;
                if (ruleInfo.Position == "매도" && CPrice > buyPrice) revenuePrice = 0;
            }
            catch (Exception ex) { }

            return revenuePrice;
        }
        public double GetTouchPrice(string position)
        {
            double touchPrice = 0;
            try
            {
                if (position == "매수")
                {
                    if (candle.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        touchPrice = candle.CenterPrice > candle.MiddlePrice ? candle.CenterPrice : candle.MiddlePrice;
                    }
                    else if (candle.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        touchPrice = candle.QuantumCenterPrice > candle.QuantumMiddlePrice ? candle.QuantumCenterPrice : candle.QuantumMiddlePrice;
                    }
                }
                if (position == "매도")
                {
                    if (candle.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        touchPrice = candle.CenterPrice < candle.MiddlePrice ? candle.CenterPrice : candle.MiddlePrice;
                    }
                    else if (candle.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        touchPrice = candle.QuantumCenterPrice < candle.QuantumMiddlePrice ? candle.QuantumCenterPrice : candle.QuantumMiddlePrice;
                    }
                }
            }
            catch (Exception ex) { }

            return touchPrice;
        }
        public double GetBuyPrice(string position)
        {
            double buyPrice = 0;
            try
            {
                if (position == "매수")
                {
                    if (candle.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        buyPrice = candle.CenterPrice < candle.MiddlePrice ? candle.CenterPrice : candle.MiddlePrice;
                    }
                    else if (candle.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        buyPrice = candle.QuantumCenterPrice < candle.QuantumMiddlePrice ? candle.QuantumCenterPrice : candle.QuantumMiddlePrice;
                    }
                }
                if (position == "매도")
                {
                    if (candle.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        buyPrice = candle.CenterPrice > candle.MiddlePrice ? candle.CenterPrice : candle.MiddlePrice;
                    }
                    else if (candle.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        buyPrice = candle.QuantumCenterPrice > candle.QuantumMiddlePrice ? candle.QuantumCenterPrice : candle.QuantumMiddlePrice;
                    }
                }
            }
            catch (Exception ex) { }

            return buyPrice;
        }

        public void SellBuy(string type, string position)
        {
            try
            {
                TradeEvents.Instance.OnTradeRuleHandler(AtmanName, ItemCode, $"{type}:{ruleInfo.TimeType}:{ruleInfo.PriceType}:{position}:{CPrice}");
                //XingContext.Instance.ClientContext.OrderBuySell();
            }
            catch (Exception)
            {
            }
        }

        public void GetSise(CurrentPrice price = null)
        {
            try
            {
                if (candle != null && price != null)
                {
                    var nextTime = candle.DTime.AddMinutes(EnumUtil.GetIntervalValueToMinutes(ruleInfo.TimeType));

                    if (price.DTime < nextTime)
                        return;
                }

                PurushaPrakriti pp = new PurushaPrakriti();
                pp.Item = ruleInfo.Item;
                pp.Interval = (int)EnumUtil.GetTimeIntervalValue(ruleInfo.TimeType);
                pp.DisplayCount = 5;
                try
                {
                    Entities entities = (Entities)pp.Collect(new Query("USP_PP_SIMPLE_LST"));
                    List<PurushaPrakriti> list = entities.Cast<PurushaPrakriti>().ToList();

                    List<int> ticks = new List<int>();
                    foreach (var k in list.GetRange(1, 4))
                    {
                        int tick = PriceTick.GetTickDiff(ItemCode
                               , Convert.ToDouble(k.OpenVal)
                               , Convert.ToDouble(k.CloseVal));

                        ticks.Add(tick);
                    }

                    int avgTick = Convert.ToInt32(ticks.Average());
                    if (avgTick < limitTicks)
                        avgTick = limitTicks;

                    var m = list[1];
                    if (candle != null)
                    {
                        if (candle.HighPrice > m.HighVal && candle.LowPrice < m.LowVal)
                            return;

                        int tick = PriceTick.GetTickDiff(ItemCode
                            , Convert.ToDouble(candle.OpenPrice)
                            , Convert.ToDouble(candle.ClosePrice));

                        if (tick < avgTick) return;
                    }

                    candle = new S_CandleItemData(ItemCode, m.OpenVal, m.HighVal, m.LowVal, m.CloseVal, m.Volume, m.DT);

                    if (!ruleInfo.IsBuyDone)
                    {
                        InitRule();
                    }
                    else
                    {
                        ruleInfo.IsCanRevenue = true;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
