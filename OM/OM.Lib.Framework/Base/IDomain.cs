using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Framework.Base
{
    public interface IDomain
    {
        IEntity GetEntity();

        IDomain SetEntity(IEntity entity);

        string DnsName
        {
            get;
            set;
        }
    }
}
