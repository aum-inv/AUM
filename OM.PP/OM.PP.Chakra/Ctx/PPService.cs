using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;

namespace OM.PP.Chakra.Ctx
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall
        , ConcurrencyMode = ConcurrencyMode.Multiple
        , UseSynchronizationContext = false)]
    public class PPService : IPPService
    {
        static object sync = new object();

        public string ServiceName => PPServerConfigData.ServiceName;

        public void Noop() { }

        public void InitSourceData(string item)
        {
            PPStorage.Instance.Init(item);
        }
       
        public List<LitePurushaPrakriti> GetSourceData(
                string itemCode
            ,   TimeIntervalEnum timeInterval
            ,   string startDate = null
            ,   string endDate = null
            ,   int cnt = 0)
        {
            List<LitePurushaPrakriti> list = new List<LitePurushaPrakriti>();

            PurushaPrakriti pp = new PurushaPrakriti();
            pp.Item = itemCode;
            pp.Interval = (int)timeInterval;
            pp.StartDate = startDate == null ? "" : startDate;
            pp.EndDate = endDate == null ? "" : endDate;
            pp.DisplayCount = cnt;
            try
            {
                Entities entities = (Entities)pp.Collect();

                foreach (var m in entities.Cast<PurushaPrakriti>())
                {
                    var n = new LitePurushaPrakriti(
                            m.OpenVal, m.HighVal, m.LowVal, m.CloseVal, m.Volume, m.DT
                        );

                    list.Add(n);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public void SetSourceData(
                string itemCode
            ,   TimeIntervalEnum timeInterval
            ,   LitePurushaPrakriti entity)
        {
            Task.Factory.StartNew(() =>
            {
                PurushaPrakriti pp = new PurushaPrakriti();
                pp.MappingProperty(entity);

                try
                {
                    pp.Interval = (int)timeInterval;
                    pp.Create();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            });
        }

        public List<S_CandleItemData> GetCandleSourceDataOrderByDesc(string itemCode, TimeIntervalEnum timeInterval)
        {
            var list = GetCandleSourceData(itemCode, timeInterval);
            if (list == null) return new List<S_CandleItemData>();

            return list.ToList();
        }
        public List<S_CandleItemData> GetCandleSourceDataOrderByAsc(string itemCode, TimeIntervalEnum timeInterval)
        {
            var list = GetCandleSourceData(itemCode, timeInterval);
            if (list == null) return new List<S_CandleItemData>();

            return list.OrderBy(t => t.DTime).ToList();
        }
        public List<S_CandleItemData> GetCandleSourceData(string itemCode, TimeIntervalEnum timeInterval)
        {
            try
            {
                List<S_CandleItemData> list = null;
                switch (timeInterval)
                {
                    case TimeIntervalEnum.Minute_01:
                        list = PPStorage.Instance.StorageMin01[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_05:
                        list = PPStorage.Instance.StorageMin05[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_10:
                        list = PPStorage.Instance.StorageMin10[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_30:
                        list = PPStorage.Instance.StorageMin30[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_01:
                        list = PPStorage.Instance. StorageMin60[itemCode];
                        break;                  
                    case TimeIntervalEnum.Hour_02:
                        list = PPStorage.Instance.StorageMin120[itemCode];
                        break;                    
                    case TimeIntervalEnum.Hour_03:
                        list = PPStorage.Instance.StorageMin180[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_04:
                        list = PPStorage.Instance.StorageMin240[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_05:
                        list = PPStorage.Instance.StorageMin300[itemCode];
                        break;                    
                    case TimeIntervalEnum.Hour_06:
                        list = PPStorage.Instance.StorageMin360[itemCode];
                        break;                    
                    case TimeIntervalEnum.Hour_08:
                        list = PPStorage.Instance.StorageMin480[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_12:
                        list = PPStorage.Instance.StorageMin720[itemCode];
                        break;
                    case TimeIntervalEnum.Day:
                        list = PPStorage.Instance.StorageDay[itemCode];
                        break;
                    case TimeIntervalEnum.Week:
                        list = PPStorage.Instance.StorageWeek[itemCode];
                        break;
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public void SetCandleSourceData(string itemCode , TimeIntervalEnum timeInterval, S_CandleItemData entity)
        {
            try
            {
                LimitedList<S_CandleItemData> list = null;
                switch (timeInterval)
                {
                    case TimeIntervalEnum.Minute_01:
                        list = PPStorage.Instance.StorageMin01[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_05:
                        list = PPStorage.Instance.StorageMin05[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_10:
                        list = PPStorage.Instance.StorageMin10[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_30:
                        list = PPStorage.Instance.StorageMin30[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_01:
                        list = PPStorage.Instance.StorageMin60[itemCode];
                        break;                    
                    case TimeIntervalEnum.Hour_02:
                        list = PPStorage.Instance.StorageMin120[itemCode];
                        break;                  
                    case TimeIntervalEnum.Hour_03:
                        list = PPStorage.Instance.StorageMin180[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_04:
                        list = PPStorage.Instance.StorageMin240[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_05:
                        list = PPStorage.Instance.StorageMin300[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_06:
                        list = PPStorage.Instance.StorageMin360[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_08:
                        list = PPStorage.Instance.StorageMin480[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_12:
                        list = PPStorage.Instance.StorageMin720[itemCode];
                        break;
                    case TimeIntervalEnum.Day:
                        list = PPStorage.Instance.StorageDay[itemCode];
                        break;
                    case TimeIntervalEnum.Week:
                        list = PPStorage.Instance.StorageWeek[itemCode];
                        break;
                }
                if (list == null) return;

                var m = list.Find(t => t.DTime == entity.DTime);
                if (m != null)
                {
                    m.OpenPrice =  entity.OpenPrice;
                    m.HighPrice = entity.HighPrice;
                    m.LowPrice = entity.LowPrice;
                    m.ClosePrice = entity.ClosePrice;
                }
                else
                    list.Insert(entity);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        //실시간 시세에 맞게 데이터 업데이트
        public void SetCandleSourceDataReal(string itemCode, S_CandleItemData entity)
        {
            try
            {
                LimitedList<S_CandleItemData> list = null;
                TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;
                switch (timeInterval)
                {
                    case TimeIntervalEnum.Minute_01:
                        list = PPStorage.Instance.StorageMin01[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_05:
                        list = PPStorage.Instance.StorageMin05[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_10:
                        list = PPStorage.Instance.StorageMin10[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_30:
                        list = PPStorage.Instance.StorageMin30[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_01:
                        list = PPStorage.Instance.StorageMin60[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_02:
                        list = PPStorage.Instance.StorageMin120[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_03:
                        list = PPStorage.Instance.StorageMin180[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_04:
                        list = PPStorage.Instance.StorageMin240[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_05:
                        list = PPStorage.Instance.StorageMin300[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_06:
                        list = PPStorage.Instance.StorageMin360[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_08:
                        list = PPStorage.Instance.StorageMin480[itemCode];
                        break;
                    case TimeIntervalEnum.Hour_12:
                        list = PPStorage.Instance.StorageMin720[itemCode];
                        break;
                    case TimeIntervalEnum.Day:
                        list = PPStorage.Instance.StorageDay[itemCode];
                        break;
                    case TimeIntervalEnum.Week:
                        list = PPStorage.Instance.StorageWeek[itemCode];
                        break;
                }
                if (list == null) return;

                var m = list.Find(t => t.DTime == entity.DTime);
                if (m != null)
                {
                    m.OpenPrice = entity.OpenPrice;
                    m.HighPrice = entity.HighPrice;
                    m.LowPrice = entity.LowPrice;
                    m.ClosePrice = entity.ClosePrice;
                }
                else
                    list.Insert(entity);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void ClearSourceData(string itemCode, TimeIntervalEnum timeInterval)
        {
            try
            {
                switch (timeInterval)
                {
                    case TimeIntervalEnum.Minute_01:
                        PPStorage.Instance.StorageMin01[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Minute_05:
                        PPStorage.Instance.StorageMin05[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Minute_10:
                        PPStorage.Instance.StorageMin10[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Minute_30:
                        PPStorage.Instance.StorageMin30[itemCode].Clear();
                        break;
                    
                    case TimeIntervalEnum.Hour_01:
                        PPStorage.Instance.StorageMin60[itemCode].Clear();
                        break;                    
                    case TimeIntervalEnum.Hour_02:
                        PPStorage.Instance.StorageMin120[itemCode].Clear();
                        break;                    
                    case TimeIntervalEnum.Hour_03:
                        PPStorage.Instance.StorageMin180[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Hour_04:
                        PPStorage.Instance.StorageMin240[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Hour_05:
                        PPStorage.Instance.StorageMin300[itemCode].Clear();
                        break;                    
                    case TimeIntervalEnum.Hour_06:
                        PPStorage.Instance.StorageMin360[itemCode].Clear();
                        break;                    
                    case TimeIntervalEnum.Hour_08:
                        PPStorage.Instance.StorageMin480[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Hour_12:
                        PPStorage.Instance.StorageMin720[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Day:
                        PPStorage.Instance.StorageDay[itemCode].Clear();
                        break;
                    case TimeIntervalEnum.Week:
                        PPStorage.Instance.StorageWeek[itemCode].Clear();
                        break;

                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
