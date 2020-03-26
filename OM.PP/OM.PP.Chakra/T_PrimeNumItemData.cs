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
    public class T_PrimeNumItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
    
        private List<S_CandleItemData> sourceDataArray = null;

        public T_PrimeNumItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = null;           
        }      
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_PrimeNumItemData(
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
                    for(int i = sourceDataArray.Count - 1; i >= 0; i--)
                    {                        
                        var cItem = sourceDataArray[i];

                        if (DTime <= cItem.DTime) continue;

                        if (isPrime(num) && WuXingType != WuXingTypeEnum.없음)
                        {
                            DTimeS = cItem.DTime;

                            AccuIdx = num;

                            break;
                        }

                        OpenPrice = cItem.OpenPrice;
                        if (HighPrice < cItem.HighPrice) HighPrice = cItem.HighPrice;
                        if (LowPrice > cItem.LowPrice) LowPrice = cItem.LowPrice;

                        num++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool isPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return false;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
