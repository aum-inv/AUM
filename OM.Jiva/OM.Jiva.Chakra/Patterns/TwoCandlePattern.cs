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
    public class TwoCandlePattern
    { 
        public List<CandlePattern_Two> patterns = null;
        public void LoadPatternData(string product = "", string item = "")
        {
            CandlePattern_Two p = new CandlePattern_Two();
            p.Product = product; 
            p.Item = item;
            var entities =  p.Collect();

            patterns = entities.Cast<CandlePattern_Two>().ToList();
        }

        public List<CandlePattern_Two> GetMatchPatterns(CandlePattern_Two s)
        {
            var list = new List<CandlePattern_Two>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT && s.EndDT == p.EndDT)
                    continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product 
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