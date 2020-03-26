using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    /// <summary>
    /// 천지인 데이터
    /// </summary>
    public class T_ThreeThreeItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        public T_ThreeThreeItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
        }
     
        private Single t_open = 0;
        private Single t_high = 0;
        private Single t_low = 0;
        private Single t_close = 0;
        public Single T_OpenPrice { get { return (Single)Math.Round(t_open, RoundLength); } }
        public Single T_HighPrice { get { return (Single)Math.Round(t_high, RoundLength); } }
        public Single T_LowPrice { get { return (Single)Math.Round(t_low, RoundLength); } }
        public Single T_ClosePrice { get { return (Single)Math.Round(t_close, RoundLength); } }

        private ThreeThreeTypeEnum ttType = ThreeThreeTypeEnum.없음;

        public ThreeThreeTypeEnum TTType { get { return ttType; } }

        public S_CandleItemData SourceData { get { return sourceData; } }
        
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
                    
                    t_open = sourceData.OpenPrice;
                    t_high = sourceData.HighPrice;
                    t_low = sourceData.LowPrice;
                    t_close = sourceData.ClosePrice;
                    
                    Single cOpen = OpenPrice < ClosePrice ? OpenPrice : ClosePrice;
                    Single cClose = OpenPrice < ClosePrice ? ClosePrice : OpenPrice;
                    Single cHigh = OpenPrice < ClosePrice ? HighPrice : HighPrice;
                    Single cLow = OpenPrice < ClosePrice ? LowPrice : LowPrice;

                    Single totalLength = cHigh - cLow;
                    Single headLength = cHigh - cClose;
                    Single bodyLength = cClose - cOpen;
                    Single legLength = cOpen - cLow;

                    int headLengthRate = (int)(headLength / totalLength * 100.0);
                    int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                    int legLengthRate = (int)(legLength / totalLength * 100.0);
                   
                    if (무극여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.무극;
                    else if (태양여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.태양;
                    else if (양명여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.양명;
                    else if (소양여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.소양;
                    else if (태음여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.태음;
                    else if (소음여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.소음;
                    else if (궐음여부(headLengthRate, bodyLengthRate, legLengthRate)) ttType = ThreeThreeTypeEnum.궐음;
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool 무극여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {  
            bool isTrue = (headLengthRate >= 30.0 && bodyLengthRate >= 30.0 && legLengthRate >= 30.0) ;

            return isTrue;
        }

        private bool 태양여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice > ClosePrice) return false;
            bool isTrue = false;
            if ((headLengthRate + bodyLengthRate) >= 70.0 && headLengthRate == bodyLengthRate)
            {
                isTrue = true;
            }

            return isTrue;
        }
        private bool 양명여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice > ClosePrice) return false;

            bool isTrue = false;
            if ((headLengthRate + bodyLengthRate) >= 70.0 && headLengthRate > bodyLengthRate)
            {
                isTrue = true;
            }

            return isTrue;
        }
        private bool 소양여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice > ClosePrice) return false;
            bool isTrue = false;
            if ((headLengthRate + bodyLengthRate) >= 70 && headLengthRate < bodyLengthRate)
            {
                isTrue = true;
            }
            return isTrue;
        }

        private bool 태음여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice < ClosePrice) return false;
            bool isTrue = false;
            if ((legLengthRate + bodyLengthRate) >= 70 && legLengthRate == bodyLengthRate)
            {
                isTrue = true;
            }
            return isTrue;
        }
        private bool 소음여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice < ClosePrice) return false;

            bool isTrue = false;
            if ((legLengthRate + bodyLengthRate) >= 70 && legLengthRate > bodyLengthRate)
            {
                isTrue = true;
            }
            return isTrue;
        }
        private bool 궐음여부(int headLengthRate, int bodyLengthRate, int legLengthRate)
        {
            if (OpenPrice < ClosePrice) return false;

            bool isTrue = false;
            if ((legLengthRate + bodyLengthRate) >= 70 && legLengthRate < bodyLengthRate)
            {
                isTrue = true;
            }
            return isTrue;
        }

    }
}