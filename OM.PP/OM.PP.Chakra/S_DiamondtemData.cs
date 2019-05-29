﻿using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class S_DiamondtemData : A_HMML
    {
        List<S_DiamondtemData> sourceItems;
        public S_DiamondtemData() { }
        
        public S_DiamondtemData(
             string itemCode
           , Single hh
           , Single hm
           , Single lm
           , Single ll
           , Single volume
           , DateTime dt)
        {
            base.ItemCode = itemCode;
            base.HHPrice = hh;
            base.HMPrice = hm;
            base.LMPrice = lm;
            base.LLPrice = ll;
            base.Volume = volume;
            base.DTime = dt;
        }
        public S_DiamondtemData(
             string itemCode
           , List<S_DiamondtemData> sourceItems)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvg();
        }
        private void calculateAvg()
        {
            if (this.sourceItems == null) return;

            base.HHPrice = (Single)Math.Round(sourceItems.Average(t => t.HHPrice), RoundLength);
            base.HMPrice = (Single)Math.Round(sourceItems.Average(t => t.HMPrice), RoundLength);
            base.LMPrice = (Single)Math.Round(sourceItems.Average(t => t.LMPrice), RoundLength);
            base.LLPrice = (Single)Math.Round(sourceItems.Average(t => t.LLPrice), RoundLength);

            base.DTime = sourceItems.Max(t => t.DTime);
            base.Volume = sourceItems.Sum(t => t.Volume);
        }

        public S_CandleItemData GetCandleItem()
        {           
            return new S_CandleItemData(
                this.ItemCode
                ,   this.HMPrice
                ,   this.HHPrice
                ,   this.LLPrice
                ,   this.LMPrice
                ,   0
                ,   this.DTime
                );
        }
    }
}
