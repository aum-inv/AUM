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
    public delegate void ThreeFiveTradingRuleMsgDelegate(string msg);
    public class ThreeFiveTradingRule : BaseTradeRule
    {
        #region 속성

        public string RuleID { get; set; } = "";        
        public string PositionType { get; set; } = "매도";
        public string CharType { get; set; } = "안정형";
        public double BalancePrice { get; set; } = 0.0;
        public double RangeValue { get; set; } = 0.0;

        public double Direction1Value { get; set; } = 0.0;
        public double Direction2Value { get; set; } = 0.0;
        public double Direction3Value { get; set; } = 0.0;
        public double Direction4Value { get; set; } = 0.0;
        public double Direction5Value { get; set; } = 0.0;
        
        public double CurPrice { get; set; } = 0;

        bool isDoneMsgW1 = false;
        bool isDoneMsgW2 = false;
        bool isDoneMsgL1 = false;
        bool isDoneMsgL2 = false;
        public event ThreeFiveTradingRuleMsgDelegate ThreeFiveTradingRuleMsgHandler;
        #endregion

        public override string AtmanName => "ThreeFiveTradeRule";

        public ThreeFiveTradingRule()
        {
        }
        public override void InitRule()
        {
            CalculateDirectionValue();
        }

        public override void Close()
        {           
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
                CPrice = Math.Round(Convert.ToDouble(price.price), RoundNum);

                if (PositionType == "매도")
                {
                    //손실 1구간
                    if (!isDoneMsgL1 && CPrice >= Direction2Value)
                    {
                        isDoneMsgL1 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                            , CharType == "안정형" ? "70" : "30", "손실");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    } 
                    //손실 2구간
                    if (!isDoneMsgL2 && CPrice >= Direction1Value)
                    {
                        isDoneMsgL2 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                           , CharType == "안정형" ? "30" : "70", "손실");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                    //수익 1구간
                    if (!isDoneMsgW1 && CPrice <= Direction4Value)
                    {
                        isDoneMsgW1 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                            , CharType == "안정형" ? "70" : "30", "수익");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                    //수익 2구간
                    if (!isDoneMsgW2 && CPrice <= Direction5Value)
                    {
                        isDoneMsgW2 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                           , CharType == "안정형" ? "30" : "70", "수익");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                }
                else if (PositionType == "매수")
                {
                    //손실 1구간
                    if (!isDoneMsgL1 && CPrice <= Direction4Value)
                    {
                        isDoneMsgL1 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                            , CharType == "안정형" ? "70" : "30", "손실");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                    //손실 2구간
                    if (!isDoneMsgL2 && CPrice <= Direction5Value)
                    {
                        isDoneMsgL2 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                           , CharType == "안정형" ? "30" : "70", "손실");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                    //수익 1구간
                    if (!isDoneMsgW1 && CPrice >= Direction4Value)
                    {
                        isDoneMsgW1 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                            , CharType == "안정형" ? "70" : "30", "수익");
                        onThreeFiveTradingRuleMsgHandler(msg);
                    }
                    //수익 2구간
                    if (!isDoneMsgW2 && CPrice >= Direction5Value)
                    {
                        isDoneMsgW2 = true;
                        string msg = string.Format("{0}%의 수량을 {1} 청산해야함."
                           , CharType == "안정형" ? "30" : "70", "수익");
                        onThreeFiveTradingRuleMsgHandler(msg);
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
        public void CalculateDirectionValue()
        {
            try
            {
                if (BalancePrice == 0) return;
                if (RangeValue == 0) return;
                //안정형 : 40 30 30 30 40
                if (CharType == "안정형")
                {
                    double p1Rate = 0.4;
                    double p2Rate = 0.3;
                    double p3Rate = 0.3;
                    double p4Rate = 0.3;
                    double p5Rate = 0.4;
                    if (PositionType == "매도")
                    {
                        Direction1Value = 
                            BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));
                        
                        Direction2Value =
                            BalancePrice + Math.Round(RangeValue * (p3Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));
                        
                        Direction3Value = BalancePrice;
                        
                        Direction4Value = 
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));
                        
                        Direction5Value = 
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate + p5Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                    } 
                    else if (PositionType == "매수")
                    {
                        Direction1Value =
                           BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate + p1Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction2Value =
                            BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction3Value = BalancePrice;

                        Direction4Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction5Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                    }
                }
                //공격형 : 30 30 40 30 30
                else if (CharType == "공격형") 
                {
                    double p1Rate = 0.3;
                    double p2Rate = 0.3;
                    double p3Rate = 0.4;
                    double p4Rate = 0.3;
                    double p5Rate = 0.3;
                    if (PositionType == "매도")
                    {
                        Direction1Value =
                            BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction2Value =
                            BalancePrice + Math.Round(RangeValue * (p3Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction3Value = BalancePrice;

                        Direction4Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction5Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate + p5Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                    }
                    else if (PositionType == "매수")
                    {
                        Direction1Value =
                           BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate + p1Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction2Value =
                            BalancePrice + Math.Round(RangeValue * (p3Rate + p2Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction3Value = BalancePrice;

                        Direction4Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                        Direction5Value =
                            BalancePrice - Math.Round(RangeValue * (p3Rate + p4Rate), ItemCodeUtil.GetItemCodeRoundNum(ItemCode));

                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void onThreeFiveTradingRuleMsgHandler(string msg)
        {
            if (ThreeFiveTradingRuleMsgHandler != null)
                ThreeFiveTradingRuleMsgHandler(msg);
        }
    }
}
