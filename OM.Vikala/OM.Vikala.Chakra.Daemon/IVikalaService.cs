using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Chakra.Daemon
{
    [ServiceContract]
    public interface IVikalaService : IWService
    {       
        
        [OperationContract]
        void SetCurrentPrice(string itemCode, CurrentPrice price);

        [OperationContract]
        void SetCurrentPriceKr(string itemCode, CurrentPrice price);
    }
}
