using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace OM.Lib.Framework.Db.Helper
{
    public class ParameterHelper
    {
        #region Private Variables
        private static Dictionary<string, IDataParameter[]> parmCache = new Dictionary<string, IDataParameter[]>();

        DBType dbType;
        #endregion

        #region 생성자
        public ParameterHelper()
        {
            dbType = DBType.MSSQL;
        }

        public ParameterHelper(DBType dbType)
        {
            this.dbType = dbType;
        }
        #endregion

        #region GetParameters 함수
        /// <summary>
        /// DataTable에 쿼리파라메터 정보를 만든다.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="index">시작인덱스</param>
        /// <returns>IDataParameter 배열</returns>
        public virtual IDataParameter[] GetParameters(DataTable dt, int index)
        {
            System.Data.DataColumnCollection cCol = dt.Columns;

            IDataParameter[] param = GetParameters(cCol.Count);

            for (int i = index; i < cCol.Count; i++)
            {
                param[i] = GetParameter("@" + cCol[i].ColumnName, Convert.DBNull);
            }

            return param;
        }

        /// <summary>
        /// DataTable에 쿼리파라메터 정보를 만든다.
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>IDataParameter 배열</returns>
        public virtual IDataParameter[] GetParameters(DataTable dt)
        {
            return GetParameters(dt, 0);
        }

        /// <summary>
        /// 문자열배열을 통해서 쿼리파라메터를 만든다.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>IDataParameter 배열</returns>
        public virtual IDataParameter[] GetParameters(params string[] obj)
        {
            IDataParameter[] param = GetParameters(obj.Length);

            for (int i = 0; i < obj.Length; i++)
            {
                param[i] = GetParameter("@" + obj[i], Convert.DBNull);
            }

            return param;
        }

        /// <summary>
        /// 모델객체를 통해서 파라메터를 만든다.
        /// </summary>
        /// <param name="entity">IEntity인터페이스를 상속받은 Entity객체</param>
        /// <returns>IDataParameter 배열</returns>
        public virtual IDataParameter[] GetParameters(Base.IEntity entity)
        {
            Type objType = entity.GetType();

            System.Reflection.PropertyInfo[] objPropertiesArray = objType.GetProperties();

            IDataParameter[] parms = GetParameters(objPropertiesArray.Length);

            for (int i = 0; i < objPropertiesArray.Length; i++)
            {
                parms[i] = GetParameter("@" + objPropertiesArray[i].Name, Convert.DBNull);
            }

            return parms;
        }

        public virtual IDataParameter[] GetParameters(int length)
        {
            if (this.dbType == DBType.MSSQL)
                return new System.Data.SqlClient.SqlParameter[length];
            else if (this.dbType == DBType.ODBC)
                return new System.Data.Odbc.OdbcParameter[length];
            else if (this.dbType == DBType.OLEDB)
                return new System.Data.OleDb.OleDbParameter[length];
            //else if (this.dbType == DBType.ORACLE)
            //    return new System.Data.OracleClient.OracleParameter[length];
            else
                return null;

        }

        public virtual IDataParameter GetParameter(string name, object val)
        {
            if (this.dbType == DBType.MSSQL)
                return new System.Data.SqlClient.SqlParameter(name, val);
            else if (this.dbType == DBType.ODBC)
                return new System.Data.Odbc.OdbcParameter(name, val);
            else if (this.dbType == DBType.OLEDB)
                return new System.Data.OleDb.OleDbParameter(name, val);
            //else if (this.dbType == DBType.ORACLE)
            //    return new System.Data.OracleClient.OracleParameter(name, val);
            else
                return null;
        }
        #endregion

        #region SetParameterValue함수들
        public virtual IDataParameter[] SetParameterValue(IDataParameter[] param, DataTable dt, int index)
        {
            if (param == null || param.Length == 0) return param;
            System.Data.DataColumnCollection cCol = dt.Columns;

            for (int i = index; i < cCol.Count; i++)
            {
                param[i].Value = dt.Rows[index][cCol[i].ColumnName];
            }

            return param;
        }

        public virtual IDataParameter[] SetParameterValue(IDataParameter[] param, DataTable dt)
        {
            return SetParameterValue(param, dt, 0);
        }

        public virtual IDataParameter[] SetParameterValue(IDataParameter[] param, params object[] obj)
        {
            if (param == null || param.Length == 0) return param;

            for (int i = 0; i < obj.Length; i++)
            {
                if (param.Length == (i - 1)) return param;

                param[i].Value = obj[i];
            }
            return param;
        }

        public virtual IDataParameter[] SetParameterValue(IDataParameter[] parms, Base.IEntity entity)
        {
            if (parms == null || parms.Length == 0) return parms;

            Type objType = entity.GetType();
            System.Reflection.PropertyInfo[] objPropertiesArray = objType.GetProperties();

            foreach (IDataParameter sParam in parms)
            {
                string pName = sParam.ParameterName.Replace("@", "");

                foreach (PropertyInfo objProperty in objPropertiesArray)
                {
                    if (objProperty.Name.ToUpper() == pName.ToUpper())
                    {
                        sParam.Value = objProperty.GetValue(entity, null) == null ? DBNull.Value : objProperty.GetValue(entity, null);
                        break;
                    }
                }
                
                if (((EntityBase)entity).DynamicData.ContainsKey(pName))
                {
                    sParam.Value = ((EntityBase)entity).DynamicData[pName];
                }
            }
            return parms;
        }
        #endregion

        #region CacheParameter
        public virtual void SetCacheParameters(string cacheKey, params IDataParameter[] cmdParms)
        {
            //if (DBConfiguration.EnableCacheParameter)
            //{
                lock (parmCache)
                {
                    if (parmCache.ContainsKey(cacheKey))
                        parmCache[cacheKey] = cmdParms;
                    else
                    {
                        parmCache.Add(cacheKey, cmdParms);
                    }
                }
            //}
        }

        public virtual IDataParameter[] GetCachedParameters(string cacheKey)
        {
            if (parmCache.ContainsKey(cacheKey))
            {
                IDataParameter[] cachedParms = parmCache[cacheKey];
                if (this.dbType == DBType.MSSQL)
                {   
                    IDataParameter[] clonedParms = new IDataParameter[cachedParms.Length];

                    if (cachedParms == null) return null;

                    for (int i = 0; i < cachedParms.Length; i++)
                    {
                        clonedParms[i] = new System.Data.SqlClient.SqlParameter(cachedParms[i].ParameterName, cachedParms[i].DbType);
                        clonedParms[i].Direction = cachedParms[i].Direction;

                        //if (clonedParms[i] is System.Data.SqlClient.SqlParameter)
                        //    ((System.Data.SqlClient.SqlParameter)clonedParms[i]).Size = 100;
                    }
                    return clonedParms;
                }

                else if (this.dbType == DBType.ODBC)
                {
                    IDataParameter[] clonedParms = new IDataParameter[cachedParms.Length];

                    if (cachedParms == null) return null;

                    for (int i = 0; i < cachedParms.Length; i++)
                    {
                        clonedParms[i] = new System.Data.Odbc.OdbcParameter(cachedParms[i].ParameterName, Convert.DBNull);
                        clonedParms[i].Direction = cachedParms[i].Direction;
                    }
                    return clonedParms;
                }
                else if (this.dbType == DBType.OLEDB)
                {
                    IDataParameter[] clonedParms = new IDataParameter[cachedParms.Length];

                    if (cachedParms == null) return null;

                    for (int i = 0; i < cachedParms.Length; i++)
                    {
                        clonedParms[i] = new System.Data.OleDb.OleDbParameter(cachedParms[i].ParameterName, Convert.DBNull);
                        clonedParms[i].Direction = cachedParms[i].Direction;
                    }
                    return clonedParms;
                }
                //else if (this.dbType == DBType.ORACLE)
                //{
                //    IDataParameter[] clonedParms = new IDataParameter[cachedParms.Length];

                //    if (cachedParms == null) return null;

                //    for (int i = 0; i < cachedParms.Length; i++)
                //    {
                //        clonedParms[i] = new System.Data.OracleClient.OracleParameter(cachedParms[i].ParameterName, Convert.DBNull);
                //        clonedParms[i].Direction = cachedParms[i].Direction;
                //    }
                //    return clonedParms;
                //}
                else
                    return null;                
            }
            else
                return null;
        }


        public static void ClearCacheParameter()
        {
            try
            {
                parmCache.Clear();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
