using System;

namespace OM.PP.Chakra.Indicators
{
    public class RsiResult : ResultBase
    {
        public decimal? Rsi { get; set; }
        public bool? IsIncreasing { get; set; }

        // internal use only
        internal decimal Gain { get; set; } = 0;
        internal decimal Loss { get; set; } = 0;
    }
}
