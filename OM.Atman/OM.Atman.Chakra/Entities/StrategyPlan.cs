using OM.Lib.Framework.Base;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.Entities
{
	public class StrategyPlan : DomainBase
	{
		public StrategyPlan() : base("StrategyPlan") { }

		#region Override Properties

		public int StrategyPlanIDX { get; set; } = 0;
		public string Product { get; set; } = "";
		public string Item { get; set; } = "";
		public string Duration { get; set; } = "";
		public int PositionUScore { get; set; } = 0;
		public string PositionUReason { get; set; } = "";
		public int PositionSScore { get; set; } = 0;
		public string PositionSReason { get; set; } = "";
		public int PositionDScore { get; set; } = 0;
		public string PositionDReason { get; set; } = "";
		public string AnchoringULine { get; set; } = "";
		public string AnchoringSLine { get; set; } = "";
		public string AnchoringDLine { get; set; } = "";
		public string AnchoringULineReason { get; set; } = "";
		public string AnchoringSLineReason { get; set; } = "";
		public string AnchoringDLineReason { get; set; } = "";
		public string RevenueRate { get; set; } = "";
		public string LossRate { get; set; } = "";
		public string InvestTendency { get; set; } = "";
		public string InvestFundT { get; set; } = "";
		public string InvestFundA { get; set; } = "";
		public string InvestFundB { get; set; } = "";
		public string InvestFundC { get; set; } = "";
		public string ProcessState { get; set; } = "";

		#endregion

		#region Extend Method		
		#endregion

		#region Override Method
		public override IEntity Clone()
		{
			return new StrategyPlan();
		}
		#endregion
	}
}
