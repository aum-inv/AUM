using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XA_DATASETLib;

namespace OM.PP.XingApp.Api
{
    class Api_IndexFutureMaster : BaseApi
    {
        public Api_IndexFutureMaster() : base("t8413")
        {

        }
        #region Query    
        public void Query()
        {
            if (query == null)
            {
                query = new XAQueryClass();
                query.ReceiveData += query_ReceiveData;
                query.ReceiveMessage += query_ReceiveMessage;
                query.LoadFromResFile($".\\res\\{resName}.res");
            }
            query.SetFieldData(inBlock, "gubun", 0, "");           
            query.Request(false);
        }

        protected override void query_ReceiveData(string szTrCode)
        {
            int blockCnt = Convert.ToInt32(query.GetBlockCount(outBlock));

            for (int idx = 0; idx < blockCnt; idx++)
            {
                string symbol = query.GetFieldData("o3101OutBlock", "Symbol", idx);
                string applDate = query.GetFieldData("o3101OutBlock", "ApplDate", idx);
                string bscGdsCd = query.GetFieldData("o3101OutBlock", "BscGdsCd", idx);
                string bscGdsNm = query.GetFieldData("o3101OutBlock", "BscGdsNm", idx);
            
                Insert();
            }
        }
        #endregion

    }
}
