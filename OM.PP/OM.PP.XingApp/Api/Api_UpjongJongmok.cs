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
    class Api_UpjongJongmok : BaseApi
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

        public Api_UpjongJongmok() : base("t1516")
        {
        }

        #region Query
        /// <summary>
        /// 분 쿼리일때는 qrycnt
        /// 일 이상 쿼리일때는 날짜로 가져온다.
        /// </summary>

        public void Query(string upjongCode)
        {
            Task.Factory.StartNew(() =>
            {
                query.SetFieldData(inBlock, "upcode", 0, upjongCode);
                query.SetFieldData(inBlock, "gubun", 0, "");
                query.SetFieldData(inBlock, "shcode", 0, "");
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
                     
                      var list = new List<UpJongJongMokData>();
                      for (int idx = 0; idx < blockCnt; idx++)
                      {                          
                          string 종목명    = query.GetFieldData(outBlock1, "hname", idx);
                          string 현재가    = query.GetFieldData(outBlock1, "price", idx);
                          string 전일대비구분 = query.GetFieldData(outBlock1, "sign", idx);
                          string 전일대비   = query.GetFieldData(outBlock1, "change", idx);
                          string 등락율 = query.GetFieldData(outBlock1, "diff", idx);
                          string 누적거래량 = query.GetFieldData(outBlock1, "volume", idx);
                          string 시가 = query.GetFieldData(outBlock1, "open", idx);
                          string 고가 = query.GetFieldData(outBlock1, "high", idx);
                          string 저가 = query.GetFieldData(outBlock1, "low", idx);
                          string 소진율 = query.GetFieldData(outBlock1, "sojinrate", idx);
                          string 베타계수 = query.GetFieldData(outBlock1, "beta", idx);
                          string PER = query.GetFieldData(outBlock1, "perx", idx);
                          string 외인순매수 = query.GetFieldData(outBlock1, "frgsvolume", idx);
                          string 기관순매수 = query.GetFieldData(outBlock1, "orgsvolume", idx);
                          string 거래증가율 = query.GetFieldData(outBlock1, "diff_vol", idx);
                          string 종목코드 = query.GetFieldData(outBlock1, "shcode", idx); 
                          string 시가총액 = query.GetFieldData(outBlock1, "total", idx);
                          string 거래대금 = query.GetFieldData(outBlock1, "value", idx);

                          UpJongJongMokData data = new UpJongJongMokData();

                          data.종목명 = 종목명;
                          data.전일대비구분 = 전일대비구분;
                          data.종목코드 = 종목코드;
                          data.현재가 = Convert.ToDouble(현재가);
                          data.전일대비 = Convert.ToDouble(전일대비);
                          data.누적거래량 = Convert.ToDouble(누적거래량);
                          data.시가 = Convert.ToDouble(시가);
                          data.고가 = Convert.ToDouble(고가);
                          data.저가 = Convert.ToDouble(저가);
                          data.소진율 = Convert.ToDouble(소진율);
                          data.베타계수 = Convert.ToDouble(베타계수);
                          data.PER = Convert.ToDouble(PER);
                          data.외인순매수 = Convert.ToDouble(외인순매수);
                          data.기관순매수 = Convert.ToDouble(기관순매수);
                          data.거래증가율 = Convert.ToDouble(거래증가율);
                          data.시가총액 = Convert.ToDouble(시가총액);
                          data.거래대금 = Convert.ToDouble(거래대금);

                          list.Add(data);
                      }
                      OnApiLog("Api_UpjongJongmok ::: query_ReceiveData");
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
