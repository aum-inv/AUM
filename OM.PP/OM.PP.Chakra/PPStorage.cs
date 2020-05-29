using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class PPStorage
    {
        private static PPStorage storage = new PPStorage();
        private PPStorage() { }

        public static PPStorage Instance
        {
            get
            {
                return storage;
            }
        }

        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin60 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin120 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin180 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin240 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin300 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin360 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin480 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin720 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageDay = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();

        
        public void Init(string itemCode)
        {
            try
            {
                if (!StorageMin60.ContainsKey(itemCode))
                {
                    StorageMin60.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin60[itemCode].Clear();
                }

                if (!StorageMin120.ContainsKey(itemCode))
                {
                    StorageMin120.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin120[itemCode].Clear();
                }

                if (!StorageMin180.ContainsKey(itemCode))
                {
                    StorageMin180.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin180[itemCode].Clear();
                }

                if (!StorageMin240.ContainsKey(itemCode))
                {
                    StorageMin240.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin240[itemCode].Clear();
                }


                if (!StorageMin300.ContainsKey(itemCode))
                {
                    StorageMin300.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin300[itemCode].Clear();
                }

                if (!StorageMin360.ContainsKey(itemCode))
                {
                    StorageMin360.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin360[itemCode].Clear();
                }

                if (!StorageMin480.ContainsKey(itemCode))
                {
                    StorageMin480.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin480[itemCode].Clear();
                }

                if (!StorageMin720.ContainsKey(itemCode))
                {
                    StorageMin720.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin720[itemCode].Clear();
                }

                if (!StorageDay.ContainsKey(itemCode))
                {
                    StorageDay.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageDay[itemCode].Clear();
                }
            }
            catch (Exception)
            {
            }
        }
        public void Load(string itemCode, TimeIntervalEnum timeInterval, List<S_CandleItemData> list)
        {
            LimitedList<S_CandleItemData> storageList = null;

            try
            {
                if (!StorageMin60.ContainsKey(itemCode))
                    Init(itemCode);

                switch (timeInterval)
                {
                    case TimeIntervalEnum.Minute_60:
                        storageList = StorageMin60[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_120:
                        storageList = StorageMin120[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_180:
                        storageList = StorageMin180[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_240:
                        storageList = StorageMin240[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_300:
                        storageList = StorageMin300[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_360:
                        storageList = StorageMin360[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_480:
                        storageList = StorageMin480[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_720:
                        storageList = StorageMin720[itemCode];
                        break;

                    case TimeIntervalEnum.Day:
                        storageList = StorageDay[itemCode];
                        break;                    
                }
              
                if (storageList != null)
                {
                    storageList.Clear();
                    foreach (var m in list)
                        storageList.Insert(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        
        public void GetState(string itemCode, TimeIntervalEnum timeInterval)
        {
            LimitedList<S_CandleItemData> list = null;
            switch (timeInterval)
            {
                case TimeIntervalEnum.Minute_60:
                    list = StorageMin60[itemCode];
                    break;

                case TimeIntervalEnum.Minute_120:
                    list = StorageMin120[itemCode];
                    break;

                case TimeIntervalEnum.Minute_180:
                    list = StorageMin180[itemCode];
                    break;

                case TimeIntervalEnum.Minute_240:
                    list = StorageMin240[itemCode];
                    break;

                case TimeIntervalEnum.Minute_300:
                    list = StorageMin300[itemCode];
                    break;

                case TimeIntervalEnum.Minute_360:
                    list = StorageMin360[itemCode];
                    break;

                case TimeIntervalEnum.Minute_480:
                    list = StorageMin480[itemCode];
                    break;

                case TimeIntervalEnum.Minute_720:
                    list = StorageMin720[itemCode];
                    break;

                case TimeIntervalEnum.Day:
                    list = StorageDay[itemCode];
                    break;               
            }
            if (list == null) return;
            if (list.Count < 10) return;

            
            try
            {
                var result = PPUtils.GetSameUpDownCount(list);
                int cnt = result.Item1;
                PlusMinusTypeEnum pmType = result.Item2;
                PPEvents.Instance.OnCandleOccurHandler(itemCode, timeInterval, cnt, pmType);
                var massUpDown = PPUtils.GetMassPattern(list);
                PPEvents.Instance.OnCandleMassPatternHandler(itemCode, timeInterval, massUpDown);

                var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                    candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                    candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                    candleUpDown = PPUtils.GetCandleChartPattern(list, 3);
                PPEvents.Instance.OnCandleChartPatternHandler(itemCode, timeInterval, candleUpDown);
            }
            catch (Exception) { }
        }
    }
}
