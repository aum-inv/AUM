using OM.PP.Chakra;
using OM.PP.Chakra.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Charts
{
    public static class ChartDataLoads
    {
        #region BasicCandleChart
        public static void loadDataAndApply(this BasicCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {               
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this BasicCandleChart c
        //    , string itemCode
        //    , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //    , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(itemCode, sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region RealCandleChart
        public static void loadDataAndApply(this RealCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this RealCandleChart c
        //    , string itemCode
        //    , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //    , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(itemCode, sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region AtomChart
        public static void loadDataAndApply(this AtomChart c
            , string itemCode, List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_AtomItemData transData = new T_AtomItemData(sourceDatas[i-1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this AtomChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

        //        for (int i = itemCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region AntiMatter
        public static void loadDataAndApply(this AntiMatterChart c
            , string itemCode, List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_AntiMatterItemData> transformedDatas = new List<T_AntiMatterItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_AntiMatterItemData transData = new T_AntiMatterItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this AtomChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

        //        for (int i = itemCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region AntiMatter
        public static void loadDataAndApply(this CheonbugyeongChart c
            , string itemCode, List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_CheonbugyeongItemData> transformedDatas = new List<T_CheonbugyeongItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_CheonbugyeongItemData transData = new T_CheonbugyeongItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this AtomChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

        //        for (int i = itemCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region CandleAntiCandle
        public static void loadDataAndApply(this CandleAntiCandleChart c
            , string itemCode, List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_CandleAntiCandleItemData> transformedDatas = new List<T_CandleAntiCandleItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_CandleAntiCandleItemData transData = new T_CandleAntiCandleItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this AtomChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

        //        for (int i = itemCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region DarkMassChart
        public static void loadDataAndApply(this DarkMassrChart c
            , string itemCode, List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_DarkMassItemData> transformedDatas = new List<T_DarkMassItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_DarkMassItemData transData = new T_DarkMassItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this AtomChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();

        //        for (int i = itemCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region BasicLineChart
        public static void loadDataAndApply(this BasicLineChart c
            , string itemCode
            , List<S_LineItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this BasicLineChart c
        //    , string itemCode
        //    , List<S_LineItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //    , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(itemCode, sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region BasicVolumeChart
        public static void loadDataAndApply(this BasicVolumeChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas           
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemCnt = 7)
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this BasicVolumeChart c
        //    , string itemCode
        //    , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemCnt = 7)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region CandleStick
        public static void loadDataAndApply(this Candlestick c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                c.LoadData(sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this Candlestick c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}

        #endregion

        #region FiveColorChart
        public static void loadDataAndApply(this FiveColorChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_FiveColorItemData> transformedDatas = new List<T_FiveColorItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_FiveColorItemData transData = new T_FiveColorItemData(sourceDatas[i-1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this FiveColorChart c
        //     , string itemCode
        //     , List<S_CandleItemData> sourceDatas
        //     , List<S_CandleItemData> averageDatas
        //     , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //     , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_FiveColorItemData> transformedDatas = new List<T_FiveColorItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_FiveColorItemData transData = new T_FiveColorItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }

        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region PrimeNumCandleChart
        public static void loadDataAndApply(this PrimeNumCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_PrimeNumItemData> transformedDatas = new List<T_PrimeNumItemData>();
                DateTime? dtime = null;
                foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
                {
                    if (dtime != null && dtime.Value <= m.DTime) continue;

                    T_PrimeNumItemData tData = new T_PrimeNumItemData(m, sourceDatas);
                    tData.Transform();
                    transformedDatas.Add(tData);

                    dtime = tData.DTimeS;
                }
                c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this PrimeNumCandleChart c
        //    , string itemCode
        //    , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //    , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_PrimeNumItemData> transformedDatas = new List<T_PrimeNumItemData>();
        //        DateTime? dtime = null;
        //        foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
        //        {
        //            if (dtime != null && dtime.Value <= m.DTime) continue;

        //            T_PrimeNumItemData tData = new T_PrimeNumItemData(m, sourceDatas);
        //            tData.Transform();
        //            transformedDatas.Add(tData);

        //            dtime = tData.DTimeS;
        //        }
        //        c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region  QuantumLineChart
        public static void loadDataAndApply(this QuantumLineChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();             
               
                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i-1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this QuantumLineChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}

        public static void loadDataAndApply(this QuantumLineTradeChart c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemsCnt = 7)
        {
            try
            {
                List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this QuantumLineTradeChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}

        public static void loadDataAndApply(this QuantumLineChartHL c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this QuantumLineChartHL c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region  DiceCandleChart
        public static void loadDataAndApply(this DiceCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this DiceCandleChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_QuantumItemData> transformedDatas = new List<T_QuantumItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_QuantumItemData transData = new T_QuantumItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}

        #endregion

        #region ReverseCandleChart
        public static void loadDataAndApply(this ReverseCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<S_CandleItemData> reverseDatas = new List<S_CandleItemData>();                
                for (int i = 0, j = sourceDatas.Count - 1; i < sourceDatas.Count; i++, j--)
                {
                    S_CandleItemData reverseData = new S_CandleItemData(
                          itemCode
                          , sourceDatas[j].ClosePrice
                          , sourceDatas[j].HighPrice
                          , sourceDatas[j].LowPrice
                          , sourceDatas[j].OpenPrice
                          , 0
                          , sourceDatas[i].DTime
                        );
                    reverseDatas.Add(reverseData);
                }
                c.LoadData(itemCode, sourceDatas, reverseDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this ReverseCandleChart c
        //  , string itemCode
        //  , List<S_CandleItemData> sourceDatas
        //  , List<S_CandleItemData> averageDatas
        //  , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //  , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<S_CandleItemData> reverseDatas = new List<S_CandleItemData>();
        //        for (int i = 0, j = sourceDatas.Count - 1; i < sourceDatas.Count; i++, j--)
        //        {
        //            S_CandleItemData reverseData = new S_CandleItemData(
        //                  itemCode
        //                  , sourceDatas[j].ClosePrice
        //                  , sourceDatas[j].HighPrice
        //                  , sourceDatas[j].LowPrice
        //                  , sourceDatas[j].OpenPrice
        //                  , 0
        //                  , sourceDatas[i].DTime
        //                );
        //            reverseDatas.Add(reverseData);
        //        }
        //        c.LoadData(itemCode, sourceDatas, reverseDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region ThreeThaChiChart
        public static void loadDataAndApply(this ThreeThaChiChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_ThaChiItemData> transformedDatas = new List<T_ThaChiItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_ThaChiItemData transData = new T_ThaChiItemData(sourceDatas[i-1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this ThreeThaChiChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_ThaChiItemData> transformedDatas = new List<T_ThaChiItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_ThaChiItemData transData = new T_ThaChiItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }

        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region VelocityLineChart
        public static void loadDataAndApply(this VelocityLineChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_VelocityItemData> transformedDatas = new List<T_VelocityItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_VelocityItemData transData =
                        new T_VelocityItemData(sourceDatas[i-1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this VelocityLineChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_VelocityItemData> transformedDatas = new List<T_VelocityItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_VelocityItemData transData =
        //                new T_VelocityItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion
        #region LengthRateLineChart
        public static void loadDataAndApply(this LengthRateLineChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {                
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this VelocityLineChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemsCnt = 7)
        //{
        //    try
        //    {
        //        List<T_VelocityItemData> transformedDatas = new List<T_VelocityItemData>();

        //        for (int i = itemsCnt; i <= sourceDatas.Count; i++)
        //        {
        //            T_VelocityItemData transData =
        //                new T_VelocityItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
        //            transData.Transform();
        //            transformedDatas.Add(transData);
        //        }
        //        c.LoadData(itemCode, transformedDatas, timeInterval);
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion
        #region WuxingCandleChart
        public static void loadDataAndApply(this WuXingCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_WuXingItemData> transformedDatas = new List<T_WuXingItemData>();
                DateTime? dtime = null;
                foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
                {
                    if (dtime != null && dtime.Value <= m.DTime) continue;

                    T_WuXingItemData tData = new T_WuXingItemData(m, sourceDatas);
                    tData.Transform();
                    transformedDatas.Add(tData);

                    dtime = tData.DTimeS;
                }
                c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this WuXingCandleChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_WuXingItemData> transformedDatas = new List<T_WuXingItemData>();
        //        DateTime? dtime = null;
        //        foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
        //        {
        //            if (dtime != null && dtime.Value <= m.DTime) continue;

        //            T_WuXingItemData tData = new T_WuXingItemData(m, sourceDatas);
        //            tData.Transform();
        //            transformedDatas.Add(tData);

        //            dtime = tData.DTimeS;
        //        }
        //        c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion
        #region ANodeLineChart
        public static void loadDataAndApply(this ANodeLineChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub1
            , List<S_CandleItemData> sourceDatasSub2
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, sourceDatasSub1, sourceDatasSub2, timeInterval);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region QuarkCandleChart
        public static void loadDataAndApply(this QuarkCandleChart c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemCnt = 7)
        {
            try
            {
                List<T_QuarkItemData> transformedDatas = new List<T_QuarkItemData>();
                DateTime? dtime = null;
                foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
                {
                    if (dtime != null && dtime.Value <= m.DTime) continue;

                    T_QuarkItemData tData = new T_QuarkItemData(m, sourceDatas);
                    tData.Transform();
                    transformedDatas.Add(tData);

                    dtime = tData.DTimeS;
                }
                c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this QuarkCandleChart c
        //   , string itemCode
        //   , List<S_CandleItemData> sourceDatas
        //   , List<S_CandleItemData> averageDatas
        //   , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //   , int itemCnt = 7)
        //{
        //    try
        //    {
        //        List<T_QuarkItemData> transformedDatas = new List<T_QuarkItemData>();
        //        DateTime? dtime = null;
        //        foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
        //        {
        //            if (dtime != null && dtime.Value <= m.DTime) continue;

        //            T_QuarkItemData tData = new T_QuarkItemData(m, sourceDatas);
        //            tData.Transform();
        //            transformedDatas.Add(tData);

        //            dtime = tData.DTimeS;
        //        }
        //        c.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList(), timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region ChakraChart
        public static void loadDataAndApply(this ChakraChart c
          , string itemCode
          , List<S_CandleItemData> sourceDatas
          , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
          , int itemCnt = 7)
        {
            try
            {                
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this ChakraChart c
        // , string itemCode
        // , List<S_CandleItemData> sourceDatas
        // , List<S_CandleItemData> averageDatas
        // , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        // , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(itemCode, sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}

        public static void loadDataAndApply(this ChakraTradeChart c
         , string itemCode
         , List<S_CandleItemData> sourceDatas
         , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
         , int itemCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //public static void loadDataAverageAndApply(this ChakraTradeChart c
        // , string itemCode
        // , List<S_CandleItemData> sourceDatas
        // , List<S_CandleItemData> averageDatas
        // , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        // , int itemCnt = 7)
        //{
        //    try
        //    {
        //        c.LoadData(itemCode, sourceDatas, timeInterval);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        #endregion

        #region ComplexChart
        public static void loadDataAndApply(this ComplexChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, sourceDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Etc_ParkChart
        
        public static void loadDataAndApply(this ParkChart c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , List<ParabolicSarResult> quoteDatas
           , List<ParabolicSarResult> quoteDatas2
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemCnt = 7)
        {
            try
            {
                List<T_ParkItemData> transformedDatas = new List<T_ParkItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_ParkItemData transData = new T_ParkItemData(sourceDatas[i - 1], sourceDatas, quoteDatas, quoteDatas2);
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        public static void LoadDataAndApply(this BaseChartControl c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;
            if (c is BasicCandleChart) ((BasicCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is AntiMatterChart) ((AntiMatterChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is CheonbugyeongChart) ((CheonbugyeongChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
           
            else if (c is AtomChart) ((AtomChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is BasicVolumeChart) ((BasicVolumeChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is Candlestick) ((Candlestick)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is FiveColorChart) ((FiveColorChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is PrimeNumCandleChart) ((PrimeNumCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuantumLineChart) ((QuantumLineChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuantumLineChartHL) ((QuantumLineChartHL)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is DiceCandleChart) ((DiceCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ReverseCandleChart) ((ReverseCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ThreeThaChiChart) ((ThreeThaChiChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is VelocityLineChart) ((VelocityLineChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is WuXingCandleChart) ((WuXingCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuarkCandleChart) ((QuarkCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ChakraChart) ((ChakraChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ChakraTradeChart) ((ChakraTradeChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuantumLineTradeChart) ((QuantumLineTradeChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is RealCandleChart) ((RealCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is CandleAntiCandleChart) ((CandleAntiCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is DarkMassrChart) ((DarkMassrChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is LengthRateLineChart) ((LengthRateLineChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
        }
        public static void LoadDataAndApply(this BaseChartControl c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , List<S_CandleItemData> sourceDatasSub
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;
            if (c is ComplexChart) ((ComplexChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
        }
        public static void LoadDataAndApply(this BaseChartControl c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , List<S_CandleItemData> sourceDatasSub1, List<S_CandleItemData> sourceDatasSub2
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;           
            if (c is ANodeLineChart) ((ANodeLineChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, sourceDatasSub2, timeInterval, itemsCnt);
        }
        public static void LoadDataAndApply(this BaseChartControl c
          , string itemCode
          , List<S_CandleItemData> sourceDatas
          , List<ParabolicSarResult> quoteDatas
          , List<ParabolicSarResult> quoteDatas2
          , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
          , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;
            if (c is ParkChart) ((ParkChart)c).loadDataAndApply(itemCode, sourceDatas, quoteDatas, quoteDatas2, timeInterval, itemsCnt);
        }
        //public static void LoadDataAverageAndApply(this BaseChartControl c
        //    , string itemCode
        //    , List<S_CandleItemData> sourceDatas
        //    , List<S_CandleItemData> averageDatas
        //    , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
        //    , int itemsCnt = 9)
        //{
        //    if (sourceDatas.Count == 0) return;
        //    itemsCnt = 9;
        //    if (c is BasicCandleChart) ((BasicCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is AtomChart) ((AtomChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is BasicVolumeChart) ((BasicVolumeChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is Candlestick) ((Candlestick)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is FiveColorChart) ((FiveColorChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is PrimeNumCandleChart) ((PrimeNumCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is QuantumLineChart) ((QuantumLineChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is QuantumLineChartHL) ((QuantumLineChartHL)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is DiceCandleChart) ((DiceCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is ReverseCandleChart) ((ReverseCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is ThreeThaChiChart) ((ThreeThaChiChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is VelocityLineChart) ((VelocityLineChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is WuXingCandleChart) ((WuXingCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is QuarkCandleChart) ((QuarkCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is ChakraChart) ((ChakraChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is ChakraTradeChart) ((ChakraTradeChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is QuantumLineTradeChart) ((QuantumLineTradeChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);
        //    else if (c is RealCandleChart) ((RealCandleChart)c).loadDataAverageAndApply(itemCode, sourceDatas, averageDatas, timeInterval, itemsCnt);

        //}


    }
}
