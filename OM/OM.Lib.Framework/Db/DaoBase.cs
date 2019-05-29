using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OM.Lib.Framework.Db.Helper;
using OM.Lib.Framework.Utility;

namespace OM.Lib.Framework.Db
{
    /// <summary>
    /// Data Access Logic 클래스의 Base클래스입니다.
    /// 모든 DAL클래스들은 Base클래스의 서브 클래스가 됩니다.
    /// </summary>
    public class DaoBase
    {
        /// <summary>
        /// Data Access Helper 클래스 
        /// </summary>
        static DBHelper ixdb = null;
        /// <summary>
        /// Data Parameter Helper 클래스 
        /// </summary>
        static ParameterHelper paramHelper = null;

        IDbConnection cn = null;
        IDbCommand cm = null;

        DBType dbType;
        string dnsName = string.Empty;

        #region 생성자
        public DaoBase()
        {
            dbType = DBConfiguration.GetDbType(string.Empty);
        }

        public DaoBase(string dnsName)
        {
            dbType = DBConfiguration.GetDbType(dnsName);
            this.dnsName = dnsName;
        }
        #endregion

        #region 필요한 프로퍼티
        private IDbTransaction transaction = null;
        public IDbTransaction Transaction
        {
            get
            {
                return transaction;
            }
            set
            {
                transaction = value;
            }
        }

        /// <summary>
        /// DBHelper (Data Access Helper Component)
        /// </summary>
        public DBHelper IXDB
        {
            get
            {
                lock (this)
                {
                    if (ixdb == null)
                        ixdb = new DBHelper();

                    return ixdb;
                }
            }
        }

        /// <summary>
        /// 디비 파라메터 유틸 객체
        /// </summary>
        protected ParameterHelper ParamHelper
        {
            get
            {
                lock (this)
                {
                    if (paramHelper == null)
                        paramHelper = new ParameterHelper(this.dbType);

                    return paramHelper;
                }
            }
        }
        #endregion

        #region IDbConnection
        /// <summary>
        /// 디폴트 디비 커넥션 객체를 가져온다.
        /// </summary>
        /// <returns>IDbConnection</returns>
        public virtual IDbConnection GetConnection()
        {
            return GetConnection("DefaultDNS");
        }

        /// <summary>
        /// web.config에 설정된 디비 연결문에 맞는  디비 커넥션 객체를 넘겨준다.
        /// </summary>
        /// <param name="dnsName"></param>
        /// <returns>IDbConnection</returns>
        public virtual IDbConnection GetConnection(string dnsName)
        {
            try
            {
                string connectString = DBConfiguration.GetConnectionString(dnsName);

                if (dbType == DBType.MSSQL)
                    this.cn = new System.Data.SqlClient.SqlConnection(connectString);
                //else if (dbType == DBType.OLEDB)
                //    this.cn = new System.Data.OleDb.OleDbConnection(connectString);
                //else if (dbType == DBType.ODBC)
                //    this.cn = new System.Data.Odbc.OdbcConnection(connectString);
                //else if (dbType == DBType.ORACLE)
                //    this.cn = new System.Data.OracleClient.OracleConnection(connectString);
                else
                    this.cn = null;

                 Retry.RetryAction(() =>
                    {
                        if (this.cn != null && this.cn.State != ConnectionState.Open)
                            this.cn.Open();
                    }, 3, 0);
                
                return this.cn;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 커넥션을 닫는다.
        /// </summary>
        public virtual void CloseConnection()
        {
            if (this.Transaction != null) return;

            if (this.cn == null) return;

            if (this.cn.State == System.Data.ConnectionState.Open)
                this.cn.Close();

            this.cn = null;
        }
        /// <summary>
        /// 커넥션을 닫는다.
        /// </summary>
        /// <param name="con"></param>
        public virtual void CloseConnection(System.Data.IDbConnection con)
        {
            if (this.Transaction != null) return;

            if (con == null) return;

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            con = null;
        }

        #endregion

        #region IDbCommand
        /// <summary>
        /// Stored Procedure용 커멘트 객체를 만든다.
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        protected virtual IDbCommand GetSpCommand(string cmdStr, IDataParameter[] cmdParms)
        {
            return GetCommand(cmdStr, CommandType.StoredProcedure, cmdParms);
        }
        /// <summary>
        /// Ad-Hoc용 커멘트 객체를 만든다.
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        protected virtual IDbCommand GetTxtCommand(string cmdStr, IDataParameter[] cmdParms)
        {
            return GetCommand(cmdStr, CommandType.Text, cmdParms);
        }
        /// <summary>
        /// Query객체를 가지고 커맨드 객체를 만든다.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        protected virtual IDbCommand GetCommand(Query query, IDataParameter[] cmdParms)
        {
            return GetCommand(query.SQL, query.QueryType, cmdParms);
        }


        /// <summary>
        /// 커멘트 객체를 만든다.
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        private IDbCommand GetCommand(string cmdStr, CommandType cmdType, IDataParameter[] cmdParms)
        {
            try
            {
                if (this.Transaction == null)
                {
                    if (this.cn == null)
                    {
                        this.cn = GetConnection(dnsName);
                    }
                }
                else
                {
                    if (this.transaction.Connection == null)
                        this.cn = GetConnection(dnsName);
                    else
                        this.cn = this.transaction.Connection;
                }

                if (dbType == DBType.MSSQL)
                    this.cm = new System.Data.SqlClient.SqlCommand(cmdStr, (System.Data.SqlClient.SqlConnection)this.cn);
                //else if (dbType == DBType.OLEDB)
                //    this.cm = new System.Data.OleDb.OleDbCommand(cmdStr, (System.Data.OleDb.OleDbConnection)this.cn);
                //else if (dbType == DBType.ODBC)
                //    this.cm = new System.Data.Odbc.OdbcCommand(cmdStr, (System.Data.Odbc.OdbcConnection)this.cn);
                //else if (dbType == DBType.ORACLE)
                //    this.cm = new System.Data.OracleClient.OracleCommand(cmdStr, (System.Data.OracleClient.OracleConnection)this.cn);
                else
                    this.cm = new System.Data.SqlClient.SqlCommand(cmdStr, (System.Data.SqlClient.SqlConnection)this.cn);

                if (this.transaction != null)
                {
                    this.cm.Transaction = this.Transaction;
                }

                this.cm.CommandType = cmdType;

                if (cmdParms != null)
                {   
                    foreach (IDataParameter parm in cmdParms)
                        this.cm.Parameters.Add(parm);
                }
                return this.cm;
            }
            catch (System.Exception ex)
            {
                this.CloseConnection();

                throw ex;
            }
        }
        #endregion

        #region IDataParamter
        /// <summary>
        /// 디비 파라메터를 가져온다.(디폴트로 저장프로시저를 사용한다)
        /// Dictionary<string, IDataParameter[]>에 캐쉬되어 있음.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected IDataParameter[] GetParameters(Query query)
        {
            if (!query.IsParsingSql) return null;

            string key = query.QueryType == CommandType.StoredProcedure ? query.SQL : query.CacheKey;
           
            IDataParameter[] parms = ParamHelper.GetCachedParameters(key);
            if (parms == null)
            {
                if (query.QueryType == CommandType.Text)
                {
                    parms = GetTxtParameters(query);
                }
                else
                {
                    parms = GetSpParameters(query);
                }
                ParamHelper.SetCacheParameters(key, parms);
            }
            return parms;
        }


        /// <summary>
        /// 디비 파라메터를 가져온다.(디폴트로 저장프로시저를 사용한다)
        /// Dictionary<string, IDataParameter[]>에 캐쉬되어 있음.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected IDataParameter[] GetParameters(string sql, CommandType type)
        {
            IDataParameter[] parms = ParamHelper.GetCachedParameters(sql);
            if (parms == null)
            {
                if (type == CommandType.Text)
                {
                    parms = GetTxtParameters(new Query { SQL = sql, QueryType = type });
                }
                else
                {
                    parms = GetSpParameters(new Query { SQL = sql, QueryType = type });
                }
                ParamHelper.SetCacheParameters(sql, parms);
            }
            return parms;
        }

        /// <summary>
        /// 아웃풋 파라메터의 값을 가져온다.
        /// </summary>
        /// <param name="parms"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        protected object GetOutputParameterValue(IDataParameter[] parms, string paramName)
        {
            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i].Direction == ParameterDirection.Output
                    && parms[i].ParameterName.Equals(paramName))
                    return parms[i].Value;
            }
            return null;
        }

        /// <summary>
        /// 아웃풋 파라메터의 전체리스트를 가져온다.
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        protected System.Collections.Generic.Dictionary<string, object> GetOutputParameterValues(IDataParameter[] parms)
        {
            System.Collections.Generic.Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i].Direction == ParameterDirection.Output)
                    dic.Add(parms[i].ParameterName, parms[i].Value);
            }
            return dic;
        }

        /// <summary>
        /// 저장 프로시저의 파라메터 정보를 읽어서 객체화 한다.
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        protected virtual IDataParameter[] GetSpParameters(Query query)
        {
            string sql = SearchParameterSQL.GetString(dbType);

            IDataParameter[] parms = ParamHelper.GetCachedParameters("getParameterInfo");

            if (parms == null)
            {
                parms = ParamHelper.GetParameters("SpName");

                //ParamHelper.SetCacheParameters(sql, parms);
            }

            parms = ParamHelper.SetParameterValue(parms, query.SQL.Replace("dbo.", "").Replace("[", "").Replace("]", ""));

            using (IDataReader reader = IXDB.ExecuteReader(this.GetCommand(sql, CommandType.Text, parms)))
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                this.CloseConnection();
                IDataParameter[] parms2 = new IDataParameter[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    parms2[i] = ParamHelper.GetParameter(dt.Rows[i][0].ToString(), Convert.DBNull);
                    if (dt.Rows[i][1].ToString().Equals("1")) //isoutputparam 필드 체크
                    {
                        parms2[i].Direction = ParameterDirection.Output;
                        
                        if (parms2[i] is System.Data.SqlClient.SqlParameter)
                        {
                            ((System.Data.SqlClient.SqlParameter)parms2[i]).Size = Convert.ToInt32(dt.Rows[i][2]);
                        }
                    }

                    if (query.Params != null)
                    {
                        foreach (var p in query.Params)
                        {
                            if (p.ParamName == parms2[i].ParameterName)
                            {
                                parms2[i].Value = p.ParamValue;
                                continue;
                            }
                        }
                    }
                }

                return parms2;
            }
        }
        /// <summary>
        /// 저장 프로시저의 파라메터 정보를 읽어서 객체화 한다.
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        //protected virtual IDataParameter[] GetSpParameters(string spName)
        //{
        //    string sql = SearchParameterSQL.GetString(dbType);

        //    IDataParameter[] parms = ParamHelper.GetCachedParameters("getParameterInfo");

        //    if (parms == null)
        //    {
        //        parms = ParamHelper.GetParameters("SpName");

        //        //ParamHelper.SetCacheParameters(sql, parms);
        //    }

        //    parms = ParamHelper.SetParameterValue(parms, spName.Replace("dbo.", ""));

        //    using (IDataReader reader = IXDB.ExecuteReader(this.GetCommand(sql, CommandType.Text, parms)))
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Load(reader);
        //        reader.Close();
        //        this.CloseConnection();
        //        IDataParameter[] parms2 = new IDataParameter[dt.Rows.Count];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            parms2[i] = ParamHelper.GetParameter(dt.Rows[i][0].ToString(), Convert.DBNull);
        //            if (dt.Rows[i][1].ToString().Equals("1")) //isoutputparam 필드 체크
        //            {
        //                parms2[i].Direction = ParameterDirection.Output;
        //                parms2[i].DbType = DbType.AnsiString;

        //                if (parms2[i] is System.Data.SqlClient.SqlParameter)
        //                    ((System.Data.SqlClient.SqlParameter)parms2[i]).Size = 100;
        //            }
        //        }

        //        return parms2;
        //    }
        //}
        /// <summary>
        /// 텍스트 파라메터를 사용하려면, 항상 @앞뒤로 공백문자가 필요함.
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        protected virtual IDataParameter[] GetTxtParameters(Query query)
        {
            string[] tmp = query.SQL.Split(' ');

            List<string> list = new List<string>();

            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].StartsWith("@"))
                {
                    if (!list.Contains(tmp[i]))
                        list.Add(tmp[i]);
                }
            }

            //if (query.Params != null)
            //{
            //    foreach (KeyValuePair<string, object> kVal in query.Params)
            //    {
            //        foreach (string p in list)
            //        {
            //            if (p.Equals(kVal.Key))
            //                continue;
            //            else
            //            {
            //                list.Add(kVal.Key);
            //            }
            //        }
            //    }
            //}

            if (query.Params != null)
            {
                foreach (var p in query.Params)
                {
                    if (!p.ParamName.StartsWith("@"))
                        p.ParamName = p.ParamName.Insert(0, "@");

                    if (list.Contains(p.ParamName))
                        continue;
                    else
                        list.Add(p.ParamName);                                      
                }
            }

            IDataParameter[] parms = new IDataParameter[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                parms[i] = ParamHelper.GetParameter(list[i], Convert.DBNull);

                if (query.Params != null)
                {
                    foreach (var p in query.Params)
                    {
                        if (p.ParamName == list[i])
                            parms[i].Value = p.ParamValue;
                    }
                }
            }

            return parms;
        }
        #endregion
    }
}
