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
    public class T_QuantumItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;
        List<S_CandleItemData> sourceDataArray = null; 
        List<S_CandleItemData> sourceDataArray2 = null;

        private Single t_openAvg = 0;
        private Single t_closeAvg = 0;
        private Single t_highAvg = 0;
        private Single t_lowAvg = 0;

        public Single t_VikalaAvg = 0;
        public Single t_TotalCenterAvg = 0;

        public Single T_OpenAvg { get { return (Single)Math.Round(t_openAvg, RoundLength); } }
        public Single T_CloseAvg { get { return (Single)Math.Round(t_closeAvg, RoundLength); } }
        public Single T_HighAvg { get { return (Single)Math.Round(t_highAvg, RoundLength); } }
        public Single T_LowAvg { get { return (Single)Math.Round(t_lowAvg, RoundLength); } }


        private Single t_massAvg = 0;
        private Single t_quantumAvg = 0;
        private Single t_quantumHighAvg = 0;
        private Single t_quantumLowAvg = 0;

        private Single t_massAvg2 = 0;
        private Single t_quantumAvg2 = 0;
        private Single t_quantumHighAvg2 = 0;
        private Single t_quantumLowAvg2 = 0;

        private Single t_vikalaHighAvg = 0;
        private Single t_vikalaLowAvg = 0;

        public Single T_MassAvg { get { return (Single)Math.Round(t_massAvg, RoundLength); } }
        public Single T_QuantumAvg { get { return (Single)Math.Round(t_quantumAvg, RoundLength); } }
        public Single T_QuantumHighAvg { get { return (Single)Math.Round(t_quantumHighAvg, RoundLength); } }
        public Single T_QuantumLowAvg { get { return (Single)Math.Round(t_quantumLowAvg, RoundLength); } }

        public Single T_MassAvg2 { get { return (Single)Math.Round(t_massAvg2, RoundLength); } }
        public Single T_QuantumAvg2 { get { return (Single)Math.Round(t_quantumAvg2, RoundLength); } }
        public Single T_QuantumHighAvg2 { get { return (Single)Math.Round(t_quantumHighAvg2, RoundLength); } }
        public Single T_QuantumLowAvg2 { get { return (Single)Math.Round(t_quantumLowAvg2, RoundLength); } }

        public Single T_VikalaHighAvg { get { return (Single)Math.Round(t_vikalaHighAvg, RoundLength); } }
        public Single T_VikalaLowAvg { get { return (Single)Math.Round(t_vikalaLowAvg, RoundLength); } }

        public Single T_VikalaAvg { get { return (Single)Math.Round(t_VikalaAvg, RoundLength); } }
        public Single T_TotalCenterAvg { get { return (Single)Math.Round(t_TotalCenterAvg, RoundLength); } }
        /// <summary>
        /// 당일 가격만 가지고 퀀텀데이터 만든다.
        /// </summary>
        /// <param name="sourceData"></param>
        public T_QuantumItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
        }
        /// <summary>
        /// 전일가격 및 당일가격으로 퀀텀데이터 만든다.
        /// </summary>
        /// <param name="sourceBData"></param>
        /// <param name="sourceCData"></param>
        public T_QuantumItemData(S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }
        
        public S_CandleItemData Source1Data { get { return sourceData; } }
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

                //t_openAvg = OpenPriceAvg = (Single)sourceDataArray.Average(t => t.OpenPrice);
                t_closeAvg = ClosePriceAvg = (Single)sourceDataArray.Average(t => t.ClosePrice);
                //t_highAvg = HighPriceAvg = (Single)sourceDataArray.Average(t => t.HighPrice);
                //t_lowAvg = LowPriceAvg = (Single)sourceDataArray.Average(t => t.LowPrice);

                t_quantumAvg = (Single)sourceDataArray.Average(t => t.QuantumBasePrice);
                t_quantumHighAvg = (Single)sourceDataArray.Average(t => t.QuantumHighPrice);
                t_quantumLowAvg = (Single)sourceDataArray.Average(t => t.QuantumLowPrice);
                t_massAvg = (Single)sourceDataArray.Average(t => t.MassPrice);

                //t_VikalaAvg = (Single)sourceDataArray.Average(t => t.VikalaPrice);
                //t_vikalaHighAvg = (Single)sourceDataArray.Average(t => t.VikalaHighPrice);
                //t_vikalaLowAvg = (Single)sourceDataArray.Average(t => t.VikalaLowPrice);

                //t_TotalCenterAvg = (Single)sourceDataArray.Average(t => t.TotalCenterPrice);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}

