using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Lib.Framework.Db
{
    public class DBConfiguration
    {
        private DBConfiguration()
        { }

        private static string defaultConnectionString = string.Empty;

        /// <summary>
        /// 디폴트 디비연결문을 가져옵니다.
        /// </summary>
        public static string DefaultConnectionString
        {
            get
            {
                return defaultConnectionString == string.Empty ? System.Configuration.ConfigurationManager.ConnectionStrings["DefaultDNS"].ConnectionString : defaultConnectionString;
            }
        }
        /// <summary>
        /// 특정 DNS에 맞는 디비연결문을 가져옵니다.
        /// </summary>
        /// <param name="dns"></param>
        /// <returns></returns>
        public static string GetConnectionString(string dns)
        {            
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[dns].ConnectionString;

            if (defaultConnectionString.Length > 0)
                return defaultConnectionString;
            else
                return string.IsNullOrEmpty(connStr) ? DefaultConnectionString : connStr;
        }

        /// <summary>
        /// 특정 DNS에 맞는 디비연결문을 가져옵니다.
        /// </summary>
        /// <param name="dns"></param>
        /// <returns></returns>
        public static void SetDefaultConnectionString(string conString)
        {
            defaultConnectionString = conString;
        }

        /// <summary>
        /// 데이터베이스 타입을 가져옵니다.
        /// </summary>
        /// <param name="dns"></param>
        /// <returns></returns>
        public static DBType GetDbType(string dns)
        {
            try
            {
                if (dns.Equals(""))
                    dns = "DefaultDNS";

                string dbTypeString = System.Configuration.ConfigurationManager.ConnectionStrings[dns].ProviderName;

                switch (dbTypeString)
                {
                    case "MSSQL": return DBType.MSSQL;
                    case "ORACLE": return DBType.ORACLE;
                    case "DB2": return DBType.DB2;
                    case "SYBASE": return DBType.SYBASE;
                    case "OLEDB": return DBType.OLEDB;
                    case "ODBC": return DBType.ODBC;
                    default: return DBType.MSSQL;
                }
            }
            catch (System.Exception) {
                return DBType.MSSQL;
            }
        }


        /// <summary>
        /// 파라메터 정보를 캐시할 것인가
        /// </summary>
        public static bool EnableCacheParameter
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EnableCacheParameter"] == null ?
               true : System.Configuration.ConfigurationManager.AppSettings["EnableCacheParameter"] == "True";
               
            }
        }
    }
}
