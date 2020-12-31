using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public abstract class A_HLOC
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

        #region 기본정보_시가대비
        private Single _OpenPrice = 0;
        private Single _HighPrice = 0;
        private Single _LowPrice = 0;
        private Single _ClosePrice = 0;
        public Single OpenPrice { get { return (Single)Math.Round(_OpenPrice, RoundLength); } set { _OpenPrice = value; } }
        public Single HighPrice { get { return (Single)Math.Round(_HighPrice, RoundLength); ; } set { _HighPrice = value; } }
        public Single LowPrice { get { return (Single)Math.Round(_LowPrice, RoundLength); ; } set { _LowPrice = value; } }
        public Single ClosePrice { get { return (Single)Math.Round(_ClosePrice, RoundLength); ; } set { _ClosePrice = value; } }
        public Single Volume { get; set; } = 0;
        #endregion

        #region 기본정보_전일종가대비

        #endregion

        #region 기본정보_전일종가대비

        #endregion

        #region 양자정보_시가대비

        #endregion

        #region 기본정보_전일종가대비

        #endregion

        public Single CenterPrice
        {
            get
            {
                return (Single)Math.Round((HighPrice + LowPrice) / 2.0f, RoundLength);
            }
        }
        public Single HCenterPrice
        {
            get
            {
                return (Single)Math.Round((HighPrice + CenterPrice) / 2.0f, RoundLength);
            }
        }
        public Single LCenterPrice
        {
            get
            {
                return (Single)Math.Round((CenterPrice + LowPrice) / 2.0f, RoundLength);
            }
        }
        public Single MiddlePrice
        {
            get
            {
                return (Single)Math.Round((OpenPrice + ClosePrice) / 2.0f, RoundLength);
            }
        }
        public Single HeadLength
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round(Math.Abs(HighPrice - ClosePrice), RoundLength);
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    return (Single)Math.Round(Math.Abs(HighPrice - OpenPrice), RoundLength);
                }
                else
                {
                    return (Single)Math.Round(Math.Abs(HighPrice - ClosePrice), RoundLength);
                }
            }
        }
        public Single LegLength
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round(Math.Abs(OpenPrice - LowPrice), RoundLength);
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    return (Single)Math.Round(Math.Abs(ClosePrice - LowPrice), RoundLength);
                }
                else
                {
                    return (Single)Math.Round(Math.Abs(ClosePrice - LowPrice), RoundLength);
                }
            }
        }
        public Single BodyLength
        {
            get
            {
                return (Single)Math.Round(Math.Abs(OpenPrice - ClosePrice), RoundLength);
            }
        }
        public Single TotalLength
        {
            get
            {
                return (Single)Math.Round(Math.Abs(HighPrice - LowPrice), RoundLength);
            }
        }
        public Single QuantumPrice
        {
            get
            {
                Single v;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    v = (Single)Math.Round(OpenPrice - Math.Abs(OpenPrice - ClosePrice), RoundLength);
                    v += LegLength;
                    if (v > OpenPrice) v = OpenPrice;
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    v = (Single)Math.Round(OpenPrice + Math.Abs(OpenPrice - ClosePrice), RoundLength);
                    v -= HeadLength;
                    if (v < OpenPrice) v = OpenPrice;
                }
                else
                    v = (Single)Math.Round(OpenPrice, RoundLength);

                return v;
            }
        }
        public Single QuantumLowPrice
        {
            get
            {
                if (QuantumPrice > LowPrice)
                    return LowPrice;

                return QuantumPrice;
            }
        }
        public Single QuantumHighPrice
        {
            get
            {
                if (QuantumPrice < HighPrice)
                    return HighPrice;

                return QuantumPrice;
            }
        }
        public Single QuantumBasePrice
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round(OpenPrice - BodyLength, RoundLength);                  
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    return (Single)Math.Round(OpenPrice + BodyLength, RoundLength);                  
                }
                else
                    return (Single)Math.Round(OpenPrice, RoundLength);
            }
        }        
        public Single QuantumBaseHighPrice
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round(OpenPrice + LegLength, RoundLength);
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    return (Single)Math.Round(QuantumBasePrice + LegLength, RoundLength);
                }
                else
                    return (Single)Math.Round(OpenPrice + LegLength, RoundLength);
            }
        }
        public Single QuantumBaseLowPrice
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round(QuantumBasePrice - HeadLength, RoundLength);
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    return (Single)Math.Round(OpenPrice - HeadLength, RoundLength);
                }
                else
                    return (Single)Math.Round(OpenPrice - HeadLength, RoundLength);
            }
        }
        public Single QuantumCenterPrice
        {
            get
            {
                return (Single)Math.Round((QuantumHighPrice + QuantumLowPrice) / 2.0f, RoundLength);
            }
        }
        public Single QuantumMiddlePrice
        {
            get
            {
                return (Single)Math.Round((OpenPrice + QuantumPrice) / 2.0f, RoundLength);
            }
        }
        public Single VikalaPrice
        {
            get
            {
                Single v;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    v = (Single)Math.Round(ClosePrice + Math.Abs(OpenPrice - ClosePrice), RoundLength);
                    v -= HeadLength;
                    if (v < ClosePrice) v = ClosePrice;
                }
                else if (PlusMinusType == PlusMinusTypeEnum.음)
                {
                    v = (Single)Math.Round(ClosePrice - Math.Abs(OpenPrice - ClosePrice), RoundLength);
                    v += LegLength;
                    if (v > ClosePrice) v = ClosePrice;
                }
                else
                    v = (Single)Math.Round(OpenPrice, RoundLength);

                return v;
            }
        }
        public Single VikalaLowPrice
        {
            get
            {
                if (VikalaPrice > LowPrice)
                    return LowPrice;
                return VikalaPrice;
            }
        }
        public Single VikalaHighPrice
        {
            get
            {
                if (VikalaPrice < HighPrice)
                    return HighPrice;
                return VikalaPrice;
            }
        }
        public Single VikalaCenterPrice
        {
            get
            {
                return (Single)Math.Round((VikalaHighPrice + VikalaLowPrice) / 2.0f, RoundLength);
            }
        }
        public Single VikalaMiddlePrice
        {
            get
            {
                return (Single)Math.Round((ClosePrice + VikalaPrice) / 2.0f, RoundLength);
            }
        }
        public Single TotalCenterPrice
        {
            get
            {
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    return (Single)Math.Round((VikalaHighPrice + QuantumLowPrice) / 2.0f, RoundLength);
                }
                else
                {
                    return (Single)Math.Round((QuantumHighPrice + VikalaLowPrice) / 2.0f, RoundLength);
                }
            }
        }

        public Single DarkMassPrice
        {
            get
            {

                Single m =  Math.Abs(OpenPrice - ClosePrice)
                    + Math.Abs(OpenPrice - HighPrice)
                    + Math.Abs(OpenPrice - LowPrice)
                    + Math.Abs(ClosePrice - HighPrice)
                    + Math.Abs(ClosePrice - LowPrice)
                    + Math.Abs(HighPrice - LowPrice);

                return (Single)Math.Round(m, RoundLength);

            }
        }

        public Single MassPrice
        {
            get
            {
                List<double> list = new List<double>();

                list.Add(OpenPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, OpenPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, OpenPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, OpenPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, OpenPrice, 2));

                list.Add(HighPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, HighPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, HighPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, HighPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, HighPrice, 2));

                list.Add(LowPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, LowPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, LowPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, LowPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, LowPrice, 2));

                list.Add(ClosePrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, ClosePrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, ClosePrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, ClosePrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, ClosePrice, 2));

                list.Add(QuantumBaseHighPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBaseHighPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBaseHighPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBaseHighPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBaseHighPrice, 2));

                list.Add(QuantumLowPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBaseLowPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBaseLowPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBaseLowPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBaseLowPrice, 2));

                list.Add(QuantumPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBasePrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumBasePrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBasePrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumBasePrice, 2));

                list.Add(VikalaPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaPrice, 2));

                list.Add(VikalaHighPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaHighPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaHighPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaHighPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaHighPrice, 2));

                list.Add(VikalaLowPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaLowPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaLowPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaLowPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaLowPrice, 2));

                return (Single)Math.Round(list.Average(), RoundLength);

            }
        }
        public Single HMassPrice
        {
            get
            {
                return CenterPrice;
            }
        }
        public Single QMassPrice
        {
            get
            {
                List<double> list = new List<double>();

                list.Add(QuantumHighPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumHighPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumHighPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumHighPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumHighPrice, 2));

                list.Add(QuantumLowPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumLowPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumLowPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumLowPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumLowPrice, 2));

                list.Add(QuantumPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, QuantumPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, QuantumPrice, 2));

                return (Single)Math.Round(list.Average(), RoundLength);
            }
        }
        public Single VMassPrice
        {
            get
            {
                List<double> list = new List<double>();

                list.Add(VikalaPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaPrice, 2));

                list.Add(VikalaHighPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaHighPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaHighPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaHighPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaHighPrice, 2));

                list.Add(VikalaLowPrice);
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaLowPrice, 1));
                list.Add(PriceTick.GetUpPriceOfTick(ItemCode, VikalaLowPrice, 2));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaLowPrice, 1));
                list.Add(PriceTick.GetDownPriceOfTick(ItemCode, VikalaLowPrice, 2));

                return (Single)Math.Round(list.Average(), RoundLength);
            }
        }

        public DateTime DTime { get; set; }

        public virtual PlusMinusTypeEnum PlusMinusType
        {
            get
            {   
                if (OpenPrice < ClosePrice) return PlusMinusTypeEnum.양;
                else if (OpenPrice > ClosePrice) return PlusMinusTypeEnum.음;
                else return PlusMinusTypeEnum.무;
            }
        }

        public Single U_HighPrice
        {
            get
            {
                //if (PlusMinusType == PlusMinusTypeEnum.음)
                //{
                //    return QuantumBaseHighPrice;
                //}
                //else
                //{
                //    return HighPrice;
                //}

                return HighPrice + TotalLength;
            }
        }
        public Single U_LowPrice
        {
            get
            {
                //if (PlusMinusType == PlusMinusTypeEnum.음)
                //{
                //    return QuantumBaseLowPrice;
                //}
                //else
                //{
                //    return LowPrice;
                //}
                return HighPrice;
            }
        }


        public Single D_HighPrice
        {
            get
            {
                //if (PlusMinusType == PlusMinusTypeEnum.음)
                //{
                //    return HighPrice;
                //}
                //else
                //{
                //    return QuantumBaseHighPrice;
                //}
                return LowPrice;
            }
        }
        public Single D_LowPrice
        {
            get
            {
                //if (PlusMinusType == PlusMinusTypeEnum.음)
                //{
                //    return LowPrice;
                //}
                //else
                //{
                //    return QuantumBaseLowPrice;
                //}
                return LowPrice - TotalLength;
            }
        }

        public int DiceNum
        {
            get
            {
                double[] anArray = {
                        OpenPrice, HighPrice, LowPrice, ClosePrice
                    //,   QuantumPrice, QuantumHighPrice, QuantumLowPrice
                    //,   VikalaPrice, VikalaHighPrice, VikalaLowPrice
                };
                double[] anArray2 = {
                        OpenPrice, ClosePrice
                    //,   QuantumPrice
                    //,   VikalaPrice
                };
                double highPrice = anArray.Max();
                double lowPrice = anArray.Min();
                double openPrice = anArray2.Min();
                double closePrice = anArray2.Max();

                double totalLength = Math.Round(highPrice - lowPrice, RoundLength);
                double headLength = Math.Round(Math.Abs(highPrice - closePrice), RoundLength);
                double legLength = Math.Round(Math.Abs(lowPrice - openPrice), RoundLength);
                double bodyLength = Math.Round(Math.Abs(openPrice - closePrice), RoundLength);

                int headLengthRate = (int)Math.Round((headLength / totalLength * 100.0), 0);
                int bodyLengthRate = (int)Math.Round((bodyLength / totalLength * 100.0), 0);
                int legLengthRate = (int)Math.Round((legLength / totalLength * 100.0), 0);

                int n = 0;
                try
                {
                    if (bodyLengthRate >= 80) n = 1;
                    else if (headLengthRate >= 40 && legLengthRate >= 40) n = 6;

                    else if (headLengthRate >= 40 && legLengthRate == 0) n = 2;
                    else if (headLengthRate == 0 && legLengthRate >= 40) n = 5;

                    else if (headLengthRate >= 20 && legLengthRate >= 20 && headLengthRate > legLengthRate) n = 3;
                    else if (headLengthRate >= 20 && legLengthRate >= 20 && headLengthRate < legLengthRate) n = 4;
                }
                catch (Exception)
                {
                }
                if (n == 0)
                {

                }
                return n;
            }
        }


        #region ALL Length
       
        public Single AllLength
        {
            get 
            {
                Single totalLength;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    totalLength = (Math.Abs(OpenPrice - LowPrice)
                                        + Math.Abs(LowPrice - HighPrice)
                                        + Math.Abs(HighPrice - ClosePrice))
                                + (Math.Abs(LowPrice - HighPrice)
                                        + Math.Abs(HighPrice - ClosePrice))
                                + (Math.Abs(HighPrice - ClosePrice));
                }
                else
                {
                    totalLength = (Math.Abs(OpenPrice - HighPrice)
                                        + Math.Abs(HighPrice - LowPrice)
                                        + Math.Abs(LowPrice - ClosePrice))
                                + (Math.Abs(HighPrice - LowPrice)
                                        + Math.Abs(LowPrice - ClosePrice))
                                + (Math.Abs(LowPrice - ClosePrice));

                }
                return (Single)Math.Round(totalLength, RoundLength); 
            }
        }
        public Single AllLengthRate
        {
            get
            {   
                return (Single)Math.Round( (AllLength / 6.0), RoundLength);
            }
        }

        public Single AllQuantumLength
        {
            get
            {
                Single totalLength;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    totalLength = (Math.Abs(OpenPrice - QuantumBaseLowPrice)
                                        + Math.Abs(QuantumBaseLowPrice - QuantumBaseHighPrice)
                                        + Math.Abs(QuantumBaseHighPrice - QuantumBasePrice))
                                + (Math.Abs(QuantumBaseLowPrice - QuantumBaseHighPrice)
                                        + Math.Abs(QuantumBaseHighPrice - QuantumBasePrice))
                                + (Math.Abs(QuantumBaseHighPrice - QuantumBasePrice));
                }
                else
                {
                    totalLength = (Math.Abs(OpenPrice - QuantumBaseHighPrice)
                                        + Math.Abs(QuantumBaseHighPrice - QuantumBaseLowPrice)
                                        + Math.Abs(QuantumBaseLowPrice - QuantumBasePrice))
                                + (Math.Abs(QuantumBaseHighPrice - QuantumBaseLowPrice)
                                        + Math.Abs(QuantumBaseLowPrice - QuantumBasePrice))
                                + (Math.Abs(QuantumBaseLowPrice - QuantumBasePrice));

                }
                return (Single)Math.Round(totalLength, RoundLength);
            }
        }
        public Single AllQuantumLengthRate
        {
            get
            {
                return (Single)Math.Round((AllQuantumLength / 6.0), RoundLength);
            }
        }

        public Single AllVikalaLength
        {
            get
            {
                Single totalLength;
                if (PlusMinusType == PlusMinusTypeEnum.양)
                {
                    totalLength = (Math.Abs(OpenPrice - VikalaLowPrice)
                                        + Math.Abs(VikalaLowPrice - VikalaHighPrice)
                                        + Math.Abs(VikalaHighPrice - VikalaPrice))
                                + (Math.Abs(VikalaLowPrice - VikalaHighPrice)
                                        + Math.Abs(VikalaHighPrice - VikalaPrice))
                                + (Math.Abs(VikalaHighPrice - VikalaPrice));
                }
                else
                {
                    totalLength = (Math.Abs(OpenPrice - VikalaHighPrice)
                                        + Math.Abs(VikalaHighPrice - VikalaLowPrice)
                                        + Math.Abs(VikalaLowPrice - VikalaPrice))
                                + (Math.Abs(VikalaHighPrice - VikalaLowPrice)
                                        + Math.Abs(VikalaLowPrice - VikalaPrice))
                                + (Math.Abs(VikalaLowPrice - VikalaPrice));

                }
                return (Single)Math.Round(totalLength, RoundLength);
            }
        }
        public Single AllVikalaLengthRate
        {
            get
            {
                return (Single)Math.Round((AllVikalaLength / 6.0), RoundLength);
            }
        }
        #endregion

       
    }
}
