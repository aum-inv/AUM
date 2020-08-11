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
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin01 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin05 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin10 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin30 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();

        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin60 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin120 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin180 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin240 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin300 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin360 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin480 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageMin720 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageDay = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageWeek = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();


        public void Init(string itemCode)
        {
            try
            {
                if (!StorageMin01.ContainsKey(itemCode))
                {
                    StorageMin01.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin01[itemCode].Clear();
                }

                if (!StorageMin05.ContainsKey(itemCode))
                {
                    StorageMin05.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin05[itemCode].Clear();
                }

                if (!StorageMin10.ContainsKey(itemCode))
                {
                    StorageMin10.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin10[itemCode].Clear();
                }

                if (!StorageMin30.ContainsKey(itemCode))
                {
                    StorageMin30.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageMin30[itemCode].Clear();
                }

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

                if (!StorageWeek.ContainsKey(itemCode))
                {
                    StorageWeek.Add(itemCode, new LimitedList<S_CandleItemData>(1000));
                }
                else
                {
                    StorageWeek[itemCode].Clear();
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
                    case TimeIntervalEnum.Minute_01:
                        storageList = StorageMin01[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_05:
                        storageList = StorageMin05[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_10:
                        storageList = StorageMin10[itemCode];
                        break;

                    case TimeIntervalEnum.Minute_30:
                        storageList = StorageMin30[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_01:
                        storageList = StorageMin60[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_02:
                        storageList = StorageMin120[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_03:
                        storageList = StorageMin180[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_04:
                        storageList = StorageMin240[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_05:
                        storageList = StorageMin300[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_06:
                        storageList = StorageMin360[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_08:
                        storageList = StorageMin480[itemCode];
                        break;

                    case TimeIntervalEnum.Hour_12:
                        storageList = StorageMin720[itemCode];
                        break;

                    case TimeIntervalEnum.Day:
                        storageList = StorageDay[itemCode];
                        break;

                    case TimeIntervalEnum.Week:
                        storageList = StorageWeek[itemCode];
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
                case TimeIntervalEnum.Minute_01:
                    list = StorageMin01[itemCode];
                    break;

                case TimeIntervalEnum.Minute_05:
                    list = StorageMin05[itemCode];
                    break;

                case TimeIntervalEnum.Minute_10:
                    list = StorageMin10[itemCode];
                    break;

                case TimeIntervalEnum.Minute_30:
                    list = StorageMin30[itemCode];
                    break;

                case TimeIntervalEnum.Hour_01:
                    list = StorageMin60[itemCode];
                    break;

                case TimeIntervalEnum.Hour_02:
                    list = StorageMin120[itemCode];
                    break;

                case TimeIntervalEnum.Hour_03:
                    list = StorageMin180[itemCode];
                    break;

                case TimeIntervalEnum.Hour_04:
                    list = StorageMin240[itemCode];
                    break;

                case TimeIntervalEnum.Hour_05:
                    list = StorageMin300[itemCode];
                    break;

                case TimeIntervalEnum.Hour_06:
                    list = StorageMin360[itemCode];
                    break;

                case TimeIntervalEnum.Hour_08:
                    list = StorageMin480[itemCode];
                    break;

                case TimeIntervalEnum.Hour_12:
                    list = StorageMin720[itemCode];
                    break;

                case TimeIntervalEnum.Day:
                    list = StorageDay[itemCode];
                    break;

                case TimeIntervalEnum.Week:
                    list = StorageWeek[itemCode];
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
