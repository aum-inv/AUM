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
    public class T_FiveColorItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        private List<S_CandleItemData> sourceDataArray = null;
              
        /// <summary>
        /// 최근 시고저종을 찾고, 거기에서 퀀텀을 만든다.
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_FiveColorItemData(S_CandleItemData sourceData, List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }

        public S_CandleItemData T1 = new S_CandleItemData();
        public S_CandleItemData T2 = new S_CandleItemData();
        public S_CandleItemData T3 = new S_CandleItemData();
        public S_CandleItemData T4 = new S_CandleItemData();
        public S_CandleItemData T5 = new S_CandleItemData();
        public S_CandleItemData T6 = new S_CandleItemData();
        public S_CandleItemData T7 = new S_CandleItemData();
        public S_CandleItemData T8 = new S_CandleItemData();
        public S_CandleItemData T9 = new S_CandleItemData();
        public S_CandleItemData T10 = new S_CandleItemData();

        public List<S_CandleItemData> SourceDataArray { get { return sourceDataArray; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Transform()
        {
            try
            {
                this.DTime = sourceData.DTime;

                if (sourceDataArray != null)
                {
                    S_CandleItemData[] datas = { T1, T2, T3, T4, T5, T6, T7, T8, T9, T10 };

                    List<double> hList = new List<double>();
                    List<double> lList = new List<double>();
                    List<double> cList = new List<double>();
                    List<double> oList = new List<double>();

                    int idx = 0;
                    for(int i = sourceDataArray.Count - 1; i >= 0; i--)
                    {
                        var item = sourceDataArray[i];
                        hList.Add(item.HighPrice);
                        lList.Add(item.LowPrice);
                        oList.Add(item.OpenPrice);
                        cList.Add(item.ClosePrice);
                                         
                        datas[idx].HighPrice = (Single)hList.Max();
                        datas[idx].LowPrice = (Single)cList.Min();
                        datas[idx].OpenPrice = (Single)oList.Last();
                        datas[idx].ClosePrice = (Single)cList.First();
                        idx++;

                        if (idx >= 10) break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
