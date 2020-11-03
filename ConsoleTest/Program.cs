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
        enum AAA { a= 1, b=2, c=3}
        static void Main(string[] args)
        {
            //SmartCandleData preprepreData = new SmartCandleData("101", 306.86, 310.27, 303.39, 309.33, 0, null, null);
            //SmartCandleData prepreData = new SmartCandleData("101", 306.86,  310.27,  303.39,  309.33, 0, null, preprepreData);
            //SmartCandleData preData = new SmartCandleData("101", 312.45, 314.14,  310.57,  313.59, 0, null, prepreData);
            //SmartCandleData data = new SmartCandleData("101", 313.61,    314.57,  309.74,  311.94,0 , null, preData);

            //Console.WriteLine("BasicPrice");
            //Console.WriteLine($"{data.BasicPrice_Open}");
            //Console.WriteLine($"{data.BasicPrice_High}");
            //Console.WriteLine($"{data.BasicPrice_Low}");
            //Console.WriteLine($"{data.BasicPrice_Close}");
            //Console.WriteLine($"{data.BasicPrice_Middle}");
            //Console.WriteLine($"{data.BasicPrice_Center}");
            //Console.WriteLine($"{data.BasicPrice_BodyLength}");
            //Console.WriteLine($"{data.BasicPrice_TotalLength}");

            //Console.WriteLine("ComparedPreviousDayPrice");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_Open}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_High}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_Low}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_Close}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_Middle}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_Center}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_BodyLength}");
            //Console.WriteLine($"{data.ComparedPreviousDayPrice_TotalLength}");

            //Console.WriteLine("QuantumPrice");
            //Console.WriteLine($"{data.QuantumPrice_Open}");
            //Console.WriteLine($"{data.QuantumPrice_High}");
            //Console.WriteLine($"{data.QuantumPrice_Low}");
            //Console.WriteLine($"{data.QuantumPrice_Close}");
            //Console.WriteLine($"{data.QuantumPrice_Middle}");
            //Console.WriteLine($"{data.QuantumPrice_Center}");
            //Console.WriteLine($"{data.QuantumPrice_BodyLength}");
            //Console.WriteLine($"{data.QuantumPrice_TotalLength}");

            //Console.WriteLine("ComparedPreviousDayQuantumPrice");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_Open}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_High}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_Low}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_Close}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_Middle}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_Center}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_BodyLength}");
            //Console.WriteLine($"{data.ComparedPreviousDayQuantumPrice_TotalLength}");

            //Console.WriteLine("Variance");           
            //Console.WriteLine($"{data.Variance_BasicPrice}");
            //Console.WriteLine($"{data.Variance_ComparedPreviousDayPrice}");
            //Console.WriteLine($"{data.Variance_QuantumPrice}");
            //Console.WriteLine($"{data.Variance_ComparedPreviousDayQuantumPrice}");
            //Console.WriteLine($"{data.VarianceTotalRate}");

            //Console.WriteLine("Space");
            //Console.WriteLine($"{data.Space_BasicPrice}");
            //Console.WriteLine($"{data.Space_ComparedPreviousDayPrice}");
            //Console.WriteLine($"{data.SpaceTotal}");
            //Console.WriteLine($"{data.SpaceTotalAverage}"); 
            //Console.WriteLine($"{data.SpaceTotalChangeRate}");

            //Console.WriteLine("Energy");
            //Console.WriteLine($"{data.ColorEnergy}");
            //Console.WriteLine($"{data.TimeEnergy}");
            //Console.WriteLine($"{data.SpaceEnergy}");
            //Console.WriteLine($"{data.TotalEnergy}");
            //Console.ReadLine();


            //string xml = @"<?xml version=""1.0"" encoding=""utf - 8"" ?><atman></atman>";

            //XmlUtility xmlUtility = new XmlUtility("", xml);

            //xmlUtility.InsertElement("atman", "projects", "<projectPlan1>abc</projectPlan1><projectPlan2>abc</projectPlan2>");

            //Console.WriteLine(xmlUtility.Xml);


            Console.WriteLine(Convert.ToInt32(AAA.a).ToString());
            Console.ReadLine();
            return;

            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1600570570);

            string urlPath = "https://tvc4.forexpros.com/1cc1f0b6f392b9fad2b50b7aebef1f7c/1601866558/18/18/88/history?symbol=8849&resolution=D&from=1600570570&to=1601866630";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPath);
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            string content = readStream.ReadToEnd();

            Console.WriteLine(content);

            var dyObj = JsonConverter.JsonToDynamicObject(content);
            int cnt = dyObj.t.Count;
            for (int i = 0; i < cnt; i++)
            {
                Int64 t = dyObj.t[i];
                double o = dyObj.o[i];
                double c = dyObj.c[i];
                double h = dyObj.h[i];
                double l = dyObj.l[i];

                DateTime cTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(t);
                Console.WriteLine($"DT : {cTime.ToLongDateString()} O : {Math.Round(o, 2)}, H : {Math.Round(h, 2)}, L : {Math.Round(l, 2)}, C : {Math.Round(c, 2)}");
            }
            Console.ReadLine();
        }
    }
}
