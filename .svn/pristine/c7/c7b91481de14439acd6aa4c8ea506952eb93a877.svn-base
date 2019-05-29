using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OM.Lib.Framework.Base;

namespace OM.Lib.Framework.Db
{
    public class DomainBaseEx : DomainBase
    {
        #region 생성자
        public DomainBaseEx()
            : base(string.Empty)
        {
            this.dnsName = "DefaultDNS";
        }
        public DomainBaseEx(IEntity entity)
            : base(entity.EntityName)
        {            
            this.SetEntity(entity);
        }
        public DomainBaseEx(string dnsName, IEntity entity)
            : base(dnsName, entity.EntityName)
        {
            this.dnsName = dnsName;
            this.SetEntity(entity);
        }
        #endregion       
    }
}
