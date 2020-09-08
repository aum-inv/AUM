using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.App.AIForms
{

    class EnergyRank
    {
        public EnergyRank()
        {        
        }
        public int TimeRank { get; set; } = 0;
        public double TimeEnergy { get; set; } = 10000;

        public int SpaceRank { get; set; } = 0;
        public double SpaceEnergy { get; set; } = 10000;
                
        public int SumRank { get; set; } = 0;
        public double SumEnergy { get; set; } = 10000;

        public int ColorRank { get; set; } = 0;
        public double ColorEnergy { get; set; } = 10000;

        public int TotalRank { get; set; }
    }
}

