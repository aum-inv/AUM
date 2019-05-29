﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Entity
{
    [Serializable]
    public class CurrentPrice
    {
        public string chetime { get; set; }
        public string chetimeKr { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string price { get; set; }
        public string sign { get; set; }
        public string change { get; set; }
        public string drate { get; set; }

        public DateTime DTime
        {
            get
            {
                string str = chetime;
                string[] format = { "yyyyMMddHHmmss" };
                DateTime date;

                DateTime.TryParseExact(str, format,
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None,
                                           out date);

                return date;
            }
        }
        public DateTime DTimeKr
        {
            get
            {
                string str = chetimeKr;
                string[] format = { "yyyyMMddHHmmss" };
                DateTime date;

                DateTime.TryParseExact(str, format,
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None,
                                           out date);

                return date;
            }
        }

        public double price3 { get; set; } = 0;
        public double price5 { get; set; } = 0;
        public double price7 { get; set; } = 0;
    }
}
