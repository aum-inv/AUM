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
    public class T_MirrorItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
        List<S_CandleItemData> sourceDataArray = null;

        public Single t_open = 0;
        public Single t_high = 0;
        public Single t_low = 0;
        public Single t_close = 0;
        public Single T_OpenPrice { get { return (Single)Math.Round(t_open, RoundLength); } }
        public Single T_HighPrice { get { return (Single)Math.Round(t_high, RoundLength); } }
        public Single T_LowPrice { get { return (Single)Math.Round(t_low, RoundLength); } }
        public Single T_ClosePrice { get { return (Single)Math.Round(t_close, RoundLength); } }

        public T_MirrorItemData(S_CandleItemData sourceData, List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }
        
        public S_CandleItemData SourceData { get { return sourceData; } }
        public List<S_CandleItemData> SourceDataArray { get { return sourceDataArray; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Transform()
        {
            try
            {
                ItemCode = sourceData.ItemCode;
                OpenPrice = sourceData.OpenPrice;
                HighPrice = sourceData.HighPrice;
                LowPrice = sourceData.LowPrice;
                ClosePrice = sourceData.ClosePrice;
                DTime = sourceData.DTime;

                double maxPrice = sourceDataArray.Max(t => t.HighPrice);
                //int idx = sourceDataArray.FindIndex(t => t.DTime == DTime);
                //idx = sourceDataArray.Count - idx - 1;

                //DTime = sourceDataArray[idx].DTime;
                t_open = (Single)Math.Round((maxPrice - OpenPrice), RoundLength);
                t_high = (Single)Math.Round((maxPrice - HighPrice), RoundLength);
                t_low = (Single)Math.Round((maxPrice - LowPrice), RoundLength);
                t_close = (Single)Math.Round((maxPrice - ClosePrice), RoundLength);
            }
            catch (Exception ex)
            {
            }
        }
    }
}

