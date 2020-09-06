using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class S_CandleItemData_ : A_HLOC
    {
        List<S_CandleItemData> sourceItems;
        public S_CandleItemData_() { }
        
        public S_CandleItemData_(
             string itemCode
           , Single open
           , Single high
           , Single low
           , Single close
           , Single volume
           , DateTime dt)
        {
            base.ItemCode = itemCode;
            base.OpenPrice = open;
            base.HighPrice = high;
            base.LowPrice = low;
            base.ClosePrice = close;
            base.Volume = volume;
            base.DTime = dt;
        }
        public S_CandleItemData_(
             string itemCode
           , List<S_CandleItemData> sourceItems)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx();
        }
        public S_CandleItemData_(
             string itemCode
           , List<S_CandleItemData> sourceItems
           , DateTime dtime)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx();
            base.DTime = dtime;
        }
        public S_CandleItemData_(
            string itemCode
          , List<S_CandleItemData> sourceItems
          , bool isAccum)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx(isAccum);           
        }
        public S_CandleItemData_(
           string itemCode
         , List<S_CandleItemData> sourceItems
         , bool isAccum
         , DateTime dtime)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx(isAccum);
            base.DTime = dtime;
        }


        public Single OpenPriceAvg
        {
            get; set;
        } = 0;
        public Single HighPriceAvg
        {
            get; set;
        } = 0;
        public Single LowPriceAvg
        {
            get; set;
        } = 0;
        public Single ClosePriceAvg
        {
            get; set;
        } = 0;
        public Single CenterPriceAvg
        {
            get; set;
        } = 0;
        public Single HCenterPriceAvg
        {
            get; set;
        } = 0;
        public Single LCenterPriceAvg
        {
            get; set;
        } = 0;
        public Single MiddlePriceAvg
        {
            get; set;
        } = 0;
        public Single HeadLengthAvg
        {
            get; set;
        } = 0;
        public Single LegLengthAvg
        {
            get; set;
        } = 0;
        public Single QuantumPriceAvg
        {
            get; set;
        } = 0;
        public Single QuantumLowPriceAvg
        {
            get; set;
        } = 0;
        public Single QuantumHighPriceAvg
        {
            get; set;
        } = 0;
        public Single QuantumCenterPriceAvg
        {
            get; set;
        } = 0;
        public Single QuantumMiddlePriceAvg
        {
            get; set;
        } = 0;
        public Single VikalaPriceAvg
        {
            get; set;
        } = 0;
        public Single VikalaLowPriceAvg
        {
            get; set;
        } = 0;
        public Single VikalaHighPriceAvg
        {
            get; set;
        } = 0;
        public Single VikalaCenterPriceAvg
        {
            get; set;
        } = 0;
        public Single VikalaMiddlePriceAvg
        {
            get; set;
        } = 0;
        public Single TotalCenterPriceAvg
        {
            get; set;
        } = 0;
        public Single MassPriceAvg
        {
            get; set;
        } = 0;
        public Single HMassPriceAvg
        {
            get; set;
        } = 0;
        public Single QMassPriceAvg
        {
            get; set;
        } = 0;
        public Single VMassPriceAvg
        {
            get; set;
        } = 0;

        public Int32 Index
        {
            get;
            set;
        } = 0;
        private void calculateAvg()
        {
            if (this.sourceItems == null) return;

            base.OpenPrice = (Single)Math.Round(sourceItems.Average(t => t.OpenPrice), RoundLength);
            base.ClosePrice = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice), RoundLength);
            base.HighPrice = (Single)Math.Round(sourceItems.Average(t => t.HighPrice), RoundLength);
            base.LowPrice = (Single)Math.Round(sourceItems.Average(t => t.LowPrice), RoundLength);
        }
        private void calculateAvgEx(bool isAccumulate = false)
        {
            if (this.sourceItems == null) return;
            if (isAccumulate)
            {
                
                var list1 = sourceItems.GetRange(Convert.ToInt32(sourceItems.Count * 0.7), Convert.ToInt32(sourceItems.Count * 0.3));
                var list2 = sourceItems.GetRange(Convert.ToInt32(sourceItems.Count * 0.3), Convert.ToInt32(sourceItems.Count * 0.7));
                var list3 = sourceItems.GetRange(0, Convert.ToInt32(sourceItems.Count * 1.0));

                var list = new List<S_CandleItemData>();

                list.AddRange(list1);
                list.AddRange(list2);
                list.AddRange(list3);

                base.OpenPrice = (Single)Math.Round(list.Average(t => t.OpenPrice), RoundLength);
                base.ClosePrice = (Single)Math.Round(list.Average(t => t.ClosePrice), RoundLength);
                base.HighPrice = (Single)Math.Round(list.Average(t => t.HighPrice), RoundLength);
                base.LowPrice = (Single)Math.Round(list.Average(t => t.LowPrice), RoundLength);
            }
            else
            {
                base.OpenPrice = (Single)Math.Round(sourceItems.Average(t => t.OpenPrice), RoundLength);
                base.ClosePrice = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice), RoundLength);
                base.HighPrice = (Single)Math.Round(sourceItems.Average(t => t.HighPrice), RoundLength);
                base.LowPrice = (Single)Math.Round(sourceItems.Average(t => t.LowPrice), RoundLength);
            }

            OpenPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.OpenPrice), RoundLength);
            HighPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.HighPrice), RoundLength);
            LowPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.LowPrice), RoundLength);
            ClosePriceAvg = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice), RoundLength);
            CenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.CenterPrice), RoundLength);
            HCenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.HCenterPrice), RoundLength);
            LCenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.LCenterPrice), RoundLength);
            MiddlePriceAvg = (Single)Math.Round(sourceItems.Average(t => t.MiddlePrice), RoundLength);
            HeadLengthAvg = (Single)Math.Round(sourceItems.Average(t => t.HeadLength), RoundLength);
            LegLengthAvg = (Single)Math.Round(sourceItems.Average(t => t.LegLength), RoundLength);
            QuantumPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QuantumBasePrice), RoundLength);
            QuantumLowPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QuantumBaseLowPrice), RoundLength);
            QuantumHighPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QuantumBaseHighPrice), RoundLength);
            QuantumCenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QuantumCenterPrice), RoundLength);
            QuantumMiddlePriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QuantumMiddlePrice), RoundLength);
            VikalaPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VikalaPrice), RoundLength);
            VikalaLowPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VikalaLowPrice), RoundLength);
            VikalaHighPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VikalaHighPrice), RoundLength);
            VikalaCenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VikalaCenterPrice), RoundLength);
            VikalaMiddlePriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VikalaMiddlePrice), RoundLength);
            TotalCenterPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.TotalCenterPrice), RoundLength);
        
            MassPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.MassPrice), RoundLength);
            HMassPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.HMassPrice), RoundLength);
            QMassPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.QMassPrice), RoundLength);
            VMassPriceAvg = (Single)Math.Round(sourceItems.Average(t => t.VMassPrice), RoundLength);

            base.DTime = sourceItems.Max(t => t.DTime);
            base.Volume = sourceItems.Sum(t => t.Volume);
        }

        public virtual WuXingTypeEnum WuXingType
        {
            get
            {
                WuXingTypeEnum type = WuXingTypeEnum.없음;

                if (QuantumHighPrice > HighPrice
                    && HighPrice > ClosePrice
                    && ClosePrice > OpenPrice
                    && OpenPrice > QuantumPrice
                    && QuantumPrice > QuantumLowPrice
                    && QuantumLowPrice > LowPrice)
                    type = WuXingTypeEnum.소양;

                if (HighPrice > ClosePrice
                    && ClosePrice > QuantumHighPrice
                    && QuantumHighPrice > OpenPrice
                    && OpenPrice > LowPrice
                    && LowPrice > QuantumPrice
                    && QuantumPrice > QuantumLowPrice)
                    type = WuXingTypeEnum.태양;

                if (QuantumHighPrice > QuantumPrice
                    && QuantumPrice > HighPrice
                    && HighPrice > OpenPrice
                    && OpenPrice > QuantumLowPrice
                    && QuantumLowPrice > ClosePrice
                    && ClosePrice > LowPrice)
                    type = WuXingTypeEnum.태음;

                if (HighPrice > QuantumHighPrice
                    && QuantumHighPrice > QuantumPrice
                    && QuantumPrice > OpenPrice
                    && OpenPrice > ClosePrice
                    && ClosePrice > LowPrice
                    && LowPrice > QuantumLowPrice)
                    type = WuXingTypeEnum.소음;

                return type;
            }
        }

        public virtual EightRuleTypeEnum EightRuleType
        {
            get
            {
                double totalLength = HighPrice - LowPrice;
                double bodyLength = Math.Round(Math.Abs(ClosePrice - OpenPrice), RoundLength);
                double headLength = Math.Round(PlusMinusType == PlusMinusTypeEnum.양 ? 
                    (HighPrice - ClosePrice) : (HighPrice - OpenPrice), RoundLength);
                double legLength = Math.Round(PlusMinusType == PlusMinusTypeEnum.양 ? 
                    (OpenPrice - LowPrice) : (ClosePrice - LowPrice), RoundLength);

                int headLengthRate = (int)(headLength / totalLength * 100.0);
                int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                int legLengthRate = (int)(legLength / totalLength * 100.0);

                string type = "";

                if (headLengthRate > 30) type += "1";
                else type += "0";
                if (bodyLengthRate > 30) type += "1";
                else type += "0";
                if (legLengthRate > 30) type += "1";
                else type += "0";
                              
                if (type == "000" && PlusMinusType == PlusMinusTypeEnum.양)
                    type = "111";
                if (type == "111" && PlusMinusType == PlusMinusTypeEnum.음)
                    type = "000";

                EightRuleTypeEnum eightRuleType = EightRuleTypeEnum.무_0_없음;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    switch (type)
                    {
                        case "111":
                            eightRuleType = EightRuleTypeEnum.건_1_111_양_태양;
                            break;
                        case "110":
                            eightRuleType = EightRuleTypeEnum.손_5_110_양_소양;
                            break;
                        case "101":
                            eightRuleType = EightRuleTypeEnum.리_3_101_양_소음;
                            break;
                        case "100":
                            eightRuleType = EightRuleTypeEnum.간_7_100_양_태음;
                            break;                       
                    }
                }
                if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    switch (type)
                    {
                        case "000":
                            eightRuleType = EightRuleTypeEnum.곤_8_000_음_태음;
                            break;
                        case "001":
                            eightRuleType = EightRuleTypeEnum.진_4_001_음_소음;
                            break;
                        case "010":
                            eightRuleType = EightRuleTypeEnum.감_6_010_음_소양;
                            break;
                        case "011":
                            eightRuleType = EightRuleTypeEnum.태_2_011_음_태양;
                            break;
                    }
                }
               
                return eightRuleType;
            }
        }
    }
}
