using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra.Patterns
{
    public class ThreeCandlePattern
    {
        public CandlePatternTypeEnum CheckAllPattern(S_CandleItemData item)
        {
            CandlePatternTypeEnum type = CandlePatternTypeEnum.Unknown;

            if (item.PreCandleItem == null) return type;
            if (item.NextCandleItem == null) return type;

            if (상승역망치형(item)) return CandlePatternTypeEnum.Up;
            else if (상승망치형(item)) return CandlePatternTypeEnum.Up;
            else if (상승샅바형(item)) return CandlePatternTypeEnum.Up;
            else if (상승십자성형(item)) return CandlePatternTypeEnum.Up;
            else if (상승샛별형(item)) return CandlePatternTypeEnum.Up;
            else if (상승십자샛별형(item)) return CandlePatternTypeEnum.Up;
            else if (상승기아형(item)) return CandlePatternTypeEnum.Up;
            else if (상승잉태확인형(item)) return CandlePatternTypeEnum.Up;
            else if (상승장악확인형(item)) return CandlePatternTypeEnum.Up;

            else if (하락유성형(item)) return CandlePatternTypeEnum.Down;
            else if (하락교수형(item)) return CandlePatternTypeEnum.Down;
            else if (하락샅바형(item)) return CandlePatternTypeEnum.Down;
            else if (하락십자성형(item)) return CandlePatternTypeEnum.Down;
            else if (하락석별형(item)) return CandlePatternTypeEnum.Down;
            else if (하락기아형(item)) return CandlePatternTypeEnum.Down;
            else if (하락잉태확인형(item)) return CandlePatternTypeEnum.Down;
            else if (하락장악확인형(item)) return CandlePatternTypeEnum.Down;

            else if (상승지속블럭형(item)) return CandlePatternTypeEnum.Up;
            else if (상승지속지연형(item)) return CandlePatternTypeEnum.Up;
            else if (상승지속갭타스키형(item)) return CandlePatternTypeEnum.Up;
            else if (상승지속갭삼법형(item)) return CandlePatternTypeEnum.Up;

            else if (하락지속갭타스키형(item)) return CandlePatternTypeEnum.Down;
            else if (하락지속갭삼법형(item)) return CandlePatternTypeEnum.Down;

            return type;
        }
        #region 상승반전패턴유형
        public bool 상승역망치형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool 상승망치형(S_CandleItemData item)
        {
            if (item.PlusMinusType_P == PlusMinusTypeEnum.음
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
                && item.PlusMinusType == PlusMinusTypeEnum.음
                && item.PlusMinusType_N == PlusMinusTypeEnum.양)
            {
                if (item.TimeType_P == CandleTimeTypeEnum.음
                    && item.TimeType_N == CandleTimeTypeEnum.양)
                {
                    if (item.SpaceType_P == CandleSpaceTypeEnum.Hammer || item.SpaceType_P == CandleSpaceTypeEnum.SmallHammer)
                    {
                        if (item.SpaceType_C == CandleSpaceTypeEnum.Hammer || item.SpaceType_C == CandleSpaceTypeEnum.SmallHammer || item.SpaceType_C == CandleSpaceTypeEnum.Spinning)
                        {
                            if (item.SpaceType_N == CandleSpaceTypeEnum.Hammer || item.SpaceType_N == CandleSpaceTypeEnum.SmallHammer)
                            {
                                return true;
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
            return false;
        }
        public bool 하락교수형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락샅바형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락십자성형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락석별형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락기아형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락잉태확인형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락장악확인형(S_CandleItemData item)
        {
            return false;
        }

        #endregion

        #region 상승지속패턴유형
        public bool 상승지속블럭형(S_CandleItemData item)
        {
            return false;
        }
        public bool 상승지속지연형(S_CandleItemData item)
        {
            return false;
        }
        public bool 상승지속갭타스키형(S_CandleItemData item)
        {
            return false;
        }
        public bool 상승지속갭삼법형(S_CandleItemData item)
        {
            return false;
        }
        #endregion

        #region 하락지속패턴유형
        public bool 하락지속갭타스키형(S_CandleItemData item)
        {
            return false;
        }
        public bool 하락지속갭삼법형(S_CandleItemData item)
        {
            return false;
        }
        #endregion
    }
}