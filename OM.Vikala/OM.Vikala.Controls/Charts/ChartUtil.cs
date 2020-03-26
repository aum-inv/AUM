using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Charts
{
    public class ChartUtil
    {
        const string VF_1 = "396";
        const string VF_2 = "417";
        const string VF_3 = "528";
        const string VF_4 = "639";
        const string VF_5 = "741";
        const string VF_6 = "852";
        const string VF_7 = "963";

        const string VF_8 = "432";
        const string VF_9 = "440";

        public static int SumOfEachDigit(Single price)
        {
            List<char> priceLit = price.ToString().ToList<char>();
            int totalNum = 0;

            foreach (var c in priceLit)
            {  
                int n = 0;
                var isParseing = Int32.TryParse(c.ToString(), out n);

                if (isParseing)
                    totalNum += n;
            }

            if (totalNum > 9) totalNum = SumOfEachDigit(totalNum);

            return totalNum;
        }
        public static (ChakraTypeEnum head, ChakraTypeEnum body, ChakraTypeEnum leg) GetChakraType(Single headPrice, Single bodyPrice, Single legPrice)
        {
            ChakraTypeEnum headType = ChakraTypeEnum._0_무_없음;
            ChakraTypeEnum bodyType = ChakraTypeEnum._0_무_없음;
            ChakraTypeEnum legType = ChakraTypeEnum._0_무_없음;

            try
            {
                int headNum = SumOfEachDigit(headPrice);
                int bodyNum = SumOfEachDigit(bodyPrice);
                int legNum = SumOfEachDigit(legPrice);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }

            return (headType, bodyType, legType);
        }

        public static (RainbowTypeEnum head, RainbowTypeEnum body, RainbowTypeEnum leg) GetRainbowType(Single headPrice, Single bodyPrice, Single legPrice)
        {
            RainbowTypeEnum headType = RainbowTypeEnum._0_무;
            RainbowTypeEnum bodyType = RainbowTypeEnum._0_무;
            RainbowTypeEnum legType = RainbowTypeEnum._0_무;

            try
            {
                int headNum = SumOfEachDigit(headPrice);
                int bodyNum = SumOfEachDigit(bodyPrice);
                int legNum = SumOfEachDigit(legPrice);

                if (headNum == Convert.ToInt32(VF_1.Substring(0,1))) headType = RainbowTypeEnum._1_빨;
                else if (headNum == Convert.ToInt32(VF_2.Substring(0, 1))) headType = RainbowTypeEnum._2_주;
                else if (headNum == Convert.ToInt32(VF_3.Substring(0, 1))) headType = RainbowTypeEnum._3_노;
                else if (headNum == Convert.ToInt32(VF_4.Substring(0, 1))) headType = RainbowTypeEnum._4_초;
                else if (headNum == Convert.ToInt32(VF_5.Substring(0, 1))) headType = RainbowTypeEnum._5_파;
                else if (headNum == Convert.ToInt32(VF_6.Substring(0, 1))) headType = RainbowTypeEnum._6_남;
                else if (headNum == Convert.ToInt32(VF_7.Substring(0, 1))) headType = RainbowTypeEnum._7_보;
                else if (headNum == Convert.ToInt32(VF_8.Substring(0, 1))) headType = RainbowTypeEnum._8_금;
                else if (headNum == Convert.ToInt32(VF_9.Substring(0, 1))) headType = RainbowTypeEnum._9_흑;

                if (bodyNum == Convert.ToInt32(VF_1.Substring(1, 1))) bodyType = RainbowTypeEnum._1_빨;
                else if (bodyNum == Convert.ToInt32(VF_2.Substring(1, 1))) bodyType = RainbowTypeEnum._2_주;
                else if (bodyNum == Convert.ToInt32(VF_3.Substring(1, 1))) bodyType = RainbowTypeEnum._3_노;
                else if (bodyNum == Convert.ToInt32(VF_4.Substring(1, 1))) bodyType = RainbowTypeEnum._4_초;
                else if (bodyNum == Convert.ToInt32(VF_5.Substring(1, 1))) bodyType = RainbowTypeEnum._5_파;
                else if (bodyNum == Convert.ToInt32(VF_6.Substring(1, 1))) bodyType = RainbowTypeEnum._6_남;
                else if (bodyNum == Convert.ToInt32(VF_7.Substring(1, 1))) bodyType = RainbowTypeEnum._7_보;
                else if (bodyNum == Convert.ToInt32(VF_8.Substring(1, 1))) bodyType = RainbowTypeEnum._8_금;
                else if (bodyNum == Convert.ToInt32(VF_9.Substring(1, 1))) bodyType = RainbowTypeEnum._9_흑;

                if (legNum == Convert.ToInt32(VF_1.Substring(2, 1))) legType = RainbowTypeEnum._1_빨;
                else if (legNum == Convert.ToInt32(VF_2.Substring(2, 1))) legType = RainbowTypeEnum._2_주;
                else if (legNum == Convert.ToInt32(VF_3.Substring(2, 1))) legType = RainbowTypeEnum._3_노;
                else if (legNum == Convert.ToInt32(VF_4.Substring(2, 1))) legType = RainbowTypeEnum._4_초;
                else if (legNum == Convert.ToInt32(VF_5.Substring(2, 1))) legType = RainbowTypeEnum._5_파;
                else if (legNum == Convert.ToInt32(VF_6.Substring(2, 1))) legType = RainbowTypeEnum._6_남;
                else if (legNum == Convert.ToInt32(VF_7.Substring(2, 1))) legType = RainbowTypeEnum._7_보;
                else if (legNum == Convert.ToInt32(VF_8.Substring(2, 1))) legType = RainbowTypeEnum._8_금;
                else if (legNum == Convert.ToInt32(VF_9.Substring(2, 1))) legType = RainbowTypeEnum._9_흑;
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }

            return (headType, bodyType, legType);
        }
    }
}
