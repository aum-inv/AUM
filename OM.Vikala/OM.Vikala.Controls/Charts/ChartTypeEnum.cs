﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Charts
{
    public enum BaseCandleChartTypeEnum
    {
        인, 천, 지
    }

    public enum CandleChartTypeEnum
    {
        기본, 음양오행, 삼태극, 삼양삼음, 천지인, 쿼크, 진동주파수, 원자, 리버스
    }

    public enum LineChartTypeEnum
    {
        기본, 양자라인, 삼태극, 변화, 질량, 속도
    }

    public enum ChakraTypeEnum
    {
        _0_무_없음
        , _1_빨_물라다라
        , _2_주_스와디스타나
        , _3_노_마니푸라
        , _4_초_아나하타
        , _5_파_비슈다
        , _6_남_아즈나
        , _7_보_사하스라라
    }

    public enum RainbowTypeEnum
    {
        _0_무
        , _1_빨
        , _2_주
        , _3_노
        , _4_초
        , _5_파
        , _6_남
        , _7_보

        , _8_금
        , _9_흑
    }
}
