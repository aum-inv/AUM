using Accord.MachineLearning;
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
         
           
            // Declare some observations
            double[][] observations =
            {
                new double[] { 101} ,
                new double[] { 102},
                new double[] { 102},
                new double[] { 103},
                new double[] { 104},
                new double[] { 106},
                new double[] { 103},
                new double[] { 102},
                new double[] { 101},
            };

            // Create a new K-Means algorithm
            KMeans kmeans = new KMeans(k: 5);

            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(observations);

            // Use the centroids to parition all the data
            int[] labels = clusters.Decide(observations);
            Dictionary<int, int> results = new Dictionary<int, int>();
            foreach (var m in labels)
            {
                Console.WriteLine(m);
                if (results.ContainsKey(m))
                    results[m]++;
                else
                    results.Add(m, 1);              
            }
            int firstGroup = results.OrderByDescending(t => t.Value).First().Key;

            Console.WriteLine(firstGroup);

            List<double> resultList = new List<double>();

            int idx = 0;
            foreach (var m in labels)
            {
                if (m == firstGroup)
                    resultList.Add(observations[idx][0]);
                idx++;
            }
            Console.WriteLine(resultList.Average());
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
