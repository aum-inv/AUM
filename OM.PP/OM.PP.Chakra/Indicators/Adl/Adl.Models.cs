using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OM.PP.Chakra.Indicators
{
    public class AdlResult : ResultBase
    {
        public decimal MoneyFlowMultiplier { get; set; }
        public decimal MoneyFlowVolume { get; set; }
        public decimal Adl { get; set; }
    }
}
