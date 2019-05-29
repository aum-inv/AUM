using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra
{
    public class BasicTradeRule :BaseTradeRule
    {
        //"UP↑", "DOWN↓", "UPDOWN↑↓", "DOWNUP↓↑"

        #region 속성

        public string RuleID { get; set; } = "";
        public string TimeType { get; set; } = "";

        public bool IsUseP2 { get; set; } = false;
        public bool IsTouchedP2 { get; set; } = false;
        public double P2BuyPrice1 { get; set; } = 0;
        public double P2BuyPrice2 { get; set; } = 0;
        public double P2LosscutPrice1 { get; set; } = 0;
        public PricePatternEnum P2LosscutPattern1 { get; set; } = PricePatternEnum.UPDOWN;
        public double P2LosscutPrice2 { get; set; } = 0;
        public PricePatternEnum P2BuyPattern1 { get; set; } = PricePatternEnum.UP;
        public PricePatternEnum P2BuyPattern2 { get; set; } = PricePatternEnum.DOWNUP;

        public bool IsUseP1 { get; set; } = false;
        public bool IsTouchedP1 { get; set; } = false;
        public double P1BuyPrice1 { get; set; } = 0;
        public double P1BuyPrice2 { get; set; } = 0;
        public double P1LosscutPrice1 { get; set; } = 0;
        public PricePatternEnum P1LosscutPattern1 { get; set; } = PricePatternEnum.DOWNUP;
        public double P1LosscutPrice2 { get; set; } = 0;
        public PricePatternEnum P1BuyPattern1 { get; set; } = PricePatternEnum.DOWN;
        public PricePatternEnum P1BuyPattern2 { get; set; } = PricePatternEnum.UPDOWN;

        public bool IsBuyDone { get; set; } = false;
        public bool IsUseRevenue1 { get; set; } = false;
        public bool IsUseRevenue2 { get; set; } = false;
        public bool IsMinimumRevenue1 { get; set; } = false;
        public bool IsMinimumRevenue2 { get; set; } = false;
        public double RevenuePrice { get; set; } = 0;
        public double RevenueRate { get; set; } = 0;
        public double MinimumRevenuePrice1 { get; set; } = 0;
        public double MinimumRevenuePrice2 { get; set; } = 0;
        #endregion

        protected override string AtmanName => "TRADE";

        public BasicTradeRule()
        {            
        }
        public override void InitRule()
        {
            IsBuyDone = false;
            IsTouchedP2 = false;
            IsTouchedP1 = false;
            Position = "";
            BuyPrice = 0;
            LosscutPrice = 0;
        }
        public override void Close()
        {
            IsUse = false;
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
                switch (PriceType)
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
                if (! IsUse) return;

                // //매수포지션 사용여부
                if (!IsBuyDone)
                {   
                    if (IsUseP2)
                    {
                        //터치여부
                        if (!IsTouchedP2)
                        {
                            if (PointsUtil.IsBreakThrough(P2BuyPattern1, P2BuyPrice1, PriceList))
                            {
                                IsTouchedP2 = true;
                                SellBuy("가격터치", "매수");
                            }
                        }
                        if (IsTouchedP2)
                        {
                            if (PointsUtil.IsBreakThrough(P2BuyPattern2, P2BuyPrice2, PriceList) && !IsBuyDone)
                            {
                                //매수포지션 진입
                                IsBuyDone = true;
                                BuyPrice = CPrice;
                                Position = "매수";
                                SellBuy("신규진입", "매수");
                            }
                        }
                    }
                }
                //매도포지션 사용여부
                if (!IsBuyDone)
                {                    
                    if (IsUseP1)
                    {
                        //터치여부
                        if (!IsTouchedP1)
                        {
                            if (PointsUtil.IsBreakThrough(P1BuyPattern1, P1BuyPrice1, PriceList))
                            {
                                IsTouchedP1 = true;
                                SellBuy("가격터치", "매도");
                            }
                        }
                        if (IsTouchedP1)
                        {
                            if (PointsUtil.IsBreakThrough(P1BuyPattern2, P1BuyPrice2, PriceList) && !IsBuyDone)
                            {
                                IsBuyDone = true;
                                BuyPrice = CPrice;
                                Position = "매도";
                                SellBuy("신규진입", "매도");
                            }
                        }
                    }
                }
                if (!IsBuyDone) return;
                if (Position == "매수" && IsMinimumRevenue2 && MinimumRevenuePrice2 > 0)
                {
                    if (MinimumRevenuePrice2 < CPrice) return;
                }
                if (Position == "매도" && IsMinimumRevenue1 && MinimumRevenuePrice1 > 0)
                {
                    if (MinimumRevenuePrice1 > CPrice) return;
                }

                //손실체크
                if (Position == "매수")
                {
                    if (PointsUtil.IsBreakThrough(P2LosscutPattern1, P2LosscutPrice1, PriceList))
                    {
                        InitRule();
                        SellBuy("손실청산1", "매도");
                    }

                    if (P2LosscutPrice2 > 0 && P2LosscutPrice2 >= CPrice)
                    {
                        //매도진입
                        InitRule();
                        SellBuy("손실청산2", "매도");
                    }
                }
                if (Position == "매도")
                {
                    if (PointsUtil.IsBreakThrough(P1LosscutPattern1, P1LosscutPrice1, PriceList))
                    {
                        InitRule();
                        SellBuy("손실청산1", "매수");
                    }

                    if (P1LosscutPrice2 > 0 && P1LosscutPrice2 <= CPrice)
                    {
                        //매수진입
                        InitRule();
                        SellBuy("손실청산2", "매수");
                    }
                }

              
                //수익체크
                if (IsUseRevenue1)
                {
                    double revenuePrice = Math.Round(GetRevenuePrice1(), RoundNum);
                    if (revenuePrice == 0) return;
                    if (Position == "매수")
                    {
                        if (revenuePrice <= CPrice)
                        {
                            //매도진입
                            InitRule();
                            SellBuy("수익청산", "매도");
                        }
                    }
                    if (Position == "매도")
                    {
                        if (revenuePrice >= CPrice)
                        {
                            //매수진입
                            InitRule();
                            SellBuy("수익청산", "매수");
                        }
                    }
                }
                if (IsUseRevenue2)
                {
                    double revenuePrice = Math.Round(GetRevenuePrice2(), RoundNum);
                    if (revenuePrice == 0) return;
                    if (Position == "매수")
                    {
                        if (revenuePrice <= CPrice)
                        {
                            //매도진입
                            InitRule();
                            SellBuy("수익청산", "매도");
                        }
                    }
                    if (Position == "매도")
                    {
                        if (revenuePrice >= CPrice)
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

        public double GetRevenuePrice1()
        {   
            double revenuePrice = 0;
            try
            {
                if (RevenuePrice != 0) revenuePrice = RevenuePrice;
                if (Position == "매수" && revenuePrice < BuyPrice) revenuePrice = 0;
                if (Position == "매도" && revenuePrice > BuyPrice) revenuePrice = 0;
            }
            catch (Exception ) { }

            return revenuePrice;
        }
        public double GetRevenuePrice2()
        {
            double revenuePrice = 0;
            try
            {
                if (RevenueRate != 0)
                {
                    if (Position == "매수")
                        revenuePrice = PriceTick.GetDownPriceOfRate(ItemCode, HPrice, RevenueRate);
                    if (Position == "매도")
                        revenuePrice = PriceTick.GetUpPriceOfRate(ItemCode, LPrice, RevenueRate);
                }
                if (Position == "매수" && revenuePrice < BuyPrice) revenuePrice = 0;
                if (Position == "매도" && revenuePrice > BuyPrice) revenuePrice = 0;
            }
            catch (Exception ) { }

            return revenuePrice;
        }

        public void SellBuy(string type, string position)
        {
            try
            {
                TradeEvents.Instance.OnTradeRuleHandler(AtmanName, RuleID, ItemCode, $"{type}::{position}::{CPrice}");
                //XingContext.Instance.ClientContext.OrderBuySell();
            }
            catch (Exception)
            {
            }
        }
    }
}
