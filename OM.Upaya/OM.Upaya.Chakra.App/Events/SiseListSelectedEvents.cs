using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Upaya.Chakra.App.Events
{
    public delegate void SiseListSelectedChangedDelegae(int selectedIndex, SmartCandleData data);
    public class SiseListSelectedEvents
    {
        private static SiseListSelectedEvents eventInstance = new SiseListSelectedEvents();
        public static SiseListSelectedEvents Instance
        {
            get
            {
                return eventInstance;
            }
        }

        public event SiseListSelectedChangedDelegae SiseListSelectedChangedHandler;

        public void OnSiseListSelectedChangedHandler(int selectedIndex, SmartCandleData selectedCandle)
        {
            if (SiseListSelectedChangedHandler != null)
                SiseListSelectedChangedHandler(selectedIndex, selectedCandle);
        }
    }
}
