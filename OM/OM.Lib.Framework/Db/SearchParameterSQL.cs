using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Lib.Framework.Db
{
    class SearchParameterSQL
    {
        private static string mssql = "SELECT name , isoutparam, length FROM dbo.syscolumns WHERE ID = (SELECT id FROM sysobjects WHERE name = @SpName) ORDER BY COLORDER ASC";

        private static string oracle = "";

        private static string sybase = "";

        private static string db2 = "";

        public static string GetString(DBType type)
        {
            switch (type)
            {
                case DBType.MSSQL: return mssql;
                case DBType.ORACLE: return oracle;
                case DBType.SYBASE: return sybase;
                case DBType.DB2: return db2;
                default: return mssql;
            }
        }
    }
}
