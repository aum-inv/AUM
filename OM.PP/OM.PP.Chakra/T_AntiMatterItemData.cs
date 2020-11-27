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
        
        public Single u_HighAvg = 0;
        public Single u_LowAvg = 0;                  
        public Single U_HighAvg { get { return (Single)Math.Round(u_HighAvg, RoundLength); } }
        public Single U_LowAvg { get { return (Single)Math.Round(u_LowAvg, RoundLength); } }

        public Single d_HighAvg = 0;
        public Single d_LowAvg = 0;
        public Single D_HighAvg { get { return (Single)Math.Round(d_HighAvg, RoundLength); } }
        public Single D_LowAvg { get { return (Single)Math.Round(d_LowAvg, RoundLength); } }
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
                    u_HighAvg = (Single)sourceDataArray.Average(t => t.U_HighPrice + HeadLength + LegLength);
                    u_LowAvg = (Single)sourceDataArray.Average(t => t.U_LowPrice + HeadLength + LegLength);

                    d_HighAvg = (Single)sourceDataArray.Average(t => t.D_HighPrice - HeadLength - LegLength);
                    d_LowAvg = (Single)sourceDataArray.Average(t => t.D_LowPrice - HeadLength - LegLength);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
