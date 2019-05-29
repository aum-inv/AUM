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
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageDay = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();

        public Dictionary<string, LimitedList<S_CandleItemData>> StorageTick180 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageTick360 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageTick720 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageTick1080 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();
        public Dictionary<string, LimitedList<S_CandleItemData>> StorageTick1440 = new Dictionary<string, Lib.Base.LimitedList<S_CandleItemData>>();

        public void Init(string itemCode)
        {
            try
            {
                if (!StorageMin01.ContainsKey(itemCode))
                {
                    StorageMin01.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin01[itemCode].Clear();
                }

                if (!StorageMin05.ContainsKey(itemCode))
                {
                    StorageMin05.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin05[itemCode].Clear();
                }

                if (!StorageMin10.ContainsKey(itemCode))
                {
                    StorageMin10.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin10[itemCode].Clear();
                }

                if (!StorageMin30.ContainsKey(itemCode))
                {
                    StorageMin30.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin30[itemCode].Clear();
                }

                if (!StorageMin60.ContainsKey(itemCode))
                {
                    StorageMin60.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin60[itemCode].Clear();
                }

                if (!StorageMin120.ContainsKey(itemCode))
                {
                    StorageMin120.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageMin120[itemCode].Clear();
                }

                if (!StorageDay.ContainsKey(itemCode))
                {
                    StorageDay.Add(itemCode, new LimitedList<S_CandleItemData>(200));
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
        public void InitTick(string itemCode)
        {
            try
            {
                if (!StorageTick180.ContainsKey(itemCode))
                {
                    StorageTick180.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageTick180[itemCode].Clear();
                }

                if (!StorageTick360.ContainsKey(itemCode))
                {
                    StorageTick360.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageTick360[itemCode].Clear();
                }

                if (!StorageTick720.ContainsKey(itemCode))
                {
                    StorageTick720.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageTick720[itemCode].Clear();
                }

                if (!StorageTick1080.ContainsKey(itemCode))
                {
                    StorageTick1080.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageTick1080[itemCode].Clear();
                }

                if (!StorageTick1440.ContainsKey(itemCode))
                {
                    StorageTick1440.Add(itemCode, new LimitedList<S_CandleItemData>(200));
                }
                else
                {
                    StorageTick1440[itemCode].Clear();
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
                    case TimeIntervalEnum.Minute_60:
                        storageList = StorageMin60[itemCode];
                        break;
                    case TimeIntervalEnum.Minute_120:
                        storageList = StorageMin120[itemCode];
                        break;
                    case TimeIntervalEnum.Day:
                        storageList = StorageDay[itemCode];
                        break;
                    case TimeIntervalEnum.Tick_180:
                        storageList = StorageTick180[itemCode];
                        break;
                    case TimeIntervalEnum.Tick_360:
                        storageList = StorageTick360[itemCode];
                        break;
                    case TimeIntervalEnum.Tick_720:
                        storageList = StorageTick720[itemCode];
                        break;
                    case TimeIntervalEnum.Tick_1080:
                        storageList = StorageTick1080[itemCode];
                        break;
                    case TimeIntervalEnum.Tick_1440:
                        storageList = StorageTick1440[itemCode];
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
            }
        }
        
        public void GetState(string itemCode, TimeIntervalEnum timeInterval)
        {
            LimitedList<S_CandleItemData> list = null;
            switch (timeInterval)
            {
                case TimeIntervalEnum.Minute_10:
                    list = StorageMin10[itemCode];
                    break;
                case TimeIntervalEnum.Minute_30:
                    list = StorageMin30[itemCode];
                    break;
                case TimeIntervalEnum.Minute_60:
                    list = StorageMin60[itemCode];
                    break;
                case TimeIntervalEnum.Minute_120:
                    list = StorageMin120[itemCode];
                    break;
                case TimeIntervalEnum.Day:
                    list = StorageDay[itemCode];
                    break;
                case TimeIntervalEnum.Tick_180:
                    list = StorageTick180[itemCode];
                    break;
                case TimeIntervalEnum.Tick_360:
                    list = StorageTick360[itemCode];
                    break;
                case TimeIntervalEnum.Tick_720:
                    list = StorageTick720[itemCode];
                    break;
                case TimeIntervalEnum.Tick_1080:
                    list = StorageTick1080[itemCode];
                    break;
                case TimeIntervalEnum.Tick_1440:
                    list = StorageTick1440[itemCode];
                    break;
            }
            if (list == null) return;
            if (list.Count < 10) return;

            try
            {
                LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, timeInterval, lineChartPattern2, "Line2");

                var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, timeInterval, lineChartPattern3, "Line3");

                var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, timeInterval, upDownH, "High");

                var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, timeInterval, upDownL, "Low");

                var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, timeInterval, upDownHL, "HL");
            }
            catch (Exception) { }
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

        /* Add 
        public void Add(string itemCode, DateTime dateTime, Single price)
        {
            try
            {
                AddMin05(itemCode, dateTime, price);
                AddMin10(itemCode, dateTime, price);
                AddMin30(itemCode, dateTime, price);
                AddMin60(itemCode, dateTime, price);
                //AddMin120(itemCode, dateTime, price);
                //AddDay(itemCode, dateTime, price);
            }
            catch (Exception)
            {
            }
        }
        public void AddMin05(string itemCode, DateTime dt, Single price)
        {
            try
            {
                bool isCheck = false;

                var list = StorageMin05[itemCode];
                var item = list[0];
                DateTime newDt = GetTime(dt, 5);

                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 5) isCheck = false;
                }
                isCheck = false;
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        //if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_05, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        //if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_05, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        //if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_05, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        //if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_05, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        //if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_05, upDownHL, "HL");
                    }
                    catch (Exception) { }
                    try
                    {
                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;
                        PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_05, cnt, pmType);                       
                        var massUpDown = PPUtils.GetMassPattern(list);
                        //if (massUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_05, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);

                        //if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_05, candleUpDown);
                    }
                    catch (Exception) { }
                }

                if(item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));
                }
            }
            catch (Exception)
            {
            }
        }
        public void AddMin10(string itemCode, DateTime dt, Single price)
        {
            try
            {
                bool isCheck = false;

                var list = StorageMin10[itemCode];
                var item = list[0];
                DateTime newDt = GetTime(dt, 10);
                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 10) isCheck = false;
                }
                isCheck = false;
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        //if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_10, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        //if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_10, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        //if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_10, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        //if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_10, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        //if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_10, upDownHL, "HL");
                    }
                    catch (Exception) { }

                    try
                    {
                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;
                        PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_10, cnt, pmType);

                        var massUpDown = PPUtils.GetMassPattern(list);
                        //if (massUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_10, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);

                        //if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_10, candleUpDown);
                    }
                    catch (Exception) { }
                }
                if (item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));
                }
            }
            catch (Exception)
            {
            }
        }
        public void AddMin30(string itemCode, DateTime dt, Single price)
        {
            try
            {
                bool isCheck = false;

                var list = StorageMin30[itemCode];
                var item = list[0];
                DateTime newDt = GetTime(dt, 30);
                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 10) isCheck = false;
                }
                isCheck = false;
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        //if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_30, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        //if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_30, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        //if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_30, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        //if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_30, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        //if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_30, upDownHL, "HL");
                    }
                    catch (Exception) { }

                    try
                    {
                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;
                        PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_30, cnt, pmType);

                        var massUpDown = PPUtils.GetMassPattern(list);
                        //if (massUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_30, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);

                        //if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_30, candleUpDown);
                    }
                    catch (Exception) { }
                }
                if (item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));                    
                }
            }
            catch (Exception)
            {
            }
        }
        public void AddMin60(string itemCode, DateTime dt, Single price)
        {
            try
            {
                bool isCheck = false;

                var list = StorageMin60[itemCode];
                var item = list[0];
                DateTime newDt = GetTime(dt, 60);

                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 10) isCheck = false;
                }
                isCheck = false;
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        //if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_60, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        //if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_60, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        //if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_60, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        //if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_60, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        //if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_60, upDownHL, "HL");
                    }
                    catch (Exception) { }

                    try
                    {
                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;
                        PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_60, cnt, pmType);

                        var massUpDown = PPUtils.GetMassPattern(list);
                        //if (massUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_60, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);

                        //if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_60, candleUpDown);
                    }
                    catch (Exception) { }
                }
                if (item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));
                }
            }
            catch (Exception)
            {
            }
        }        
        public void AddMin120(string itemCode, DateTime dt, Single price)
        {
            try
            {
                bool isCheck = false;

                var list = StorageMin120[itemCode];
                var item = list[0];
                DateTime newDt = GetHour(item.DTime, dt, 2);

                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 10) isCheck = false;
                }
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_120, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Minute_120, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_120, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_120, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Minute_120, upDownHL, "HL");

                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;

                        if (cnt >= 3)
                            PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_120, cnt, pmType);

                        var massUpDown = PPUtils.GetMassPattern(list);
                        if (massUpDown != Lib.Base.Enums.CandleMassPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_120, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);
                        if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Minute_120, candleUpDown);
                    }
                    catch (Exception)
                    { }
                }

                if (item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));                 
                }
            }
            catch (Exception)
            {
            }
        }
        public void AddDay(string itemCode, DateTime dt, Single price)
        {           
            try
            {
                bool isCheck = false;

                var list = StorageDay[itemCode];
                var item = list[0];
                DateTime newDt = GetDay(dt);
                if (item.DTime == newDt)
                {
                    if (item.HighPrice < price) { item.HighPrice = price; isCheck = true; }
                    if (item.LowPrice > price) { item.LowPrice = price; isCheck = true; }
                    item.ClosePrice = price;
                }
                if (isCheck)
                {
                    int tickDiff = PriceTick.GetTickDiff(itemCode, item.HighPrice, item.LowPrice);
                    if (tickDiff <= 10) isCheck = false;
                }
                if (isCheck || item.DTime != newDt)
                {
                    try
                    {
                        LimitedList<double> priceList = PPUtils.GetLinePointByCandle(list);

                        var lineChartPattern2 = PointsUtil.GetTwoLinePattern(priceList);
                        if (lineChartPattern2 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Day, lineChartPattern2, "Line2");

                        var lineChartPattern3 = PointsUtil.GetThreeLinePattern(priceList);
                        if (lineChartPattern3 != TickLineChartPatternEnum.None)
                            PPEvents.Instance.OnTickLineChartPatternHandler(itemCode, TimeIntervalEnum.Day, lineChartPattern3, "Line3");

                        var upDownH = PointsUtil.GetOneLineUpDownPatternH(priceList);
                        if (upDownH != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Day, upDownH, "High");

                        var upDownL = PointsUtil.GetOneLineUpDownPatternL(priceList);
                        if (upDownL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Day, upDownL, "Low");

                        var upDownHL = PointsUtil.GetTwoLineUpDownPatternHL(priceList);
                        if (upDownHL != UpDownPatternEnum.None)
                            PPEvents.Instance.OnTickLineUpDownPatternHandler(itemCode, TimeIntervalEnum.Day, upDownHL, "HL");

                        var result = PPUtils.GetSameUpDownCount(list);
                        int cnt = result.Item1;
                        PlusMinusTypeEnum pmType = result.Item2;

                        if (cnt >= 3)
                            PPEvents.Instance.OnCandleOccurHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Day, cnt, pmType);

                        var massUpDown = PPUtils.GetMassPattern(list);
                        if (massUpDown != Lib.Base.Enums.CandleMassPatternEnum.None)
                            PPEvents.Instance.OnCandleMassPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Day, massUpDown);

                        var candleUpDown = PPUtils.GetCandleChartPattern(list, 6);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 5);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 4);
                        if (candleUpDown == Lib.Base.Enums.CandleChartPatternEnum.None)
                            candleUpDown = PPUtils.GetCandleChartPattern(list, 3);
                        if (candleUpDown != Lib.Base.Enums.CandleChartPatternEnum.None)
                            PPEvents.Instance.OnCandleChartPatternHandler(itemCode, Lib.Base.Enums.TimeIntervalEnum.Day, candleUpDown);
                    }
                    catch (Exception) { }
                }
                if (item.DTime != newDt)
                {
                    list.Insert(new S_CandleItemData(itemCode, price, price, price, price, 0, newDt));
                }
            }
            catch (Exception)
            {
            }
        }       
        private DateTime GetTime(DateTime dt, int min)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int hour = dt.Hour;
            int minute = dt.Minute;
            int newMin = (min * ((minute / min) + 1));

            DateTime dateTime = new DateTime(year, month, day, hour, 0, 0);

            if (newMin == 60) dateTime = dateTime.AddHours(1);
            else dateTime = dateTime.AddMinutes(newMin);

            return dateTime;
        }
        private DateTime GetHour(DateTime oldDT, DateTime newDT, int h)
        {
            if (oldDT < newDT)
                return oldDT.AddHours(h);
            else
                return oldDT;
        }
        private DateTime GetDay(DateTime dt)
        {
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;

            DateTime dateTime = new DateTime(year, month, day, 0, 0, 0);
            return dateTime;
        }
        */
    }
}
