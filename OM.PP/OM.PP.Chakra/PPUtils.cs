using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static List<S_CandleItemData> GetBalancedAverageDatas(string itemCode, List<S_CandleItemData> sourceDatas, int averageCnt)
        {
            List<S_CandleItemData> averageDatas = new List<S_CandleItemData>();

            try
            {
                for (int i = averageCnt; i < sourceDatas.Count; i++)
                {
                    DateTime dTime = sourceDatas[i].DTime;

                    int idx = i - averageCnt;
                    int cnt = averageCnt + averageCnt;

                    if (sourceDatas.Count - (idx + cnt) < 0)
                        cnt -= ((idx + cnt) - sourceDatas.Count);

                    S_CandleItemData transData = new S_CandleItemData(itemCode, sourceDatas.GetRange(idx, cnt), dTime);
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
                    S_CandleItemData transData = new S_CandleItemData(itemCode, sourceDatas.GetRange(i - averageCnt, averageCnt), true);
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
        public static List<S_CandleItemData> GetQuantumDatas(List<S_CandleItemData> sourceDatas)
        {
            List<S_CandleItemData> sourceDatasNew = new List<S_CandleItemData>();
            try
            {
                foreach (var m in sourceDatas)
                {
                    sourceDatasNew.Add(new S_CandleItemData(
                        m.ItemCode, 
                        m.OpenPrice, 
                        m.QuantumBaseHighPrice, 
                        m.QuantumBaseLowPrice, 
                        m.QuantumBasePrice, 
                        m.Volume, 
                        m.DTime));
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
        public static List<double> GetLinePointsByCandles(List<S_CandleItemData> sourceDatas)
        {
            List<S_CandleItemData> list = sourceDatas.ToList();
            List<double> resultList = new List<double>(list.Count * 6);
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
        public static int GetRenko(S_CandleItemData cData, S_CandleItemData bData, double renkoValue)
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

        #region ReCreateSecondsData
        public static List<S_CandleItemData> GetRecreateWhimDatas(string itemCode, List<S_CandleItemData> sourceDatas, bool isWhim = false, double whimRate = 1.0, DateTime? dt = null)
        {
            List<S_CandleItemData> sourceDatasNew = new List<S_CandleItemData>();
            try
            {
                for (int i = 1; i < sourceDatas.Count; i++)
                {
                    var m0 = sourceDatas[i - 1];
                    var m1 = sourceDatas[i];

                    if (dt != null && m1.DTime < dt) continue;

                    var rate = Math.Abs((m1.ClosePrice - m0.ClosePrice) / m0.ClosePrice * 100.0);

                    //변덕인것만 추리기
                    if (isWhim)
                    {
                        if (rate >= whimRate)
                        {
                            sourceDatasNew.Add(new S_CandleItemData(itemCode, m1.OpenPrice, m1.HighPrice, m1.LowPrice, m1.ClosePrice, m1.Volume, m1.DTime));
                        }
                        else
                        {
                            sourceDatasNew.Add(new S_CandleItemData(itemCode, m0.OpenPrice, m0.HighPrice, m0.LowPrice, m0.ClosePrice, m0.Volume, m0.DTime));
                        }
                    }                    
                    else 
                    {
                        if (rate >= whimRate)
                        {
                            sourceDatasNew.Add(new S_CandleItemData(itemCode, m0.OpenPrice, m0.HighPrice, m0.LowPrice, m0.ClosePrice, m0.Volume, m0.DTime));
                        }
                        else
                        {
                            sourceDatasNew.Add(new S_CandleItemData(itemCode, m1.OpenPrice, m1.HighPrice, m1.LowPrice, m1.ClosePrice, m1.Volume, m1.DTime));
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sourceDatasNew;
        }

        public static List<S_CandleItemData> GetRecreateSecondDatas(string itemCode, List<S_CandleItemData> sourceDatas, int duration = 5, bool isQutum= false)
        {
            List<S_CandleItemData> sourceDatasNew = new List<S_CandleItemData>();
            try
            {                
                for (int i = duration; i <= sourceDatas.Count; i++)
                {
                    if (isQutum)
                    {
                        var subs = sourceDatas.GetRange(i - duration, duration);
                        int cnt = subs.Count;
                        int rankIndex = cnt > 1 ? 1 : 0;

                        var open = subs.OrderBy(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                        var open2 = subs.OrderByDescending(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                        var close = subs.OrderByDescending(t => t.ClosePrice).ElementAt(rankIndex).QuantumBasePrice;
                        var close2 = subs.OrderBy(t => t.ClosePrice).ElementAt(rankIndex).QuantumBasePrice;
                        var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).QuantumBaseHighPrice;
                        var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).QuantumBaseLowPrice;
                        var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                        var volume = subs.Sum(t => t.Volume);
                        var fc = subs[0];
                        var lc = subs[subs.Count - 1];

                        //sourceDatasNew.Add(
                        //    new S_CandleItemData(
                        //        itemCode
                        //        , (Single)Math.Round((open + open2) / 2.0, ItemCodeUtil.GetItemCodeRoundNum(itemCode))
                        //        , high
                        //        , low
                        //        , (Single)Math.Round((close + close2) / 2.0, ItemCodeUtil.GetItemCodeRoundNum(itemCode))
                        //        , volume
                        //        , dtime)
                        //    );

                        //sourceDatasNew.Add(
                        //    new S_CandleItemData(
                        //        itemCode
                        //        , fc.OpenPrice > lc.ClosePrice ? open2 : open
                        //        , high
                        //        , low
                        //        , fc.OpenPrice > lc.ClosePrice ? close2 : close
                        //        , volume
                        //        , dtime)
                        //    );

                        sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , Math.Abs(open - close) > Math.Abs(open2 - close2) ? open : open2
                                , high
                                , low
                                , Math.Abs(open - close) > Math.Abs(open2 - close2) ? close : close2
                                , volume
                                , dtime)
                            );
                    }
                    else
                    {
                        var subs = sourceDatas.GetRange(i - duration, duration);
                        int cnt = subs.Count;
                        int rankIndex = cnt > 1 ? 1 : 0;

                        var open = subs.OrderBy(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                        var open2 = subs.OrderByDescending(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                        var close = subs.OrderByDescending(t => t.ClosePrice).ElementAt(rankIndex).ClosePrice;
                        var close2 = subs.OrderBy(t => t.ClosePrice).ElementAt(rankIndex).ClosePrice;
                        var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).HighPrice;
                        var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).LowPrice;
                        var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                        var volume = subs.Sum(t => t.Volume);
                        var fc = subs[0];
                        var lc = subs[subs.Count - 1];
                        //sourceDatasNew.Add(
                        //   new S_CandleItemData(
                        //       itemCode
                        //       , (Single)Math.Round((open + open2) / 2.0, ItemCodeUtil.GetItemCodeRoundNum(itemCode))
                        //       , high
                        //       , low
                        //       , (Single)Math.Round((close + close2) / 2.0, ItemCodeUtil.GetItemCodeRoundNum(itemCode))
                        //       , volume
                        //       , dtime)
                        //   );

                        //sourceDatasNew.Add(
                        //   new S_CandleItemData(
                        //       itemCode
                        //       , fc.OpenPrice > lc.ClosePrice ? open2 : open
                        //       , high
                        //       , low
                        //       , fc.OpenPrice > lc.ClosePrice ? close2 : close
                        //       , volume
                        //       , dtime)
                        //   );

                        sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , Math.Abs(open - close) > Math.Abs(open2 - close2) ? open : open2
                                , high
                                , low
                                , Math.Abs(open - close) > Math.Abs(open2 - close2) ? close : close2
                                , volume
                                , dtime)
                            );
                    }                    
                }               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sourceDatasNew;
        }

        public static List<S_CandleItemData> GetRecreateSecondDatas2(string itemCode, List<S_CandleItemData> sourceDatas, int duration = 5, bool isQutum = false)
        {
            List<S_CandleItemData> sourceDatasNew = new List<S_CandleItemData>();
            try
            {
                List<Single> tmpList = new List<float>();
                
                for (int i = duration; i <= sourceDatas.Count; i++)
                {
                    if (isQutum)
                    {
                        var subs = sourceDatas.GetRange(i - duration, duration);
                        int cnt = subs.Count;
                        int rankIndex = cnt > 1 ? 1 : 0;
                        var fc = subs[0];
                        var lc = subs[subs.Count - 1];

                        if (fc.OpenPrice < lc.ClosePrice)
                        {
                            var open = subs.OrderBy(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                            var close = subs.OrderByDescending(t => t.ClosePrice).ElementAt(rankIndex).QuantumBasePrice;
                            var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).QuantumBaseHighPrice;
                            var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).QuantumBaseLowPrice;
                            var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                            var volume = subs.Sum(t => t.Volume);
                            tmpList.Clear();
                            tmpList.Add(open);
                            tmpList.Add(close);
                            tmpList.Add(high);
                            tmpList.Add(low);
                            sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , open
                                , tmpList.Max()
                                , tmpList.Min()
                                , close
                                , volume
                                , dtime)
                            ) ;
                        }
                        else if (fc.OpenPrice > lc.ClosePrice)
                        {
                            var open = subs.OrderByDescending(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                            var close = subs.OrderBy(t => t.ClosePrice).ElementAt(rankIndex).QuantumBasePrice;
                            var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).QuantumBaseHighPrice;
                            var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).QuantumBaseLowPrice;
                            var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                            var volume = subs.Sum(t => t.Volume);
                            tmpList.Clear();
                            tmpList.Add(open);
                            tmpList.Add(close);
                            tmpList.Add(high);
                            tmpList.Add(low);
                            sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , open
                                , tmpList.Max()
                                , tmpList.Min()
                                , close
                                , volume
                                , dtime)
                            );
                        }
                        
                    }
                    else
                    {
                        var subs = sourceDatas.GetRange(i - duration, duration);
                        int cnt = subs.Count;
                        int rankIndex = cnt > 1 ? 1 : 0;
                        var fc = subs[0];
                        var lc = subs[subs.Count - 1];

                        if (fc.OpenPrice < lc.ClosePrice)
                        {
                            var open = subs.OrderBy(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                            var close = subs.OrderByDescending(t => t.ClosePrice).ElementAt(rankIndex).ClosePrice;
                            var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).HighPrice;
                            var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).LowPrice;
                            var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                            var volume = subs.Sum(t => t.Volume);
                            tmpList.Clear();
                            tmpList.Add(open);
                            tmpList.Add(close);
                            tmpList.Add(high);
                            tmpList.Add(low);
                            sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , open                                
                                , tmpList.Max()
                                , tmpList.Min()
                                , close
                                , volume
                                , dtime)
                            );
                        }
                        else if (fc.OpenPrice > lc.ClosePrice)
                        {
                            var open = subs.OrderByDescending(t => t.OpenPrice).ElementAt(rankIndex).OpenPrice;
                            var close = subs.OrderBy(t => t.ClosePrice).ElementAt(rankIndex).ClosePrice;
                            var high = subs.OrderByDescending(t => t.HighPrice).ElementAt(rankIndex).HighPrice;
                            var low = subs.OrderBy(t => t.LowPrice).ElementAt(rankIndex).LowPrice;
                            var dtime = subs.OrderBy(t => t.DTime).Last().DTime;
                            var volume = subs.Sum(t => t.Volume);
                            tmpList.Clear();
                            tmpList.Add(open);
                            tmpList.Add(close);
                            tmpList.Add(high);
                            tmpList.Add(low);
                            sourceDatasNew.Add(
                            new S_CandleItemData(
                                itemCode
                                , open
                                , tmpList.Max()
                                , tmpList.Min()
                                , close
                                , volume
                                , dtime)
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sourceDatasNew;
        }
        #endregion

        #region Duration
        public static List<S_CandleItemData> GetDurationSum(string itemCode, List<S_CandleItemData> baseDatas, List<S_CandleItemData> sourceDatas, DateTime? dt = null)
        {
            List<S_CandleItemData> sumDatasNew = new List<S_CandleItemData>();
            try
            {
                for (int i = 0; i < baseDatas.Count - 1; i++)
                {
                    var m0 = baseDatas[i];
                    var m1 = baseDatas[i + 1];

                    if (dt != null && m0.DTime < dt) continue;

                    var list = sourceDatas.FindAll(t => t.DTime >= m0.DTime && t.DTime < m1.DTime);

                    var open = list.First().OpenPrice;
                    var high = list.Max(t => t.HighPrice);
                    var low = list.Min(t => t.LowPrice);
                    var close = list.Last().ClosePrice;
                    if(open < close)
                        sumDatasNew.Add(new S_CandleItemData(itemCode, low, high, low, high, 0, m0.DTime));
                    else
                        sumDatasNew.Add(new S_CandleItemData(itemCode, high, high, low, low, 0, m0.DTime));
                }
                var mLast = baseDatas.Last();
                var list2 = sourceDatas.FindAll(t => t.DTime >= mLast.DTime);
                var open2 = list2.First().OpenPrice;
                var high2 = list2.Max(t => t.HighPrice);
                var low2 = list2.Min(t => t.LowPrice);
                var close2 = list2.Last().ClosePrice;
                if (open2 < close2)
                    sumDatasNew.Add(new S_CandleItemData(itemCode, low2, high2, low2, high2, 0, mLast.DTime));
                else
                    sumDatasNew.Add(new S_CandleItemData(itemCode, high2, high2, low2, low2, 0, mLast.DTime));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return sumDatasNew;
        }
        #endregion

        #region MovingAverage
        public static List<S_CandleItemData> GetMovingAverageDurationFlow(string itemCode, List<S_CandleItemData> averageDatas, bool isStrengthed = false, int inflectionPoint = 3, DateTime? dt = null)
        {
            List<S_CandleItemData> newDatas = new List<S_CandleItemData>();
            try
            {
                int plusCnt = 0;
                int minusCnt = 0;

                S_CandleItemData bCandle = null;
                for (int i = 1; i < averageDatas.Count; i++)
                {
                    var m0 = averageDatas[i - 1];
                    var m1 = averageDatas[i];

                    if (dt != null && m1.DTime < dt) continue;

                    if (bCandle == null) bCandle = m0;

                    if (isStrengthed)
                    {
                        if (m0.HighPrice < m1.HighPrice && m0.LowPrice < m1.LowPrice) plusCnt++;                       
                        if (m0.HighPrice > m1.HighPrice && m0.LowPrice > m1.LowPrice) minusCnt++;
                    }
                    else
                    {
                        if (m0.PlusMinusType == PlusMinusTypeEnum.양 && m1.PlusMinusType == PlusMinusTypeEnum.양 ) plusCnt++;
                        if (m0.PlusMinusType == PlusMinusTypeEnum.음 && m1.PlusMinusType == PlusMinusTypeEnum.음) minusCnt++;
                    }

                    if (plusCnt > inflectionPoint && minusCnt > inflectionPoint && plusCnt != minusCnt)
                    {
                        int c = plusCnt > minusCnt ? plusCnt : minusCnt;
                        if (plusCnt > minusCnt)
                            newDatas.Add(new S_CandleItemData(itemCode, 0, plusCnt, 0, plusCnt, 0, bCandle.DTime));
                        else
                            newDatas.Add(new S_CandleItemData(itemCode, minusCnt, minusCnt, 0, 0, 0, bCandle.DTime));
                 
                        plusCnt = 0;
                        minusCnt = 0;
                        bCandle = null;
                    }                 
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return newDatas;
        }
        #endregion

        #region ANode Converter
        public static (List<S_CandleItemData> plusList, List<S_CandleItemData>minusList) GetANodeDatas(List<S_CandleItemData> sourceDatas)
        {
            List<S_CandleItemData> plusDatasNew = new List<S_CandleItemData>();
            List<S_CandleItemData> minusDatasNew = new List<S_CandleItemData>();

            //양자화 한다.
            var quantumDatas = GetQuantumDatas(sourceDatas);

            try
            {
                S_CandleItemData bp = null;
                S_CandleItemData bm = null;

                foreach (var m in quantumDatas)
                {
                    if (bp == null) bp = m;
                    if (bm == null) bm = m;

                    if (m.PlusMinusType == PlusMinusTypeEnum.양)
                    {
                        plusDatasNew.Add(
                            new S_CandleItemData(m.ItemCode,m.OpenPrice,m.HighPrice,m.LowPrice,m.ClosePrice,m.Volume,m.DTime));
                      
                        bp = new S_CandleItemData(m.ItemCode, m.OpenPrice, m.HighPrice, m.LowPrice, m.ClosePrice, m.Volume, m.DTime);

                        if (bm != null)
                        {
                            minusDatasNew.Add(new S_CandleItemData(
                                bm.ItemCode,
                                bm.OpenPrice,
                                bm.HighPrice,
                                bm.LowPrice,
                                bm.ClosePrice,
                                bm.Volume,
                                m.DTime
                                ));
                        }
                    }
                    else if (m.PlusMinusType == PlusMinusTypeEnum.음)
                    {
                        minusDatasNew.Add(
                            new S_CandleItemData(m.ItemCode, m.OpenPrice, m.HighPrice, m.LowPrice, m.ClosePrice, m.Volume, m.DTime));
                       
                        bm = new S_CandleItemData(m.ItemCode, m.OpenPrice, m.HighPrice, m.LowPrice, m.ClosePrice, m.Volume, m.DTime);

                        if (bp != null)
                        {
                            plusDatasNew.Add(new S_CandleItemData(
                                bp.ItemCode,
                                bp.OpenPrice,
                                bp.HighPrice,
                                bp.LowPrice,
                                bp.ClosePrice,
                                bp.Volume,
                                m.DTime
                                ));
                        }
                    }
                    else
                    {
                        plusDatasNew.Add(
                            new S_CandleItemData(m.ItemCode, m.OpenPrice, m.HighPrice, m.LowPrice, m.ClosePrice, m.Volume, m.DTime));
                        minusDatasNew.Add(
                            new S_CandleItemData(m.ItemCode, m.OpenPrice, m.HighPrice, m.LowPrice, m.ClosePrice, m.Volume, m.DTime));
                    }
                }

                if (plusDatasNew.Count > minusDatasNew.Count)
                {
                    plusDatasNew = GetCutDatas(plusDatasNew, minusDatasNew[0].DTime);
                }
                else if (plusDatasNew.Count < minusDatasNew.Count)
                {
                    minusDatasNew = GetCutDatas(minusDatasNew, plusDatasNew[0].DTime);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return (plusDatasNew, minusDatasNew);
        }
        #endregion
    }
}
