using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Enums
{
    public enum TimeIntervalEnum
    {
            Minute_01 = 1
        ,   Minute_05 = 2
        ,   Minute_10 = 3
        ,   Minute_15 = 4
        ,   Minute_30 = 5
        ,   Hour_01 = 11
        ,   Hour_02 = 12
        ,   Hour_03 = 13
        ,   Hour_04 = 14
        ,   Hour_05 = 15
        ,   Hour_06 = 16
        ,   Hour_08 = 17
        ,   Hour_12 = 18
        ,   Day = 20
        ,   Week = 30
        ,   Month = 40     
          
        ,   None = 0
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
