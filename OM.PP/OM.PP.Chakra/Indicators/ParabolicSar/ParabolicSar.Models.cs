using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OM.PP.Chakra.Indicators
{
    public class ParabolicSarResult : ResultBase
    {
        public decimal? Sar { get; set; }
        public bool? IsReversal { get; set; }
        public bool? IsRising { get; set; }
    }
}
