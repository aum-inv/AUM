using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Controls.Charts
{
    public delegate void ChangeChartScrollBarDelegate(object source, int changedValue);
    public delegate void ChangeChartTrackBarDelegate(object source, int changedValue);
    public delegate void ChangeChartMouseMoveDelegate(object sender, MouseEventArgs e);
    public class ChartEvents
    {
        public event ChangeChartScrollBarDelegate ChangeChartScrollBarHandler;

        public event ChangeChartTrackBarDelegate ChangeChartTrackBarHandler;

        public event ChangeChartMouseMoveDelegate ChangeChartMouseMoveHandler;

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

        public void OnChangeChartMouseMoveHandler(object source, MouseEventArgs changedValue)
        {
            if (ChangeChartTrackBarHandler != null)
                ChangeChartMouseMoveHandler(source, changedValue);
        }
    }
}
