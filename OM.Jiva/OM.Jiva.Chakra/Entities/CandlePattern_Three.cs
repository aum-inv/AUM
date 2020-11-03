using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Jiva.Chakra.Entities
{
    public class CandlePattern_Three : DomainBase
    {
        public CandlePattern_Three() : base("CandlePattern_Three") { }

		#region Override Properties

		public int IDX { get; set; } = 0;

		public string Product { get; set; } = "";
		public string Item { get; set; } = "";
		public int TimeInterval { get; set; } = 0;
		public string PlusMinusType_P2 { get; set; } = "";
		public string PlusMinusType_P1 { get; set; } = "";
		public string PlusMinusType_P0 { get; set; } = "";
		public string CandleSpaceType_P2 { get; set; } = "";
		public string CandleSpaceType_P1 { get; set; } = "";
		public string CandleSpaceType_P0 { get; set; } = "";
		public string CandleTimeType_O_P21 { get; set; } = "";
		public string CandleTimeType_C_P21 { get; set; } = "";
		public string CandleTimeType_H_P21 { get; set; } = "";
		public string CandleTimeType_L_P21 { get; set; } = "";
		public string CandleTimeType_O_P10 { get; set; } = "";
		public string CandleTimeType_C_P10 { get; set; } = "";
		public string CandleTimeType_H_P10 { get; set; } = "";
		public string CandleTimeType_L_P10 { get; set; } = "";
		public string CandleTimeType_O_P20 { get; set; } = "";
		public string CandleTimeType_C_P20 { get; set; } = "";
		public string CandleTimeType_H_P20 { get; set; } = "";
		public string CandleTimeType_L_P20 { get; set; } = "";
		public string CandleSizeType_B_P21 { get; set; } = "";
		public string CandleSizeType_B_P10 { get; set; } = "";
		public string CandleSizeType_B_P20 { get; set; } = "";
		public string CandleSizeType_T_P21 { get; set; } = "";
		public string CandleSizeType_T_P10 { get; set; } = "";
		public string CandleSizeType_T_P20 { get; set; } = "";
		public string CandlePatternType { get; set; } = "";
		public DateTime StartDT { get; set; }
		public DateTime EndDT { get; set; }
		#endregion

		#region Extend Method		
		#endregion

		#region Override Method
		public override IEntity Clone()
		{
			return new CandlePattern_Three();
		}
		#endregion
	}
}
