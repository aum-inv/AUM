using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Reflection;
using Newtonsoft.Json;
using OM.Lib.Framework.Base;
////using System.Web.Mvc;

namespace OM.Lib.Framework.Db
{
    /// <summary>
    /// 엔티티클래스가 상속받아야 할 클래스
    /// </summary>
    /// 
    [Serializable]
    public abstract class EntityBase : IEntity
    {
        static string[] exceptionsJsonFields = { "entity", "DnsName", "DAO", "IXDB", "Domain", "DynamicData", "EntityName", "Json", "d"};
        static string[] exceptionsCopyFields = { "entity", "DnsName", "DAO", "IXDB", "Domain", "EntityName", "Json", "d"};

        [NonSerialized]
        private string _EntityName = string.Empty;

        public EntityBase()
        {
        }
        public EntityBase(string entityName) : this(entityName, false)
        {
        }
        public EntityBase(string entityName, bool isUseDomain)
        {
            this._EntityName = entityName;

            if (isUseDomain)
                this.SetDomain(new DomainBaseEx(this));
        }
        public EntityBase(string entityName, IDomain domain)
        {
            this._EntityName = entityName;
            this.SetDomain(domain);
        }

        #region IDomain
        public void SetDomain(IDomain domain)
        {
            Domain = domain;
        }
        public IDomain Domain
        {
            get;
            set;
        }
        #endregion

        #region Dynamic Option필드

        //[NonSerialized]
        private DynamicDataDictionary _viewData;

        [NonSerialized]
        private DynamicColumnDataDictionary _dynamicViewData;

        public dynamic d
        {
            get
            {
                Func<DynamicDataDictionary> viewDataThunk = null;
                if (this._dynamicViewData == null)
                {
                    if (viewDataThunk == null)
                    {
                        viewDataThunk = () => this.DynamicData;
                    }
                    this._dynamicViewData = new DynamicColumnDataDictionary(viewDataThunk);
                }
                return this._dynamicViewData;
            }
            set
            {
                d = value;
            }
        }
        
        public DynamicDataDictionary DynamicData
        {
            get
            {
                if (this._viewData == null)
                {
                    this.SetViewData(new DynamicDataDictionary());
                }
                return this._viewData;
            }
            set
            {

                this.SetViewData(value);
            }
        }
        protected virtual void SetViewData(DynamicDataDictionary viewData)
        {
            this._viewData = viewData;
        }



        //Dictionary<string, object> properties = new Dictionary<string, object>();
        //public object this[string name]
        //{
        //    get
        //    {                
        //        if (properties.ContainsKey(name))
        //        {
        //            return properties[name];
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        properties[name] = value;
        //    }
        //}

        //System.Collections.Generic.Dictionary<string, string> _OptionProperties = null;
        //public string GetOptionProperty(string propertyName)
        //{
        //    if (_OptionProperties == null)
        //        _OptionProperties = new Dictionary<string, string>();

        //    if (_OptionProperties.ContainsKey(propertyName))
        //        return _OptionProperties[propertyName];
        //    return string.Empty;
        //}
        //public void SetOptionProperty(string propertyName, string propertyValue)
        //{
        //    if (_OptionProperties == null)
        //        _OptionProperties = new Dictionary<string, string>();

        //    if (_OptionProperties.ContainsKey(propertyName))
        //        _OptionProperties[propertyName] = propertyValue;
        //    else
        //        _OptionProperties.Add(propertyName, propertyValue);
        //}
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
        #endregion

        #region IEntity 멤버

        public virtual IEntity Clone()
        {
            return this.Clone();
        }
        public virtual string EntityName
        {
            get { return _EntityName; }
            set { _EntityName = value; }
        }
        #endregion

        #region CopyProperties
        public virtual T CopyProperty<T>() where T : new ()
        {
            try
            {
                T t = new T();

                var pInfos = this.GetType().GetProperties();
                var pInfos2 = t.GetType().GetProperties();

                foreach (var p in pInfos)
                {
                    if (exceptionsCopyFields.Contains(p.Name)) continue;

					object val = p.GetValue(this, null);

                    if (p.Name.Equals("DynamicData"))
					{                        
                        foreach (var item in (val as DynamicDataDictionary).Keys)
                        {
                            bool isBind = false;

                            foreach (var p2 in pInfos2)
                            {
                                if (item != p2.Name) continue;
                                p2.SetValue(t, (val as DynamicDataDictionary)[item]);
                                isBind = true;
                            }
                            if (!isBind)
                            {
                                if (t is DomainBase)
                                {                                    
                                    if ((t as DomainBase).DynamicData.ContainsKey(item))
                                        (t as DomainBase).DynamicData[item] = (val as DynamicDataDictionary)[item];
                                    else
                                        (t as DomainBase).DynamicData.Add(item, (val as DynamicDataDictionary)[item]);
                                }
                            }
                        }
                    }
                    else 
                    {
						foreach (var p2 in pInfos2)
						{   
                            if (p.Name == p2.Name && p2.CanWrite)
                            {
                                //var setterMethod = p2.GetSetMethod(true);
                                //setterMethod?.Invoke(t, new[] { val });
                                p2.SetValue(t, val);
                                break;
                            }
						}
                    }
                }

                return t;
            }
            catch (System.Exception ex)
            {
                return default(T);
                throw ex;
            }
        }
        public virtual void MappingProperty(object t)
        {
            try
            {   
                var pInfos = t.GetType().GetProperties();

                var pInfos2 = this.GetType().GetProperties();

                foreach (var p in pInfos)
                {
                    if (exceptionsCopyFields.Contains(p.Name)) continue;

                    object val = p.GetValue(t, null);

                    bool isMapped = false;
                  
                    foreach (var p2 in pInfos2)
                    {
                        if (exceptionsCopyFields.Contains(p2.Name)) continue;
                        if (p.Name != p2.Name) continue;

                        p2.SetValue(this, val);
                        isMapped = true;
                    }
                    
                    if (!isMapped)
                    {
                        this.DynamicData.Add(p.Name, Convert.ToString(val));
                    }
                }
            }
            catch (System.Exception)
            {                
            }
        }
        #endregion

        #region Json
        public virtual string Json
        {
            get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    var pInfos = this.GetType().GetProperties();

                    sb.Append('{');
                    foreach (var p in pInfos)
                    {
                        if (exceptionsJsonFields.Contains(p.Name)) continue;
                        object val = p.GetValue(this, null);
                        sb.Append('\"');
                        sb.Append(p.Name);
                        sb.Append('\"');
                        sb.Append(':');
                        if (val == null)
                        {
                            sb.Append("null");
                        }
                        else
                        {
                            if (val.GetType() == typeof(DateTime))
                                sb.Append(JsonConvert.SerializeObject(((DateTime)val).ToString("s")));
                            else
                                sb.Append(JsonConvert.SerializeObject(val));
                        }
                        sb.Append(',');
                    }
                    foreach (var p in DynamicData)
                    {
                        sb.Append('\"');
                        sb.Append(p.Key);
                        sb.Append('\"');
                        sb.Append(':');
                        DateTime d;
                        if (DateTime.TryParse(p.Value, out d))
                        {
                            sb.Append(JsonConvert.SerializeObject(d.ToString("s")));
                        }
                        else
                        {
                            sb.Append(JsonConvert.SerializeObject(p.Value));
                        }
                        sb.Append(',');
                    }

                    if(sb.Length > 1)
                        sb.Remove(sb.Length - 1, 1);

                    sb.Append('}');


                    return sb.ToString();
                }
                catch (System.Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public virtual T JsonToEntity<T>(string jsonString) where T : new()
        {
            try
            {               
                T jsonPL = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                                
                return jsonPL;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }
        #endregion
    }
}
