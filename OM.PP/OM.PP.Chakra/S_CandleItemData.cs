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

        public int VirtualDepth
        {
            get; set;
        } = 0;

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

        public Double RangeHighPrice
        {
            get; set;
        } = Double.NaN;
        public Double RangeLowPrice
        {
            get; set;
        } = Double.NaN;

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
            double totalLength = item.TotalLength;
            double headLength = item.HeadLength;
            double legLength = item.LegLength;
            double bodyLength = item.BodyLength;

            int headLengthRate = (int)Math.Round((headLength / totalLength * 100.0), 0);
            int bodyLengthRate = (int)Math.Round((bodyLength / totalLength * 100.0), 0);
            int legLengthRate = (int)Math.Round((legLength / totalLength * 100.0), 0);

            CandleSpaceTypeEnum type = CandleSpaceTypeEnum.Unknown;
            if (bodyLengthRate >= 80)
                type = CandleSpaceTypeEnum.Marubozu;

            else if (bodyLengthRate >= 60)
                type = CandleSpaceTypeEnum.LongBody;

            else if ((bodyLengthRate >= 10 && bodyLengthRate < 25) && headLengthRate >= 35 && legLengthRate >= 35)
                type = CandleSpaceTypeEnum.Spinning;

            else if ((bodyLengthRate <= 50 && bodyLengthRate >= 20) && (headLengthRate >= 45 || legLengthRate >= 45))
                type = CandleSpaceTypeEnum.Hammer;

            else if (bodyLengthRate < 20 && (headLengthRate >= 75 || legLengthRate >= 75))
                type = CandleSpaceTypeEnum.SmallHammer;

            if (type == CandleSpaceTypeEnum.Unknown)
            {
                if (bodyLengthRate < 10)
                    type = CandleSpaceTypeEnum.Dogi;

                else if (bodyLengthRate >= 25 && bodyLengthRate < 60 && headLengthRate >= 3 && legLengthRate >= 3)
                    type = CandleSpaceTypeEnum.ShortBody;
            }

            return type;
        }

        public string GetSpaceType(S_CandleItemData item)
        {
            double totalLength = item.TotalLength;
            double headLength = item.HeadLength;
            double legLength = item.LegLength;
            double bodyLength = item.BodyLength;

            int headLengthRate = (int)Math.Round((headLength / totalLength * 100.0), 0);
            int bodyLengthRate = (int)Math.Round((bodyLength / totalLength * 100.0), 0);
            int legLengthRate = (int)Math.Round((legLength / totalLength * 100.0), 0);

            string type = "";
            //Marubozu
            if (bodyLengthRate >= 80)
                type = "➀";

            //Long Body
            else if (bodyLengthRate >= 60)
                type = "➁";

            //Spinning
            else if ((bodyLengthRate >= 10 && bodyLengthRate < 25) && headLengthRate >= 35 && legLengthRate >= 35)
                type = "➃";

            //Hammer
            else if ((bodyLengthRate <= 50 && bodyLengthRate >= 20) && (headLengthRate >= 45 || legLengthRate >= 45))
                type = "➄";

            //Small Hammer
            else if (bodyLengthRate < 20 && (headLengthRate >= 75 || legLengthRate >= 75))
                type = "➅";

            if (type == "")
            {
                //Doji
                if (bodyLengthRate < 10)
                    type = "⑦";

                //Short Body
                else if (bodyLengthRate >= 25 && bodyLengthRate < 60)
                    type = "➂";

                else
                    type = "★";
            }

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

        public CandleTimeTypeEnum TimeType_OpenPrice_P
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.OpenPrice < this.OpenPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.OpenPrice > this.OpenPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_ClosePrice_P
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
        public CandleTimeTypeEnum TimeType_HighPrice_P
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.HighPrice < this.HighPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.HighPrice > this.HighPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_LowPrice_P
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.LowPrice < this.LowPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.LowPrice > this.LowPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_OpenPrice_PN
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.OpenPrice < NextCandleItem.OpenPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.OpenPrice > NextCandleItem.OpenPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_ClosePrice_PN
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
        public CandleTimeTypeEnum TimeType_HighPrice_PN
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.HighPrice < NextCandleItem.HighPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.HighPrice > NextCandleItem.HighPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_LowPrice_PN
        {
            get
            {
                if (PreCandleItem == null) return CandleTimeTypeEnum.모름;
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (PreCandleItem.LowPrice < NextCandleItem.LowPrice) return CandleTimeTypeEnum.양;
                    else if (PreCandleItem.LowPrice > NextCandleItem.LowPrice) return CandleTimeTypeEnum.음;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_OpenPrice_N
        {
            get
            {
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (NextCandleItem.OpenPrice < this.OpenPrice) return CandleTimeTypeEnum.음;
                    else if (NextCandleItem.OpenPrice > this.OpenPrice) return CandleTimeTypeEnum.양;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_ClosePrice_N
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
        public CandleTimeTypeEnum TimeType_HighPrice_N
        {
            get
            {
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (NextCandleItem.HighPrice < this.HighPrice) return CandleTimeTypeEnum.음;
                    else if (NextCandleItem.HighPrice > this.HighPrice) return CandleTimeTypeEnum.양;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        public CandleTimeTypeEnum TimeType_LowPrice_N
        {
            get
            {
                if (NextCandleItem == null) return CandleTimeTypeEnum.모름;
                else
                {
                    if (NextCandleItem.LowPrice < this.LowPrice) return CandleTimeTypeEnum.음;
                    else if (NextCandleItem.LowPrice > this.LowPrice) return CandleTimeTypeEnum.양;
                    else return CandleTimeTypeEnum.무;
                }
            }
        }
        #endregion

        #region Candle_Force
        public CandleGravitationalForceTypeEnum GForceType
        {
            //캔들중력힘 (캔들종류)
            get
            {
                var type = CandleGravitationalForceTypeEnum.Unknown;

                double totalLength = this.TotalLength;
                double headLength = this.HeadLength;
                double legLength = this.LegLength;
                double bodyLength = this.BodyLength;

                int headLengthRate = (int)Math.Ceiling((headLength / totalLength * 100.0));
                int bodyLengthRate = (int)Math.Ceiling((bodyLength / totalLength * 100.0));
                int legLengthRate = (int)Math.Ceiling((legLength / totalLength * 100.0));

                if (bodyLengthRate >= 90)
                {
                    if (bodyLengthRate >= 95)
                        type = CandleGravitationalForceTypeEnum.MarubozuT;
                    else
                        type = CandleGravitationalForceTypeEnum.MarubozuB;
                }

                else if (bodyLengthRate >= 60 && bodyLengthRate < 90)
                {
                    if (bodyLengthRate + legLengthRate > 95)
                        type = CandleGravitationalForceTypeEnum.LongBodyT;
                    else if (bodyLengthRate + headLengthRate > 95)
                        type = CandleGravitationalForceTypeEnum.LongBodyB;
                    else
                        type = CandleGravitationalForceTypeEnum.LongBodyC;
                }

                else if (bodyLengthRate >= 30 && bodyLengthRate < 60)
                {
                    if (bodyLengthRate + legLengthRate > 95)
                        type = CandleGravitationalForceTypeEnum.ShortBodyT;
                    else if (bodyLengthRate + headLengthRate > 95)
                        type = CandleGravitationalForceTypeEnum.ShortBodyB;
                    else
                        type = CandleGravitationalForceTypeEnum.ShortBodyC;
                }

                else if (bodyLengthRate >= 20 && bodyLengthRate < 30)
                {
                    if (bodyLengthRate + legLengthRate > 90)
                        type = CandleGravitationalForceTypeEnum.HammerT;
                    else if (bodyLengthRate + headLengthRate > 90)
                        type = CandleGravitationalForceTypeEnum.HammerB;
                    else
                    {
                        if (bodyLengthRate + legLengthRate > 70)
                            type = CandleGravitationalForceTypeEnum.SpinningT;
                        else if (bodyLengthRate + headLengthRate > 70)
                            type = CandleGravitationalForceTypeEnum.SpinningB;
                        else
                            type = CandleGravitationalForceTypeEnum.SpinningC;
                    }
                }
                else if (bodyLengthRate >= 10 && bodyLengthRate < 20)
                {
                    if (bodyLengthRate + legLengthRate > 90)
                        type = CandleGravitationalForceTypeEnum.SmallHammerT;
                    else if (bodyLengthRate + headLengthRate > 90)
                        type = CandleGravitationalForceTypeEnum.SmallHammerB;
                    else
                    {
                        if (bodyLengthRate + legLengthRate > 70)
                            type = CandleGravitationalForceTypeEnum.SpinningT;
                        else if (bodyLengthRate + headLengthRate > 70)
                            type = CandleGravitationalForceTypeEnum.SpinningB;
                        else
                            type = CandleGravitationalForceTypeEnum.SpinningC;
                    }
                }

                else if (bodyLengthRate < 10)
                {
                    if (bodyLengthRate + legLengthRate > 70)
                        type = CandleGravitationalForceTypeEnum.DogiT;
                    else if (bodyLengthRate + headLengthRate > 70)
                        type = CandleGravitationalForceTypeEnum.DogiB;
                    else
                        type = CandleGravitationalForceTypeEnum.DogiC;
                }
                return type;
            }
        }
        public CandleElectromagneticForceTypeEnum EForceType_OC
        {
            //캔들전자기력힘 (음양무)
            get
            {
                if (this.OpenPrice < this.ClosePrice) return CandleElectromagneticForceTypeEnum.양;
                else if (this.OpenPrice > this.ClosePrice) return CandleElectromagneticForceTypeEnum.음;
                else return CandleElectromagneticForceTypeEnum.무;
            }
        }
        public CandleElectromagneticForceTypeEnum EForceType_CC
        {
            //캔들전자기력힘 (음양무)
            get
            {
                if (PreCandleItem.ClosePrice < this.ClosePrice) return CandleElectromagneticForceTypeEnum.양;
                else if (PreCandleItem.ClosePrice > this.ClosePrice) return CandleElectromagneticForceTypeEnum.음;
                else return CandleElectromagneticForceTypeEnum.무;
            }
        }
        public CandleStrongForceTypeEnum SForceType_O
        {
            //캔들강력 (시고저종 이전가격 비교)
            get
            {
                if (PreCandleItem.OpenPrice < this.OpenPrice) return CandleStrongForceTypeEnum.High;
                else if (PreCandleItem.OpenPrice > this.OpenPrice) return CandleStrongForceTypeEnum.Low;
                else return CandleStrongForceTypeEnum.Same;
            }
        }
        public CandleStrongForceTypeEnum SForceType_H
        {
            //캔들강력 (시고저종 이전가격 비교)
            get
            {
                if (PreCandleItem.HighPrice < this.HighPrice) return CandleStrongForceTypeEnum.High;
                else if (PreCandleItem.HighPrice > this.HighPrice) return CandleStrongForceTypeEnum.Low;
                else return CandleStrongForceTypeEnum.Same;
            }
        }
        public CandleStrongForceTypeEnum SForceType_L
        {
            //캔들강력 (시고저종 이전가격 비교)
            get
            {
                if (PreCandleItem.LowPrice < this.LowPrice) return CandleStrongForceTypeEnum.High;
                else if (PreCandleItem.LowPrice > this.LowPrice) return CandleStrongForceTypeEnum.Low;
                else return CandleStrongForceTypeEnum.Same;
            }
        }
        public CandleStrongForceTypeEnum SForceType_C
        {
            //캔들강력 (시고저종 이전가격 비교)
            get
            {
                if (PreCandleItem.ClosePrice < this.ClosePrice) return CandleStrongForceTypeEnum.High;
                else if (PreCandleItem.ClosePrice > this.ClosePrice) return CandleStrongForceTypeEnum.Low;
                else return CandleStrongForceTypeEnum.Same;
            }
        }
        public CandleWeakForceTypeEnum WForceType_T
        {
            //캔들약력 (머리, 몸통, 꼬리 길이 비교)
            get
            {
                if (PreCandleItem.TotalLength < this.TotalLength) return CandleWeakForceTypeEnum.Big;
                else if (PreCandleItem.TotalLength > this.TotalLength) return CandleWeakForceTypeEnum.Small;
                else return CandleWeakForceTypeEnum.Same;
            }
        }
        public CandleWeakForceTypeEnum WForceType_H
        {
            //캔들약력 (머리, 몸통, 꼬리 길이 비교)
            get
            {
                if (PreCandleItem.HeadLength < this.HeadLength) return CandleWeakForceTypeEnum.Big;
                else if (PreCandleItem.HeadLength > this.HeadLength) return CandleWeakForceTypeEnum.Small;
                else return CandleWeakForceTypeEnum.Same;
            }
        }
        public CandleWeakForceTypeEnum WForceType_B
        {
            //캔들약력 (머리, 몸통, 꼬리 길이 비교)
            get
            {
                if (PreCandleItem.BodyLength < this.BodyLength) return CandleWeakForceTypeEnum.Big;
                else if (PreCandleItem.BodyLength > this.BodyLength) return CandleWeakForceTypeEnum.Small;
                else return CandleWeakForceTypeEnum.Same;
            }
        }
        public CandleWeakForceTypeEnum WForceType_L
        {
            //캔들약력 (머리, 몸통, 꼬리 길이 비교)
            get
            {
                if (PreCandleItem.LegLength < this.LegLength) return CandleWeakForceTypeEnum.Big;
                else if (PreCandleItem.LegLength > this.LegLength) return CandleWeakForceTypeEnum.Small;
                else return CandleWeakForceTypeEnum.Same;
            }
        }
        #endregion

        public PlusMinusTypeEnum YinAndYang
        {
            get
            {
                if (PreCandleItem == null)
                {
                    if (OpenPrice < ClosePrice) return PlusMinusTypeEnum.양;
                    else if (OpenPrice > ClosePrice) return PlusMinusTypeEnum.음;
                    else return PlusMinusTypeEnum.무;
                }
                else
                {
                    if (LowPrice > PreCandleItem.MiddlePrice || HighPrice < PreCandleItem.MiddlePrice)
                        return PlusMinusTypeEnum.양;

                    else if (HighPrice > PreCandleItem.HighPrice && LowPrice < PreCandleItem.LowPrice)
                        return PlusMinusTypeEnum.양;

                    else if (HighPrice <= PreCandleItem.HighPrice && LowPrice >= PreCandleItem.LowPrice)
                        return PlusMinusTypeEnum.음;
                    else
                        return PlusMinusTypeEnum.무;

                }
            }
        }

        public int ElectronForce
        {
            get
            {
                if (PreCandleItem == null)
                {
                    return 0;
                }
                else
                {
                    double pTotalLength = PreCandleItem.TotalLength;
                    double pHigh = PreCandleItem.HighPrice;
                    double pLow = PreCandleItem.LowPrice;
                    double pClose = PreCandleItem.ClosePrice;

                    double high = this.HighPrice;
                    double low = this.LowPrice;

                    int force = 0;
                    int pforce = 0;
                    int mforce = 0;
                    if (PreCandleItem.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        //if (this.PlusMinusType == PlusMinusTypeEnum.양)
                        //{
                            if ((pClose + (pTotalLength * 2.0)) <= high) pforce = 5;
                            else if ((pClose + (pTotalLength * 1.5)) <= high) pforce = 4;
                            else if ((pClose + (pTotalLength * 1.0)) <= high) pforce = 3;
                            else if ((pClose + (pTotalLength * 0.5)) <= high) pforce = 2;
                            else if ((pClose + (pTotalLength * 0.5)) > high) pforce = 1;
                        //}
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.음)
                        //{
                            if ((pClose - (pTotalLength * 2.0)) >= low) mforce = -5;
                            else if ((pClose - (pTotalLength * 1.5)) >= low) mforce = -4;
                            else if ((pClose - (pTotalLength * 1.0)) >= low) mforce = -3;
                            else if ((pClose - (pTotalLength * 0.5)) >= low) mforce = -2;
                            else if ((pClose - (pTotalLength * 0.5)) < low) mforce = -1;
                        //}
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.무)
                        //{
                        //    force = 0;
                        //}
                    }
                    else if (PreCandleItem.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        //if (this.PlusMinusType == PlusMinusTypeEnum.음)
                        //{
                            if ((pClose - (pTotalLength * 2.0)) >= low) mforce = -5;
                            else if ((pClose - (pTotalLength * 1.5)) >= low) mforce = -4;
                            else if ((pClose - (pTotalLength * 1.0)) >= low) mforce = -3;
                            else if ((pClose - (pTotalLength * 0.5)) >= low) mforce = -2;
                            else if ((pClose - (pTotalLength * 0.5)) < low) mforce = -1;
                        //}
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.양)
                        //{
                            if ((pClose + (pTotalLength * 2.0)) <= high) pforce = 5;
                            else if ((pClose + (pTotalLength * 1.5)) <= high) pforce = 4;
                            else if ((pClose + (pTotalLength * 1.0)) <= high) pforce = 3;
                            else if ((pClose + (pTotalLength * 0.5)) <= high) pforce = 2;
                            else if ((pClose + (pTotalLength * 0.5)) > high) pforce = 1;
                        //}                        
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.무)
                        //{
                        //    force = 0;
                        //}
                    }
                    else if (PreCandleItem.PlusMinusType == PlusMinusTypeEnum.무)
                    {
                        //if (this.PlusMinusType == PlusMinusTypeEnum.음)
                        //{
                        if ((pClose - (pTotalLength * 2.0)) >= low) mforce = -5;
                        else if ((pClose - (pTotalLength * 1.5)) >= low) mforce = -4;
                        else if ((pClose - (pTotalLength * 1.0)) >= low) mforce = -3;
                        else if ((pClose - (pTotalLength * 0.5)) >= low) mforce = -2;
                        else if ((pClose - (pTotalLength * 0.5)) < low) mforce = -1;
                        //}
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.양)
                        //{
                        if ((pClose + (pTotalLength * 2.0)) <= high) pforce = 5;
                        else if ((pClose + (pTotalLength * 1.5)) <= high) pforce = 4;
                        else if ((pClose + (pTotalLength * 1.0)) <= high) pforce = 3;
                        else if ((pClose + (pTotalLength * 0.5)) <= high) pforce = 2;
                        else if ((pClose + (pTotalLength * 0.5)) > high) pforce = 1;
                        //}                        
                        //else if (this.PlusMinusType == PlusMinusTypeEnum.무)
                        //{
                        //    force = 0;
                        //}
                    }
                    force = pforce + mforce;

                    return force;
                }
            }
        }
    }
}
