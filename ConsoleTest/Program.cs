using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Framework.Utility;
using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double d1 = 45.02;
            double d2 = 45.05;
            double d3 = 45.55;
            double d4 = 45.65;
            double d5 = 45.67;
            
            Console.WriteLine(System.Math.Truncate(d1 / 0.1) * 0.1);
            Console.WriteLine(System.Math.Truncate(d2 / 0.1) * 0.1);
            Console.WriteLine(System.Math.Truncate(d3 / 0.1) * 0.1);
            Console.WriteLine(System.Math.Truncate(d4 / 0.1) * 0.1);
            Console.WriteLine(System.Math.Truncate(d5 / 0.1) * 0.1);
            Console.ReadLine();      
        }

        static double getDevation(double v, int r)
        {          
            double quotient = System.Math.Truncate(v); // 몫
            double remainder = Math.Round(v - quotient, r);  // 나머지
            var ret = quotient + remainder;
            return ret;   
        }
        static int NumLength(long number)
        {
            if (number == 0L)
            {
                return 1;
            }
            return ((int)Math.Log10(number > 0L ? number : -number)) + 1;
        }
    }
}
