using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Jiva.Chakra.Entities
{
    public class CandleForcePatternData : DomainBase
    {
        public CandleForcePatternData() : base("CandleForcePattern") { }

		#region Override Properties

		public int IDX { get; set; } = 0;

		public string Product { get; set; } = "";
		public string Item { get; set; } = "";
		public int TimeInterval { get; set; } = 0;	
		public DateTime StartDT { get; set; }
		public DateTime EndDT { get; set; }

		public string GForceType_P3 { get; set; } = "";
		public string GForceType_P2 { get; set; } = "";
		public string GForceType_P1 { get; set; } = "";
		public string GForceType_P0 { get; set; } = "";

		public string EForceType_OC_P3 { get; set; } = "";
		public string EForceType_OC_P2 { get; set; } = "";
		public string EForceType_OC_P1 { get; set; } = "";
		public string EForceType_OC_P0 { get; set; } = "";
		public string EForceType_CC_P3 { get; set; } = "";
		public string EForceType_CC_P2 { get; set; } = "";
		public string EForceType_CC_P1 { get; set; } = "";
		public string EForceType_CC_P0 { get; set; } = "";

		public string SForceType_O_P3 { get; set; } = "";
		public string SForceType_O_P2 { get; set; } = "";
		public string SForceType_O_P1 { get; set; } = "";
		public string SForceType_O_P0 { get; set; } = "";
		public string SForceType_H_P3 { get; set; } = "";
		public string SForceType_H_P2 { get; set; } = "";
		public string SForceType_H_P1 { get; set; } = "";
		public string SForceType_H_P0 { get; set; } = "";
		public string SForceType_L_P3 { get; set; } = "";
		public string SForceType_L_P2 { get; set; } = "";
		public string SForceType_L_P1 { get; set; } = "";
		public string SForceType_L_P0 { get; set; } = "";
		public string SForceType_C_P3 { get; set; } = "";
		public string SForceType_C_P2 { get; set; } = "";
		public string SForceType_C_P1 { get; set; } = "";
		public string SForceType_C_P0 { get; set; } = "";

		public string WForceType_T_P3 { get; set; } = "";
		public string WForceType_T_P2 { get; set; } = "";
		public string WForceType_T_P1 { get; set; } = "";
		public string WForceType_T_P0 { get; set; } = "";
		public string WForceType_H_P3 { get; set; } = "";
		public string WForceType_H_P2 { get; set; } = "";
		public string WForceType_H_P1 { get; set; } = "";
		public string WForceType_H_P0 { get; set; } = "";
		public string WForceType_B_P3 { get; set; } = "";
		public string WForceType_B_P2 { get; set; } = "";
		public string WForceType_B_P1 { get; set; } = "";
		public string WForceType_B_P0 { get; set; } = "";
		public string WForceType_L_P3 { get; set; } = "";
		public string WForceType_L_P2 { get; set; } = "";
		public string WForceType_L_P1 { get; set; } = "";
		public string WForceType_L_P0 { get; set; } = "";
		public string CandlePatternType2 { get; set; } = "";
		public string CandlePatternType3 { get; set; } = "";
		public string CandlePatternType4 { get; set; } = "";
		#endregion

		#region Extend Method		
		#endregion

		#region Override Method
		public override IEntity Clone()
		{
			return new CandleForcePatternData();
		}
		#endregion
	}
}
