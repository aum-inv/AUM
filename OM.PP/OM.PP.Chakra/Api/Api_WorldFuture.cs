using OM.Lib.Base.Enums;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XA_DATASETLib;

namespace OM.PP.XingApp.Api
{
    class Api_WorldFuture : BaseApi
    {
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

        public Api_WorldFuture() : base("o3103")
        {
        }

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
                OnApiLog("Api_WorldFuture ::: query_ReceiveData");
            });
        }
        #endregion
    }
}
