using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.PP.Chakra
{
    public class S_LineItemData : A_CLOSE
    {
        public S_LineItemData() { }

        public S_LineItemData(string itemCode, Single close1, DateTime dt)
        {
            base.ItemCode = itemCode;
            base.ClosePrice1 = close1;
            base.DTime = dt;
        }
        public S_LineItemData(string itemCode, Single close1, Single close2, DateTime dt)
        {
            base.ItemCode = itemCode;
            base.ClosePrice1 = close1;
            base.ClosePrice2 = close2;
            base.DTime = dt;
        }
        public S_LineItemData(string itemCode, Single close1, Single close2, Single close3, DateTime dt)
        {
            base.ItemCode = itemCode;
            base.ClosePrice1 = close1;
            base.ClosePrice2 = close2;
            base.ClosePrice3 = close3;
            base.DTime = dt;
        }
        public S_LineItemData(string itemCode, Single close1, Single close2, Single close3, Single close4, DateTime dt)
        {
            base.ItemCode = itemCode;
            base.ClosePrice1 = close1;
            base.ClosePrice2 = close2;
            base.ClosePrice3 = close3;
            base.ClosePrice4 = close4;
            base.DTime = dt;
        }
        List<S_LineItemData> sourceItems;
        public S_LineItemData(
             string itemCode
           , List<S_LineItemData> sourceItems)
        {
            base.ItemCode = itemCode;
            this.sourceItems = sourceItems;
            calculateAvg();
        }
        private void calculateAvg()
        {
            if (this.sourceItems == null) return;

            base.ClosePrice1 = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice1), RoundLength);
            base.ClosePrice2 = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice2), RoundLength);
            base.ClosePrice3 = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice3), RoundLength);
            base.ClosePrice4 = (Single)Math.Round(sourceItems.Average(t => t.ClosePrice4), RoundLength);
            base.DTime = sourceItems.Max(t => t.DTime);            
        }
    }
}
