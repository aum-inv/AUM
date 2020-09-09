using OM.Atman.Chakra.Ctx;
using OM.Lib.Base.Enums;
using OM.Lib.Entity;
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
    class Api_IndexReal : BaseRealApi
    {
        public static bool IsSend = true;

        public string ItemCode
        {
            get;
            set;
        }
        public string ShCode
        {
            get;
            set;
        }
        public TimeIntervalEnum TimeInterval
        {
            get;
            set;
        }

        public Api_IndexReal() : base("IJ_")
        {
        }

        #region Query
        
        public void Query(string shcode)
        {
            ShCode = shcode;
            ItemCode = shcode;
            real.SetFieldData(inBlock, "upcode", shcode);
            real.AdviseRealData();
        }

        public override void Real_ReceiveRealData(string szTrCode)
        {
            string ovsdate = DateTime.Today.ToString("yyyyMMdd");
            string kordate = ovsdate; 
            string time = real.GetFieldData(outBlock, "time");        

            string open = real.GetFieldData(outBlock, "openjisu");
            string high = real.GetFieldData(outBlock, "highjisu");
            string low = real.GetFieldData(outBlock, "lowjisu");
            string curpr = real.GetFieldData(outBlock, "jisu");

            string sign = real.GetFieldData(outBlock, "sign");
            string change = real.GetFieldData(outBlock, "change");
            string drate = real.GetFieldData(outBlock, "drate");
            CurrentPrice item = new CurrentPrice();
            item.chetime = ovsdate + time;
            item.chetimeKr = kordate + time;
            item.open = open;
            item.high = high;
            item.low = low;
            item.price = curpr;
            item.sign = sign;
            item.change = change;
            item.drate = drate;

            if (Api_IndexReal.IsSend)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        AtmanContext.Instance.ClientContext.SetCurrentPriceKr(ItemCode, item);
                    }
                    catch (Exception) { }
                });
            }
        }
        #endregion
    }
}
