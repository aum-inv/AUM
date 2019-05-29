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
    public class MantraHistory : DomainBase
    {
        public MantraHistory(string entityeName = "MANTRA_HISTORY", string domainName = "AUM")
           : base(entityeName, domainName) { }

        public int No { get; set; } = 0;
        public string Item { get; set; } = "";
        public string Position { get; set; } = "";
        public string BuySell { get; set; } = "";
        public string ContractPrice { get; set; } = ""; 
        public string ContractTime { get; set; } = "";

        public int Quantity { get; set; } = 0;
     
        public string BuyReason { get; set; } = "";
        public string SellReason { get; set; } = "";
        public string IncomingType { get; set; } = "";
        public string Incoming { get; set; } = "";        
      
        #region Override Method
        public override IEntity Clone()
        {
            return new MantraHistory();
        }
        #endregion
    }
}
