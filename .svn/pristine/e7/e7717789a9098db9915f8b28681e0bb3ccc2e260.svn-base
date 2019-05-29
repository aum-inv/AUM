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
    public class T_VelocityItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;    
        private List<S_CandleItemData> sourceDataArray = null;

        public T_VelocityItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;        
        }      
       
        public T_VelocityItemData(
            S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;            
            this.sourceDataArray = sourceDataArray;            
        }       

        private Single t_open = 0;
        private Single t_high = 0;
        private Single t_low = 0;
        private Single t_close = 0;
        public Single T_OpenPrice { get { return (Single)Math.Round(t_open, RoundLength); } }
        public Single T_HighPrice { get { return (Single)Math.Round(t_high, RoundLength); } }
        public Single T_LowPrice { get { return (Single)Math.Round(t_low, RoundLength); } }
        public Single T_ClosePrice { get { return (Single)Math.Round(t_close, RoundLength); } }
     

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
                }

                List<float> tOpenList = new List<float>();
                List<float> tCloseList = new List<float>();
                List<float> tHighList = new List<float>();
                List<float> tLowList = new List<float>();
                if (sourceDataArray != null)
                {   
                    foreach (var item in sourceDataArray)
                    {
                        tOpenList.Add(Math.Abs(ClosePrice - item.OpenPrice));
                        tCloseList.Add(Math.Abs(ClosePrice - item.ClosePrice));
                        tHighList.Add(Math.Abs(ClosePrice - item.HighPrice));
                        tLowList.Add(Math.Abs(ClosePrice - item.LowPrice));
                    }

                    t_open = (Single)Math.Round(tOpenList.Average(), RoundLength);
                    t_close = (Single)Math.Round(tCloseList.Average(), RoundLength);
                    t_high = (Single)Math.Round(tHighList.Average(), RoundLength);
                    t_low = (Single)Math.Round(tLowList.Average(), RoundLength);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
