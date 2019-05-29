using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Enums
{
    public enum UpDownPatternEnum
    {
             [Description("-")] None
        ,    [Description("↘↗↘↗↘↗↘")]DownUpDownUpDownUpDown
        ,    [Description("↗↘↗↘↗↘↗")]UpDownUpDownUpDownUp
        ,    [Description("↘↗↘↗↘↗")]DownUpDownUpDownUp
        ,    [Description("↗↘↗↘↗↘")]UpDownUpDownUpDown
        ,    [Description("↘↗↘↗↘")]DownUpDownUpDown
        ,    [Description("↗↘↗↘↗")]UpDownUpDownUp
        ,    [Description("↘↗↘↗")]DownUpDownUp
        ,    [Description("↗↘↗↘")]UpDownUpDown
        ,    [Description("↘↗↘")]DownUpDown
        ,    [Description("↗↘↗")]UpDownUp
        ,    [Description("↘↗")]DownUp
        ,    [Description("↗↘")]UpDown
        ,    [Description("↘")]Down
        ,    [Description("↗")] Up
    }

    public enum UpDownSimplePatternEnum
    {
          None
        , DownUpDownUpDownUpDown
        , UpDownUpDownUpDownUp
        , DownUpDownUpDownUp
        , UpDownUpDownUpDown
        , DownUpDownUpDown
        , UpDownUpDownUp
        , DownUpDownUp
        , UpDownUpDown
        , DownUpDown
        , UpDownUp
        , DownUp
        , UpDown
        , Down
        , Up
    }

}
