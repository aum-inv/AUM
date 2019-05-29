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
    public class T_SLHItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        public T_SLHItemData(S_CandleItemData sourceData)
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
        
        public S_CandleItemData SourceData { get { return sourceData; } }

        private SLHTypeEnum slhType = SLHTypeEnum.없음;

        public SLHTypeEnum SLHType { get { return slhType; } }

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
                    
                    t_high = sourceData.HighPrice;
                    t_low = sourceData.LowPrice;
                    t_close = sourceData.ClosePrice;
                    t_open = sourceData.QuantumPrice;

                    if (PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        if (t_open < t_low) t_low = t_open;
                    }
                    if (PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        if (t_open > t_high) t_high = t_open;
                    }

                    Single totalLength = t_high - t_low;
                    if (t_open < t_close && t_open == t_low && t_close < t_high)
                    {                       
                        Single bodyLength = t_close - t_open;                       
                        int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                        if(bodyLengthRate >= 70)
                            slhType = SLHTypeEnum.천;
                    }
                    else if (t_open > t_close && t_open == t_high && t_close > t_low)
                    {
                        Single bodyLength = t_open - t_close;
                        int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                        if (bodyLengthRate >= 70)                           
                            slhType = SLHTypeEnum.지;
                    }
                    else if (t_open != t_high && t_open != t_low && t_close != t_high && t_close != t_low)
                    {
                        if (t_open < t_close)
                        {
                            Single bodyLength = t_close - t_open;
                            Single headLength = t_high - t_close;                            
                            Single legLength = t_open - t_low;
                            int headLengthRate = (int)(headLength / totalLength * 100.0);
                            int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                            int legLengthRate = (int)(legLength / totalLength * 100.0);

                            if (bodyLengthRate >= 60 & (headLengthRate + legLengthRate) >= 25)
                                slhType = SLHTypeEnum.인;
                        }
                        else if (t_open > t_close)
                        {
                            Single bodyLength = t_open - t_close;
                            Single headLength = t_high - t_open;
                            Single legLength = t_close - t_low;
                            int headLengthRate = (int)(headLength / totalLength * 100.0);
                            int bodyLengthRate = (int)(bodyLength / totalLength * 100.0);
                            int legLengthRate = (int)(legLength / totalLength * 100.0);

                            if (bodyLengthRate >= 60 & (headLengthRate + legLengthRate) >= 25)
                                slhType = SLHTypeEnum.인;
                        }                       
                    }
                    else if ((t_open == t_high && t_close == t_low) || (t_open == t_low && t_close == t_high))
                        slhType = SLHTypeEnum.무;

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}