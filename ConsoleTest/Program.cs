using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = {55, 54, 59, 60, 61, 62, 58, 57 };
            double pAvg = prices.Average();
            double pSD = GetStandardDeviation(prices, pAvg);
            
            Console.WriteLine(pSD);

            Console.ReadLine();
        }


        public static double GetStandardDeviation(double[] valueArray, double average)
        {

            int valueCount = valueArray.Length;
            if (valueCount == 0)
            {
                return 0d;
            }
            double standardDeviation = 0d;
            double variance = 0d;
            try
            {
                for (int i = 0; i < valueCount; i++)
                {
                    variance += Math.Pow(valueArray[i] - average, 2);
                }
                standardDeviation = Math.Sqrt(SafeDivide(variance, valueCount));
            }
            catch (Exception)
            {
                throw;
            }

            return standardDeviation;

        }
        private static double SafeDivide(double value1, double value2)
        {
            double result = 0d;
            try
            {
                if ((value1 == 0) || (value2 == 0))
                {
                    return 0d;
                }
                result = value1 / value2;
            }
            catch
            {
            }
            return result;
        }
    }
}
