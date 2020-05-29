using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    /// <summary>
    /// 
    /// </summary>
    public class T_CandleAntiCandleItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        private List<S_CandleItemData> sourceDataArray = null;

        public T_CandleAntiCandleItemData(S_CandleItemData sourceData)
        {         
            this.sourceData = sourceData;
            this.sourceDataArray = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDataArray"></param>
        public T_CandleAntiCandleItemData(S_CandleItemData sourceData, List<S_CandleItemData> sourceDataArray)
        {
            this.sourceData = sourceData;
            this.sourceDataArray = sourceDataArray;
        }

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
                   
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static List<S_CandleItemData> GetFlow(List<S_CandleItemData> sourceDataArray)
        {
            if (sourceDataArray == null) return null;

            List<S_CandleItemData> resultList = new List<S_CandleItemData>();

            try
            {
                for (int i = 1; i < sourceDataArray.Count; i++)
                {
                    if (i == sourceDataArray.Count - 1)
                    {
                        var bCandle = sourceDataArray[i - 1];
                        var cCandle = sourceDataArray[i];

                        if ((bCandle.PlusMinusType == PlusMinusTypeEnum.양 && cCandle.PlusMinusType == PlusMinusTypeEnum.음)
                            || (bCandle.PlusMinusType == PlusMinusTypeEnum.음 && cCandle.PlusMinusType == PlusMinusTypeEnum.양))
                        {
                            S_CandleItemData item = new S_CandleItemData(
                                    cCandle.ItemCode
                                , cCandle.OpenPrice
                                , cCandle.QuantumBaseHighPrice
                                , cCandle.QuantumBaseLowPrice
                                , cCandle.QuantumBasePrice
                                , cCandle.Volume
                                , cCandle.DTime
                                );

                            resultList.Add(item);
                        }
                        else
                        {
                            S_CandleItemData item = new S_CandleItemData(
                                       cCandle.ItemCode
                                   , cCandle.OpenPrice
                                   , cCandle.HighPrice
                                   , cCandle.LowPrice
                                   , cCandle.ClosePrice
                                   , cCandle.Volume
                                   , cCandle.DTime
                                   );

                            resultList.Add(item);
                        }
                    }
                    else
                    {
                        var bCandle = sourceDataArray[i - 1];
                        var cCandle = sourceDataArray[i];
                        var fCandle = sourceDataArray[i + 1];

                        int pCnt = 0, mCnt = 0;

                        if (bCandle.PlusMinusType == PlusMinusTypeEnum.양) pCnt++;
                        else if (bCandle.PlusMinusType == PlusMinusTypeEnum.음) mCnt++;

                        if (cCandle.PlusMinusType == PlusMinusTypeEnum.양) pCnt++;
                        else if (cCandle.PlusMinusType == PlusMinusTypeEnum.음) mCnt++;

                        if (fCandle.PlusMinusType == PlusMinusTypeEnum.양) pCnt++;
                        else if (fCandle.PlusMinusType == PlusMinusTypeEnum.음) mCnt++;

                        if ((pCnt > mCnt && cCandle.PlusMinusType == PlusMinusTypeEnum.음)
                            || (pCnt < mCnt && cCandle.PlusMinusType == PlusMinusTypeEnum.양)
                            ) // 음을 반양으로 변경   양을 반음으로 변경
                        {
                            S_CandleItemData item = new S_CandleItemData(
                                    cCandle.ItemCode
                                , cCandle.OpenPrice
                                , cCandle.QuantumBaseHighPrice
                                , cCandle.QuantumBaseLowPrice
                                , cCandle.QuantumBasePrice
                                , cCandle.Volume
                                , cCandle.DTime
                                );

                            resultList.Add(item);
                        }
                        else
                        {
                            S_CandleItemData item = new S_CandleItemData(
                                       cCandle.ItemCode
                                   , cCandle.OpenPrice
                                   , cCandle.HighPrice
                                   , cCandle.LowPrice
                                   , cCandle.ClosePrice
                                   , cCandle.Volume
                                   , cCandle.DTime
                                   );

                            resultList.Add(item);
                        }
                    }

                }
            }
            catch (Exception)
            {
            }

            return resultList;            
        }
    }
}
