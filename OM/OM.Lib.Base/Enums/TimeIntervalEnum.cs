using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Enums
{
    public enum TimeIntervalEnum
    {
            Minute_60 = 1
        ,   Minute_120 = 2
        ,   Minute_180 = 3
        ,   Minute_240 = 4
        ,   Minute_300 = 5
        ,   Minute_360 = 6
        ,   Minute_480 = 8
        ,   Minute_720 = 12
        ,   Day
        ,   Week
        ,   Month          
          
        ,   None
    }
}


// 1시간 : 60분
// 2시간 : 120분
// 3시간 : 180분
// 4시간 : 240분
// 5시간 : 300분
// 6시간 : 360분
// 8시간 : 480분
// 12시간 : 720분
