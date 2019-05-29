using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Entity
{
    public class CurrentPriceStorage
    {
        public static Dictionary<string, CurrentPrice> PriceList = new Dictionary<string, CurrentPrice>();

        public static void SetPrice(string itemCode, CurrentPrice price)
        {
            try
            {
                if (PriceList.ContainsKey(itemCode))
                {
                    PriceList[itemCode] = price;
                }
                else
                {
                    PriceList.Add(itemCode, price);
                }
            }
            catch (Exception ex) { }
        }
    }
}
