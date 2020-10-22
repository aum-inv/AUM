using OM.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra
{
    public delegate void UpayaTradeRuleDelegate(string message);

    public class UpayaTradeEvents
    {
        private static UpayaTradeEvents instance = new UpayaTradeEvents();

        public static UpayaTradeEvents Instance
        {
            get
            {
                return instance;
            }
        }

        public event UpayaTradeRuleDelegate TradeRuleHandler;
     
        public void OnTradeRuleHandler(string message)
        {
            if (TradeRuleHandler != null)
                TradeRuleHandler(message);
        }
    }
}
