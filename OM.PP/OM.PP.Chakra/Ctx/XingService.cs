using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using OM.PP.XingApp.Api;
using OM.PP.XingApp.Config;

namespace OM.PP.Chakra.Ctx
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall
        , ConcurrencyMode = ConcurrencyMode.Multiple
        , UseSynchronizationContext = false)]
    public class XingService : IXingService
    {
        static object sync = new object();

        public string ServiceName => XingServerConfigData.ServiceName;

        public void Noop() { }
       
        public void OrderBuySell(string itemCode, string position, string tradeType, string orderPrice, string quantity)
        {
            try
            {
                string IsuCodeVal = itemCode;
                if(IsuCodeVal.Length  < 4 )
                    IsuCodeVal = ItemCodeSet.GetItemSHCodeByCode(itemCode);

                if (position == "매수") position = "2";
                else if (position == "매도") position = "1";

                if (tradeType == "시장가") tradeType = "1";
                else if (tradeType == "지정가") tradeType = "2";

                Api_WorldFutureTrade api = new Api_WorldFutureTrade();
                api.Query(
                      ""
                    , DateTime.Now.ToString("yyyyMMdd")
                    , WorldFutureAccountInfo.계좌번호
                    , WorldFutureAccountInfo.계좌비밀번호
                    , ItemCodeSet.GetItemSHCodeByCode(itemCode)
                    , "1"
                    , position
                    , tradeType
                    , orderPrice
                    , orderPrice
                    , quantity
                    );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        public List<S_CandleItemData> GetUpJongSiseData(string upjongCode, string gubun,  string ncnt, string qrycnt)
        {
            try
            {
                OM.PP.XingApp.Ex.Api.Api_Upjong api = new XingApp.Ex.Api.Api_Upjong();
                return api.Query(upjongCode, gubun, ncnt, qrycnt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public List<S_CandleItemData> GetJongmokSiseData(string upjongCode, string gubun, string ncnt, string qrycnt)
        {
            try
            {
                OM.PP.XingApp.Ex.Api.Api_Jongmok api = new XingApp.Ex.Api.Api_Jongmok();
                return api.Query(upjongCode, gubun, ncnt, qrycnt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public List<S_CandleItemData> GetWorldIndexSiseData(string code, string gubun)
        {
            try
            {
                OM.PP.XingApp.Ex.Api.Api_WorldIndex api = new XingApp.Ex.Api.Api_WorldIndex();
                return api.Query(code, gubun);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<UpJongJongMokData> GetUpJongJongMokData(string upjongCode)
        {            
            try
            {
                OM.PP.XingApp.Ex.Api.Api_UpjongJongmok api = new XingApp.Ex.Api.Api_UpjongJongmok();
                return api.Query(upjongCode);
            }   
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
