using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Jiva.Chakra.Entities
{
    public class CandleHistoryData : DomainBase
    {
        public CandleHistoryData() : base("CandleHistory") { }

		#region Override Properties

		public string Product { get; set; } = "";
		public string Item { get; set; } = "";
		public int TimeInterval { get; set; } = 0;	
		public DateTime DTime { get; set; }
	
		public string OpenPrice { get; set; } = "0";
		public string HighPrice { get; set; } = "0";
		public string LowPrice { get; set; } = "0";
		public string ClosePrice { get; set; } = "0";
		public string Volume { get; set; } = "0";
		#endregion

		#region Extend Method		
		#endregion

		#region Override Method
		public override IEntity Clone()
		{
			return new CandleHistoryData();
		}
		#endregion
	}
}
