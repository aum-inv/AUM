using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace OM.Lib.Framework.Db
{    
    public class DynamicColumnDataDictionary: DynamicObject
    {
        private readonly Func<DynamicDataDictionary> _viewDataThunk;

        public DynamicColumnDataDictionary(Func<DynamicDataDictionary> viewDataThunk)
        {
            this._viewDataThunk = viewDataThunk;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.DynamicData.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.DynamicData[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.DynamicData[binder.Name] = Convert.ToString(value);
            return true;
        }

        private DynamicDataDictionary DynamicData
        {
            get
            {
                return this._viewDataThunk();
            }
        }
    }
}
