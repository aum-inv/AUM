using Microsoft.SqlServer.Server;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Framework.Utility;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XA_DATASETLib;

namespace OM.PP.XingApp.Ex.Api
{
    class Api_Crypto : BaseApi
    {
        public ManualResetEvent manualEvent = new ManualResetEvent(false);

        public string ItemCode
        {
            get;
            set;
        }

        public TimeIntervalEnum TimeInterval
        {
            get;
            set;
        }

        public Api_Crypto() : base("o3103")
        {
        }

        List<S_CandleItemData> returnList = new List<S_CandleItemData>();

        #region Query Http
        public List<S_CandleItemData> Query(
             string itemCode
           , string gubun = "D" //M : 15Min, H : Hour, D : Day, W : Week, M : Month
           )
        {
            this.ItemCode = itemCode;
            int round = ItemCodeUtil.GetItemCodeRoundNum(ItemCode);

            Task.Factory.StartNew(() => {
                try
                {
                    string symbol = "945629";
                    if (itemCode == "BTCUSD") symbol = "945629";
                    else if (itemCode == "ETHUSD") symbol = "997650";
                    else if (itemCode == "BCHUSD") symbol = "1058255";
                    else if (itemCode == "LTCUSD") symbol = "1057982";

                    string resolution = gubun;
                    if (gubun == "H" || gubun == "1H") resolution = "60";
                    else if (gubun == "2H") resolution = "120";
                    else if (gubun == "4H") resolution = "240";
                    else if (gubun == "5H") resolution = "300";
                    else if (gubun == "M" || gubun == "1M") resolution = "1";
                    else if (gubun == "5M") resolution = "5";
                    else if (gubun == "15M") resolution = "15";
                    else if (gubun == "30M") resolution = "30";

                    Int32 from = (Int32)(DateTime.UtcNow.AddYears(-2).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    Int32 to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    if (gubun == "M" || gubun == "1M")
                    {
                        from = (Int32)(DateTime.UtcNow.AddDays(-1).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "5M")
                    {
                        from = (Int32)(DateTime.UtcNow.AddDays(-5).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "15M")
                    {
                        from = (Int32)(DateTime.UtcNow.AddDays(-15).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "30M")
                    {
                        from = (Int32)(DateTime.UtcNow.AddMonths(-1).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(1).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "H" || gubun == "1H")
                    {
                        from = (Int32)(DateTime.UtcNow.AddMonths(-2).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "2H")
                    {
                        from = (Int32)(DateTime.UtcNow.AddMonths(-4).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "4H")
                    {
                        from = (Int32)(DateTime.UtcNow.AddMonths(-8).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "5H")
                    {
                        from = (Int32)(DateTime.UtcNow.AddMonths(-10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "W")
                    {
                        from = (Int32)(DateTime.UtcNow.AddYears(-5).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }
                    else if (gubun == "M")
                    {
                        from = (Int32)(DateTime.UtcNow.AddYears(-10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                        to = (Int32)(DateTime.UtcNow.AddDays(10).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    }

                    string urlPath = $"https://tvc4.forexpros.com/1cc1f0b6f392b9fad2b50b7aebef1f7c/1601866558/18/18/88/history?symbol={symbol}&resolution={resolution}&from={from}&to={to}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPath);
                    request.MaximumAutomaticRedirections = 4;
                    request.MaximumResponseHeadersLength = 4;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    string content = readStream.ReadToEnd();

                    var dyObj = JsonConverter.JsonToDynamicObject(content);
                    int cnt = dyObj.t.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        Int64 t = dyObj.t[i];
                        double o = dyObj.o[i];
                        double c = dyObj.c[i];
                        double h = dyObj.h[i];
                        double l = dyObj.l[i];
                        DateTime cTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(t);
                        //Console.WriteLine($"DT : {cTime.ToLongDateString()} O : {Math.Round(o, 2)}, H : {Math.Round(h, 2)}, L : {Math.Round(l, 2)}, C : {Math.Round(c, 2)}");

                        S_CandleItemData data = new S_CandleItemData();
                        data.DTime = cTime;
                        data.ItemCode = ItemCode;
                        data.OpenPrice = (Single)Math.Round(o, round);
                        data.HighPrice = (Single)Math.Round(h, round);
                        data.LowPrice = (Single)Math.Round(l, round);
                        data.ClosePrice = (Single)Math.Round(c, round);
                        data.Volume = 0;

                        returnList.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
                finally
                {
                    manualEvent.Set();
                }
            });
            manualEvent.WaitOne();

            return returnList;
        }

        public List<S_CandleItemData> Query(
                string itemCode           
            ,   string gubun//M : 15Min, H : Hour, D : Day, W : Week, M : Month
            ,   DateTime sDT
            ,   DateTime dDT
           )
        {
            this.ItemCode = itemCode;
            int round = ItemCodeUtil.GetItemCodeRoundNum(ItemCode);

            Int32 from = (Int32)(sDT.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 to = (Int32)(dDT.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            Task.Factory.StartNew(() => {
                try
                {
                    string symbol = "945629";
                    if (itemCode == "BTCUSD") symbol = "945629";
                    else if (itemCode == "ETHUSD") symbol = "997650";
                    else if (itemCode == "BCHUSD") symbol = "1058255";
                    else if (itemCode == "LTCUSD") symbol = "1057982";

                    string resolution = gubun;
                    if (gubun == "H" || gubun == "1H") resolution = "60";
                    else if (gubun == "2H") resolution = "120";
                    else if (gubun == "4H") resolution = "240";
                    else if (gubun == "5H") resolution = "300";
                    else if (gubun == "M" || gubun == "1M") resolution = "1";
                    else if (gubun == "5M") resolution = "5";
                    else if (gubun == "15M") resolution = "15";
                    else if (gubun == "30M") resolution = "30";
                                       
                    string urlPath = $"https://tvc4.forexpros.com/1cc1f0b6f392b9fad2b50b7aebef1f7c/1601866558/18/18/88/history?symbol={symbol}&resolution={resolution}&from={from}&to={to}";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPath);
                    request.MaximumAutomaticRedirections = 4;
                    request.MaximumResponseHeadersLength = 4;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    string content = readStream.ReadToEnd();

                    var dyObj = JsonConverter.JsonToDynamicObject(content);
                    int cnt = dyObj.t.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        Int64 t = dyObj.t[i];
                        double o = dyObj.o[i];
                        double c = dyObj.c[i];
                        double h = dyObj.h[i];
                        double l = dyObj.l[i];
                        DateTime cTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(t);
                        //Console.WriteLine($"DT : {cTime.ToLongDateString()} O : {Math.Round(o, 2)}, H : {Math.Round(h, 2)}, L : {Math.Round(l, 2)}, C : {Math.Round(c, 2)}");

                        S_CandleItemData data = new S_CandleItemData();
                        data.DTime = cTime;
                        data.ItemCode = ItemCode;
                        data.OpenPrice = (Single)Math.Round(o, round);
                        data.HighPrice = (Single)Math.Round(h, round);
                        data.LowPrice = (Single)Math.Round(l, round);
                        data.ClosePrice = (Single)Math.Round(c, round);
                        data.Volume = 0;

                        returnList.Add(data);
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
                finally
                {
                    manualEvent.Set();
                }
            });
            manualEvent.WaitOne();

            return returnList;
        }
        #endregion
        #region Query
            /// <summary>
            /// 분 쿼리일때는 qrycnt
            /// 일 이상 쿼리일때는 날짜로 가져온다.
            /// </summary>
            /// <param name="shcode">101</param>
            /// <param name="ncnt"></param>
            /// <param name="qrycnt"></param>
            /// <param name="cts_date"></param>
            /// <param name="cts_time"></param>
            /// <param name="cts_daygb">연속당일구분(0. 연속전체, 1.연속당)</param>
            public void Query(
              string shcode
            , string gubun = "1"
            , string ncnt = "1"
            , string qrycnt = "100"
            , string cts_date = ""
            , string cts_time = "")
        {  
            ItemCode = shcode;

            TimeInterval = EnumUtil.GetTimeIntervalValue(gubun, ncnt);
            if (cts_date == "") cts_date = DateTime.Now.ToString("yyyyMMdd");
            query.SetFieldData(inBlock, "shcode", 0, shcode + ".1");     
            query.SetFieldData(inBlock, "ncnt", 0, ncnt);
            query.SetFieldData(inBlock, "readcnt", 0, qrycnt);
            query.SetFieldData(inBlock, "cts_date", 0, cts_date);
            query.SetFieldData(inBlock, "cts_time", 0, cts_time);

            query.Request(false);
        }

        protected override void query_ReceiveData(string szTrCode)
        {
            Task.Factory.StartNew(() =>
            {
                int blockCnt = Convert.ToInt32(query.GetBlockCount(outBlock1));

                for (int idx = 0; idx < blockCnt; idx++)
                {
                    string date = query.GetFieldData(outBlock1, "date", idx);
                    string time = query.GetFieldData(outBlock1, "time", idx);
                    string open = query.GetFieldData(outBlock1, "open", idx);
                    string high = query.GetFieldData(outBlock1, "high", idx);
                    string low = query.GetFieldData(outBlock1, "low", idx);
                    string close = query.GetFieldData(outBlock1, "close", idx);
                    //string jdiff_vol = query.GetFieldData(outBlock1, "jdiff_vol", idx);
                    //string value = query.GetFieldData(outBlock1, "value", idx);

                    if (date.Length == 0) continue;

                    OM.Lib.Entity.LitePurushaPrakriti data = new Lib.Entity.LitePurushaPrakriti();

                    string format = "yyyyMMdd" + (time.Length > 0 ? "HHmmss" : "");

                    var dt = DateTime.ParseExact(date + time, format, CultureInfo.InvariantCulture);

                    data.DT = dt;
                    data.Item = ItemCode;
                    data.OpenVal = Convert.ToSingle(open);
                    data.HighVal = Convert.ToSingle(high);
                    data.LowVal = Convert.ToSingle(low);
                    data.CloseVal = Convert.ToSingle(close);
                    data.Volume = 0;
                    data.Interval = (int)TimeInterval;

                    PPContext.Instance.ClientContext.SetSourceData(
                          ItemCode
                        , TimeInterval
                        , data);

                    OnApiLog($"date : {date} time : {time} opne : {open} high : {high} low : {low} close : {close} ");
                }
                OnApiLog("Api_Crypto ::: query_ReceiveData");
            });
        }
        #endregion
    }
}
