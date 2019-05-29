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
    public interface IPPService : IWService
    {       
        [OperationContract]
        List<LitePurushaPrakriti> GetSourceData(
                string itemCode
            ,   TimeIntervalEnum timeInterval
            ,   string startDate = null
            ,   string endDate = null
            ,   int cnt = 0);

        [OperationContract]
        void SetSourceData(
                string itemCode
            ,   TimeIntervalEnum timeInterval
            ,   LitePurushaPrakriti data);

        [OperationContract]
        List<S_CandleItemData> GetCandleSourceData(
                string itemCode
            , TimeIntervalEnum timeInterval);
        [OperationContract]

        List<S_CandleItemData> GetCandleSourceDataOrderByDesc(
                string itemCode
            , TimeIntervalEnum timeInterval);

        [OperationContract]
        List<S_CandleItemData> GetCandleSourceDataOrderByAsc(
                        string itemCode
                    , TimeIntervalEnum timeInterval);

        [OperationContract]
        void SetCandleSourceData(
              string itemCode
            , TimeIntervalEnum timeInterval
            , S_CandleItemData data);

        [OperationContract]
        void InitSourceData(string item);

        [OperationContract]
        void ClearSourceData(string item, TimeIntervalEnum timeInterval);

        [OperationContract]
        void InitSourceTickData(string item);
    }
}
