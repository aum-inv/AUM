﻿using OM.Lib.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Utils
{
    public class ItemCodeUtil
    {
        public static int GetItemCodeRoundNum(string code)
        {
            int num = ItemCodeSet.GetItemRoundNum(code);
           
            return num;
        }
    }
}
