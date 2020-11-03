using OM.Jiva.Chakra.Entities;
using OM.Lib.Base.Enums;
using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OM.Jiva.Chakra.Patterns
{
    public class ThreeCandlePattern
    {
        public (CandlePatternTypeEnum patternType, string patternName) CheckAllPattern(S_CandleItemData item)
        {
            CandlePatternTypeEnum type = CandlePatternTypeEnum.Unknown;

            if (item.PreCandleItem == null) return (type, "");
            if (item.NextCandleItem == null) return (type, "");

            if (상승역망치형(item)) return (CandlePatternTypeEnum.Up, "상승역망치형");
            else if (상승망치형(item)) return (CandlePatternTypeEnum.Up, "상승망치형");
            else if (상승샅바형(item)) return (CandlePatternTypeEnum.Up, "상승샅바형");
            else if (상승십자성형(item)) return (CandlePatternTypeEnum.Up, "상승십자성형");
            else if (상승샛별형(item)) return (CandlePatternTypeEnum.Up, "상승샛별형");
            else if (상승십자샛별형(item)) return (CandlePatternTypeEnum.Up, "상승십자샛별형");
            else if (상승기아형(item)) return (CandlePatternTypeEnum.Up, "상승기아형");
            else if (상승잉태확인형(item)) return (CandlePatternTypeEnum.Up, "상승잉태확인형");
            else if (상승장악확인형(item)) return (CandlePatternTypeEnum.Up, "상승장악확인형");

            else if (하락유성형(item)) return (CandlePatternTypeEnum.Down, "하락유성형");
            else if (하락교수형(item)) return (CandlePatternTypeEnum.Down, "하락교수형");
            else if (하락샅바형(item)) return (CandlePatternTypeEnum.Down, "하락샅바형");
            else if (하락십자성형(item)) return (CandlePatternTypeEnum.Down, "하락십자성형");
            else if (하락석별형(item)) return (CandlePatternTypeEnum.Down, "하락석별형");
            else if (하락십자석별형(item)) return (CandlePatternTypeEnum.Down, "하락십자석별형");
            else if (하락기아형(item)) return (CandlePatternTypeEnum.Down, "하락기아형");
            else if (하락잉태확인형(item)) return (CandlePatternTypeEnum.Down, "하락잉태확인형");
            else if (하락장악확인형(item)) return (CandlePatternTypeEnum.Down, "하락장악확인형");

            else if (상승지속블럭형(item)) return (CandlePatternTypeEnum.Up, "상승지속블럭형");
            else if (상승지속지연형(item)) return (CandlePatternTypeEnum.Up, "상승지속지연형");
            else if (상승지속갭타스키형(item)) return (CandlePatternTypeEnum.Up, "상승지속갭타스키형");
            else if (상승지속갭타스키형2(item)) return (CandlePatternTypeEnum.Up, "상승지속갭타스키형2");
            else if (상승지속갭삼법형(item)) return (CandlePatternTypeEnum.Up, "상승지속갭삼법형");

            else if (하락지속갭삼법형(item)) return (CandlePatternTypeEnum.Down, "하락지속갭삼법형");

            return (type, "");
        }
        #region 상승반전패턴유형
        public bool 상승역망치형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음 
                    && (item.TimeType_HighPrice_P == CandleTimeTypeEnum.음 || item.TimeType_HighPrice_P == CandleTimeTypeEnum.무)
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.ShortBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승망치형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                 && item.PlusMinusType == PlusMinusTypeEnum.음
                 && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if ((item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음 || item.TimeType_OpenPrice_P == CandleTimeTypeEnum.무)
                    && (item.TimeType_HighPrice_P == CandleTimeTypeEnum.음 || item.TimeType_HighPrice_P == CandleTimeTypeEnum.무)
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Dogi)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승샅바형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody || item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승십자성형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Marubozu)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승샛별형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody || item.SpaceType_P == CandleSpaceTypeEnum.ShortBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody || item.SpaceType_C == CandleSpaceTypeEnum.ShortBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody || item.SpaceType_N == CandleSpaceTypeEnum.Marubozu)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승십자샛별형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승기아형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음                           
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu || item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Marubozu || item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승잉태확인형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu || item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Marubozu || item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승장악확인형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양                           
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Marubozu)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region 하락반전패턴유형
        public bool 하락유성형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if ((item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양 || item.TimeType_OpenPrice_N == CandleTimeTypeEnum.무)
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_N == CandleSpaceTypeEnum.Hammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락교수형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음 || item.TimeType_HighPrice_PN == CandleTimeTypeEnum.무
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음 || item.TimeType_LowPrice_PN == CandleTimeTypeEnum.무
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.ShortBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락샅바형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu || item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Marubozu || item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락십자성형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양 || item.TimeType_ClosePrice_N == CandleTimeTypeEnum.무)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Dogi)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락석별형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody || item.SpaceType_N == CandleSpaceTypeEnum.Spinning)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락십자석별형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Spinning)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락기아형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음 || item.TimeType_HighPrice_PN == CandleTimeTypeEnum.무
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음 || item.TimeType_LowPrice_PN == CandleTimeTypeEnum.무
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Dogi)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락잉태확인형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Spinning || item.SpaceType_C == CandleSpaceTypeEnum.ShortBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 하락장악확인형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Dogi)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.ShortBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region 상승지속패턴유형
        public bool 상승지속블럭형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.ShortBody)
                                {
                                    if(item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승지속지연형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승지속갭타스키형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                && item.PlusMinusType == PlusMinusTypeEnum.양
                && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if ((item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음 || item.TimeType_OpenPrice_N == CandleTimeTypeEnum.무)
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.Marubozu)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.ShortBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool 상승지속갭삼법형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.양
                 && item.PlusMinusType == PlusMinusTypeEnum.양
                 && item.PlusMinusType_N == PlusMinusTypeEnum.음)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.양
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.양)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.음)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.양
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool 상승지속갭타스키형2(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                  && item.PlusMinusType == PlusMinusTypeEnum.음
                  && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if ((item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음 || item.TimeType_OpenPrice_N == CandleTimeTypeEnum.무)
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.양)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region 하락지속패턴유형

        public bool 하락지속갭삼법형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_OpenPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_HighPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_LowPrice_P == CandleTimeTypeEnum.음
                    && item.TimeType_ClosePrice_P == CandleTimeTypeEnum.음)
                {
                    if (item.TimeType_OpenPrice_N == CandleTimeTypeEnum.음
                        && item.TimeType_HighPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_LowPrice_N == CandleTimeTypeEnum.양
                        && item.TimeType_ClosePrice_N == CandleTimeTypeEnum.양)
                    {
                        if (item.TimeType_OpenPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_HighPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_LowPrice_PN == CandleTimeTypeEnum.음
                            && item.TimeType_ClosePrice_PN == CandleTimeTypeEnum.음)
                        {
                            if (item.SpaceType_P == CandleSpaceTypeEnum.LongBody)
                            {
                                if (item.SpaceType_C == CandleSpaceTypeEnum.LongBody)
                                {
                                    if (item.SpaceType_N == CandleSpaceTypeEnum.LongBody)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        #endregion


        public List<CandlePattern_Three> patterns = null;
        public void LoadPatternData(string product = "", string item = "")
        {
            CandlePattern_Three p = new CandlePattern_Three();
            p.Product = product;
            p.Item = item;
            var entities =  p.Collect();

            patterns = entities.Cast<CandlePattern_Three>().ToList();
        }

        public List<CandlePattern_Three> GetMatchPatterns(CandlePattern_Three s)
        {
            var list = new List<CandlePattern_Three>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT && s.EndDT == p.EndDT)
                    continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    && s.PlusMinusType_P2 == p.PlusMinusType_P2
                    && s.PlusMinusType_P1 == p.PlusMinusType_P1
                    && s.PlusMinusType_P0 == p.PlusMinusType_P0
                    && s.CandleSpaceType_P2 == p.CandleSpaceType_P2
                    && s.CandleSpaceType_P1 == p.CandleSpaceType_P1
                    && s.CandleSpaceType_P0 == p.CandleSpaceType_P0
                    && s.CandleTimeType_O_P21 == p.CandleTimeType_O_P21
                    && s.CandleTimeType_C_P21 == p.CandleTimeType_C_P21
                    && s.CandleTimeType_H_P21 == p.CandleTimeType_H_P21
                    && s.CandleTimeType_L_P21 == p.CandleTimeType_L_P21
                    && s.CandleTimeType_O_P10 == p.CandleTimeType_O_P10
                    && s.CandleTimeType_C_P10 == p.CandleTimeType_C_P10
                    && s.CandleTimeType_H_P10 == p.CandleTimeType_H_P10
                    && s.CandleTimeType_L_P10 == p.CandleTimeType_L_P10
                    && s.CandleTimeType_O_P20 == p.CandleTimeType_O_P20
                    && s.CandleTimeType_C_P20 == p.CandleTimeType_C_P20
                    && s.CandleTimeType_H_P20 == p.CandleTimeType_H_P20
                    && s.CandleTimeType_L_P20 == p.CandleTimeType_L_P20
                    && s.CandleSizeType_B_P21 == p.CandleSizeType_B_P21
                    && s.CandleSizeType_B_P10 == p.CandleSizeType_B_P10
                    && s.CandleSizeType_B_P20 == p.CandleSizeType_B_P20
                    && s.CandleSizeType_T_P21 == p.CandleSizeType_T_P21
                    && s.CandleSizeType_T_P10 == p.CandleSizeType_T_P10
                    && s.CandleSizeType_T_P20 == p.CandleSizeType_T_P20                   
                    )
                {                    
                    list.Add(p);
                }
            }
            return list;
        }
    }
}