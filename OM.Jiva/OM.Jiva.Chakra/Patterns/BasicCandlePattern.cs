using OM.Jiva.Chakra.Entities;
using OM.Lib.Base.Enums;
using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OM.Jiva.Chakra.Patterns
{
    public class BasicCandlePattern
    {       
        public List<CandlePatternData> patterns = null;
        public void LoadPatternData(string product = "", string item = "")
        {
            CandlePatternData p = new CandlePatternData();
            p.Product = product;
            p.Item = item;
            var entities =  p.Collect();

            patterns = entities.Cast<CandlePatternData>().ToList();
        }

        public List<CandlePatternData> GetMatchPatterns4(CandlePatternData s)
        {
            var list = new List<CandlePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT && s.EndDT == p.EndDT)
                    continue;

                if (s.Product != p.Product) continue;
                if (s.Item != p.Item) continue;
                if (s.TimeInterval != p.TimeInterval) continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    && s.PlusMinusType_P3 == p.PlusMinusType_P3
                    && s.PlusMinusType_P2 == p.PlusMinusType_P2
                    && s.PlusMinusType_P1 == p.PlusMinusType_P1
                    && s.PlusMinusType_P0 == p.PlusMinusType_P0

                    && s.CandleSpaceType_P3 == p.CandleSpaceType_P3
                    && s.CandleSpaceType_P2 == p.CandleSpaceType_P2
                    && s.CandleSpaceType_P1 == p.CandleSpaceType_P1
                    && s.CandleSpaceType_P0 == p.CandleSpaceType_P0

                    && s.CandleTimeType_O_P32 == p.CandleTimeType_O_P32
                    && s.CandleTimeType_C_P32 == p.CandleTimeType_C_P32
                    && s.CandleTimeType_H_P32 == p.CandleTimeType_H_P32
                    && s.CandleTimeType_L_P32 == p.CandleTimeType_L_P32

                    && s.CandleTimeType_O_P31 == p.CandleTimeType_O_P31
                    && s.CandleTimeType_C_P31 == p.CandleTimeType_C_P31
                    && s.CandleTimeType_H_P31 == p.CandleTimeType_H_P31
                    && s.CandleTimeType_L_P31 == p.CandleTimeType_L_P31

                    && s.CandleTimeType_O_P30 == p.CandleTimeType_O_P30
                    && s.CandleTimeType_C_P30 == p.CandleTimeType_C_P30
                    && s.CandleTimeType_H_P30 == p.CandleTimeType_H_P30
                    && s.CandleTimeType_L_P30 == p.CandleTimeType_L_P30

                    && s.CandleTimeType_O_P21 == p.CandleTimeType_O_P21
                    && s.CandleTimeType_C_P21 == p.CandleTimeType_C_P21
                    && s.CandleTimeType_H_P21 == p.CandleTimeType_H_P21
                    && s.CandleTimeType_L_P21 == p.CandleTimeType_L_P21

                    && s.CandleTimeType_O_P10 == p.CandleTimeType_O_P10
                    && s.CandleTimeType_C_P10 == p.CandleTimeType_C_P10
                    && s.CandleTimeType_H_P10 == p.CandleTimeType_H_P10
                    && s.CandleTimeType_L_P10 == p.CandleTimeType_L_P10

                    && s.CandleTimeType_O_P20 == p.CandleTimeType_O_P20
                    && s.CandleTimeType_C_P20 == p.CandleTimeType_C_P20
                    && s.CandleTimeType_H_P20 == p.CandleTimeType_H_P20
                    && s.CandleTimeType_L_P20 == p.CandleTimeType_L_P20

                    && s.CandleSizeType_B_P32 == p.CandleSizeType_B_P32
                    && s.CandleSizeType_B_P31 == p.CandleSizeType_B_P31
                    && s.CandleSizeType_B_P30 == p.CandleSizeType_B_P30

                    && s.CandleSizeType_B_P21 == p.CandleSizeType_B_P21
                    && s.CandleSizeType_B_P10 == p.CandleSizeType_B_P10
                    && s.CandleSizeType_B_P20 == p.CandleSizeType_B_P20

                    && s.CandleSizeType_T_P32 == p.CandleSizeType_T_P32
                    && s.CandleSizeType_T_P31 == p.CandleSizeType_T_P31
                    && s.CandleSizeType_T_P30 == p.CandleSizeType_T_P30

                    && s.CandleSizeType_T_P21 == p.CandleSizeType_T_P21
                    && s.CandleSizeType_T_P10 == p.CandleSizeType_T_P10
                    && s.CandleSizeType_T_P20 == p.CandleSizeType_T_P20                   
                    )
                {                    
                    list.Add(p);
                }
            }
            return list;
        }

        public List<CandlePatternData> GetMatchPatterns3(CandlePatternData s)
        {
            var list = new List<CandlePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT && s.EndDT == p.EndDT)
                    continue;

                if (s.Product != p.Product) continue;
                if (s.Item != p.Item) continue;
                if (s.TimeInterval != p.TimeInterval) continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    && s.PlusMinusType_P2 == p.PlusMinusType_P2
                    && s.PlusMinusType_P1 == p.PlusMinusType_P1
                    && s.PlusMinusType_P0 == p.PlusMinusType_P0
                    && s.CandleSpaceType_P2 == p.CandleSpaceType_P2
                    && s.CandleSpaceType_P1 == p.CandleSpaceType_P1
                    && s.CandleSpaceType_P0 == p.CandleSpaceType_P0
                    && s.CandleTimeType_O_P21 == p.CandleTimeType_O_P21
                    && s.CandleTimeType_C_P21 == p.CandleTimeType_C_P21
                    && s.CandleTimeType_H_P21 == p.CandleTimeType_H_P21
                    && s.CandleTimeType_L_P21 == p.CandleTimeType_L_P21
                    && s.CandleTimeType_O_P10 == p.CandleTimeType_O_P10
                    && s.CandleTimeType_C_P10 == p.CandleTimeType_C_P10
                    && s.CandleTimeType_H_P10 == p.CandleTimeType_H_P10
                    && s.CandleTimeType_L_P10 == p.CandleTimeType_L_P10
                    && s.CandleTimeType_O_P20 == p.CandleTimeType_O_P20
                    && s.CandleTimeType_C_P20 == p.CandleTimeType_C_P20
                    && s.CandleTimeType_H_P20 == p.CandleTimeType_H_P20
                    && s.CandleTimeType_L_P20 == p.CandleTimeType_L_P20
                    && s.CandleSizeType_B_P21 == p.CandleSizeType_B_P21
                    && s.CandleSizeType_B_P10 == p.CandleSizeType_B_P10
                    && s.CandleSizeType_B_P20 == p.CandleSizeType_B_P20
                    && s.CandleSizeType_T_P21 == p.CandleSizeType_T_P21
                    && s.CandleSizeType_T_P10 == p.CandleSizeType_T_P10
                    && s.CandleSizeType_T_P20 == p.CandleSizeType_T_P20
                    )
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public List<CandlePatternData> GetMatchPatterns2(CandlePatternData s)
        {
            var list = new List<CandlePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT && s.EndDT == p.EndDT)
                    continue;

                if (s.Product != p.Product) continue;
                if (s.Item != p.Item) continue;
                if (s.TimeInterval != p.TimeInterval) continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product && s.Item == p.Item
                    && s.PlusMinusType_P1 == p.PlusMinusType_P1
                    && s.PlusMinusType_P0 == p.PlusMinusType_P0
                    && s.CandleSpaceType_P1 == p.CandleSpaceType_P1
                    && s.CandleSpaceType_P0 == p.CandleSpaceType_P0
                    && s.CandleTimeType_O_P10 == p.CandleTimeType_O_P10
                    && s.CandleTimeType_C_P10 == p.CandleTimeType_C_P10
                    && s.CandleTimeType_H_P10 == p.CandleTimeType_H_P10
                    && s.CandleTimeType_L_P10 == p.CandleTimeType_L_P10
                    && s.CandleSizeType_B_P10 == p.CandleSizeType_B_P10
                    && s.CandleSizeType_T_P10 == p.CandleSizeType_T_P10
                    )
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}