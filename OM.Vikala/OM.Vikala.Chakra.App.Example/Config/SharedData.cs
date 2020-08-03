using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Chakra.App.Config
{
    public static class SharedData
    {
        public static string SelectedType
        {
            get;
            set;
        } = "2";

        public static ItemData SelectedItem
        {
            get;
            set;
        }

        public static TimeIntervalEnum SelectedInterval
        {
            get;
            set;
        } = TimeIntervalEnum.Day;

        public static int SelectedItemCount
        {
            get;
            set;
        } = 300;
    }
}
