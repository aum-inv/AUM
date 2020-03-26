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
    public class OrderMITRule : BaseTradeRule
    {
        #region 속성

        public string RuleID { get; set; } = "";
        public string TradeType { get; set; } = "1";
       
        public bool IsUseMITBuy { get; set; } = false;
        public bool IsUseMITSell { get; set; } = false;

        public double BuyPrice1 { get; set; } = 0;
        public double BuyPrice2 { get; set; } = 0;
        public double SellPrice1 { get; set; } = 0;
        public double SellPrice2 { get; set; } = 0;

        public bool IsUseCurPrice { get; set; } = false;
        public double CurPrice { get; set; } = 0;

        #endregion

        public override string AtmanName => "ORDER_MIT";

        public OrderMITRule()
        {
        }
        public override void InitRule()
        {
            IsBuyed = false;
        }
        public override void Close()
        {
            IsUseMITBuy = IsUseMITSell = false;
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

                if (BPrice == CPrice) return;
                if (HPrice < CPrice) HPrice = Math.Round(CPrice, RoundNum);
                if (LPrice > CPrice) LPrice = Math.Round(CPrice, RoundNum);

                if (IsBuyed) return;

                if (IsUseMITBuy)
                {
                    if (BuyPrice2 > 0 && CPrice == BuyPrice2)
                    {
                        IsBuyed = true;
                        Position = "2";
                        SellBuy("진입", Position);
                    }
                    else if (BuyPrice1 > 0 && CPrice == BuyPrice1)
                    {
                        IsBuyed = true;
                        Position = "1";
                        SellBuy("진입", Position);
                    }
                }

                if (IsUseMITSell)
                {
                    if (SellPrice1 > 0 && CPrice == SellPrice1)
                    {
                        IsBuyed = true;
                        Position = "1";
                        SellBuy("청산", Position);
                    }
                    else if (SellPrice2 > 0 && CPrice == SellPrice2)
                    {
                        IsBuyed = true;
                        Position = "2";
                        SellBuy("청산", Position);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
