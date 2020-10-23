using OM.Lib.Base;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra
{   
    public abstract class UpayaBaseTradeRule
    {
        protected LimitedList<double> PriceList = null;
        
        public UpayaBaseTradeRule(int limit = 6006)
        {
            PriceList = new LimitedList<double>(limit);
        }
        
        public int RoundNum
        {
            get
            {
                return ItemCodeUtil.GetItemCodeRoundNum(Item);
            }
        }
        public string Item { get; set; } = "";
        public string ItemCode { get; set; } = "";
        public double CPrice { get; set; } = 0;
        public bool IsUse { get; set; } = false;
        
        public abstract void AnalysisAsync(CurrentPrice price);
        public abstract void Analysis(CurrentPrice price);
        
        public virtual void SellBuy(string position, string qty, string tradeType)
        {
            try
            {
                ExApi.XingApi.UpayaOrder(Item, position, qty, tradeType, CPrice.ToString());           
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
           
        }       
    }
}
