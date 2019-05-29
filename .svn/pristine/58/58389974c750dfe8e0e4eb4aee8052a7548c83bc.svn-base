using OM.Lib.Base.Utils;
using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Entity
{
    [Serializable]
    public class AtmanRule : DomainBase
    {
        public AtmanRule(string entityeName = "ATMAN_RULE", string domainName = "AUM")
           : base(entityeName, domainName) { }

        public string RuleID { get; set; } = "";
        public string Item { get; set; } = "";
        public string TimeType { get; set; } = "";
        public string PriceType { get; set; } = "0";
        public string ForcastOfStrength { get; set; } = ""; 

        public string Position { get; set; } = "매도";
        public string BasePrice { get; set; } = "0";
        public bool IsTouchedBasePrice { get; set; } = false;
        public DateTime BasePriceTouchTime { get; set; } = DateTime.Now;

        public string BuyPrice { get; set; } = "0";
        public string BuyTick { get; set; } = "0";
        public string BuyRate { get; set; } = "0";
        public bool IsBuyDone { get; set; } = false;        
        public int BuyLimitTime { get; set; } = 0;
        public DateTime BuyedTime { get; set; } = DateTime.Now;


        public string LossPrice { get; set; } = "0";
        public string LossTick { get; set; } = "0";
        public string LossRate { get; set; } = "0";

        public bool IsCanRevenue { get; set; } = false;
        public string RevenuePrice { get; set; } = "0";
        public string RevenueTick { get; set; } = "0";
        public string RevenueRate { get; set; } = "0";
        public int RevenueLimitTime { get; set; } = 0;
        public string IsUse { get; set; } = "N";

        #region Override Method
        public override IEntity Clone()
        {
            return new AtmanRule();
        }
        #endregion
    }
}
