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
    class Api_WorldIndex : BaseApi
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

        public Api_WorldIndex() : base("t3518")
        {
        }

        #region Query
        /// <summary>
        /// 분 쿼리일때는 qrycnt
        /// 일 이상 쿼리일때는 날짜로 가져온다.
        /// </summary>

        public void Query(
              string kind = "S"
            , string symbol = ""
            , string gubun = "0" //0:일 1:주 2:월           
            )
        {
            Task.Factory.StartNew(() =>
            {
                ItemCode = symbol;

                if (gubun == "0")
                    TimeInterval = TimeIntervalEnum.Day;
                else if (gubun == "1")
                    TimeInterval = TimeIntervalEnum.Week;
                else if (gubun == "2")
                    TimeInterval = TimeIntervalEnum.Month;

                string qrycnt = "500"; //건수
                string cts_date = "";
                string cts_time = "";
              
                query.SetFieldData(inBlock, "kind", 0, kind);
                query.SetFieldData(inBlock, "symbol", 0, symbol);
                query.SetFieldData(inBlock, "cnt", 0, qrycnt);
                query.SetFieldData(inBlock, "jgbn", 0, gubun);
                query.SetFieldData(inBlock, "nmin", 0, "");        
                query.SetFieldData(inBlock, "cts_date", 0, cts_date);
                query.SetFieldData(inBlock, "cts_time", 0, cts_time);
                query.Request(false);
            });
        }

        protected override void query_ReceiveData(string szTrCode)
        {
            Task.Factory.StartNew(() =>
              {
                  try
                  {
                      int blockCnt = Convert.ToInt32(query.GetBlockCount(outBlock1));
                      int round = ItemCodeUtil.GetItemCodeRoundNum(ItemCode);

                      for (int idx = 0; idx < blockCnt; idx++)
                      {
                          string date = query.GetFieldData(outBlock1, "date", idx);
                          string time = query.GetFieldData(outBlock1, "time", idx);
                          string open = query.GetFieldData(outBlock1, "open", idx);
                          string high = query.GetFieldData(outBlock1, "high", idx);
                          string low = query.GetFieldData(outBlock1, "low", idx);
                          string close = query.GetFieldData(outBlock1, "price", idx);                         
                          string volume = query.GetFieldData(outBlock1, "volume", idx);

                          if (date.Length == 0) continue;

                          //string format = "yyyyMMdd" + (time.Length > 0 ? "HHmmss" : "");
                          string format = "yyyyMMdd";
                          var dt = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);

                          S_CandleItemData data = new S_CandleItemData();
                          data.DTime = dt;
                          data.ItemCode = ItemCode;
                          data.OpenPrice = (Single)Math.Round(Convert.ToDouble(open) * 100, round);
                          data.HighPrice = (Single)Math.Round(Convert.ToDouble(high) * 100, round);
                          data.LowPrice = (Single)Math.Round(Convert.ToDouble(low) * 100, round);
                          data.ClosePrice = (Single)Math.Round(Convert.ToDouble(close) * 100, round);
                          data.Volume = Convert.ToSingle(volume);

                          PPContext.Instance.ClientContext.SetCandleSourceData(ItemCode, TimeInterval, data);

                          OnApiLog($"date : {date} time : {time} opne : {open} high : {high} low : {low} close : {close} ");
                      }
                      OnApiLog("Api_WorldIndex ::: query_ReceiveData");
                  }
                  catch (Exception ex)
                  {
                      OnApiLog("Error ::: " + ex.Message);
                  }
                  finally
                  {
                      manualEvent.Set();
                  }

              });
        }
       
    }

    #endregion
}
