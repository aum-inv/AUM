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
        Unknown = 9,
        Up = 1,
        Down = 2,
        StrongUp = 3,
        StrongDown = 4
    }
}
