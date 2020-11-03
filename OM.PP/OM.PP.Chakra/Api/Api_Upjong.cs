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

namespace OM.PP.XingApp.Ex.Api
{
    class Api_Upjong : BaseApi
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

        public Api_Upjong() : base("t4203")
        {
        }
        List<S_CandleItemData> returnList = new List<S_CandleItemData>();
        #region Query
        /// <summary>
        /// 분 쿼리일때는 qrycnt
        /// 일 이상 쿼리일때는 날짜로 가져온다.
        /// </summary>

        public List<S_CandleItemData> Query(
              string shcode
            , string gubun = "1" //1:분 2:일 3:주
            , string ncnt = "0" // 분일때 60 120  일일때 0         
            , string qrycnt = "500"
            )
        {
                this.ItemCode = shcode;
            
                TimeInterval = EnumUtil.GetTimeIntervalValue(gubun, ncnt);
                string tdgb = "0";  //당일구분
                string sdate = DateTime.Now.AddYears(Convert.ToInt32(qrycnt) * -1).ToString("yyyyMMdd");
                string edate = DateTime.Now.ToString("yyyyMMdd"); ;
                string cts_date = "";
                string cts_time = "";
                string cts_daygb = "0";

                if (gubun == "1")
                {
                    qrycnt = "500";
                    sdate = edate = "";
                }
                query.SetFieldData(inBlock, "shcode", 0, shcode);
                query.SetFieldData(inBlock, "gubun", 0, gubun);
                query.SetFieldData(inBlock, "ncnt", 0, ncnt);
                query.SetFieldData(inBlock, "qrycnt", 0, qrycnt);
                query.SetFieldData(inBlock, "tdgb", 0, tdgb);
                query.SetFieldData(inBlock, "sdate", 0, sdate);
                query.SetFieldData(inBlock, "edate", 0, edate);
                query.SetFieldData(inBlock, "cts_date", 0, cts_date);
                query.SetFieldData(inBlock, "cts_time", 0, cts_time);
                query.SetFieldData(inBlock, "cts_daygb", 0, cts_daygb);
                query.Request(false);                
            
            manualEvent.WaitOne();
            
            return returnList.OrderBy(t => t.DTime).ToList();
        }

        protected override void query_ReceiveData(string szTrCode)
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
                    string close = query.GetFieldData(outBlock1, "close", idx);
                    string jdiff_vol = query.GetFieldData(outBlock1, "jdiff_vol", idx);
                    string volume = query.GetFieldData(outBlock1, "value", idx);

                    if (date.Length == 0) continue;

                    string format = "yyyyMMdd" + (time.Length > 0 ? "HHmmss" : "");
                    var dt = DateTime.ParseExact(date + time, format, CultureInfo.InvariantCulture);

                    S_CandleItemData data = new S_CandleItemData();
                    data.DTime = dt;
                    data.ItemCode = ItemCode;
                    data.OpenPrice = (Single)Math.Round(Convert.ToDouble(open), round);
                    data.HighPrice = (Single)Math.Round(Convert.ToDouble(high), round);
                    data.LowPrice = (Single)Math.Round(Convert.ToDouble(low), round);
                    data.ClosePrice = (Single)Math.Round(Convert.ToDouble(close), round);
                    data.Volume = Convert.ToSingle(volume);

                    returnList.Add(data);
                }
                
                OnApiLog("Api_Upjong ::: query_ReceiveData");
            }
            catch (Exception ex)
            {
                OnApiLog("Error ::: " + ex.Message);
            }
            finally
            {
                manualEvent.Set();
            }
        }
       
    }

    #endregion
}
