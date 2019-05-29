using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    /// <summary>
    /// 천지인 데이터
    /// </summary>
    public class T_EightRuleItemData : S_CandleItemData, ITransform
    {
        private S_CandleItemData sourceData = null;

        public T_EightRuleItemData(S_CandleItemData sourceData)
        {
            this.sourceData = sourceData;
        }
     
        private string t_s = 0;
        private string t_l = 0;
        private string t_h = 0;

        public string T_S { get { return t_s; } }
        public string T_H { get { return t_h; } }
        public string T_L { get { return t_l; } }
        
        
        public S_CandleItemData SourceData { get { return sourceData; } }

        private EightRuleTypeEnum eightype = EightRuleTypeEnum.없음;

        public EightRuleTypeEnum EightRuleType { get { return eightype; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Transform()
        {
            try
            {
                if (sourceData != null)
                {
                    ItemCode = sourceData.ItemCode;

                    OpenPrice = sourceData.OpenPrice;
                    HighPrice = sourceData.HighPrice;
                    LowPrice = sourceData.LowPrice;
                    ClosePrice = sourceData.ClosePrice;
                    DTime = sourceData.DTime;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}