﻿using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.XingApp.Order
{
    public class OrderInstances
    {
        public static IndexFutureOrder IndexFutureOrderInstance = new IndexFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_국내_코스피200));

        public static WorldFutureOrder WorldFutureOrderInstanceGC = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_GOLD));
        public static WorldFutureOrder WorldFutureOrderInstanceNG = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_NG));
        public static WorldFutureOrder WorldFutureOrderInstanceSI = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_SILVER));
        public static WorldFutureOrder WorldFutureOrderInstanceCL = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_WTI));
        public static WorldFutureOrder WorldFutureOrderInstanceNQ = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_나스닥));
        public static WorldFutureOrder WorldFutureOrderInstanceHSI = new WorldFutureOrder(ItemCodeSet.GetItemSHCodeByName(ItemCode.선물_해외_항셍));

        public static Dictionary<string, WorldFutureOrder> WorldFutureOrderInstance = new Dictionary<string, WorldFutureOrder>()
        {
            {"GC" , WorldFutureOrderInstanceGC },
            {"NG" , WorldFutureOrderInstanceNG },
            {"SI" , WorldFutureOrderInstanceSI },
            {"CL" , WorldFutureOrderInstanceCL },
            {"NQ" , WorldFutureOrderInstanceNQ },
            {"HMH", WorldFutureOrderInstanceHSI }
        };
    }
}
