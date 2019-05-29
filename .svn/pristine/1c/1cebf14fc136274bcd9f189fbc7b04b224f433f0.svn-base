using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public abstract class A_HMML
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

        private Single _HHPrice = 0;
        private Single _HMPrice = 0;
        private Single _LMPrice  = 0;
        private Single _LLPrice = 0;

        public Single HHPrice { get { return (Single)Math.Round(_HHPrice, RoundLength); } set { _HHPrice = value; } }
        public Single HMPrice { get { return (Single)Math.Round(_HMPrice, RoundLength); } set { _HMPrice = value; } }
        public Single LMPrice { get { return (Single)Math.Round(_LMPrice, RoundLength); } set { _LMPrice = value; } }
        public Single LLPrice { get { return (Single)Math.Round(_LLPrice, RoundLength); } set { _LLPrice = value; } }
        
        public Single HQPrice { get { return (Single)Math.Round(LMPrice, RoundLength); }}
        public Single LQPrice { get { return (Single)Math.Round(LMPrice - BodyPriceLength, RoundLength); }}
        public Single MQPrice
        {
            get
            {
                return (Single)Math.Round((HQPrice + LQPrice) / 2.0f, RoundLength);
            }
        }
        public Single HVPrice { get { return (Single)Math.Round(HMPrice + BodyPriceLength, RoundLength); }}
        public Single LVPrice { get { return (Single)Math.Round(HMPrice, RoundLength); }}
        public Single MVPrice
        {
            get
            {
                return (Single)Math.Round((HVPrice + LVPrice) / 2.0f, RoundLength);
            }
        }

        public Single Volume { get; set; } = 0;
         
        public Single CenterPrice
        {
            get
            {
                return (Single)Math.Round((HHPrice + LLPrice) / 2.0f, RoundLength);
            }
        }

        public Single HCenterPrice
        {
            get
            {
                return (Single)Math.Round((HHPrice + CenterPrice) / 2.0f, RoundLength);
            }
        }

        public Single LCenterPrice
        {
            get
            {
                return (Single)Math.Round((CenterPrice + LLPrice) / 2.0f, RoundLength);
            }
        }

        public Single MMPrice
        {
            get
            {
                return (Single)Math.Round((HMPrice + LMPrice) / 2.0f, RoundLength);
            }
        }

        public Single VerticalPrice
        {
            get
            {
                return (Single)Math.Round((HHPrice - LLPrice), RoundLength);
            }
        }
        public Single HorizontalPrice
        {
            get
            {
                return (Single)Math.Round((HMPrice - LMPrice), RoundLength);
            }
        }
        public Single BodyPriceLength
        {
            get
            {
                return (Single)Math.Round((HMPrice - LMPrice), RoundLength);
            }
        }

        public DateTime DTime { get; set; }


        public Single 천고
        {
            get
            {
                return HVPrice;               
            }
        }
        public Single 천중
        {
            get
            {
                return MVPrice;
            }
        }
        public Single 천저인고
        {
            get
            {
                return HMPrice;
            }
        }
        public Single 인중
        {
            get
            {
                return MMPrice;
            }
        }
        public Single 인저지고
        {
            get
            {
                return LMPrice;
            }
        }
        public Single 지중
        {
            get
            {
                return MQPrice;
            }
        }
        public Single 지저
        {
            get
            {
                return LQPrice;
            }
        }
    }
}
