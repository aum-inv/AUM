using OM.PP.Chakra.Indicators;
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
    public class T_ParkItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        private List<S_CandleItemData> sourceDataArray = null;
        private List<ParabolicSarResult> psarList = null;
        private List<ParabolicSarResult> psarList2 = null;
        public T_ParkItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = null;
        }
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_ParkItemData(S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }
        
        public T_ParkItemData(S_CandleItemData sourceData
            , List<S_CandleItemData> sourceDataArray
            , List<ParabolicSarResult> psarList
            , List<ParabolicSarResult> psarList2)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
            this.psarList = psarList;
            this.psarList2 = psarList2;
        }
        private Single t_Psar = 0;       

        public Single T_Psar { get { return (Single)Math.Round(t_Psar, RoundLength); } }

        private Single t_Psar2 = 0;

        public Single T_Psar2 { get { return (Single)Math.Round(t_Psar2, RoundLength); } }

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
                if (psarList != null)
                {                    
                    decimal? bSar = 0m;
                    var sub = psarList.Where(t =>
                    (t.Date.Year == DTime.Year
                        && t.Date.Month == DTime.Month
                        && t.Date.Day == DTime.Day
                        )).First();
                    if (sub != null)
                    {
                        bSar = sub.Sar;
                    }

                    if (bSar <= 0m) t_Psar = Single.NaN;
                    else t_Psar = Convert.ToSingle(bSar);
                }

                if (psarList2 != null)
                {
                    decimal? bSar = 0m;
                    var sub = psarList2.Where(t =>
                    (t.Date.Year == DTime.Year
                        && t.Date.Month == DTime.Month
                        && t.Date.Day == DTime.Day                       
                        )).First();
                    if (sub != null)
                    {
                        bSar = sub.Sar;
                    }
                    if (bSar <= 0m) t_Psar2 = Single.NaN;
                    else t_Psar2 = Convert.ToSingle(bSar);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
