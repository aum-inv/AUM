﻿using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Entity
{
    [Serializable]
    public class PurushaPrakriti : DomainBase
    {
        public PurushaPrakriti(string entityeName = "PP", string domainName = "AUM") 
            : base(entityeName, domainName) { }

        public string Item { get; set; }

        public int Interval { get; set; }

        public DateTime DT { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DisplayCount { get; set; }

        public Single OpenVal { get; set; }

        public Single HighVal { get; set; }

        public Single LowVal { get; set; }

        public Single CloseVal { get; set; }

        public Int64 Volume { get; set; }

        #region Override Method
        public override IEntity Clone()
        {
            return new PurushaPrakriti();
        }
        #endregion
    }
}