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
    /// <summary>
    /// 코스피 200 지수
    /// </summary>
    class Api_IndexFutureTrade : BaseTradeApi
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

        public Api_IndexFutureTrade()
        {   
            this.resName = "CFOAT00100";
            inBlock = resName + "InBlock1";            
            outBlock1 = resName + "OutBlock1";
            outBlock2 = resName + "OutBlock2";

            if (query == null)
            {
                query = new XAQueryClass();
                query.ReceiveData += query_ReceiveData;
                query.ReceiveMessage += query_ReceiveMessage;
                query.LoadFromResFile($".\\res\\{resName}.res");
            }
        }

        #region Query
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AcntNo">계좌번호</param>
        /// <param name="pwd">비밀번호</param>
        /// <param name="FnolsuNo">선물옵션종목번호</param>
        /// <param name="BnsTpCode">매매구분 1.매도 2.매수</param>
        /// <param name="FnoOrdprcPtnCode">선물옵션호가유형코드 00.지정가 , 03. 시장가</param>
        /// <param name="OrdPrc">주문가격</param>
        /// <param name="OrdQty">주문수량</param>
        public void Query(
              string AcntNo = ""
            , string Pwd = ""            
            , string FnoIsuNo = ""
            , string BnsTpCode = ""
            , string FnoOrdprcPtnCode = ""
            , string OrdPrc = ""
            , string OrdQty = "")
        {
            ItemCode = FnoIsuNo;            
            query.SetFieldData(inBlock, "AcntNo", 0, AcntNo);
            query.SetFieldData(inBlock, "Pwd", 0, Pwd);
            query.SetFieldData(inBlock, "FnoIsuNo", 0, FnoIsuNo);
            query.SetFieldData(inBlock, "BnsTpCode", 0, BnsTpCode);
            query.SetFieldData(inBlock, "FnoOrdprcPtnCode", 0, FnoOrdprcPtnCode);
            query.SetFieldData(inBlock, "OrdPrc", 0, OrdPrc);
            query.SetFieldData(inBlock, "OrdQty", 0, OrdQty);
            query.Request(false);
        }

        protected override void query_ReceiveData(string szTrCode)
        {            
            string FnolsuNo = query.GetFieldData(outBlock1, "FnoIsuNo", 0);
            string BnsTpCode = query.GetFieldData(outBlock1, "BnsTpCode", 0);
            string FnoOrdPtnCode = query.GetFieldData(outBlock1, "FnoOrdPtnCode", 0);
            string FnoOrdprcPtnCode = query.GetFieldData(outBlock1, "FnoOrdprcPtnCode", 0);
            string OrdPrc = query.GetFieldData(outBlock1, "OrdPrc", 0);
            string OrdQty = query.GetFieldData(outBlock1, "OrdQty", 0);

            //OnApiLog("Api_IndexFutureTrade ::: query_ReceiveData");
        }
        #endregion

    }
}
