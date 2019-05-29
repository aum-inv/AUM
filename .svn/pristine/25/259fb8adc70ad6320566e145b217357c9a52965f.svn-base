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
    public class T_QuarkItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
        private List<S_CandleItemData> sourceDataArray = null;

        public T_QuarkItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = null;
        }
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_QuarkItemData(
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

        public DateTime DTimeS { get; set; }
        public DateTime DTimeE { get; set; }
        public int AccuIdx { get; set; }

        public S_CandleItemData SourceData { get { return sourceData; } }

        private QuarkTypeEnum quarkType = QuarkTypeEnum.없음;

        public QuarkTypeEnum QuarkType { get { return quarkType; } }

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

                    t_open = sourceData.QuantumPrice;
                    t_high = sourceData.HighPrice;
                    t_low = sourceData.LowPrice;
                    t_close = sourceData.ClosePrice;                 

                    if (PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        if (t_open < t_low) t_low = t_open;
                    }
                    if (PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        if (t_open > t_high) t_high = t_open;
                    }

                    if (t_open < t_close && t_open == t_low && t_close < t_high)
                    {
                        double l1 = Math.Round(Math.Abs(t_open - t_close), RoundLength);
                        double l2 = Math.Round(Math.Abs(t_close - t_high), RoundLength);
                        if (l1 < l2) quarkType = QuarkTypeEnum.빨쿼크_양;
                        if (l1 > l2) quarkType = QuarkTypeEnum.빨쿼크_음;
                        if (l1 == l2) quarkType = QuarkTypeEnum.빨쿼크_무;
                    }

                    if (t_open > t_close && t_open == t_high && t_close > t_low)
                    {
                        double l1 = Math.Round(Math.Abs(t_open - t_close), RoundLength);
                        double l2 = Math.Round(Math.Abs(t_close - t_low), RoundLength);
                        if (l1 < l2) quarkType = QuarkTypeEnum.파쿼크_양;
                        if (l1 > l2) quarkType = QuarkTypeEnum.파쿼크_음;
                        if (l1 == l2) quarkType = QuarkTypeEnum.파쿼크_무;
                    }

                    if (t_open < t_close && t_open > t_low && t_close < t_high)                        
                    {
                        double l1 = Math.Round(Math.Abs(t_close - t_high), RoundLength);
                        double l2 = Math.Round(Math.Abs(t_open - t_close), RoundLength);
                        double l3 = Math.Round(Math.Abs(t_open - t_low), RoundLength);                       
                        if (l1 == l3) quarkType = QuarkTypeEnum.초쿼크_무;                                               
                        if (l1 > l3) quarkType = QuarkTypeEnum.초쿼크_양;
                        if (l1 < l3) quarkType = QuarkTypeEnum.초쿼크_음;
                    }
                    if (t_open > t_close && t_open < t_high && t_close > t_low)
                    {
                        double l1 = Math.Round(Math.Abs(t_open - t_high), RoundLength);
                        double l2 = Math.Round(Math.Abs(t_open - t_close), RoundLength);
                        double l3 = Math.Round(Math.Abs(t_close - t_low), RoundLength);
                        if (l1 == l3) quarkType = QuarkTypeEnum.초쿼크_무;                             
                        if (l1 > l3) quarkType = QuarkTypeEnum.초쿼크_양;
                        if (l1 < l3) quarkType = QuarkTypeEnum.초쿼크_음;
                    }
                    else if ((t_open == t_high && t_close == t_low) || (t_open == t_low && t_close == t_high))
                        quarkType = QuarkTypeEnum.무;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}