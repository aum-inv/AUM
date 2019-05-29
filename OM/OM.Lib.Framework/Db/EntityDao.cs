using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using OM.Lib.Framework.Base;

namespace OM.Lib.Framework.Db
{
    public class EntityDao : DaoBase
    {
        #region 생성자
        public EntityDao()
            : base()
        { }

        public EntityDao(string dnsName)
            : base(dnsName)
        { }
        #endregion

        #region Count 메쏘드
        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual int Count(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                int count = (int)this.IXDB.ExecuteScalar(this.GetCommand(query, parms));

                return count;
            }
            catch (System.Exception ex)
            {
                //throw new Exception.DBException(ex.Message, ex);               
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual int Count(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                int count = (int)this.IXDB.ExecuteScalar(this.GetCommand(query, parms));

                return count;
            }
            catch (System.Exception ex)
            {
                //throw new Exception.DBException(ex.Message, ex);
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }
       
        #endregion

        #region List 메쏘드
        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable List(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                DataTable dt = new DataTable();
                dt.Load(reader);

                reader.Close();

                return dt;
            }
            catch (System.Exception ex)
            {
                //throw new Exception.DBException(ex.Message, ex);                
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable List(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                DataTable dt = new DataTable();
                dt.Load(reader);

                reader.Close();
                return dt;
            }
            catch (System.Exception ex)
            {
                //throw new Exception.DBException(ex.Message, ex);             
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public virtual IDataReader ListEx(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);
                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));
                return reader;
            }
            catch (System.Exception ex)
            {
                //throw new Exception.DBException(ex.Message, ex);                
                throw ex;
            }            
        }
        #endregion

        #region Lists 메쏘드
        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public virtual DataSet Lists(Query query, params string[] tables)
        //{
        //    try
        //    {
        //        IDataParameter[] parms = this.GetParameters(query);

        //        IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

        //        DataSet ds = new DataSet();
        //        ds.Load(reader, LoadOption.OverwriteChanges, tables);

        //        reader.Close();

        //        return ds;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new Exception.DBException(ex.Message, ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}
        #endregion

        #region ListAndCount 메쏘드
        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable ListAndCount(Query query, out int count)
        {
            count = 0;
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                DataSet ds = new DataSet();

                ds.Load(reader, LoadOption.OverwriteChanges, "LIST", "COUNT");

                count = Convert.ToInt32(ds.Tables["COUNT"].Rows[0][0]);

                reader.Close();
                return ds.Tables["LIST"];
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);              
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DataTable ListAndCount(Query query, out int count, IEntity entity)
        {
            count = 0;
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                DataSet ds = new DataSet();

                ds.Load(reader, LoadOption.OverwriteChanges, "LIST", "COUNT");

                count = Convert.ToInt32(ds.Tables["COUNT"].Rows[0][0]);

                reader.Close();
                return ds.Tables["LIST"];
            }
            catch (System.Exception ex)
            {
                throw ex; // throw new Exception.DBException(ex.Message, ex);              
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// 리턴값이 리스트형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        //public virtual DataTable ListAndCount(Query query, out int count, params object[] sp)
        //{
        //    count = 0;
        //    try
        //    {
        //        IDataParameter[] parms = this.GetParameters(query);

        //        parms = this.ParamHelper.SetParameterValue(parms, sp);

        //        IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

        //        DataSet ds = new DataSet();

        //        ds.Load(reader, LoadOption.OverwriteChanges, "LIST", "COUNT");

        //        count = Convert.ToInt32(ds.Tables["COUNT"].Rows[0][0]);

        //        reader.Close();

        //        return ds.Tables["LIST"];
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new Exception.DBException(ex.Message, ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}
        #endregion

        #region Collect 메쏘드
        /// <summary>
        /// 리턴값이 콜렉션 형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual Entities Collect(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                using (IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms)))
                {

                    Entities entityCol = new Entities();

                    while (reader.Read())
                    {
                        IEntity entity2 = entity.Clone();

                        this.GetObjectMapping(entity2, reader);

                        entityCol.Add(entity2);
                    }
                    reader.Close();

                    GetOutputParameterMapping(entity, parms);

                    return entityCol;
                }
              
            }
            catch (System.Exception ex)
            {
                throw ex; //Exception.ExceptionCreator.GetExceptor(Config.Exception.ExceptionType.DB).SetException(ex);              
            }
            finally
            {
                this.CloseConnection();
            }
        }

       
        #endregion

        #region CollectAndCount 메쏘드
        /// <summary>
        /// 리턴값이 콜렉션 형태의 쿼리에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual Entities CollectAndCount(Query query, out int count, IEntity entity)
        {
            count = 0;
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                using (IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms)))
                {

                    Entities entityCol = new Entities();

                    while (reader.Read())
                    {
                        IEntity entity2 = entity.Clone();

                        this.GetObjectMapping(entity2, reader);

                        entityCol.Add(entity2);
                    }

                    if (reader.NextResult() && reader.Read())
                    {
                        count = Convert.ToInt32(reader[0]);
                    }
                    reader.Close();

                    return entityCol;
                }
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        
        #endregion

        #region Create, Read, Update, Delete

        /// <summary>
        /// Insert 쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Create(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);
                
                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Insert 쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Create(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                GetOutputParameterMapping(entity, parms);

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Select쿼리에 사용되며, 리턴형태가 단일행인 경우 입니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        public virtual IDataReader ReadEx(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                return reader;
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }         
        }

        /// <summary>
        /// Select쿼리에 사용되며, 리턴형태가 단일행인 경우 입니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        public virtual bool Read(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

                if (reader.Read())
                {
                    this.GetObjectMapping(entity, reader);
                }

                reader.Close();

                GetOutputParameterMapping(entity, parms);

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Select쿼리에 사용되며, 리턴형태가 단일행인 경우 입니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        //public virtual bool Read(Query query, IEntity entity, params object[] param)
        //{
        //    try
        //    {
        //        IDataParameter[] parms = this.GetParameters(query);

        //        parms = this.ParamHelper.SetParameterValue(parms, param);

        //        IDataReader reader = this.IXDB.ExecuteReader(this.GetCommand(query, parms));

        //        if (reader.Read())
        //        {
        //            this.GetObjectMapping(entity, reader);
        //        }

        //        reader.Close();

        //        GetOutputParameterMapping(entity, parms);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new Exception.DBException(ex.Message, ex);

        //        return false;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}


        /// <summary>
        /// Update쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Update(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Update쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Update(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                GetOutputParameterMapping(entity, parms);

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Update쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public virtual bool Update(Query query, IEntity entity, params object[] parm)
        //{
        //    try
        //    {
        //        IDataParameter[] parms = this.GetParameters(query);

        //        parms = this.ParamHelper.SetParameterValue(parms, parm);

        //        int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

        //        GetOutputParameterMapping(entity, parms);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new Exception.DBException(ex.Message, ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}


        /// <summary>
        /// Delete쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Delete(Query query)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex; //throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Delete쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual bool Delete(Query query, IEntity entity)
        {
            try
            {
                IDataParameter[] parms = this.GetParameters(query);

                parms = this.ParamHelper.SetParameterValue(parms, entity);

                int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

                GetOutputParameterMapping(entity, parms);

                return true;
            }
            catch (System.Exception ex)
            {
                throw ex; // throw new Exception.DBException(ex.Message, ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Delete쿼리문에 사용됩니다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public virtual bool Delete(Query query, IEntity entity, params object[] parm)
        //{
        //    try
        //    {
        //        IDataParameter[] parms = this.GetParameters(query);

        //        parms = this.ParamHelper.SetParameterValue(parms, parm);

        //        int res = this.IXDB.ExecuteNonQuery(this.GetCommand(query, parms));

        //        GetOutputParameterMapping(entity, parms);

        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw new Exception.DBException(ex.Message, ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}
        #endregion

        #region ObjectMappgin
        /// <summary>
        /// 객체와 데이터리더로 가져온 값을 자동매핑시켜주는 역활을 한다.
        /// 자동매핑 규칙을 객체의 프로퍼티명과 디비의 컬럼명을 비교한다.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="reader"></param>
        protected virtual void GetObjectMapping(IEntity entity, IDataReader reader)
        {
            Type objType = entity.GetType();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                if (!hasProperty(objType, columnName))
                {
                    if (((EntityBase)entity).DynamicData.ContainsKey(columnName))
                        ((EntityBase)entity).DynamicData[columnName] = Convert.IsDBNull(reader[columnName]) ? "" : Convert.ToString(reader[columnName]);
                    else
                        ((EntityBase)entity).DynamicData.Add(columnName, Convert.IsDBNull(reader[columnName]) ? "" : Convert.ToString(reader[columnName]));                    
                    continue;
                }
                                
                PropertyInfo objProperties = objType.GetProperty(columnName);
                switch (objProperties.PropertyType.ToString())
                { 
                    case "System.String" :
                        objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(reader[columnName]) ? string.Empty : reader[columnName]), null);
                        break;
                    case "System.Int32" :
                        objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(reader[columnName]) ? 0 : reader[columnName]), null);
                        break;
                    case "System.Int64":
                        objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(reader[columnName]) ? 0 : reader[columnName]), null);
                        break;
                    case "System.Double":
                        objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(reader[columnName]) ? 0 : reader[columnName]), null);
                        break;
                    case "System.Nullable`1[System.Int32]":
                        objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                        break;
                    case "System.Nullable`1[System.Int64]":
                        objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                        break;
                    case "System.Nullable`1[System.Double]":
                        objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                        break;
                    case "System.Single":
                        objProperties.SetValue(entity, Convert.ToSingle(Convert.IsDBNull(reader[columnName]) ? 0 : reader[columnName]), null);
                        break;
                    case "System.DateTime":
                        objProperties.SetValue(entity, Convert.ToDateTime(Convert.IsDBNull(reader[columnName]) ? DateTime.Now : reader[columnName]), null);
                        break;
                    case "System.Nullable`1[System.DateTime]":
                        objProperties.SetValue(entity, Convert.IsDBNull(reader[columnName]) ? new Nullable<DateTime>() : Convert.ToDateTime(reader[columnName].ToString()), null);
                        break;
                    case "System.Char":
                        objProperties.SetValue(entity, Convert.ToChar(Convert.IsDBNull(reader[columnName]) ? 0 : reader[columnName]), null);
                        break;
                    case "System.Byte[]":
                        objProperties.SetValue(entity, (byte[])(Convert.IsDBNull(reader[columnName]) ? new byte[0] : reader[columnName]), null);
                        break;
                    default :
                        objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(reader[columnName]) ? string.Empty : reader[columnName]), null);
                        break;                        
                }               
            }

            return;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="parms"></param>
        protected virtual void GetOutputParameterMapping(IEntity entity, IDataParameter[] parms)
        {
            Type objType = entity.GetType();

            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i].Direction != ParameterDirection.Output)
                    continue;

                string columnName = parms[i].ParameterName.Replace("@", "");

                if (!hasProperty(objType, columnName))
                {
                    if (((EntityBase)entity).DynamicData.ContainsKey(columnName))
                        ((EntityBase)entity).DynamicData[columnName] = Convert.ToString(parms[i].Value);
                    else
                        ((EntityBase)entity).DynamicData.Add(columnName, Convert.ToString(parms[i].Value));

                    continue;
                }

                PropertyInfo objProperties = objType.GetProperty(columnName);
                switch (objProperties.PropertyType.ToString())
                {
                    case "System.String":
                        objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                        break;
                    case "System.Int32":
                        objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(parms[i].Value) ? 0 : parms[i].Value), null);
                        break;
                    case "System.Int64":
                        objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(parms[i].Value) ? 0 : parms[i].Value), null);
                        break;
                    case "System.Nullable`1[System.Int32]":
                        objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(parms[i].Value) ? null : parms[i].Value), null);
                        break;
                    case "System.Nullable`1[System.Int64]":
                        objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(parms[i].Value) ? null : parms[i].Value), null);
                        break;
                    case "System.Nullable`1[System.Double]":
                        objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(parms[i].Value) ? null : parms[i].Value), null);
                        break;
                    case "System.Double":
                        objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(parms[i].Value) ? 0.0 : parms[i].Value), null);
                        break;
                    case "System.DateTime":
                        objProperties.SetValue(entity, Convert.ToDateTime(Convert.IsDBNull(parms[i].Value) ? null : parms[i].Value.ToString()), null);
                        break;
                    case "System.Nullable`1[System.DateTime]":
                        objProperties.SetValue(entity, Convert.IsDBNull(parms[i].Value) ? new Nullable<DateTime>() : Convert.ToDateTime(parms[i].Value.ToString()), null);
                        break;
                    case "System.Char":
                        objProperties.SetValue(entity, Convert.ToChar(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                        break;
                    default:
                        objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                        break;
                }

                //if (objProperties.PropertyType.ToString().Equals("System.String"))
                //{
                //    objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                //}
                //else if (objProperties.PropertyType.ToString().Equals("System.Int32"))
                //{
                //    objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(parms[i].Value) ? 0 : parms[i].Value), null);
                //}
                //else if (objProperties.PropertyType.ToString().Equals("System.Int64"))
                //{
                //    objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(parms[i].Value) ? 0 : parms[i].Value), null);
                //}
                //case "System.Nullable`1[System.Int32]":
                //        objProperties.SetValue(entity, Convert.ToInt32(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                //break;
                //    case "System.Nullable`1[System.Int64]":
                //        objProperties.SetValue(entity, Convert.ToInt64(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                //break;
                //    case "System.Nullable`1[System.Double]":
                //        objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(reader[columnName]) ? null : reader[columnName]), null);
                //break;

                //else if (objProperties.PropertyType.ToString().Equals("System.Double"))
                //{
                //    objProperties.SetValue(entity, Convert.ToDouble(Convert.IsDBNull(parms[i].Value) ? 0.0 : parms[i].Value), null);
                //}
                //else if (objProperties.PropertyType.ToString().Equals("System.DateTime"))
                //{
                //    objProperties.SetValue(entity, Convert.ToDateTime(Convert.IsDBNull(parms[i].Value) ? null : parms[i].Value.ToString()), null);
                //}
                //else if (objProperties.PropertyType.ToString().Equals("System.Char"))
                //{
                //    objProperties.SetValue(entity, Convert.ToChar(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                //}
                //else
                //{
                //    objProperties.SetValue(entity, Convert.ToString(Convert.IsDBNull(parms[i].Value) ? string.Empty : parms[i].Value), null);
                //}
            }

            return;
        }
        /// <summary>
        /// 객체의 Property 존재하는지 체크한다.
        /// </summary>
        /// <param name="reader"></param> 
        /// <param name="columnName"></param>
        /// <returns></returns>
        private bool hasProperty(Type objType, string columnName)
        {
            try
            {
                PropertyInfo info = objType.GetProperty(columnName);
                if (info == null)
                    return false;

                return true;
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                return false;
            }
        }

        private void makeProperty(Type objType, string name)
        {
            AppDomain myDomain = System.AppDomain.CurrentDomain;
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = AppDomain.CurrentDomain.FriendlyName;

            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(assemblyName.Name);

            TypeBuilder myTypeBuilder = myModBuilder.DefineType(objType.Name);

            FieldBuilder customerNameBldr = myTypeBuilder.DefineField("_" + name,
                                                                typeof(string),
                                                                FieldAttributes.Private);
            PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty(name,
                                                                System.Reflection.PropertyAttributes.HasDefault,
                                                                typeof(string),
                                                                null);
            myTypeBuilder.CreateType();
        }
        /// <summary>
        /// Select쿼리에서 해당 컬럼이 존재하는지 체크한다.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private bool hasColumn(IDataReader reader, string columnName)
        {
            try
            {
                string str = reader[columnName].ToString();
                return true;
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
