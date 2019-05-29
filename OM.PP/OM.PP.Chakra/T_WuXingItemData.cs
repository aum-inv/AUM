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
    public class T_WuXingItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
    
        private List<S_CandleItemData> sourceDataArray = null;

        public T_WuXingItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = null;           
        }      
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_WuXingItemData(
            S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;            
            this.sourceDataArray = sourceDataArray;            
        }

        public DateTime DTimeS { get; set; }
        public DateTime DTimeE { get; set; }

        public int AccuIdx { get; set; }
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
                    DTimeE = DTime = sourceData.DTime;    
                }

                if (sourceDataArray != null)
                { 
                    int num = 1;
                    for (int i = sourceDataArray.Count - 1; i >= 0; i--)
                    {
                        var cItem = sourceDataArray[i];

                        if (DTime <= cItem.DTime) continue;                                  

                        OpenPrice = cItem.OpenPrice;
                        if (HighPrice < cItem.HighPrice) HighPrice = cItem.HighPrice;
                        if (LowPrice > cItem.LowPrice) LowPrice = cItem.LowPrice;

                        if (WuXingType != WuXingTypeEnum.없음)
                        {
                            DTimeS = cItem.DTime;

                            AccuIdx = num;

                            break;
                        }

                        num++;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
