using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Ctx
{
    [ServiceContract]
    public interface IXingService : IWService
    {              
        [OperationContract]
        void OrderBuySell(string itemCode, string position, string tradeType, string orderPrice, string quantity);

        [OperationContract]
        List<S_CandleItemData> GetUpJongSiseData(string upjongCode, string gubun, string ncnt, string qrycnt);
        
        
        [OperationContract]
        List<S_CandleItemData> GetJongmokSiseData(string itemCode, string gubun, string ncnt, string qrycnt);
       
        
        [OperationContract]
        List<S_CandleItemData> GetWorldIndexSiseData(string itemCode, string gubun);

        [OperationContract]
        List<S_CandleItemData> GetWorldFutureSiseData(string itemCode, string gubun);


        [OperationContract]
        List<UpJongJongMokData> GetUpJongJongMokData(string upjongCode);

        [OperationContract]
        List<UpJongJongMokData> GetJongMokRankData(string gubun, string sdiff, string ediff);
    }

}
