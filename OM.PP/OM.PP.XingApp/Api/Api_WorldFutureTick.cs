using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XA_DATASETLib;

namespace OM.PP.XingApp.Api
{
    class Api_WorldFutureTick : BaseApi
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

        public Api_WorldFutureTick() : base("o3117")
        {
            maximumReadCnt = 0;
        }
        public Api_WorldFutureTick(int maximumReadCnt) : base("o3117")
        {
            this.maximumReadCnt = maximumReadCnt;
        }

        public string NCnt
        { get; set; }
        
        public int totalReadCnt = 0;
        public int maximumReadCnt = 0;
        #region Query

        public void Query(
              string shcode     
            , string ncnt = "180")
        {
            Task.Factory.StartNew(() =>
            {
                ItemCode = shcode;
                NCnt = ncnt;
                TimeInterval = EnumUtil.GetTimeIntervalValue("0", NCnt);
              
                query.SetFieldData(inBlock, "shcode", 0, shcode + ".1");
                query.SetFieldData(inBlock, "ncnt", 0, ncnt);
                query.SetFieldData(inBlock, "qrycnt", 0, "10000");
                query.SetFieldData(inBlock, "cts_seq", 0, "");
                query.SetFieldData(inBlock, "cts_daygb", 0, "");

                query.Request(false);
            });
        }

        public void Query(
              string shcode
            , string ncnt = "1"
            , string cts_seq = ""
            , string cts_daygb = "")
        {
            Task.Factory.StartNew(() =>
            {
                ItemCode = shcode;                
                TimeInterval = EnumUtil.GetTimeIntervalValue("0", ncnt);

                query.SetFieldData(inBlock, "shcode", 0, shcode + ".1");
                query.SetFieldData(inBlock, "ncnt", 0, ncnt);
                query.SetFieldData(inBlock, "qrycnt", 0, "10000");
                query.SetFieldData(inBlock, "cts_seq", 0, cts_seq);
                query.SetFieldData(inBlock, "cts_daygb", 0, cts_daygb);

                query.Request(true);
            });
        }

        protected override void query_ReceiveData(string szTrCode)
        {
            PPContext.Instance.ClientContext.ClearSourceData(ItemCode, TimeInterval);

            Task.Factory.StartNew(() =>
            {
                string cts_seq = query.GetFieldData(outBlock, "cts_seq", 0);
                string cts_daygb = query.GetFieldData(outBlock, "cts_daygb", 0);

                int blockCnt = Convert.ToInt32(query.GetBlockCount(outBlock1));
                totalReadCnt += blockCnt;
                int round = ItemCodeUtil.GetItemCodeRoundNum(ItemCode);
                for (int idx = 0; idx < blockCnt; idx++)
                {
                    string date = query.GetFieldData(outBlock1, "date", idx);
                    string time = query.GetFieldData(outBlock1, "time", idx);
                    string open = query.GetFieldData(outBlock1, "open", idx);
                    string high = query.GetFieldData(outBlock1, "high", idx);
                    string low = query.GetFieldData(outBlock1, "low", idx);
                    string close = query.GetFieldData(outBlock1, "close", idx);
                  
                    if (date.Length == 0) continue;
                    /*
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
                    */
                    string format = "yyyyMMdd" + (time.Length > 0 ? "HHmmss" : "");
                    var dt = DateTime.ParseExact(date + time, format, CultureInfo.InvariantCulture);
                    S_CandleItemData data = new S_CandleItemData();
                    data.DTime = dt;
                    data.ItemCode = ItemCode;
                    data.OpenPrice = (Single)Math.Round(Convert.ToDouble(open), round);
                    data.HighPrice = (Single)Math.Round(Convert.ToDouble(high), round);
                    data.LowPrice = (Single)Math.Round(Convert.ToDouble(low), round);
                    data.ClosePrice = (Single)Math.Round(Convert.ToDouble(close), round);
                    data.Volume = 0;
                    PPContext.Instance.ClientContext.SetCandleSourceData(ItemCode, TimeInterval, data);

                    OnApiLog($"date : {date} time : {time} opne : {open} high : {high} low : {low} close : {close} ");
                }
                OnApiLog("Api_WorldFutureTick ::: query_ReceiveData");

                if (totalReadCnt >= maximumReadCnt)
                {
                    manualEvent.Set();
                    return;
                }
                System.Threading.Thread.Sleep(1500);
                Query(ItemCode, NCnt, cts_seq, cts_daygb);
            });
        }
        #endregion
    }
}
