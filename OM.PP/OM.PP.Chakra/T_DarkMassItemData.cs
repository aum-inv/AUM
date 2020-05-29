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
    public class T_DarkMassItemData : S_CandleItemData, ITransform
    {
        

        private S_CandleItemData sourceData = null;

        private List<S_CandleItemData> sourceDataArray = null;

        public T_DarkMassItemData(S_CandleItemData sourceData)
        {         
            this.sourceData = sourceData;
            this.sourceDataArray = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_DarkMassItemData(S_CandleItemData sourceData, List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }
        
        public Single u_darkMassAvg = 0;
        public Single U_DarkMassAvg { get { return (Single)Math.Round(u_darkMassAvg, RoundLength); } }
     
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
                    u_darkMassAvg = (Single)sourceDataArray.Average(t => t.DarkMassPrice);               
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
