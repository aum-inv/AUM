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
    public class StrategyTradeSMRule : BaseTradeRule
    {
        //"UP↑", "DOWN↓", "UPDOWN↑↓", "DOWNUP↓↑"

        #region 속성

        public List<double> BasePrices { get; set; }
        public UpDownPatternEnum BasePattern { get; set; } = UpDownPatternEnum.None;
        public bool IsTouchedBasePrice { get; set; } = false;
        public double BuyPrice1 { get; set; } = 0;
        public double BuyPrice2 { get; set; } = 0;
        public override string AtmanName => "STRATEGY";
        #endregion



        public event StrategyTradeRuleDelegate StrategyTradeRuleEventHandler;

        public StrategyTradeSMRule() : base(365)
        {            
        }
        public override void InitRule()
        {
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
            
                RPrice = Math.Round(Convert.ToDouble(price.price), RoundNum);

                switch (PriceType)
                {
                    case "0":
                        CPrice = RPrice;
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
                if (!IsBuyed)
                {   
                    if (IsUseBuy)
                    {
                        //터치여부
                        if (!IsTouchedBasePrice)
                        {
                            if (PointsUtil.IsMatchedUpDownPattern(PriceList, BasePrices, BasePattern))
                            {
                                IsTouchedBasePrice = true;
                                onStrategyTradeRuleHandler("터치", $"베이스 가격터치::현재가{CPrice}");
                            }

                            //if (PointsUtil.IsBreakThrough(BasePattern, BasePrice, PriceList))
                            //{
                            //    IsTouchedBasePrice = true;
                            //    onStrategyTradeRuleHandler("터치", $"베이스 가격터치::현재가{CPrice}");
                            //}
                        }
                        if (IsTouchedBasePrice && !IsBuyed)
                        {
                            //매도
                            if (Position == "1")
                            {
                                if (CPrice == BuyPrice)
                                {
                                    IsBuyed = true;
                                    SellBuy("진입", Position);
                                    onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                                }
                            }
                            //매수
                            if (Position == "2")
                            {
                                if (CPrice == BuyPrice)
                                {
                                    IsBuyed = true;
                                    SellBuy("진입", Position);
                                    onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
                                }
                            }                            
                        }
                    }
                }
                if (IsBuyed && IsUseLosscut && !IsLosscuted && !IsRevenued)
                {
                    if (Position == "1")
                    {
                        if (RPrice == LosscutPrice)
                        {
                            IsLosscuted = true;
                            SellBuy("청산", "2");
                            onStrategyTradeRuleHandler("청산", $"매수청산::현재가{CPrice}");
                        }
                    }
                    //매수
                    if (Position == "2")
                    {
                        if (RPrice == LosscutPrice)
                        {
                            IsLosscuted = true;
                            SellBuy("청산", "1");
                            onStrategyTradeRuleHandler("청산", $"매도청산::현재가{CPrice}");
                        }
                    }
                }
                if (IsBuyed && IsUseRevenue && !IsRevenued && !IsLosscuted)
                {
                    if (Position == "1")
                    {
                        if (RPrice == RevenuePrice)
                        {
                            IsRevenued = true;
                            SellBuy("청산", "2");
                            onStrategyTradeRuleHandler("청산", $"매수청산::현재가{CPrice}");
                        }
                    }
                    //매수
                    if (Position == "2")
                    {
                        if (RPrice == RevenuePrice)
                        {
                            IsRevenued = true;
                            SellBuy("청산", "1");
                            onStrategyTradeRuleHandler("청산", $"매도청산::현재가{CPrice}");
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                onStrategyTradeRuleHandler("ERROR", ex.Message);
            }
            finally
            {
                BPrice = CPrice;
            }
        }

        public override void SellBuy(string type, string position)
        {
            try
            {
                base.SellBuy(type, position);
            }
            catch (Exception ex)
            {
                onStrategyTradeRuleHandler("ERROR", ex.Message);
            }
        }
        private void onStrategyTradeRuleHandler(string type, string msg)
        {
            if (StrategyTradeRuleEventHandler != null)
                StrategyTradeRuleEventHandler(type, msg);
        }
    }
}
