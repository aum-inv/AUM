using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OM.Lib.Framework.Db
{
    public class Query
    {
        public Query()
        {
        }
        public Query(string sql)
        {
            this.SQL = sql;
        }
        public Query(string sql, bool sync)
        {
            this.SQL = sql;
        }

        private bool _Sync = false;
        public bool Sync
        {
            get { return _Sync; }
            set { _Sync = value; }
        }

        private CommandType _QueryType = CommandType.StoredProcedure;
        public string SQL { get; set; }
        //public Dictionary<string, object> ParamsEx { get; set; }
        public List<DBParameter> Params { get; set; }
        public CommandType QueryType
        {
            get
            {
                return _QueryType;
            }
            set
            {
                _QueryType = value;
            }
        }
        public string CacheKey
        {
            get;
            set;
        }

        public static string QueryFormat
        {
            get
            {
                //설정값으로 뺌
                if (System.Configuration.ConfigurationManager.AppSettings["QueryFormat"] != null)
                    return System.Configuration.ConfigurationManager.AppSettings.Get("QueryFormat");
                else
                    return "dbo.USP_{0}_{1}";
            }
        }

        private bool _IsParsingSql = true;
        public bool IsParsingSql
        { 
            get{ return _IsParsingSql; }
            set{ _IsParsingSql = value;}
        }
    }
}
