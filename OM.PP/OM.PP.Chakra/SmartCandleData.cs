using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class SmartCandleData
    {
        private double open;
        private double high;
        private double low;
        private double close;

        public DateTime? DTime { get; set; }
        public double Volume { get; set; }
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

        public SmartCandleData PreviousCandleData { get; set; } = null;

        public SmartCandleData(
              string itemCode
            , double open
            , double high
            , double low
            , double close
            , double volume = double.NaN
            , DateTime? dt = null
            , SmartCandleData previousCandleData = null)
        {
            this.ItemCode = itemCode;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.Volume = volume;
            this.DTime = dt;
            this.PreviousCandleData = previousCandleData;
        }

        #region 기본가격정보_시가대비       
        public double BasicPrice_Open { get { return Math.Round(open, RoundLength); } }
        public double BasicPrice_High { get { return Math.Round(high, RoundLength); } }
        public double BasicPrice_Low { get { return Math.Round(low, RoundLength); } }
        public double BasicPrice_Close { get { return Math.Round(close, RoundLength); } }
        public double BasicPrice_Center
        {
            get
            {
                return Math.Round((BasicPrice_High + BasicPrice_Low) / 2.0d, RoundLength);
            }
        } 
        public double BasicPrice_Middle
        {
            get
            {
                return Math.Round((BasicPrice_Open + BasicPrice_Close) / 2.0d, RoundLength);
            }
        }
        public double BasicPrice_BodyLength
        {
            get
            {
                return Math.Round(Math.Abs(BasicPrice_Open - BasicPrice_Close), RoundLength);
            }
        }
        public double BasicPrice_TotalLength
        {
            get
            {
                return Math.Round(Math.Abs(BasicPrice_High - BasicPrice_Low), RoundLength);
            }
        }
        #endregion

        #region 기본가격정보_전일종가대비
        public double ComparedPreviousDayPrice_Open { 
            get 
            { 
                return Math.Round(PreviousCandleData.BasicPrice_Close, RoundLength); 
            } 
        }
        public double ComparedPreviousDayPrice_High { 
            get 
            { 
                return Math.Round(ComparedPreviousDayPrice_Open > high ? ComparedPreviousDayPrice_Open : high, RoundLength); 
            } 
        }
        public double ComparedPreviousDayPrice_Low { 
            get 
            { 
                return Math.Round(ComparedPreviousDayPrice_Open < low ? ComparedPreviousDayPrice_Open : low, RoundLength); 
            } 
        }
        public double ComparedPreviousDayPrice_Close { 
            get 
            { 
                return Math.Round(close, RoundLength); 
            } 
        }
        public double ComparedPreviousDayPrice_Center
        {
            get
            {
                return Math.Round((ComparedPreviousDayPrice_High + ComparedPreviousDayPrice_Low) / 2.0d, RoundLength);
            }
        }
        public double ComparedPreviousDayPrice_Middle
        {
            get
            {
                return Math.Round((ComparedPreviousDayPrice_Open + ComparedPreviousDayPrice_Close) / 2.0d, RoundLength);
            }
        }
        public double ComparedPreviousDayPrice_BodyLength
        {
            get
            {
                return Math.Round(Math.Abs(ComparedPreviousDayPrice_Open - ComparedPreviousDayPrice_Close), RoundLength);
            }
        }
        public double ComparedPreviousDayPrice_TotalLength
        {
            get
            {
                return Math.Round(Math.Abs(ComparedPreviousDayPrice_High - ComparedPreviousDayPrice_Low), RoundLength);
            }
        }
        #endregion

        #region 양자가격정보_시가대비
        public double QuantumPrice_Open { 
            get 
            { 
                return Math.Round(open, RoundLength);             
            } 
        }
        public double QuantumPrice_High {
            get
            {
                return Math.Round(BasicPrice_Open + (BasicPrice_Open - BasicPrice_Low), RoundLength);
            }
        }
        public double QuantumPrice_Low { 
            get 
            {
                return Math.Round(BasicPrice_Open - (BasicPrice_High - BasicPrice_Open), RoundLength);
            } 
        }
        public double QuantumPrice_Close { 
            get 
            {
                if (BasicPrice_Open < BasicPrice_Close) 
                {
                    return Math.Round(BasicPrice_Open - (BasicPrice_Close - BasicPrice_Open), RoundLength);
                }
                else if (BasicPrice_Open > BasicPrice_Close) 
                {
                    return Math.Round(BasicPrice_Open + (BasicPrice_Open - BasicPrice_Close), RoundLength);
                }
                else
                    return BasicPrice_Open;
            } 
        }
        public double QuantumPrice_Center
        {
            get
            {
                return Math.Round((QuantumPrice_High + QuantumPrice_Low) / 2.0d, RoundLength);
            }
        }
        public double QuantumPrice_Middle
        {
            get
            {
                return Math.Round((QuantumPrice_Open + QuantumPrice_Close) / 2.0d, RoundLength);
            }
        }
        public double QuantumPrice_BodyLength
        {
            get
            {
                return Math.Round(Math.Abs(QuantumPrice_Open - QuantumPrice_Close), RoundLength);
            }
        }
        public double QuantumPrice_TotalLength
        {
            get
            {
                return Math.Round(Math.Abs(QuantumPrice_High - QuantumPrice_Low), RoundLength);
            }
        }
        #endregion

        #region 양자가격정보_전일종가대비
        public double ComparedPreviousDayQuantumPrice_Open
        {
            get
            {
                return Math.Round(ComparedPreviousDayPrice_Open, RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_High
        {
            get
            {
                return Math.Round(ComparedPreviousDayPrice_Open + (ComparedPreviousDayPrice_Open - ComparedPreviousDayPrice_Low), RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_Low
        {
            get
            {
                return Math.Round(ComparedPreviousDayPrice_Open - (ComparedPreviousDayPrice_High - ComparedPreviousDayPrice_Open), RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_Close
        {
            get
            {
                if (ComparedPreviousDayPrice_Open < ComparedPreviousDayPrice_Close)
                {
                    return Math.Round(ComparedPreviousDayPrice_Open - (ComparedPreviousDayPrice_Close - ComparedPreviousDayPrice_Open), RoundLength);
                }
                else if (ComparedPreviousDayPrice_Open > ComparedPreviousDayPrice_Close)
                {
                    return Math.Round(ComparedPreviousDayPrice_Open + (ComparedPreviousDayPrice_Open - ComparedPreviousDayPrice_Close), RoundLength);
                }
                else
                    return ComparedPreviousDayPrice_Open;
            }
        }
        public double ComparedPreviousDayQuantumPrice_Center
        {
            get
            {
                return Math.Round((ComparedPreviousDayQuantumPrice_High + ComparedPreviousDayQuantumPrice_Low) / 2.0d, RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_Middle
        {
            get
            {
                return Math.Round((ComparedPreviousDayQuantumPrice_Open + ComparedPreviousDayQuantumPrice_Close) / 2.0d, RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_BodyLength
        {
            get
            {
                return Math.Round(Math.Abs(ComparedPreviousDayQuantumPrice_Open - ComparedPreviousDayQuantumPrice_Close), RoundLength);
            }
        }
        public double ComparedPreviousDayQuantumPrice_TotalLength
        {
            get
            {
                return Math.Round(Math.Abs(ComparedPreviousDayQuantumPrice_High - ComparedPreviousDayQuantumPrice_Low), RoundLength);
            }
        }

        #endregion

        #region 음양정보
        public CandleColorTypeEnum BasicPriceColorType
        {
            get
            {
                if (BasicPrice_Open < BasicPrice_Close) return CandleColorTypeEnum.양;
                else if (BasicPrice_Open > BasicPrice_Close) return CandleColorTypeEnum.음;
                else return CandleColorTypeEnum.무;
            }
        }
        public CandleColorTypeEnum ComparedPreviousDayPriceColorType
        {
            get
            {
                if (ComparedPreviousDayPrice_Open < ComparedPreviousDayPrice_Close) return CandleColorTypeEnum.양;
                else if (ComparedPreviousDayPrice_Open > ComparedPreviousDayPrice_Close) return CandleColorTypeEnum.음;
                else return CandleColorTypeEnum.무;
            }
        }
        public CandleColorTypeEnum QuantumPriceColorType
        {
            get
            {
                if (QuantumPrice_Open < QuantumPrice_Close) return CandleColorTypeEnum.양;
                else if (QuantumPrice_Open > QuantumPrice_Close) return CandleColorTypeEnum.음;
                else return CandleColorTypeEnum.무;
            }
        }
        public CandleColorTypeEnum ComparedPreviousDayQuantumPriceColorType
        {
            get
            {
                if (ComparedPreviousDayQuantumPrice_Open < ComparedPreviousDayQuantumPrice_Close) return CandleColorTypeEnum.양;
                else if (ComparedPreviousDayQuantumPrice_Open > ComparedPreviousDayQuantumPrice_Close) return CandleColorTypeEnum.음;
                else return CandleColorTypeEnum.무;
            }
        }
        #endregion

        #region 변화정보 (시간) 
        #region 변화_기본_시가대비
        public double Variance_BasicPrice
        {
            get 
            {
                if (PreviousCandleData == null) 
                    return Double.NaN;

                double tRate =
                      PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_Open)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_Open)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_Open)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_Open)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_Open)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_Open)

                    + PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_High)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_High)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_High)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_High)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_High)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_High)

                    + PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_Low)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_Low)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_Low)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_Low)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_Low)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_Low)

                    + PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_Close)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_Close)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_Close)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_Close)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_Close)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_Close)

                    + PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_Center)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_Center)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_Center)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_Center)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_Center)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_Center)

                    + PPUtils.GetRateOfChange(this.BasicPrice_Open, PreviousCandleData.PreviousCandleData.BasicPrice_Middle)
                    + PPUtils.GetRateOfChange(this.BasicPrice_High, PreviousCandleData.PreviousCandleData.BasicPrice_Middle)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Low, PreviousCandleData.PreviousCandleData.BasicPrice_Middle)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Close, PreviousCandleData.PreviousCandleData.BasicPrice_Middle)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Center, PreviousCandleData.PreviousCandleData.BasicPrice_Middle)
                    + PPUtils.GetRateOfChange(this.BasicPrice_Middle, PreviousCandleData.PreviousCandleData.BasicPrice_Middle);


                return tRate;
            }
        }
        #endregion
        #region 변화_기본_전가대비
        public double Variance_ComparedPreviousDayPrice
        {
            get
            {
                if (PreviousCandleData == null) 
                    return Double.NaN;

                double tRate =
                      PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Open)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_High)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Low)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Close)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Center)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayPrice_Middle);


                return tRate;
            }
        }
        #endregion
        #region 변화_양자_시가대비
        public double Variance_QuantumPrice
        {
            get
            {
                if (PreviousCandleData == null)                     
                    return Double.NaN;

                double tRate =
                      PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_Open)

                    + PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_High)

                    + PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_Low)

                    + PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_Close)

                    + PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_Center)

                    + PPUtils.GetRateOfChange(this.QuantumPrice_Open, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_High, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Low, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Close, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Center, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.QuantumPrice_Middle, PreviousCandleData.PreviousCandleData.QuantumPrice_Middle);


                return tRate;
            }
        }
        #endregion
        #region 변화_양자_전가대비
        public double Variance_ComparedPreviousDayQuantumPrice
        {
            get
            {
                if (PreviousCandleData == null) 
                    return Double.NaN;

                double tRate =
                      PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Open)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_High)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Low)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Close)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Center)

                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Open, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_High, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Low, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Close, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Center, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle)
                    + PPUtils.GetRateOfChange(this.ComparedPreviousDayQuantumPrice_Middle, PreviousCandleData.PreviousCandleData.ComparedPreviousDayQuantumPrice_Middle);

                return tRate;
            }
        }
        #endregion
        #region 변화종합
        public double VarianceTotalRate
        {
            get
            {
                return (Variance_BasicPrice
                    + Variance_ComparedPreviousDayPrice
                    + Variance_QuantumPrice
                    + Variance_ComparedPreviousDayQuantumPrice) / 4.0;
            }
        }
        #endregion
        #endregion

        #region 공간정보 
        #region 공간_기본_시가대비
        public double Space_BasicPrice
        {
            get
            {
                if (PreviousCandleData == null)
                    return Double.NaN;

                double tRate =
                    PPUtils.GetRateOfSpace(
                        Math.Abs(this.BasicPrice_Open - this.BasicPrice_Close), Math.Abs(this.BasicPrice_High - this.BasicPrice_Low));

                if (tRate == 0) tRate = 1;
                return tRate;
            }
        }
        #endregion
        #region 공간_기본_전가대비
        public double Space_ComparedPreviousDayPrice
        {
            get
            {
                if (PreviousCandleData == null)
                    return Double.NaN;

                double tRate =
                    PPUtils.GetRateOfSpace(
                        Math.Abs(this.ComparedPreviousDayPrice_Open - this.ComparedPreviousDayPrice_Close)
                        , Math.Abs(this.ComparedPreviousDayPrice_High - this.ComparedPreviousDayPrice_Low));

                if (tRate == 0) tRate = 1;
                return tRate;
            }
        }
        #endregion       
       
        public double SpaceTotal
        {
            get
            {
                return Space_BasicPrice
                    + Space_ComparedPreviousDayPrice;                 
            }
        }
        public double SpaceTotalAverage
        {
            get
            {
                return (Space_BasicPrice
                    + Space_ComparedPreviousDayPrice) / 2.0;
            }
        }
        public double SpaceTotalChangeRate
        {
            get
            {
                double tRate =
                   PPUtils.GetRateOfSpace(Space_BasicPrice, Space_ComparedPreviousDayPrice);

                return tRate;
            }
        }
       
        #endregion

        #region Energry
        
        public double SpaceEnergy
        {
            get
            {
                double energy = Space_BasicPrice + Space_ComparedPreviousDayPrice + SpaceTotalAverage + SpaceTotalChangeRate;
                return energy / 4.0;
            }
        }
        public double TimeEnergy
        {
            get
            {
                double energy1 = PPUtils.GetAvgRateOfChange(Variance_BasicPrice, VarianceTotalRate);
                double energy2 = PPUtils.GetAvgRateOfChange(Variance_ComparedPreviousDayPrice, VarianceTotalRate);
                double energy3 = PPUtils.GetAvgRateOfChange(Variance_QuantumPrice, VarianceTotalRate);
                double energy4 = PPUtils.GetAvgRateOfChange(Variance_ComparedPreviousDayQuantumPrice, VarianceTotalRate); 

                return (energy1 + energy2 + energy3 + energy4) / 4.0;
            }
        }

        public double TotalEnergy
        {
            get 
            {
                return (SpaceEnergy + TimeEnergy) / 2.0;
            }
        }
        #endregion
    }
}
