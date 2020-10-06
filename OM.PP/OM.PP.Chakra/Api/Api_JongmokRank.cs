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
    class Api_JongmokRank : BaseApi
    {
        public ManualResetEvent manualEvent = new ManualResetEvent(false);
        
        public Api_JongmokRank() : base("t1452")
        {
        }

        #region Query
        /// <summary>
        /// 분 쿼리일때는 qrycnt
        /// 일 이상 쿼리일때는 날짜로 가져온다.
        /// </summary>
        List<UpJongJongMokData> returnList = new List<UpJongJongMokData>();
        public List<UpJongJongMokData> Query(string gubun = "0", string sdiff = "-10", string ediff = "10")
        {           
            string jc_num = "-02147483648";
            string jnilgubun = "1";

            query.SetFieldData(inBlock, "gubun", 0, gubun);
            query.SetFieldData(inBlock, "jnilgubun", 0, jnilgubun);
            query.SetFieldData(inBlock, "sdiff", 0, sdiff);
            query.SetFieldData(inBlock, "ediff", 0, ediff);
            query.SetFieldData(inBlock, "jc_num", 0, jc_num);
            query.SetFieldData(inBlock, "sprice", 0, "");
            query.SetFieldData(inBlock, "eprice", 0, "");
            query.SetFieldData(inBlock, "volume", 0, "");
            query.SetFieldData(inBlock, "idx", 0, "");
            query.Request(false);           

            manualEvent.WaitOne();
            return returnList;
        }

        protected override void query_ReceiveData(string szTrCode)
        {
            try
            {
                int blockCnt = Convert.ToInt32(query.GetBlockCount(outBlock1));

                for (int idx = 0; idx < blockCnt; idx++)
                {
                    string 종목명 = query.GetFieldData(outBlock1, "hname", idx);
                    string 현재가 = query.GetFieldData(outBlock1, "price", idx);
                    string 전일대비구분 = query.GetFieldData(outBlock1, "sign", idx);
                    string 전일대비 = query.GetFieldData(outBlock1, "change", idx);
                    string 등락율 = query.GetFieldData(outBlock1, "diff", idx);
                    string 누적거래량 = query.GetFieldData(outBlock1, "volume", idx);                  
                    string 종목코드 = query.GetFieldData(outBlock1, "shcode", idx);

                    UpJongJongMokData data = new UpJongJongMokData();

                    data.종목명 = 종목명;
                    data.전일대비구분 = 전일대비구분;
                    data.종목코드 = 종목코드;
                    data.현재가 = Convert.ToDouble(현재가);
                    data.전일대비 = Convert.ToDouble(전일대비);
                    data.등락율 = Convert.ToDouble(등락율);
                    data.누적거래량 = Convert.ToDouble(누적거래량);                   

                    returnList.Add(data);
                }
                OnApiLog("Api_JongmokRank ::: query_ReceiveData");
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
