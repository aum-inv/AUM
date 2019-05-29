using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public abstract class A_CLOSE
    {
        public string ItemCode
        {
            get;
            set;
        } = "";

        public int RoundLength
        {
            get
            {
                return ItemCodeUtil.GetItemCodeRoundNum(ItemCode);
            }
        }
        private Single _ClosePrice1 = 0;
        private Single _ClosePrice2 = 0;
        private Single _ClosePrice3 = 0;
        private Single _ClosePrice4 = 0;

        public Single ClosePrice1 { get { return (Single)Math.Round(_ClosePrice1, RoundLength); } set { _ClosePrice1 = value; } }
        public Single ClosePrice2 { get { return (Single)Math.Round(_ClosePrice2, RoundLength); ; } set { _ClosePrice2 = value; } }
        public Single ClosePrice3 { get { return (Single)Math.Round(_ClosePrice3, RoundLength); ; } set { _ClosePrice3 = value; } }
        public Single ClosePrice4 { get { return (Single)Math.Round(_ClosePrice4, RoundLength); ; } set { _ClosePrice4 = value; } }

        public Single Volume { get; set; } = 0;

        public DateTime DTime { get; set; }
    }
}
