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
    public class ForceCandlePattern
    {       
        public List<CandleForcePatternData> patterns = null;
        public void LoadPatternData(string product = "", string item = "")
        {
            CandleForcePatternData p = new CandleForcePatternData();
            p.Product = product;
            p.Item = item;
            var entities =  p.Collect();

            patterns = entities.Cast<CandleForcePatternData>().ToList();
        }

        public List<CandleForcePatternData> GetMatchPatterns4(CandleForcePatternData s)
        {
            var list = new List<CandleForcePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT)
                    continue;
                
                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    && s.GForceType_P3 == p.GForceType_P3
                    && s.GForceType_P2 == p.GForceType_P2
                    && s.GForceType_P1 == p.GForceType_P1
                    && s.GForceType_P0 == p.GForceType_P0

                    && s.EForceType_OC_P3 == p.EForceType_OC_P3
                    && s.EForceType_OC_P2 == p.EForceType_OC_P2
                    && s.EForceType_OC_P1 == p.EForceType_OC_P1
                    && s.EForceType_OC_P0 == p.EForceType_OC_P0
                    && s.EForceType_CC_P3 == p.EForceType_CC_P3
                    && s.EForceType_CC_P2 == p.EForceType_CC_P2
                    && s.EForceType_CC_P1 == p.EForceType_CC_P1
                    && s.EForceType_CC_P0 == p.EForceType_CC_P0

                    && s.SForceType_O_P3 == p.SForceType_O_P3
                    && s.SForceType_O_P2 == p.SForceType_O_P2
                    && s.SForceType_O_P1 == p.SForceType_O_P1
                    && s.SForceType_O_P0 == p.SForceType_O_P0
                    && s.SForceType_H_P3 == p.SForceType_H_P3
                    && s.SForceType_H_P2 == p.SForceType_H_P2
                    && s.SForceType_H_P1 == p.SForceType_H_P1
                    && s.SForceType_H_P0 == p.SForceType_H_P0
                    && s.SForceType_L_P3 == p.SForceType_L_P3
                    && s.SForceType_L_P2 == p.SForceType_L_P2
                    && s.SForceType_L_P1 == p.SForceType_L_P1
                    && s.SForceType_L_P0 == p.SForceType_L_P0
                    && s.SForceType_C_P3 == p.SForceType_C_P3
                    && s.SForceType_C_P2 == p.SForceType_C_P2
                    && s.SForceType_C_P1 == p.SForceType_C_P1
                    && s.SForceType_C_P0 == p.SForceType_C_P0

                    && s.WForceType_T_P3 == p.WForceType_T_P3
                    && s.WForceType_T_P2 == p.WForceType_T_P2
                    && s.WForceType_T_P1 == p.WForceType_T_P1
                    && s.WForceType_T_P0 == p.WForceType_T_P0
                    && s.WForceType_H_P3 == p.WForceType_H_P3
                    && s.WForceType_H_P2 == p.WForceType_H_P2
                    && s.WForceType_H_P1 == p.WForceType_H_P1
                    && s.WForceType_H_P0 == p.WForceType_H_P0
                    && s.WForceType_B_P3 == p.WForceType_B_P3
                    && s.WForceType_B_P2 == p.WForceType_B_P2
                    && s.WForceType_B_P1 == p.WForceType_B_P1
                    && s.WForceType_B_P0 == p.WForceType_B_P0
                    && s.WForceType_L_P3 == p.WForceType_L_P3
                    && s.WForceType_L_P2 == p.WForceType_L_P2
                    && s.WForceType_L_P1 == p.WForceType_L_P1
                    && s.WForceType_L_P0 == p.WForceType_L_P0

                    )
                {                    
                    list.Add(p);
                }
            }
            return list;
        }

        public List<CandleForcePatternData> GetMatchPatterns3(CandleForcePatternData s)
        {
            var list = new List<CandleForcePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT)
                    continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    //&& s.GForceType_P3 == p.GForceType_P3
                    && s.GForceType_P2 == p.GForceType_P2
                    && s.GForceType_P1 == p.GForceType_P1
                    && s.GForceType_P0 == p.GForceType_P0

                    //&& s.EForceType_OC_P3 == p.EForceType_OC_P3
                    && s.EForceType_OC_P2 == p.EForceType_OC_P2
                    && s.EForceType_OC_P1 == p.EForceType_OC_P1
                    && s.EForceType_OC_P0 == p.EForceType_OC_P0
                    //&& s.EForceType_CC_P3 == p.EForceType_CC_P3
                    && s.EForceType_CC_P2 == p.EForceType_CC_P2
                    && s.EForceType_CC_P1 == p.EForceType_CC_P1
                    && s.EForceType_CC_P0 == p.EForceType_CC_P0

                    //&& s.SForceType_O_P3 == p.SForceType_O_P3
                    && s.SForceType_O_P2 == p.SForceType_O_P2
                    && s.SForceType_O_P1 == p.SForceType_O_P1
                    && s.SForceType_O_P0 == p.SForceType_O_P0
                    //&& s.SForceType_H_P3 == p.SForceType_H_P3
                    && s.SForceType_H_P2 == p.SForceType_H_P2
                    && s.SForceType_H_P1 == p.SForceType_H_P1
                    && s.SForceType_H_P0 == p.SForceType_H_P0
                    //&& s.SForceType_L_P3 == p.SForceType_L_P3
                    && s.SForceType_L_P2 == p.SForceType_L_P2
                    && s.SForceType_L_P1 == p.SForceType_L_P1
                    && s.SForceType_L_P0 == p.SForceType_L_P0
                    //&& s.SForceType_C_P3 == p.SForceType_C_P3
                    && s.SForceType_C_P2 == p.SForceType_C_P2
                    && s.SForceType_C_P1 == p.SForceType_C_P1
                    && s.SForceType_C_P0 == p.SForceType_C_P0

                    //&& s.WForceType_T_P3 == p.WForceType_T_P3
                    && s.WForceType_T_P2 == p.WForceType_T_P2
                    && s.WForceType_T_P1 == p.WForceType_T_P1
                    && s.WForceType_T_P0 == p.WForceType_T_P0
                    //&& s.WForceType_H_P3 == p.WForceType_H_P3
                    && s.WForceType_H_P2 == p.WForceType_H_P2
                    && s.WForceType_H_P1 == p.WForceType_H_P1
                    && s.WForceType_H_P0 == p.WForceType_H_P0
                    //&& s.WForceType_B_P3 == p.WForceType_B_P3
                    && s.WForceType_B_P2 == p.WForceType_B_P2
                    && s.WForceType_B_P1 == p.WForceType_B_P1
                    && s.WForceType_B_P0 == p.WForceType_B_P0
                    //&& s.WForceType_L_P3 == p.WForceType_L_P3
                    && s.WForceType_L_P2 == p.WForceType_L_P2
                    && s.WForceType_L_P1 == p.WForceType_L_P1
                    && s.WForceType_L_P0 == p.WForceType_L_P0

                    )
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public List<CandleForcePatternData> GetMatchPatterns2(CandleForcePatternData s)
        {
            var list = new List<CandleForcePatternData>();
            foreach (var p in patterns)
            {
                if (s.Product == p.Product && s.Item == p.Item && s.StartDT == p.StartDT)
                    continue;

                if (s.TimeInterval < 20 && p.TimeInterval >= 20) continue;
                if (s.TimeInterval == 20 && p.TimeInterval != 20) continue;
                if (s.TimeInterval == 30 && p.TimeInterval != 30) continue;

                if (
                    s.Product == p.Product
                    //&& s.GForceType_P3 == p.GForceType_P3
                    //&& s.GForceType_P2 == p.GForceType_P2
                    && s.GForceType_P1 == p.GForceType_P1
                    && s.GForceType_P0 == p.GForceType_P0

                    //&& s.EForceType_OC_P3 == p.EForceType_OC_P3
                    //&& s.EForceType_OC_P2 == p.EForceType_OC_P2
                    && s.EForceType_OC_P1 == p.EForceType_OC_P1
                    && s.EForceType_OC_P0 == p.EForceType_OC_P0
                    // && s.EForceType_CC_P3 == p.EForceType_CC_P3
                    //&& s.EForceType_CC_P2 == p.EForceType_CC_P2
                    && s.EForceType_CC_P1 == p.EForceType_CC_P1
                    && s.EForceType_CC_P0 == p.EForceType_CC_P0

                    //&& s.SForceType_O_P3 == p.SForceType_O_P3
                    //&& s.SForceType_O_P2 == p.SForceType_O_P2
                    && s.SForceType_O_P1 == p.SForceType_O_P1
                    && s.SForceType_O_P0 == p.SForceType_O_P0
                    //&& s.SForceType_H_P3 == p.SForceType_H_P3
                    //&& s.SForceType_H_P2 == p.SForceType_H_P2
                    && s.SForceType_H_P1 == p.SForceType_H_P1
                    && s.SForceType_H_P0 == p.SForceType_H_P0
                    //&& s.SForceType_L_P3 == p.SForceType_L_P3
                    //&& s.SForceType_L_P2 == p.SForceType_L_P2
                    && s.SForceType_L_P1 == p.SForceType_L_P1
                    && s.SForceType_L_P0 == p.SForceType_L_P0
                    //&& s.SForceType_C_P3 == p.SForceType_C_P3
                    //&& s.SForceType_C_P2 == p.SForceType_C_P2
                    && s.SForceType_C_P1 == p.SForceType_C_P1
                    && s.SForceType_C_P0 == p.SForceType_C_P0

                    //&& s.WForceType_T_P3 == p.WForceType_T_P3
                    //&& s.WForceType_T_P2 == p.WForceType_T_P2
                    && s.WForceType_T_P1 == p.WForceType_T_P1
                    && s.WForceType_T_P0 == p.WForceType_T_P0
                    //&& s.WForceType_H_P3 == p.WForceType_H_P3
                    //&& s.WForceType_H_P2 == p.WForceType_H_P2
                    && s.WForceType_H_P1 == p.WForceType_H_P1
                    && s.WForceType_H_P0 == p.WForceType_H_P0
                    //&& s.WForceType_B_P3 == p.WForceType_B_P3
                    //&& s.WForceType_B_P2 == p.WForceType_B_P2
                    && s.WForceType_B_P1 == p.WForceType_B_P1
                    && s.WForceType_B_P0 == p.WForceType_B_P0
                    //&& s.WForceType_L_P3 == p.WForceType_L_P3
                    //&& s.WForceType_L_P2 == p.WForceType_L_P2
                    && s.WForceType_L_P1 == p.WForceType_L_P1
                    && s.WForceType_L_P0 == p.WForceType_L_P0

                    )
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}