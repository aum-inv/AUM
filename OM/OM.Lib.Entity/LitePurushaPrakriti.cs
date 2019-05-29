using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Entity
{
    [Serializable]
    public class LitePurushaPrakriti
    {
        public LitePurushaPrakriti() { }

        public LitePurushaPrakriti(
            Single open
          , Single high
          , Single low
          , Single close
          , Single volume
          , DateTime dt)
        {
            this.OpenVal = open;
            this.HighVal = high;
            this.LowVal = low;
            this.CloseVal = close;
            this.Volume = volume;
            this.DT = dt;
        }

        public string Item { get; set; }

        public int Interval { get; set; }

        public DateTime DT { get; set; }

        public Single OpenVal { get; set; }

        public Single HighVal { get; set; }

        public Single LowVal { get; set; }

        public Single CloseVal { get; set; }

        public Single Volume { get; set; }
    }
}
