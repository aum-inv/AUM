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
    public class T_AntiMatterItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        private List<S_CandleItemData> sourceDataArray = null;

        public T_AntiMatterItemData(S_CandleItemData sourceData)
        {         
            this.sourceData = sourceData;
            this.sourceDataArray = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_AntiMatterItemData(S_CandleItemData sourceData, List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }
        
        public Single t_Avg = 0;
        public Single t_HighAvg = 0;
        public Single t_LowAvg = 0;       
        public Single t_MassAvg = 0;       
        public Single t_TotalCenterAvg = 0;

        public Single T_Avg { get { return (Single)Math.Round(t_Avg, RoundLength); } }
        public Single T_MassAvg { get { return (Single)Math.Round(t_MassAvg, RoundLength); } }
        
        public Single T_HighAvg { get { return (Single)Math.Round(t_HighAvg, RoundLength); } }

        public Single T_LowAvg { get { return (Single)Math.Round(t_LowAvg, RoundLength); } }

        public Single T_TotalCenterAvg { get { return (Single)Math.Round(t_TotalCenterAvg, RoundLength); } }

        public A_HLOC Source1Data { get { return sourceData; } }
        
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
                }

                if (sourceDataArray != null)
                {
                    t_Avg = (Single)sourceDataArray.Average(t => t.ClosePrice);
                    t_HighAvg = (Single)sourceDataArray.Average(t => t.HighPrice);
                    t_LowAvg = (Single)sourceDataArray.Average(t => t.LowPrice);
                    t_MassAvg = (Single)sourceDataArray.Average(t => t.MassPrice);
                    t_TotalCenterAvg = (Single)sourceDataArray.Average(t => t.TotalCenterPrice);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
