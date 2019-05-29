using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OM.Lib.Framework.Db
{
    public class DBParameter
    {
        public DBParameter()
        {
        }
        public DBParameter(string pName)
        {
            ParamName = pName;
        }

        public DBParameter(string pName, object pVal)
        {
            ParamName = pName;
            ParamValue = pVal;
        }

        public string ParamName
        {
            get;
            set;
        }

        public object ParamValue
        {
            get;
            set;
        }

        public bool IsDBNull
        {
            get 
            {
                return Convert.IsDBNull(ParamValue);
            }
        }
        public void SetNull()
        {
            ParamValue = Convert.DBNull;
        }
    }
}
