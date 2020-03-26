using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    /// <summary>
    /// 
    /// </summary>
    public class T_ThaChiItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
    
        private List<S_CandleItemData> sourceDataArray = null;

        public T_ThaChiItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = null;           
        }      
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_ThaChiItemData(
            S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;            
            this.sourceDataArray = sourceDataArray;            
        }

        private Single t_plusAvg = 0;
        private Single t_minusAvg = 0;
        private Single t_totalAvg = 0;

        public Single T_PlusAvg{ get { return (Single)Math.Round(t_plusAvg, RoundLength); } }
        public Single T_MinusAvg { get { return (Single)Math.Round(t_minusAvg, RoundLength); } }
        public Single T_TotalAvg { get { return (Single)Math.Round(t_totalAvg, RoundLength); } }
        
        private Single t_open = 0;
        private Single t_high = 0;
        private Single t_low = 0;
        private Single t_close = 0;
        public Single T_OpenPrice { get { return (Single)Math.Round(t_open, RoundLength); } }
        public Single T_HighPrice { get { return (Single)Math.Round(t_high, RoundLength); } }
        public Single T_LowPrice { get { return (Single)Math.Round(t_low, RoundLength); } }
        public Single T_ClosePrice { get { return (Single)Math.Round(t_close, RoundLength); } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Transform()
        {
            try
            {
                if (sourceData != null)
                {
                    ItemCode = sourceData.ItemCode;

                    OpenPrice = sourceData.OpenPrice;
                    HighPrice = sourceData.HighPrice;
                    LowPrice = sourceData.LowPrice;
                    ClosePrice = sourceData.ClosePrice;
                    DTime = sourceData.DTime;

                    if (this.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        t_open = 0;
                        t_close = MiddlePrice - CenterPrice;
                        t_high = t_close;
                        t_low = 0;
                    }
                    else if (this.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        t_open = 0;
                        t_close = MiddlePrice - CenterPrice;
                        t_high = 0;
                        t_low = t_close;
                    }                   
                }

                if (sourceDataArray != null)
                {
                    List<double> pList = new List<double>();
                    List<double> mList = new List<double>();
                    List<double> tList = new List<double>();
                    foreach (var item in sourceDataArray)
                    {
                        if (item.PlusMinusType == PlusMinusTypeEnum.양)
                            pList.Add(item.MiddlePrice - item.CenterPrice);
                        else if (item.PlusMinusType == PlusMinusTypeEnum.음)
                            mList.Add(item.MiddlePrice - item.CenterPrice);     
                        
                        tList.Add(item.MiddlePrice - item.CenterPrice);
                    }

                    t_plusAvg = pList.Count == 0 ? 0 : (Single)Math.Round(pList.Average(), 2);
                    t_minusAvg = mList.Count == 0 ? 0 : (Single)Math.Round(mList.Average(), 2);
                    t_totalAvg = tList.Count == 0 ? 0 : (Single)Math.Round(tList.Average(), 2);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
