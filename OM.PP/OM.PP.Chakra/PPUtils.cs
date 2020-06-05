using OM.Lib.Base;
using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public static class PPUtils
    {
        public static void SetModifyOpenPriceByClosePrice(List<S_CandleItemData> sourceDatas)
        {
            try
            {
                for (int i = 1; i < sourceDatas.Count; i++)
                {
                    sourceDatas[i].OpenPrice = sourceDatas[i - 1].ClosePrice;
                }
            }
            catch (Exception)
            {
            }
        }
        public static List<S_CandleItemData> GetModifyOpenPriceByClosePrice(List<S_CandleItemData> sourceDatas)
        {
            List<S_CandleItemData> modifyDatas = sourceDatas.GetRange(0, sourceDatas.Count);

            try
            {
                for (int i = 1; i < modifyDatas.Count; i++)
                {
                    modifyDatas[i].OpenPrice = sourceDatas[i - 1].ClosePrice;
                }
            }
            catch (Exception)
            {
                return modifyDatas;
            }

            return modifyDatas;
        }
        public static List<S_CandleItemData> GetAverageDatas(string itemCode, List<S_CandleItemData> sourceDatas, int averageCnt)
        {
            List<S_CandleItemData> averageDatas = new List<S_CandleItemData>();
            try
            {               
                for (int i = averageCnt; i <= sourceDatas.Count; i++)
                {
                    S_CandleItemData transData = new S_CandleItemData(itemCode, sourceDatas.GetRange(i - averageCnt, averageCnt));
                    averageDatas.Add(transData);
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return averageDatas;
        }
        public static List<S_CandleItemData> GetAccumulatedAverageDatas(string itemCode, List<S_CandleItemData> sourceDatas, int averageCnt)
        {
            List<S_CandleItemData> averageDatas = new List<S_CandleItemData>();

            try
            {
                for (int i = averageCnt; i <= sourceDatas.Count; i++)
                {
                    var subList = sourceDatas.GetRange(i - averageCnt, averageCnt);

                    List<Single> oList = new List<float>();
                    List<Single> cList = new List<float>();
                    List<Single> hList = new List<float>();
                    List<Single> lList = new List<float>();
                    for (int j = 0; j < subList.Count; j++)
                    {
                        oList.Add(subList[j].OpenPrice);
                        cList.Add(subList[j].ClosePrice);
                        hList.Add(subList[j].HighPrice);
                        lList.Add(subList[j].LowPrice);

                        subList[j].OpenPrice = oList.Average();
                        subList[j].ClosePrice = cList.Average();
                        subList[j].HighPrice = hList.Average();
                        subList[j].LowPrice = lList.Average();
                    }

                    S_CandleItemData transData = new S_CandleItemData(itemCode, sourceDatas.GetRange(i - averageCnt, averageCnt));
                    averageDatas.Add(transData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return averageDatas;
        }
        public static List<S_CandleItemData> GetCutDatas(List<S_CandleItemData> sourceDatas, DateTime dt)
        {            
            List<S_CandleItemData> sourceDatasNew = new List<S_CandleItemData>();
            try
            {
                foreach(var m in sourceDatas)
                {
                    if (m.DTime < dt) continue;

                    sourceDatasNew.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sourceDatasNew;
        }
        public static List<S_LineItemData> GetAverageDatas(string itemCode, List<S_LineItemData> sourceDatas, int averageCnt)
        {
            List<S_LineItemData> averageDatas = new List<S_LineItemData>();
            try
            {
                for (int i = averageCnt; i <= sourceDatas.Count; i++)
                {
                    S_LineItemData transData = new S_LineItemData(itemCode, sourceDatas.GetRange(i - averageCnt, averageCnt));
                    averageDatas.Add(transData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return averageDatas;
        }
        public static List<S_LineItemData> GetCutDatas(List<S_LineItemData> sourceDatas, DateTime dt)
        {
            List<S_LineItemData> sourceDatasNew = new List<S_LineItemData>();
            try
            {
                foreach (var m in sourceDatas)
                {
                    if (m.DTime < dt) continue;

                    sourceDatasNew.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sourceDatasNew;
        }

        #region Candle Pattern Util
        public static (int, PlusMinusTypeEnum) GetSameUpDownCount(LimitedList<S_CandleItemData> sourceDatas)
        {
            try
            {
                int cnt = GetSameUpDownCount(sourceDatas, PlusMinusTypeEnum.양);

                if (cnt >= 3) return (cnt, PlusMinusTypeEnum.양);

                cnt = GetSameUpDownCount(sourceDatas, PlusMinusTypeEnum.음);
                if (cnt >= 3) return (cnt, PlusMinusTypeEnum.음);

                return (0, PlusMinusTypeEnum.무); ;
            }
            catch (Exception)
            {
                return (0, PlusMinusTypeEnum.무); ;
            }
        }
        public static int GetSameUpDownCount(LimitedList<S_CandleItemData> sourceDatas, PlusMinusTypeEnum plusMinusType)
        {   
            try
            {
                List<int> rListUpDown = new List<int>();

                for (int i = 0; i < sourceDatas.Count; i++)
                {
                    var m = sourceDatas[i];
                    if (m.PlusMinusType == plusMinusType) rListUpDown.Add(1);
                    else break;
                }
                return rListUpDown.Sum();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        #endregion

        #region GetSameUpDown
        public static UpDownEnum GetSameUpDown2(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetSameUpDown(sourceDatas, 2);
        }
        public static UpDownEnum GetSameUpDown4(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetSameUpDown(sourceDatas, 4);
        }
        public static UpDownEnum GetSameUpDown5(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetSameUpDown(sourceDatas, 5);
        }
        public static UpDownEnum GetSameUpDown6(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetSameUpDown(sourceDatas, 6);
        }
        public static UpDownEnum GetSameUpDown(LimitedList<S_CandleItemData> sourceDatas, int cnt)
        {
            UpDownEnum upDown = UpDownEnum.None;
            try
            {
                List<S_CandleItemData> list = sourceDatas.GetRange(0, cnt);

                List<int> rListUpDown = new List<int>();
              
                if (list[0].PlusMinusType == PlusMinusTypeEnum.양)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];
                        if (m.PlusMinusType == PlusMinusTypeEnum.양) rListUpDown.Add(1);
                    }
                    if (cnt == rListUpDown.Sum()) upDown = UpDownEnum.Up;
                }
                else if (list[0].PlusMinusType == PlusMinusTypeEnum.음)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];
                        if (m.PlusMinusType == PlusMinusTypeEnum.음) rListUpDown.Add(1);
                    }
                    if (cnt == rListUpDown.Sum()) upDown = UpDownEnum.Down;
                }
            }
            catch (Exception)
            {
            }
            return upDown;
        }
        #endregion

        #region GetUpDown
        public static UpDownEnum GetUpDown3(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetUpDown(sourceDatas, 3);
        }
        public static UpDownEnum GetUpDown4(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetUpDown(sourceDatas, 4);
        }
        public static UpDownEnum GetUpDown5(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetUpDown(sourceDatas, 5);
        }
        public static UpDownEnum GetUpDown6(LimitedList<S_CandleItemData> sourceDatas)
        {
            return GetUpDown(sourceDatas, 6);
        }
        public static UpDownEnum GetUpDown(LimitedList<S_CandleItemData> sourceDatas, int cnt)
        {
            UpDownEnum upDown = UpDownEnum.None;

            try
            {
                List<S_CandleItemData> list = sourceDatas.GetRange(0, cnt);

                List<int> rListUpDown = new List<int>();
                List<int> rListOpen = new List<int>();
                List<int> rListHigh = new List<int>();
                List<int> rListLow = new List<int>();
                List<int> rListClose = new List<int>();
                List<int> rListMass = new List<int>();
                
                if (list[0].PlusMinusType == PlusMinusTypeEnum.양)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];                        
                        if (m.PlusMinusType == PlusMinusTypeEnum.양) rListUpDown.Add(1);                        
                    }
                    rListOpen.Add(1);
                    rListHigh.Add(1);
                    rListLow.Add(1);
                    rListClose.Add(1);
                    rListMass.Add(1);
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];
                        var m2 = list[i + 1];
                        if (m.OpenPrice < m2.OpenPrice) rListOpen.Add(1);
                        if (m.HighPrice < m2.HighPrice) rListHigh.Add(1);
                        if (m.LowPrice < m2.LowPrice) rListLow.Add(1);
                        if (m.ClosePrice < m2.ClosePrice) rListClose.Add(1);
                        if (m.MassPrice < m2.MassPrice) rListMass.Add(1);
                    }

                    //if (cnt == rListUpDown.Sum()
                    //    && cnt == rListOpen.Sum()
                    //    && cnt == rListHigh.Sum()
                    //    && cnt == rListLow.Sum()
                    //    && cnt == rListClose.Sum()
                    //    && cnt == rListMass.Sum())
                    //    upDown = UpDownEnum.StrongUp;

                    if (  ( cnt == rListUpDown.Sum()|| cnt == rListUpDown.Sum() - 1)
                       && ( cnt == rListOpen.Sum()  || cnt == rListOpen.Sum() - 1)
                       && ( cnt == rListHigh.Sum()  || cnt == rListHigh.Sum() - 1)
                       && ( cnt == rListLow.Sum()   || cnt == rListLow.Sum() - 1)
                       && ( cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                       && ( cnt == rListMass.Sum()  || cnt == rListMass.Sum() - 1))
                        upDown = UpDownEnum.StrongUp;
                    else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                      && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                        upDown = UpDownEnum.WeakUp;

                }
                else if (list[0].PlusMinusType == PlusMinusTypeEnum.음)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];
                        if (m.PlusMinusType == PlusMinusTypeEnum.음) rListUpDown.Add(1);
                    }
                    rListOpen.Add(1);
                    rListHigh.Add(1);
                    rListLow.Add(1);
                    rListClose.Add(1);
                    rListMass.Add(1);
                    for (int i = 0; i < list.Count; i++)
                    {
                        var m = list[i];
                        var m2 = list[i + 1];
                        if (m.OpenPrice > m2.OpenPrice) rListOpen.Add(1);
                        if (m.HighPrice > m2.HighPrice) rListHigh.Add(1);
                        if (m.LowPrice > m2.LowPrice) rListLow.Add(1);
                        if (m.ClosePrice > m2.ClosePrice) rListClose.Add(1);
                        if (m.MassPrice > m2.MassPrice) rListMass.Add(1);
                    }

                    if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                       && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                       && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                       && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                       && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                       && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                        upDown = UpDownEnum.StrongDown;
                    else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                      && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                        upDown = UpDownEnum.WeakDown;
                }
            }
            catch (Exception)
            {
            }
            return upDown;
        }
        #endregion

        #region Mass Pattern
        public static CandleMassPatternEnum GetMassPattern(LimitedList<S_CandleItemData> sourceDatas)
        {
            CandleMassPatternEnum upDown = CandleMassPatternEnum.None;
            if (sourceDatas.Count < 2) return upDown;
            try
            {
                List<S_CandleItemData> sourceDataList = new List<S_CandleItemData>();
                for (int i = 0; i <= 8; i++)
                    sourceDataList.Insert(0, sourceDatas[i]);

                List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

                int itemsCnt = 7;

                for (int i = itemsCnt; i <= sourceDataList.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDataList[i - 1], sourceDataList.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                var m0 = transformedDatas[2];
                var m1 = transformedDatas[1];
                var m2 = transformedDatas[0];

                if (m0.T_QuantumAvg == 0 || m0.T_MassAvg == 0) return upDown;
                if (m1.T_QuantumAvg == 0 || m1.T_MassAvg == 0) return upDown;
                if (m2.T_QuantumAvg == 0 || m2.T_MassAvg == 0) return upDown;

                if (m2.T_QuantumAvg > m2.T_MassAvg
                    && m1.T_QuantumAvg > m1.T_MassAvg
                    && m0.T_QuantumAvg > m0.T_MassAvg
                    )
                    upDown = CandleMassPatternEnum.MassDownDownDown;
                else if (m2.T_QuantumAvg < m2.T_MassAvg
                   && m1.T_QuantumAvg < m1.T_MassAvg
                   && m0.T_QuantumAvg < m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassUpUpUp;

                else if (m2.T_QuantumAvg > m2.T_MassAvg
                   && m1.T_QuantumAvg < m1.T_MassAvg
                   && m0.T_QuantumAvg < m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassDownUpUp;
                else if (m2.T_QuantumAvg < m2.T_MassAvg
                   && m1.T_QuantumAvg > m1.T_MassAvg
                   && m0.T_QuantumAvg > m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassUpDownDown;
                else if (m2.T_QuantumAvg > m2.T_MassAvg
                   && m1.T_QuantumAvg > m1.T_MassAvg
                   && m0.T_QuantumAvg < m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassDownDownUp;
                else if (m2.T_QuantumAvg < m2.T_MassAvg
                   && m1.T_QuantumAvg < m1.T_MassAvg
                   && m0.T_QuantumAvg > m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassUpUpDown;
                else if (m2.T_QuantumAvg > m2.T_MassAvg
                  && m1.T_QuantumAvg < m1.T_MassAvg
                  && m0.T_QuantumAvg > m0.T_MassAvg
                  )
                    upDown = CandleMassPatternEnum.MassDownUpDown;
                else if (m2.T_QuantumAvg < m2.T_MassAvg
                   && m1.T_QuantumAvg > m1.T_MassAvg
                   && m0.T_QuantumAvg < m0.T_MassAvg
                   )
                    upDown = CandleMassPatternEnum.MassUpDownUp;
            }
            catch (Exception) { }
            return upDown;
        }
        #endregion

        #region CandleChart Pattern
        public static CandleChartPatternEnum GetCandleChartPattern(LimitedList<S_CandleItemData> sourceDatas, int cnt = 6)
        {
            CandleChartPatternEnum upDown = CandleChartPatternEnum.None;

            try
            {
                List<S_CandleItemData> list = sourceDatas.GetRange(0, cnt + 1);

                List<int> rListUpDown = new List<int>();
                List<int> rListOpen = new List<int>();
                List<int> rListHigh = new List<int>();
                List<int> rListLow = new List<int>();
                List<int> rListClose = new List<int>();
                List<int> rListMass = new List<int>();

                if (list[0].PlusMinusType == PlusMinusTypeEnum.양)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        var m = list[i];
                        if (m.PlusMinusType == PlusMinusTypeEnum.양) rListUpDown.Add(1);
                    }
                    rListOpen.Add(1);
                    rListHigh.Add(1);
                    rListLow.Add(1);
                    rListClose.Add(1);
                    rListMass.Add(1);
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        var m = list[i];
                        var m2 = list[i + 1];
                        if (m.OpenPrice >= m2.OpenPrice) rListOpen.Add(1);
                        if (m.HighPrice >= m2.HighPrice) rListHigh.Add(1);
                        if (m.LowPrice >= m2.LowPrice) rListLow.Add(1);
                        if (m.ClosePrice >= m2.ClosePrice) rListClose.Add(1);
                        if (m.MassPrice >= m2.MassPrice) rListMass.Add(1);
                    }
                    if (cnt == 6)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.SixStrongUp;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.SixWeakUp;
                    }
                    if (cnt == 5)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.FiveStrongUp;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.FiveWeakUp;
                    }
                    if (cnt == 4)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.FourStrongUp;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.FourWeakUp;
                    }
                    if (cnt == 3)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.ThreeStrongUp;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.ThreeWeakUp;
                    }
                }
                else if (list[0].PlusMinusType == PlusMinusTypeEnum.음)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        var m = list[i];
                        if (m.PlusMinusType == PlusMinusTypeEnum.음) rListUpDown.Add(1);
                    }
                    rListOpen.Add(1);
                    rListHigh.Add(1);
                    rListLow.Add(1);
                    rListClose.Add(1);
                    rListMass.Add(1);
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        var m = list[i];
                        var m2 = list[i + 1];
                        if (m.OpenPrice <= m2.OpenPrice) rListOpen.Add(1);
                        if (m.HighPrice <= m2.HighPrice) rListHigh.Add(1);
                        if (m.LowPrice <= m2.LowPrice) rListLow.Add(1);
                        if (m.ClosePrice <= m2.ClosePrice) rListClose.Add(1);
                        if (m.MassPrice <= m2.MassPrice) rListMass.Add(1);
                    }

                    if (cnt == 6)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.SixStrongDown;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.SixWeakDown;
                    }
                    if (cnt == 5)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.FiveStrongDown;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.FiveWeakDown;
                    }
                    if (cnt == 4)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.FourStrongDown;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.FourWeakDown;
                    }
                    if (cnt == 3)
                    {
                        if (cnt == rListUpDown.Sum()
                           && cnt == rListOpen.Sum()
                           && cnt == rListHigh.Sum()
                           && cnt == rListLow.Sum()
                           && cnt == rListClose.Sum()
                           && cnt == rListMass.Sum())
                            upDown = CandleChartPatternEnum.ThreeStrongDown;
                        else if ((cnt == rListUpDown.Sum() || cnt == rListUpDown.Sum() - 1)
                           && (cnt == rListOpen.Sum() || cnt == rListOpen.Sum() - 1)
                           && (cnt == rListHigh.Sum() || cnt == rListHigh.Sum() - 1)
                           && (cnt == rListLow.Sum() || cnt == rListLow.Sum() - 1)
                           && (cnt == rListClose.Sum() || cnt == rListClose.Sum() - 1)
                           && (cnt == rListMass.Sum() || cnt == rListMass.Sum() - 1))
                            upDown = CandleChartPatternEnum.ThreeWeakDown;
                    }
                }
            }
            catch (Exception)
            {
            }
            return upDown;
        }
        #endregion

        #region CandleToLine
        public static LimitedList<double> GetLinePointsByCandles(LimitedList<S_CandleItemData> sourceDatas)
        {
            List<S_CandleItemData> list = sourceDatas.ToList();
            LimitedList<double> resultList = new LimitedList<double>(list.Count * 4);
            try
            {
                foreach (var m in list)
                {
                    if (m.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        resultList.Add(m.ClosePrice);
                        resultList.Add(m.HighPrice);
                        resultList.Add(m.LowPrice);
                        resultList.Add(m.OpenPrice);
                    }
                    else if (m.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        resultList.Add(m.ClosePrice);
                        resultList.Add(m.LowPrice);
                        resultList.Add(m.HighPrice);                       
                        resultList.Add(m.OpenPrice);
                    }
                    else
                    {
                        resultList.Add(m.ClosePrice);
                        resultList.Add(m.LowPrice);
                        resultList.Add(m.HighPrice);
                        resultList.Add(m.LowPrice);
                        resultList.Add(m.HighPrice);                     
                        resultList.Add(m.OpenPrice);
                    }
                }
            }
            catch (Exception)
            {
            }
            return resultList;
        }

        public static List<double> GetSixPointByCandle(S_CandleItemData data)
        {
            List<double> results = new List<double>();
            try
            {
                double oPrice = data.OpenPrice;
                double hPrice = data.HighPrice;
                double lPrice = data.LowPrice;
                double cPrice = data.ClosePrice;
                double mlPrice = data.MiddlePrice;
                double ctPrice = data.CenterPrice;

                if (data.PlusMinusType == PlusMinusTypeEnum.양)
                {
                    results.Add(oPrice);
                    results.Add(lPrice);

                    if (mlPrice < ctPrice)
                    {
                        results.Add(mlPrice);
                        results.Add(ctPrice);
                    }
                    else
                    {
                        results.Add(ctPrice);
                        results.Add(mlPrice);                        
                    }

                    results.Add(hPrice);
                    results.Add(cPrice);
                }
                else
                {
                    results.Add(oPrice);
                    results.Add(hPrice);

                    if (mlPrice < ctPrice)
                    {
                        results.Add(ctPrice);
                        results.Add(mlPrice);                        
                    }
                    else
                    {
                        results.Add(mlPrice);
                        results.Add(ctPrice);
                    }
                    results.Add(lPrice);
                    results.Add(cPrice);
                }
            }
            catch (Exception)
            {
            }

            return results;
        }
        public static List<double> GetSixPointsByCandles(List<S_CandleItemData> list)
        {
            List<double> results = new List<double>();
            try
            {
                foreach (var item in list)
                {
                    var r = GetSixPointByCandle(item);
                    foreach (var p in r)
                        results.Add(p);
                }
            }
            catch (Exception)
            {
            }

            return results;
        }
        #endregion

        #region Merge Candles
        public static S_CandleItemData GetMergeCandle(List<S_CandleItemData> list)
        {          
            try
            {
                Single open = 0;
                Single high = 0;
                Single low = 999999;
                Single close = 0;

                open = list[0].OpenPrice;
                close = list[list.Count - 1].ClosePrice;
                high = list.Max(t => t.HighPrice);
                low = list.Min(t => t.LowPrice);

                S_CandleItemData item = new S_CandleItemData(
                    list[0].ItemCode
                    , open
                    , high
                    , low
                    , close
                    , 0
                    , list[list.Count - 1].DTime);

                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static S_CandleItemData GetMergeCandle(params S_CandleItemData[] list)
        {
            try
            {
                var sList = list.ToList();

                return GetMergeCandle(sList);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static S_DiamondtemData GetMergeDiamondCandle(List<S_CandleItemData> list)
        {
            try
            {
                Single hh = 0;         
                Single ll = 0;

                hh = list.Max(t => t.HighPrice);
                ll = list.Min(t => t.LowPrice);

                var hm1 = list.Max(t => t.OpenPrice);
                var hm2 = list.Max(t => t.ClosePrice);

                var lm1 = list.Min(t => t.OpenPrice);
                var lm2 = list.Min(t => t.ClosePrice);

                S_DiamondtemData item = new S_DiamondtemData(
                    list[0].ItemCode
                    , hh
                    , hm1 > hm2 ? hm1 : hm2
                    , lm1 < lm2 ? lm1 : lm2
                    , ll
                    , 0
                    , list[list.Count - 1].DTime);

                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static S_DiamondtemData GetMergeDiamondCandle(params S_CandleItemData[] list)
        {
            try
            {
                var sList = list.ToList();

                return GetMergeDiamondCandle(sList);;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Renko
        public static int GetRenko(string itemCode, S_CandleItemData cData, S_CandleItemData bData, double renkoValue)
        {
            int renko = 0;
            int hrenko = 0;
            int lrenko = 0;
            if (bData.ClosePrice < cData.ClosePrice && bData.HighPrice < cData.HighPrice )
            {
                hrenko = Convert.ToInt32((cData.HighPrice - bData.HighPrice) / renkoValue);
            }
            if (bData.ClosePrice > cData.ClosePrice && bData.LowPrice > cData.LowPrice)
            {
                lrenko = Convert.ToInt32((bData.LowPrice - cData.LowPrice) / renkoValue);
            }

            if (hrenko > lrenko) renko = hrenko;
            if (hrenko < lrenko) renko = lrenko * -1;

            return renko;
        }
        #endregion
    }
}
