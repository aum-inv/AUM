using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public enum PlusMinusTypeEnum
    {
         양 = 1, 음 = 2, 무 = 0
    }

    public enum CandleColorTypeEnum
    {
        양 = 1, 음 = 2, 무 = 0
    }
    public enum CandleTimeTypeEnum
    {
        양 = 1, 음 = 2, 무 = 0, 모름 = 9
    }
    public enum CandleSizeTypeEnum
    { 
        Big = 1, Small = 2, NoMatter = 9
    }
    public enum CandleSpaceTypeEnum
    {
        None = 0, 
        Marubozu = 1,
        LongBody = 2,
        ShortBody = 3,
        Spinning = 4,
        Hammer = 5,
        SmallHammer = 6,
        Dogi = 7,
        Unknown = 9
    }

    public enum CandlePatternTypeEnum
    {
        Unknown = 0,
     
        WeakUp = 1,
        WeakDown = 2,

        Up = 3,
        Down = 4,

        StrongUp = 5,
        StrongDown = 6,

        WeakSide = 7,
        NormalSide = 8,
        StrongSide = 9
    }

    public enum CandleGravitationalForceTypeEnum
    {
        Unknown = 0,

        MarubozuT = 1,
        MarubozuB = 2,

        LongBodyT = 3,
        LongBodyC = 4,
        LongBodyB = 5,
       
        ShortBodyT = 6,
        ShortBodyC = 7,
        ShortBodyB = 8,
        
        SpinningT = 9,
        SpinningC = 10,
        SpinningB = 11,
      
        HammerT = 12,
        HammerB = 13,

        SmallHammerT = 14,
        SmallHammerB = 15,

        DogiC = 16,
        DogiT = 17,
        DogiB = 18
    }
    public enum CandleElectromagneticForceTypeEnum
    {
        양 = 1, 음 = 2, 무 = 0
    }
    public enum CandleStrongForceTypeEnum
    {
       High = 1, Low = 2, Same = 3 
    }
    public enum CandleWeakForceTypeEnum
    {
       Big = 1, Small = 2, Same = 3
    }
}
