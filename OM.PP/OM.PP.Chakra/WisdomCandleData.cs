using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    //모든것은 비율이다.
    public class WisdomCandleData
    {
        public double open;
        public double high;
        public double low;
        public double close;

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

        public WisdomCandleData PreviousCandleData { get; set; } = null;
        public WisdomCandleData(
              string itemCode
            , double open
            , double high
            , double low
            , double close
            , double volume = double.NaN
            , DateTime? dt = null
            , WisdomCandleData previousCandleData = null)
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
        public double BasicPrice_Open { get { return PPUtils.GetRateOfChange(open, PreviousCandleData.close); } }
        public double BasicPrice_High { get { return PPUtils.GetRateOfChange(high, PreviousCandleData.close); } }
        public double BasicPrice_Low { get { return PPUtils.GetRateOfChange(low, PreviousCandleData.close); } }
        public double BasicPrice_Close { get { return PPUtils.GetRateOfChange(close, PreviousCandleData.close); } }
        public double BasicPrice_Center
        {
            get
            {
                return PPUtils.GetRateOfChange((high + low) / 2.0d, PreviousCandleData.close);
            }
        } 
        public double BasicPrice_Middle
        {
            get
            {
                return PPUtils.GetRateOfChange((open + close) / 2.0d, PreviousCandleData.close);
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
                return PPUtils.GetRateOfChange(PreviousCandleData.open, PreviousCandleData.PreviousCandleData.close); 
            } 
        }
        public double ComparedPreviousDayPrice_High { 
            get 
            { 
                return PPUtils.GetRateOfChange(PreviousCandleData.high, PreviousCandleData.PreviousCandleData.close);
            } 
        }
        public double ComparedPreviousDayPrice_Low { 
            get 
            { 
                return PPUtils.GetRateOfChange(PreviousCandleData.low, PreviousCandleData.PreviousCandleData.close);
            } 
        }
        public double ComparedPreviousDayPrice_Close { 
            get 
            { 
                return PPUtils.GetRateOfChange(PreviousCandleData.close, PreviousCandleData.PreviousCandleData.close);
            } 
        }
        public double ComparedPreviousDayPrice_Center
        {
            get
            {
                return PPUtils.GetRateOfChange((PreviousCandleData.high + PreviousCandleData.low) / 2.0d, PreviousCandleData.PreviousCandleData.close);
            }
        }
        public double ComparedPreviousDayPrice_Middle
        {
            get
            {
                return PPUtils.GetRateOfChange((PreviousCandleData.open + PreviousCandleData.close) / 2.0d, PreviousCandleData.PreviousCandleData.close);
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

        #region 변화정보 (시간) 
        #region 변화_챠트용
        public double Variance_ChartPrice
        {
            get
            {
                if (PreviousCandleData == null)
                    return Double.NaN;

                double tRate = 0
                     + this.BasicPrice_Open
                     + this.BasicPrice_High
                     + this.BasicPrice_Low
                     + this.BasicPrice_Close
                     + this.BasicPrice_Center
                     + this.BasicPrice_Middle
                     + this.ComparedPreviousDayPrice_Open
                     + this.ComparedPreviousDayPrice_High
                     + this.ComparedPreviousDayPrice_Low
                     + this.ComparedPreviousDayPrice_Close
                     + this.ComparedPreviousDayPrice_Center
                     + this.ComparedPreviousDayPrice_Middle
                     + PreviousCandleData.BasicPrice_Open
                     + PreviousCandleData.BasicPrice_High
                     + PreviousCandleData.BasicPrice_Low
                     + PreviousCandleData.BasicPrice_Close
                     + PreviousCandleData.BasicPrice_Center
                     + PreviousCandleData.BasicPrice_Middle
                     + PreviousCandleData.ComparedPreviousDayPrice_Open
                     + PreviousCandleData.ComparedPreviousDayPrice_High
                     + PreviousCandleData.ComparedPreviousDayPrice_Low
                     + PreviousCandleData.ComparedPreviousDayPrice_Close
                     + PreviousCandleData.ComparedPreviousDayPrice_Center
                     + PreviousCandleData.ComparedPreviousDayPrice_Middle;

                return tRate;
            }
        }
        #endregion
        #region 변화_기본_시가대비
        public double Variance_BasicPrice
        {
            get 
            {
                double tRate =
                      PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, this.BasicPrice_Open)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, this.BasicPrice_Open)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, this.BasicPrice_Open)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, this.BasicPrice_Open)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, this.BasicPrice_Open)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, this.BasicPrice_Open)

                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, this.BasicPrice_High)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, this.BasicPrice_High)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, this.BasicPrice_High)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, this.BasicPrice_High)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, this.BasicPrice_High)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, this.BasicPrice_High)

                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, BasicPrice_Low)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, BasicPrice_Low)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, BasicPrice_Low)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, BasicPrice_Low)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, BasicPrice_Low)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, BasicPrice_Low)

                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, BasicPrice_Close)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, BasicPrice_Close)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, BasicPrice_Close)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, BasicPrice_Close)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, BasicPrice_Close)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, BasicPrice_Close)

                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, BasicPrice_Center)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, BasicPrice_Center)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, BasicPrice_Center)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, BasicPrice_Center)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, BasicPrice_Center)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, BasicPrice_Center)

                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, BasicPrice_Middle)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, BasicPrice_Middle)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, BasicPrice_Middle)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, BasicPrice_Middle)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, BasicPrice_Middle)
                    + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, BasicPrice_Middle);

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
                     PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, this.ComparedPreviousDayPrice_Open)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, this.ComparedPreviousDayPrice_Open)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, this.ComparedPreviousDayPrice_Open)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close, this.ComparedPreviousDayPrice_Open)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, this.ComparedPreviousDayPrice_Open)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, this.ComparedPreviousDayPrice_Open)

                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, this.ComparedPreviousDayPrice_High)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, this.ComparedPreviousDayPrice_High)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, this.ComparedPreviousDayPrice_High)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close,  this.ComparedPreviousDayPrice_High)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, this.ComparedPreviousDayPrice_High)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, this.ComparedPreviousDayPrice_High)

                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, ComparedPreviousDayPrice_Low)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, ComparedPreviousDayPrice_Low)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, ComparedPreviousDayPrice_Low)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close,  ComparedPreviousDayPrice_Low)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, ComparedPreviousDayPrice_Low)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, ComparedPreviousDayPrice_Low)

                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, ComparedPreviousDayPrice_Close)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, ComparedPreviousDayPrice_Close)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, ComparedPreviousDayPrice_Close)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close,  ComparedPreviousDayPrice_Close)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, ComparedPreviousDayPrice_Close)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, ComparedPreviousDayPrice_Close)

                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, ComparedPreviousDayPrice_Center)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, ComparedPreviousDayPrice_Center)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, ComparedPreviousDayPrice_Center)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close,  ComparedPreviousDayPrice_Center)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, ComparedPreviousDayPrice_Center)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, ComparedPreviousDayPrice_Center)

                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Open, ComparedPreviousDayPrice_Middle)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_High, ComparedPreviousDayPrice_Middle)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Low, ComparedPreviousDayPrice_Middle)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Close,  ComparedPreviousDayPrice_Middle)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Center, ComparedPreviousDayPrice_Middle)
                   + PPUtils.GetAvgRateOfChange(this.BasicPrice_Middle, ComparedPreviousDayPrice_Middle);
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
                    + Variance_ComparedPreviousDayPrice) / 2.0;
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

                //return SpaceTotal;
            }
        }
        public double TimeEnergy
        {
            get
            {
                //double energy1 = PPUtils.GetAvgRateOfChange(Variance_BasicPrice, VarianceTotalRate);
                //double energy2 = PPUtils.GetAvgRateOfChange(Variance_ComparedPreviousDayPrice, VarianceTotalRate);
                
                //return (energy1 + energy2) / 2.0;


                return Variance_ChartPrice;
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
