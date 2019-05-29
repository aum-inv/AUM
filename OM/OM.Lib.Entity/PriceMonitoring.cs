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
    public class PriceMonitoring : DomainBase
    {
        public PriceMonitoring(string entityeName = "PRICE_MONITORING", string domainName = "AUM")
           : base(entityeName, domainName) { }
        public string Item { get; set; }
        public int Interval { get; set; }

        private string _UpDown = "";
        private double _UBuyPrice = 0;
        private double _DBuyPrice = 0;
        private double _URevenuePrice = 0;
        private double _DRevenuePrice = 0;
        private double _ULossPrice = 0;
        private double _DLossPrice = 0;
        private int _RoundLength  
        {
            get
            {
                return ItemCodeUtil.GetItemCodeRoundNum(Item);
            }
        }
        public string UpDown { get { return _UpDown; } set { _UpDown = value; } }
        public double UBuyPrice { get { return Math.Round(_UBuyPrice, _RoundLength); } set { _UBuyPrice = value; } }
        public double DBuyPrice { get { return Math.Round(_DBuyPrice, _RoundLength); } set { _DBuyPrice = value; } }
        public double URevenuePrice { get { return Math.Round(_URevenuePrice, _RoundLength); } set { _URevenuePrice = value; } }
        public double DRevenuePrice { get { return Math.Round(_DRevenuePrice, _RoundLength); } set { _DRevenuePrice = value; } }
        public double ULossPrice { get { return Math.Round(_ULossPrice, _RoundLength); } set { _ULossPrice = value; } }        
        public double DLossPrice { get { return Math.Round(_DLossPrice, _RoundLength); } set { _DLossPrice = value; } }
        public DateTime UDate { get; set; }

        #region Override Method
        public override IEntity Clone()
        {
            return new PriceMonitoring();
        }
        #endregion
    }
}
