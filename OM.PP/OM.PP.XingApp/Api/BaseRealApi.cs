using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XA_DATASETLib;

namespace OM.PP.XingApp.Api
{   
    public class BaseRealApi
    {
        protected string resName = string.Empty;
        protected string inBlock = string.Empty;
        protected string outBlock = string.Empty;
       
        protected XARealClass real;

        public BaseRealApi(string resName)
        {
            this.resName = resName;
            inBlock = "InBlock";
            outBlock = "OutBlock";
            
            if (real == null)
            {
                real = new XARealClass();
                real.ReceiveRealData += Real_ReceiveRealData;
                real.LoadFromResFile($".\\res\\{resName}.res");
            }
        }

        public virtual void Real_ReceiveRealData(string szTrCode)
        {            
        }
    }
}
