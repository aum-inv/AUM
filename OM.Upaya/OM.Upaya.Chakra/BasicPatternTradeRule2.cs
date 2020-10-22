using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra
{
    public class BasicPatternTradeRule2 : BaseTradeRule
    {
        #region 속성

        public string RuleID { get; set; } = "";
        public string Item { get { return ItemCode; } set { ItemCode = value; } }
        public string TimeType { get; set; } = "";
        
        public bool IsBaseLine { get; set; } = true;

        public bool IsUseP2 { get; set; } = false;
        public bool IsTouchedP2 { get; set; } = false;
        public List<double> P2BuyPrice1 { get; set; }
        public List<double> P2BuyPrice2 { get; set; }
        public double P2LosscutPrice1 { get; set; } = 0;
        public PricePatternEnum P2LosscutPattern1 { get; set; } = PricePatternEnum.UPDOWN;
        public double P2LosscutPrice2 { get; set; } = 0;
        public UpDownPatternEnum P2BuyPattern { get; set; } = UpDownPatternEnum.None;

        public bool IsUseP1 { get; set; } = false;
        public bool IsTouchedP1 { get; set; } = false;
        public List<double> P1BuyPrice1 { get; set; }
        public List<double> P1BuyPrice2 { get; set; }
        public double P1LosscutPrice1 { get; set; } = 0;
        public PricePatternEnum P1LosscutPattern1 { get; set; } = PricePatternEnum.DOWNUP;
        public double P1LosscutPrice2 { get; set; } = 0;
        public UpDownPatternEnum P1BuyPattern { get; set; } = UpDownPatternEnum.None;

        public bool IsBuyDone { get; set; } = false;
        

        public bool IsUseRevenue1 { get; set; } = false;
        public bool IsUseRevenue2 { get; set; } = false;
        public bool IsMinimumRevenue1 { get; set; } = false;
        public bool IsMinimumRevenue2 { get; set; } = false;
    
        public double RevenueRate { get; set; } = 0;
        public double MinimumRevenuePrice1 { get; set; } = 0;
        public double MinimumRevenuePrice2 { get; set; } = 0;

        public override string AtmanName => throw new NotImplementedException();
        #endregion

        public BasicPatternTradeRule2(bool isBaseLine = true)
        {
            IsBaseLine = isBaseLine;
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
                            if (IsBaseLine)
                            {
                                if (PointsUtil.GetUpDownPattern(PriceList, P2BuyPrice1) == P2BuyPattern)
                                {
                                    IsTouchedP2 = true;
                                    SellBuy("가격패턴매칭", "매수");
                                }
                            }
                            else
                            {
                                if (PointsUtil.GetUpDownPattern(PriceList, P2BuyPrice1, P2BuyPrice2) == P2BuyPattern)
                                {
                                    IsTouchedP2 = true;
                                    SellBuy("가격패턴매칭", "매수");
                                }
                            }
                        }
                        if (IsTouchedP2)
                        {
                            //매수포지션 진입
                            IsBuyDone = true;
                            BuyPrice = CPrice;
                            Position = "매수";
                            SellBuy("신규진입", "매수");
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
                            if (IsBaseLine)
                            {
                                if (PointsUtil.GetUpDownPattern(PriceList, P1BuyPrice1) == P1BuyPattern)
                                {
                                    IsTouchedP1 = true;
                                    SellBuy("가격패턴매칭", "매도");
                                }
                            }
                            else
                            {
                                if (PointsUtil.GetUpDownPattern(PriceList, P1BuyPrice1, P1BuyPrice2) == P1BuyPattern)
                                {
                                    IsTouchedP1 = true;
                                    SellBuy("가격패턴매칭", "매도");
                                }
                            }
                        }
                        if (IsTouchedP1)
                        {
                            IsBuyDone = true;
                            BuyPrice = CPrice;
                            Position = "매도";
                            SellBuy("신규진입", "매도");
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
    }
}
