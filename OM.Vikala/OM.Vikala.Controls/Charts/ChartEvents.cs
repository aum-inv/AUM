using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Vikala.Controls.Charts
{
    public delegate void ChangeChartScrollBarDelegate(object source, int changedValue);
    public delegate void ChangeChartTrackBarDelegate(object source, int changedValue);
    public class ChartEvents
    {
        public event ChangeChartScrollBarDelegate ChangeChartScrollBarHandler;

        public event ChangeChartTrackBarDelegate ChangeChartTrackBarHandler;

        public void OnChangeChartScrollBarHandler(object source, int changedValue)
        {
            if (ChangeChartScrollBarHandler != null)
                ChangeChartScrollBarHandler(source, changedValue);
        }

        public void OnChangeChartTrackBarHandler(object source, int changedValue)
        {
            if (ChangeChartTrackBarHandler != null)
                ChangeChartTrackBarHandler(source, changedValue);
        }
    }
}
