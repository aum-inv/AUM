﻿using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra
{
    public class StrategyAutoTradeRule : BaseTradeRule
    {
        //"UP↑", "DOWN↓", "UPDOWN↑↓", "DOWNUP↓↑"


        #region 속성
        public string StrategyDirection = "1"; //1. 추세, 2.횡보
        public string StrategyDuration = "1"; //1. 30분봉 2. 60분봉, 3. 120분봉
        public string PositionType = "12";

        public override string AtmanName => "STRATEGY";

        public string BaseCandleItemType = "1"; //1. 챠크라챠트   2. 양자평균챠트   3.다이아몬드챠트
        public S_CandleItemData BaseCandleItem = null;
       #endregion

        public event StrategyTradeRuleDelegate StrategyTradeRuleEventHandler;

        public StrategyAutoTradeRule() : base(365)
        {            
        }
        public override void InitRule()
        {
            IsBuyed = IsLosscuted = IsRevenued = false;
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

                // // 사용여부
                if (!IsBuyed)
                {
                    double hPrice = 0;
                    double lPrice = 0;
                    double mPrice = 0;
                    double qPrice = 0;
                    double qhPrice = 0;
                    double qlPrice = 0;

                    if (BaseCandleItem != null)
                    {
                        if (BaseCandleItemType == "1")
                        {
                            hPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.VikalaHighPrice : BaseCandleItem.QuantumHighPrice, RoundNum);
                            lPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.QuantumLowPrice : BaseCandleItem.VikalaLowPrice, RoundNum);
                            mPrice = Math.Round(BaseCandleItem.MassPrice, RoundNum);
                            qPrice = Math.Round(BaseCandleItem.TotalCenterPrice, RoundNum);
                            qhPrice = mPrice > qPrice ? mPrice : qPrice;
                            qlPrice = mPrice < qPrice ? mPrice : qPrice;
                        }
                        else if (BaseCandleItemType == "2")
                        {
                            hPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.VikalaHighPrice : BaseCandleItem.QuantumHighPrice, RoundNum);
                            lPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.QuantumLowPrice : BaseCandleItem.VikalaLowPrice, RoundNum);
                            mPrice = Math.Round(BaseCandleItem.MassPrice, RoundNum);
                            qPrice = Math.Round(BaseCandleItem.TotalCenterPrice, RoundNum);
                            qhPrice = mPrice > qPrice ? mPrice : qPrice;
                            qlPrice = mPrice < qPrice ? mPrice : qPrice;
                        }
                        else if (BaseCandleItemType == "3")
                        {
                            hPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.VikalaHighPrice : BaseCandleItem.QuantumHighPrice, RoundNum);
                            lPrice = Math.Round(BaseCandleItem.PlusMinusType == PlusMinusTypeEnum.양 ? BaseCandleItem.QuantumLowPrice : BaseCandleItem.VikalaLowPrice, RoundNum);
                            mPrice = Math.Round(BaseCandleItem.MassPrice, RoundNum);
                            qPrice = Math.Round(BaseCandleItem.TotalCenterPrice, RoundNum);
                            qhPrice = mPrice > qPrice ? mPrice : qPrice;
                            qlPrice = mPrice < qPrice ? mPrice : qPrice;
                        }
                    }                    

                    if (hPrice == 0 || lPrice == 0 || qhPrice == 0 || qlPrice == 0)
                        return;

                    if (StrategyDirection == "1")//추세(지지저항)
                    {
                        //매도
                        if (CPrice < lPrice && PositionType.Contains("1"))
                        {
                            Position = "1";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                        }
                        //매수
                        else if (CPrice > hPrice && PositionType.Contains("2"))
                        {
                            Position = "2";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
                        }
                    }
                    else if (StrategyDirection == "2")//횡보(지지저항)
                    {
                        //매수
                        if (CPrice < lPrice && PositionType.Contains("2"))
                        {
                            Position = "2";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
                        }
                        //매도
                        else if (CPrice > hPrice && PositionType.Contains("1"))
                        {
                            Position = "1";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                        }
                    }
                    else if (StrategyDirection == "3")//추세(질량)
                    {
                        //매도
                        if (CPrice == qlPrice && PositionType.Contains("1"))
                        {
                            Position = "1";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                        }
                        //매수
                        else if (CPrice == qhPrice && PositionType.Contains("2"))
                        {
                            Position = "2";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
                        }
                    }
                    else if (StrategyDirection == "4")//횡보(질량)
                    {
                        //매수
                        if (CPrice == qlPrice && PositionType.Contains("2"))
                        {
                            Position = "2";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
                        }
                        //매도
                        else if (CPrice == qhPrice && PositionType.Contains("1"))
                        {
                            Position = "1";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                        }
                    }
                    else if (StrategyDirection == "5")
                    {
                        //매도
                        if (CPrice == qlPrice && PositionType.Contains("1"))
                        {
                            Position = "1";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매도진입::현재가{CPrice}");
                        }
                        //매수
                        else if (CPrice == qhPrice && PositionType.Contains("2"))
                        {
                            Position = "2";
                            IsBuyed = true;
                            SellBuy("진입", Position);
                            onStrategyTradeRuleHandler("진입", $"매수진입::현재가{CPrice}");
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
                            onStrategyTradeRuleHandler("손실컷", $"매수청산::현재가{CPrice}");
                        }
                    }
                    //매수
                    if (Position == "2")
                    {
                        if (RPrice == LosscutPrice)
                        {
                            IsLosscuted = true;
                            SellBuy("청산", "1");
                            onStrategyTradeRuleHandler("손실컷", $"매도청산::현재가{CPrice}");
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
                            onStrategyTradeRuleHandler("수익컷", $"매수청산::현재가{CPrice}");
                        }
                    }
                    //매수
                    if (Position == "2")
                    {
                        if (RPrice == RevenuePrice)
                        {
                            IsRevenued = true;
                            SellBuy("청산", "1");
                            onStrategyTradeRuleHandler("수익컷", $"매도청산::현재가{CPrice}");
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
                IsBuyed = true;
                Position = position;
                base.SellBuy(type, position);            
            }
            catch (Exception ex)
            {
                onStrategyTradeRuleHandler("ERROR", ex.Message);
            }
        }
        public override void ForceSell()
        {
            try
            {
                IsLosscuted = true;
                IsRevenued = true;
                base.ForceSell();
            }
            catch (Exception ex)
            {
                onStrategyTradeRuleHandler("ERROR", ex.Message);
            }
            finally
            {
                onStrategyTradeRuleHandler("청산", $"강제청산::현재가{CPrice}");
            }
        }
        public void onStrategyTradeRuleHandler(string type, string msg)
        {
            if (StrategyTradeRuleEventHandler != null)
                StrategyTradeRuleEventHandler(type, msg);
        }
    }
}
