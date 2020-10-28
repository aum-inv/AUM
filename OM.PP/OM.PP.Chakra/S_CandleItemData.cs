using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class S_CandleItemData : A_HLOC
    {
        List<S_CandleItemData> sourceItems;

        public S_CandleItemData PreCandleItem = null;
        public S_CandleItemData NextCandleItem = null;
        public S_CandleItemData() { }
        
        public S_CandleItemData(
             string itemCode
           , Single open
           , Single high
           , Single low
           , Single close
           , Single volume
           , DateTime dt
           , bool virtualData = false)
        {
            base.ItemCode = itemCode;
            base.OpenPrice = open;
            base.HighPrice = high;
            base.LowPrice = low;
            base.ClosePrice = close;
            base.Volume = volume;
            base.DTime = dt;
            this.VirtualData = virtualData;
        }

        public S_CandleItemData(
             string itemCode
           , List<S_CandleItemData> sourceItems)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx();
        }
        public S_CandleItemData(
             string itemCode
           , List<S_CandleItemData> sourceItems
           , DateTime dtime)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx();
            base.DTime = dtime;
        }
        public S_CandleItemData(
            string itemCode
          , List<S_CandleItemData> sourceItems
          , bool isAccum)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvgEx(isAccum);           
        }
        public S_CandleItemData(
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

        public bool VirtualData
        {
            get; set;
        } = false;
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

        #region CandleType_Space
        public CandleSpaceTypeEnum SpaceType_P
        {
            get 
            {
                return getSpaceType(PreCandleItem);
            }
        }
        public CandleSpaceTypeEnum SpaceType_C
        {
            get
            {
                return getSpaceType(this);
            }
        }
        public CandleSpaceTypeEnum SpaceType_N
        {
            get
            {
                return getSpaceType(NextCandleItem);
            }
        }
        private CandleSpaceTypeEnum getSpaceType(S_CandleItemData item)
        {
            double totalLength = TotalLength;
            double headLength = HeadLength;
            double legLength = LegLength;
            double bodyLength = BodyLength;

            int headLengthRate = (int)Math.Round((headLength / totalLength * 100.0), 0);
            int bodyLengthRate = (int)Math.Round((bodyLength / totalLength * 100.0), 0);
            int legLengthRate = (int)Math.Round((legLength / totalLength * 100.0), 0);

            CandleSpaceTypeEnum type = CandleSpaceTypeEnum.None;
            if (bodyLengthRate >= 98)
                type = CandleSpaceTypeEnum.Marubozu;
            else if (bodyLengthRate >= 70 && headLengthRate >= 10 && legLengthRate >= 10)
                type = CandleSpaceTypeEnum.LongBody;
            else if (bodyLengthRate >= 30 && headLengthRate >= 30 && legLengthRate >= 30)
                type = CandleSpaceTypeEnum.ShortBody;
            else if (bodyLengthRate >= 10 && headLengthRate >= 40 && legLengthRate >= 40)
                type = CandleSpaceTypeEnum.Spinning;
            else if (bodyLengthRate >= 20 && ((headLengthRate >= 60 && legLengthRate < 5) || (headLengthRate < 5 && legLengthRate >= 60)))
                type = CandleSpaceTypeEnum.Hammer;
            else if (bodyLengthRate < 20 && ((headLengthRate >= 80 && legLengthRate < 5) || (headLengthRate < 5 && legLengthRate >= 80)))
                type = CandleSpaceTypeEnum.SmallHammer;
            else if (bodyLengthRate < 5 && headLengthRate >= 45 && legLengthRate >= 45)
                type = CandleSpaceTypeEnum.Dogi;
            else
                type = CandleSpaceTypeEnum.Unknown;

            return type;
        }
        #endregion

        #region CandleType_Time
        public virtual PlusMinusTypeEnum PlusMinusType_P
        {
            get
            {
                if (PreCandleItem.OpenPrice < PreCandleItem.ClosePrice) return PlusMinusTypeEnum.양;
                else if (PreCandleItem.OpenPrice > PreCandleItem.ClosePrice) return PlusMinusTypeEnum.음;
                else return PlusMinusTypeEnum.무;
            }
        }
        
        public virtual PlusMinusTypeEnum PlusMinusType_N
        {
            get
            {
                if (NextCandleItem.OpenPrice < NextCandleItem.ClosePrice) return PlusMinusTypeEnum.양;
                else if (NextCandleItem.OpenPrice > NextCandleItem.ClosePrice) return PlusMinusTypeEnum.음;
                else return PlusMinusTypeEnum.무;
            }
        }

        public CandleTimeTypeEnum TimeType_P
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.ClosePrice < this.ClosePrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.ClosePrice > this.ClosePrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_PN
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.ClosePrice < NextCandleItem.ClosePrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.ClosePrice > NextCandleItem.ClosePrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_N
        {
            get
            {
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (NextCandleItem.ClosePrice < this.ClosePrice) return CandleTimeTypeEnum.음;
                    else if (NextCandleItem.ClosePrice > this.ClosePrice) return CandleTimeTypeEnum.양;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        #endregion
    }
}
