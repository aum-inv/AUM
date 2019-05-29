using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using OM.Lib.Framework.Base;

namespace OM.Lib.Framework.Db
{
    /// <summary>
    /// 도메인클래스가 상속받아야 할 클래스
    /// </summary>
    /// 
    [Serializable]    
    public abstract class DomainBase : EntityBase, IDomain
    {
        [NonSerialized]
        protected string dnsName = string.Empty;

        #region 생성자
        public DomainBase()
            : base(string.Empty)
        {
            this.dnsName = "DefaultDNS";
        }
        public DomainBase(string entityName)
            : base(entityName)
        {
            this.dnsName = "DefaultDNS";
        }
        public DomainBase(string entityName, string dnsName)
            : base(entityName)
        {
            if(string.IsNullOrEmpty(dnsName))
                this.dnsName = "DefaultDNS";
            else 
                this.dnsName = dnsName;
        }
        #endregion

        #region virtual sql         
        protected virtual Query SQL_CREATE
        {
            get
            {
                return new Query
                {
                    SQL =  string.Format(Query.QueryFormat, EntityName, "INS")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }         
        protected virtual Query SQL_READ
        {
            get
            {
                return new Query
                {
                    SQL = string.Format(Query.QueryFormat, EntityName, "SEL")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }         
        protected virtual Query SQL_UPDATE
        {
            get
            {
                return new Query
                {
                    SQL = string.Format(Query.QueryFormat, EntityName, "UPD")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }         
        protected virtual Query SQL_DELETE
        {
            get
            {
                return new Query
                {
                    SQL = string.Format(Query.QueryFormat, EntityName, "DEL")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }         
        protected virtual Query SQL_COUNT
        {
            get
            {
                return new Query
                {
                    SQL = string.Format(Query.QueryFormat, EntityName, "CNT")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }
         
        protected virtual Query SQL_LIST
        {
            get
            {
                return new Query
                {
                    SQL = string.Format(Query.QueryFormat, EntityName, "LST")
                    ,
                    QueryType = System.Data.CommandType.StoredProcedure
                    ,
                    Params = null
                };
            }
        }
        #endregion
         
        public string DnsName
        {
            get { return dnsName; }
            set { dnsName = value; }
        }

        [NonSerialized]
        EntityDao _EntityDaoBase = null;        
        public EntityDao DAO
        {
            get
            {
                if (_EntityDaoBase == null)
                    _EntityDaoBase = new EntityDao(dnsName);

                return _EntityDaoBase;
            }
        }

        #region Transaction
        /// <summary>
        /// 수동으로 트랜잭션을 시작한다.
        /// </summary>
        /// <returns></returns>
        public virtual IDbTransaction BeginTransaction()
        {
            return BeginTransaction(string.Empty);
        }
        /// <summary>
        /// 수동으로 트랜잭션을 시작한다.
        /// </summary>
        /// <param name="dnsName"></param>
        /// <returns></returns>
        public virtual IDbTransaction BeginTransaction(string dnsName)
        {
            if (dnsName.Equals(string.Empty))
            {
                IDbConnection con = DAO.GetConnection();
                if (con.State != ConnectionState.Open)
                    con.Open();

                DAO.Transaction = con.BeginTransaction();
            }
            else
            {
                IDbConnection con = DAO.GetConnection(dnsName);
                if (con.State != ConnectionState.Open)
                    con.Open();

                DAO.Transaction = con.BeginTransaction();                
            }

            return DAO.Transaction;
        }
               
        /// <summary>
        /// 수동으로 트랜잭션을 시작한다.
        /// </summary>
        /// <param name="dnsName"></param>
        /// <returns></returns>
        public virtual void SetTransaction(IDbTransaction tran)
        {
            DAO.Transaction = tran;
        }
        
        /// <summary>
        /// 수동 트랜잭션을 종료한다.
        /// </summary>
        /// <param name="isCommit">Commit 여부</param>
        public virtual void EndTransaction(bool isCommit)
        {
            if (isCommit)
            {
                if (DAO.Transaction != null)
                    DAO.Transaction.Commit();
            }
            else
            {
                if (DAO.Transaction != null)
                    DAO.Transaction.Rollback();
            }

            if (DAO.Transaction != null 
                && DAO.Transaction.Connection != null 
                && DAO.Transaction.Connection.State == ConnectionState.Open)
                DAO.Transaction.Connection.Close();

            DAO.Transaction.Dispose();
            DAO.Transaction = null;
        }

        #endregion
        
        #region Entity
        public IEntity entity = null;
        public virtual IEntity GetEntity()
        {
            if (entity == null)
                return (IEntity)this;
            else
                return entity;
        }
        public virtual IDomain SetEntity(IEntity entity)
        {
            this.entity = entity;
            this.EntityName = entity.EntityName;

            return this;
        }
        #endregion

        protected virtual Query GetQuery(QueryType type)
        {
            switch (type)
            {
                case QueryType.COUNT: return SQL_COUNT;
                case QueryType.LIST: return SQL_LIST;
                case QueryType.INSERT: return SQL_CREATE;
                case QueryType.SELECT: return SQL_READ;
                case QueryType.UPDATE: return SQL_UPDATE;
                case QueryType.DELETE: return SQL_DELETE;
                case QueryType.NONE: return SQL_DELETE;
                default: return SQL_READ;
            }
        }

        #region Count
        public virtual int Count()
        {
            return DAO.Count(GetQuery(QueryType.COUNT), GetEntity());
        }

        public virtual int Count(Query query)
        {
            return DAO.Count(query, GetEntity());
        }
        #endregion

        #region List

        public virtual System.Data.DataTable List()
        {
            return DAO.List(GetQuery(QueryType.LIST), GetEntity());
        }

        public virtual System.Data.DataTable List(Query query)
        {
            return DAO.List(query, GetEntity());
        }
        #endregion

        #region ListAndCount
        //public virtual System.Data.DataTable ListAndCount(out int count)
        //{
        //    return EntityDAO.ListAndCount(GetQuery(QueryType.LIST), out count);
        //}
        public virtual System.Data.DataTable ListAndCount(out int count)
        {
            return DAO.ListAndCount(GetQuery(QueryType.LIST), out count, GetEntity());
        }
        public virtual System.Data.DataTable ListAndCount(Query query, out int count)
        {
            return DAO.ListAndCount(query, out count, GetEntity());
        }
        #endregion

        #region Collect
        public virtual Entities Collect()
        {
             return DAO.Collect(GetQuery(QueryType.LIST), GetEntity());
        }
        public virtual Entities Collect(Query query)
        {
            return DAO.Collect(query, GetEntity());
        }
       
        #endregion

        #region CollectAndCount
        public virtual Entities CollectAndCount(out int count)
        {
            return DAO.CollectAndCount(GetQuery(QueryType.LIST), out count, GetEntity());
        }
        public virtual Entities CollectAndCount(Query query, out int count)
        {
            return DAO.CollectAndCount(query, out count, GetEntity());
        }
        //        public virtual IEntityArray CollectAndCount(Query query, out int count, params object[] sp)
        //        {
        //#if (DEBUG)
        //            if (LogConfiguration.IsUseEntityLog)
        //            {
        //                Log.EntityLog.Writer(GetEntity());
        //            }
        //#endif
        //            return EntityDAO.CollectAndCount(query, out count, GetEntity(), sp);
        //        }
        #endregion

        #region Create, Read, Update, Delete
        public virtual bool Create()
        { 
            return DAO.Create(GetQuery(QueryType.INSERT), GetEntity());
        }

        public virtual bool Create(Query query)
        {
            return DAO.Create(query, GetEntity());
        }

        public virtual bool Read()
        {
            return DAO.Read(GetQuery(QueryType.SELECT), GetEntity());
        }

        public virtual bool Read(Query query)
        {
            return DAO.Read(query, GetEntity());
        }

        public virtual bool Update()
        {
            return DAO.Update(GetQuery(QueryType.UPDATE), GetEntity());
        }

        public virtual bool Update(Query query)
        {
            return DAO.Update(query, GetEntity());
        }
        //        public virtual bool Update(Query query, params object[] param)
        //        {
        //#if (DEBUG)
        //            if (LogConfiguration.IsUseEntityLog)
        //            {
        //                Log.EntityLog.Writer(GetEntity());
        //            }
        //#endif

        //            return EntityDAO.Update(query, GetEntity(), param);
        //        }

        public virtual bool Delete()
        {
            return DAO.Delete(GetQuery(QueryType.DELETE), GetEntity());
        }

        public virtual bool Delete(Query query)
        {
            return DAO.Delete(query, GetEntity());
        }
        #endregion

        #region override  Method
        public override string ToString()
        {
            Type objType = this.GetType();

            System.Reflection.PropertyInfo[] pArr = objType.GetProperties();

            System.Text.StringBuilder sb = new StringBuilder(2048);

            foreach (System.Reflection.PropertyInfo pInfo in pArr)
            {
                sb.AppendFormat("[{0}] : {1}{2}"
                    , pInfo.Name
                    , pInfo.GetValue(this, null)
                    , System.Environment.NewLine);
            }

            return sb.ToString();
        }

        public virtual async Task<int> CountAsyn()
        {
            return await Task.Run<int>(()=> { return DAO.Count(GetQuery(QueryType.COUNT), GetEntity());} );
        }

        public virtual async Task<int> CountAsyn(Query query)
        {
            return await Task.Run<int>(() => { return DAO.Count(query, GetEntity()); });
        }

        public virtual async Task<DataTable> ListAsyn()
        {
            return await Task.Run<DataTable>(() => { return DAO.List(GetQuery(QueryType.LIST), GetEntity()); });
        }

        public virtual async Task<DataTable> ListAsyn(Query query)
        {
            return await Task.Run<DataTable>(() => { return DAO.List(query, GetEntity()); });
        }

        public virtual async Task<Entities> CollectAsyn()
        {
            return await Task.Run<Entities>(() => { return DAO.Collect(GetQuery(QueryType.LIST), GetEntity()); });
        }

        public virtual async Task<Entities> CollectAsyn(Query query)
        {
            return await Task.Run<Entities>(() => { return DAO.Collect(query, GetEntity()); });
        }

        public virtual async Task<bool> CreateAsyn()
        {
            return await Task.Run<bool>(() => { return DAO.Create(GetQuery(QueryType.INSERT), GetEntity()); });
        }

        public virtual async Task<bool> CreateAsyn(Query query)
        {
            return await Task.Run<bool>(() => { return DAO.Create(query, GetEntity()); });
        }

        public virtual async Task<bool> ReadAsyn()
        {
            return await Task.Run<bool>(() => { return DAO.Read(GetQuery(QueryType.SELECT), GetEntity()); });
        }

        public virtual async Task<bool> ReadAsyn(Query query)
        {
            return await Task.Run<bool>(() => { return DAO.Read(query, GetEntity()); });
        }

        public virtual async Task<bool> UpdateAsyn()
        {
            return await Task.Run<bool>(() => { return DAO.Update(GetQuery(QueryType.UPDATE), GetEntity()); });
        }

        public virtual async Task<bool> UpdateAsyn(Query query)
        {
            return await Task.Run<bool>(() => { return DAO.Update(query, GetEntity()); });
        }

        public virtual async Task<bool> DeleteAsyn()
        {
            return await Task.Run<bool>(() => { return DAO.Delete(GetQuery(QueryType.DELETE), GetEntity()); });
        }

        public virtual async Task<bool> DeleteAsyn(Query query)
        {
            return await Task.Run<bool>(() => { return DAO.Delete(query, GetEntity()); });
        }
        #endregion
    }
}
