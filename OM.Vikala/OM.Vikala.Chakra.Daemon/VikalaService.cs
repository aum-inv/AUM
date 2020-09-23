using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;

namespace OM.Vikala.Chakra.Daemon
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall
        , ConcurrencyMode = ConcurrencyMode.Multiple
        , UseSynchronizationContext = false)]
    public class VikalaService : IVikalaService
    {
        static object sync = new object();

        public string ServiceName => VikalaServerConfigData.ServiceName;

        public void Noop() { }
       
        public void SetCurrentPrice(string itemCode, CurrentPrice price)
        {
            try
            {
                if (!SiseStorage.Instance.Prices.ContainsKey(itemCode))
                    SiseStorage.Instance.Prices.Add(itemCode, new System.Collections.Concurrent.ConcurrentQueue<CurrentPrice>());

                var prices = SiseStorage.Instance.Prices[itemCode];

                prices.Enqueue(price);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        public void SetCurrentPriceKr(string itemCode, CurrentPrice price)
        {
            try
            {
                if (!SiseStorage.Instance.PricesKr.ContainsKey(itemCode))
                    SiseStorage.Instance.PricesKr.Add(itemCode, new System.Collections.Concurrent.ConcurrentQueue<CurrentPrice>());

                var prices = SiseStorage.Instance.PricesKr[itemCode];

                prices.Enqueue(price);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
    }
}
