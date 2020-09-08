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
        public static void loadDataAndApply(this BasicCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceAvgDatas
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {               
                c.LoadData(itemCode, sourceDatas, sourceAvgDatas, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        
        #endregion
        #region ComparedBasicCandleChart
        public static void loadDataAndApply(this ComparedBasicCandleChart c
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
        public static void loadDataAndApply(this ComparedBasicCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDataSubs
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                c.LoadData(itemCode, sourceDatas, sourceDataSubs, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }       
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
        public static void loadDataAndApply(this RealCandleChart c
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
        public static void loadDataAndApply(this AtomChart c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
             , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemCnt = 7)
        {
            try
            {
                List<T_AtomItemData> transformedDatas = new List<T_AtomItemData>();
                List<T_AtomItemData> transformedDatasSub = new List<T_AtomItemData>();
                
                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_AtomItemData transData = new T_AtomItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                for (int i = itemCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_AtomItemData transData = new T_AtomItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);              
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this AntiMatterChart c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
             , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemCnt = 7)
        {
            try
            {
                List<T_AntiMatterItemData> transformedDatas = new List<T_AntiMatterItemData>();
                List<T_AntiMatterItemData> transformedDatasSub = new List<T_AntiMatterItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_AntiMatterItemData transData = new T_AntiMatterItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                for (int i = itemCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_AntiMatterItemData transData = new T_AntiMatterItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this CandleAntiCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemCnt = 7)
        {
            try
            {
                List<T_CandleAntiCandleItemData> transformedDatas = new List<T_CandleAntiCandleItemData>(); 
                List<T_CandleAntiCandleItemData> transformedDatasSub = new List<T_CandleAntiCandleItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_CandleAntiCandleItemData transData = new T_CandleAntiCandleItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                for (int i = itemCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_CandleAntiCandleItemData transData = new T_CandleAntiCandleItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this DarkMassrChart c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
             , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemCnt = 7)
        {
            try
            {
                List<T_DarkMassItemData> transformedDatas = new List<T_DarkMassItemData>();
                List<T_DarkMassItemData> transformedDatasSub = new List<T_DarkMassItemData>();

                for (int i = itemCnt; i <= sourceDatas.Count; i++)
                {
                    T_DarkMassItemData transData = new T_DarkMassItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }
                for (int i = itemCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_DarkMassItemData transData = new T_DarkMassItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemCnt, itemCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this BasicLineChart c
             , string itemCode
             , List<S_LineItemData> sourceDatas
             , List<S_LineItemData> sourceDatasSub
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
        public static void loadDataAndApply(this QuantumLineChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
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

                List<T_QuantumItemData> transformedDatasSub = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion
        #region  QuantumLineTradeChart
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
        public static void loadDataAndApply(this QuantumLineTradeChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
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

                List<T_QuantumItemData> transformedDatasSub = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion
        #region QuantumLineChartHL

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
        public static void loadDataAndApply(this QuantumLineChartHL c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
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

                List<T_QuantumItemData> transformedDatasSub = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this DiceCandleChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
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

                List<T_QuantumItemData> transformedDatasSub = new List<T_QuantumItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_QuantumItemData transData = new T_QuantumItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }
                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

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
        public static void loadDataAndApply(this ThreeThaChiChart c
            , string itemCode
            , List<S_CandleItemData> sourceDatas
            , List<S_CandleItemData> sourceDatasSub
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 7)
        {
            try
            {
                List<T_ThaChiItemData> transformedDatas = new List<T_ThaChiItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_ThaChiItemData transData = new T_ThaChiItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                List<T_ThaChiItemData> transformedDatasSub = new List<T_ThaChiItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_ThaChiItemData transData = new T_ThaChiItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);

                }
                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this VelocityLineChart c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
             , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemsCnt = 7)
        {
            try
            {
                List<T_VelocityItemData> transformedDatas = new List<T_VelocityItemData>();

                for (int i = itemsCnt; i <= sourceDatas.Count; i++)
                {
                    T_VelocityItemData transData =
                        new T_VelocityItemData(sourceDatas[i - 1], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatas.Add(transData);
                }

                List<T_VelocityItemData> transformedDatasSub = new List<T_VelocityItemData>();

                for (int i = itemsCnt; i <= sourceDatasSub.Count; i++)
                {
                    T_VelocityItemData transData =
                        new T_VelocityItemData(sourceDatasSub[i - 1], sourceDatasSub.GetRange(i - itemsCnt, itemsCnt));
                    transData.Transform();
                    transformedDatasSub.Add(transData);
                }

                c.LoadData(itemCode, transformedDatas, transformedDatasSub, timeInterval);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
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
        public static void loadDataAndApply(this LengthRateLineChart c
             , string itemCode
             , List<S_CandleItemData> sourceDatas
             , List<S_CandleItemData> sourceDatasSub
             , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
             , int itemsCnt = 7)
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
        public static void loadDataAndApply(this ChakraChart c
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
        #region ChakraTradeChart
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
        public static void loadDataAndApply(this ChakraTradeChart c
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
               

        public static void LoadDataAndApply(this BaseChartControl c
            , string itemCode
            , List<S_CandleItemData> sourceDatas            
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
            , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;

            if (c is BasicCandleChart) ((BasicCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ComparedBasicCandleChart) ((ComparedBasicCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is AntiMatterChart) ((AntiMatterChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is AtomChart) ((AtomChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuantumLineChart) ((QuantumLineChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is QuantumLineChartHL) ((QuantumLineChartHL)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is DiceCandleChart) ((DiceCandleChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is ThreeThaChiChart) ((ThreeThaChiChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
            else if (c is VelocityLineChart) ((VelocityLineChart)c).loadDataAndApply(itemCode, sourceDatas, timeInterval, itemsCnt);
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
            else if (c is ComparedBasicCandleChart) ((ComparedBasicCandleChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);

            else if (c is BasicCandleChart) ((BasicCandleChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is AntiMatterChart) ((AntiMatterChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is AtomChart) ((AtomChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is QuantumLineChart) ((QuantumLineChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is QuantumLineChartHL) ((QuantumLineChartHL)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is DiceCandleChart) ((DiceCandleChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is ThreeThaChiChart) ((ThreeThaChiChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is VelocityLineChart) ((VelocityLineChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is ChakraTradeChart) ((ChakraTradeChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is QuantumLineTradeChart) ((QuantumLineTradeChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is RealCandleChart) ((RealCandleChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is CandleAntiCandleChart) ((CandleAntiCandleChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is DarkMassrChart) ((DarkMassrChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
            else if (c is LengthRateLineChart) ((LengthRateLineChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub, timeInterval, itemsCnt);
        }
        public static void LoadDataAndApply(this BaseChartControl c
           , string itemCode
           , List<S_CandleItemData> sourceDatas
           , List<S_CandleItemData> sourceDatasSub1
           , List<S_CandleItemData> sourceDatasSub2
           , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day
           , int itemsCnt = 9)
        {
            if (sourceDatas.Count == 0) return;
            itemsCnt = 9;           
            if (c is ANodeLineChart) ((ANodeLineChart)c).loadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, sourceDatasSub2, timeInterval, itemsCnt);
        }
        
    }
}
