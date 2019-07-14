using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Chakra.App.Events
{
    public delegate void AutoReloadDelegate(bool isAutoReload);

    public delegate void ManualReloadDelegate();

    public class MainFormToolBarEvents
    {
        private static MainFormToolBarEvents events = new MainFormToolBarEvents();
        public static MainFormToolBarEvents Instance
        {
            get
            {
                return events;
            }
        }

        public event AutoReloadDelegate AutoReloadHandler;
        public event ManualReloadDelegate ManualReloadHandler;

        public void OnAutoReloadHandler(bool isAutoReload)
        {
            if (AutoReloadHandler != null)
                AutoReloadHandler(isAutoReload);
        }
        public void OnManualReloadHandler()
        {
            if (ManualReloadHandler != null)
                ManualReloadHandler();
        }
    }
}
