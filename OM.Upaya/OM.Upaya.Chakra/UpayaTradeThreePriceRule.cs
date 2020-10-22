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
    public class UpayaTradeThreePriceRule : UpayaBaseTradeRule
    {
        #region 속성      
        public string TradeType { get; set; } = "1";
       
        #region P2 Properties
        public double P2BuyPrice1 { get; set; } = 0;
        public double P2BuyPrice2 { get; set; } = 0;
        public double P2BuyPrice3 { get; set; } = 0;
        public int P2BuyQty1 { get; set; } = 0;
        public int P2BuyQty2 { get; set; } = 0;
        public int P2BuyQty3 { get; set; } = 0;
        public bool IsUseP2Buy1 { get; set; } = false;
        public bool IsUseP2Buy2 { get; set; } = false;
        public bool IsUseP2Buy3 { get; set; } = false;      
        public bool IsBuyP2Done1 { get; set; } = false;
        public bool IsBuyP2Done2 { get; set; } = false;
        public bool IsBuyP2Done3 { get; set; } = false;
        public double P2RevenuePrice1 { get; set; } = 0;
        public double P2RevenuePrice2 { get; set; } = 0;
        public double P2RevenuePrice3 { get; set; } = 0;
        public int P2RevenueQty1 { get; set; } = 0;
        public int P2RevenueQty2 { get; set; } = 0;
        public int P2RevenueQty3 { get; set; } = 0;
        public bool IsUseP2Revenue1 { get; set; } = false;
        public bool IsUseP2Revenue2 { get; set; } = false;
        public bool IsUseP2Revenue3 { get; set; } = false;
        public bool IsRevenueP2Done1 { get; set; } = false;
        public bool IsRevenueP2Done2 { get; set; } = false;
        public bool IsRevenueP2Done3 { get; set; } = false;
        public double P2LosscutPrice1 { get; set; } = 0;
        public double P2LosscutPrice2 { get; set; } = 0;
        public double P2LosscutPrice3 { get; set; } = 0;
        public int P2LosscutQty1 { get; set; } = 0;
        public int P2LosscutQty2 { get; set; } = 0;
        public int P2LosscutQty3 { get; set; } = 0;
        public bool IsUseP2Losscut1 { get; set; } = false;
        public bool IsUseP2Losscut2 { get; set; } = false;
        public bool IsUseP2Losscut3 { get; set; } = false;
        public bool IsLosscutP2Done1 { get; set; } = false;
        public bool IsLosscutP2Done2 { get; set; } = false;
        public bool IsLosscutP2Done3 { get; set; } = false;
        #endregion

        #region P1 Properties
        public double P1BuyPrice1 { get; set; } = 0;
        public double P1BuyPrice2 { get; set; } = 0;
        public double P1BuyPrice3 { get; set; } = 0;
        public int P1BuyQty1 { get; set; } = 0;
        public int P1BuyQty2 { get; set; } = 0;
        public int P1BuyQty3 { get; set; } = 0;
        public bool IsUseP1Buy1 { get; set; } = false;
        public bool IsUseP1Buy2 { get; set; } = false;
        public bool IsUseP1Buy3 { get; set; } = false;
        public bool IsBuyP1Done1 { get; set; } = false;
        public bool IsBuyP1Done2 { get; set; } = false;
        public bool IsBuyP1Done3 { get; set; } = false;
        public double P1RevenuePrice1 { get; set; } = 0;
        public double P1RevenuePrice2 { get; set; } = 0;
        public double P1RevenuePrice3 { get; set; } = 0;
        public int P1RevenueQty1 { get; set; } = 0;
        public int P1RevenueQty2 { get; set; } = 0;
        public int P1RevenueQty3 { get; set; } = 0;
        public bool IsUseP1Revenue1 { get; set; } = false;
        public bool IsUseP1Revenue2 { get; set; } = false;
        public bool IsUseP1Revenue3 { get; set; } = false;
        public bool IsRevenueP1Done1 { get; set; } = false;
        public bool IsRevenueP1Done2 { get; set; } = false;
        public bool IsRevenueP1Done3 { get; set; } = false;
        public double P1LosscutPrice1 { get; set; } = 0;
        public double P1LosscutPrice2 { get; set; } = 0;
        public double P1LosscutPrice3 { get; set; } = 0;
        public int P1LosscutQty1 { get; set; } = 0;
        public int P1LosscutQty2 { get; set; } = 0;
        public int P1LosscutQty3 { get; set; } = 0;
        public bool IsUseP1Losscut1 { get; set; } = false;
        public bool IsUseP1Losscut2 { get; set; } = false;
        public bool IsUseP1Losscut3 { get; set; } = false;
        public bool IsLosscutP1Done1 { get; set; } = false;
        public bool IsLosscutP1Done2 { get; set; } = false;
        public bool IsLosscutP1Done3 { get; set; } = false;
        #endregion

        #endregion

        public UpayaTradeThreePriceRule()
        {            
        }
      
        public override void AnalysisAsync(CurrentPrice price)
        {
            if (!IsUse) return;

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
                if (!IsUse) return;

                #region P2 Buy
                //P2 Buy 1
                if (IsUseP2Buy1 && ! IsBuyP2Done1 && P2BuyPrice1 > 0 && P2BuyQty1 > 0)
                {
                    if (CPrice == P2BuyPrice1)
                    {
                        SellBuy("2", P2BuyQty1.ToString(), TradeType);

                        IsBuyP2Done1 = true;
                    }
                }

                //P2 Buy 2
                if (IsUseP2Buy2 && !IsBuyP2Done2 && P2BuyPrice2 > 0 && P2BuyQty2 > 0)
                {
                    if (CPrice == P2BuyPrice2)
                    {
                        SellBuy("2", P2BuyQty2.ToString(), TradeType);

                        IsBuyP2Done2 = true;
                    }
                }

                //P2 Buy 3
                if (IsUseP2Buy3 && !IsBuyP2Done3 && P2BuyPrice3 > 0 && P2BuyQty3 > 0)
                {
                    if (CPrice == P2BuyPrice3)
                    {
                        SellBuy("2", P2BuyQty3.ToString(), TradeType);

                        IsBuyP2Done3 = true;
                    }
                }
                #endregion

                #region P2 Revenue
                //P2 Revenue 1
                if (IsUseP2Revenue1 && !IsRevenueP2Done1 && P2RevenuePrice1 > 0 && P2RevenueQty1 > 0)
                {
                    if (CPrice == P2RevenuePrice1)
                    {
                        SellBuy("1", P2RevenueQty1.ToString(), TradeType);
                        IsRevenueP2Done1 = true;
                    }
                }

                //P2 Revenue 2
                if (IsUseP2Revenue2 && !IsRevenueP2Done2 && P2RevenuePrice2 > 0 && P2RevenueQty2 > 0)
                {
                    if (CPrice == P2RevenuePrice2)
                    {
                        SellBuy("1", P2RevenueQty2.ToString(), TradeType);
                        IsRevenueP2Done2 = true;
                    }
                }

                //P2 Revenue 3
                if (IsUseP2Revenue3 && !IsRevenueP2Done3 && P2RevenuePrice3 > 0 && P2RevenueQty3 > 0)
                {
                    if (CPrice == P2RevenuePrice3)
                    {
                        SellBuy("1", P2RevenueQty3.ToString(), TradeType);
                        IsRevenueP2Done3 = true;
                    }
                }
                #endregion

                #region P2 Losscut
                //P2 Losscut 1
                if (IsUseP2Losscut1 && !IsLosscutP2Done1 && P2LosscutPrice1 > 0 && P2LosscutQty1 > 0)
                {
                    if (CPrice == P2LosscutPrice1)
                    {
                        SellBuy("1", P2LosscutQty1.ToString(), TradeType);
                        IsLosscutP2Done1 = true;
                    }
                }

                //P2 Losscut 2
                if (IsUseP2Losscut2 && !IsLosscutP2Done2 && P2LosscutPrice2 > 0 && P2LosscutQty2 > 0)
                {
                    if (CPrice == P2LosscutPrice2)
                    {
                        SellBuy("1", P2LosscutQty2.ToString(), TradeType);
                        IsLosscutP2Done2 = true;
                    }
                }

                //P2 Losscut 3
                if (IsUseP2Losscut3 && !IsLosscutP2Done3 && P2LosscutPrice3 > 0 && P2LosscutQty3 > 0)
                {
                    if (CPrice == P2LosscutPrice3)
                    {
                        SellBuy("1", P2LosscutQty3.ToString(), TradeType);
                        IsLosscutP2Done3 = true;
                    }
                }
                #endregion
            }
            catch (Exception)
            {
            }            
        }
    }
}
