using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.App.Events
{
    public delegate void InvestmentPlanSelectedChangedDelegae(int index);
    public class InvestmentPlanSelectedEvents
    {
        private static InvestmentPlanSelectedEvents eventInstance = new InvestmentPlanSelectedEvents();
        public static InvestmentPlanSelectedEvents Instance
        {
            get
            {
                return eventInstance;
            }
        }

        public event InvestmentPlanSelectedChangedDelegae InvestmentPlanSelectedChangedHandler;

        public void OnInvestmentPlanSelectedChangedHandler(int selectedIndex)
        {
            if (InvestmentPlanSelectedChangedHandler != null)
                InvestmentPlanSelectedChangedHandler(selectedIndex);
        }
    }
}
