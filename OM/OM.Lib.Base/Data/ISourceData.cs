﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Base.Data
{
    /// <summary>
    /// 원천 데이터
    /// </summary>
  
    public interface ISourceData
    {
        Single OpenPrice { get; }
        Single HighPrice { get; }
        Single LowPrice { get; }
        Single ClosePrice { get; }
        Single Volume { get; }

        Single CenterPrice { get; }
        Single MiddlePrice { get; }

        DateTime DTime { get; }
    }
}
