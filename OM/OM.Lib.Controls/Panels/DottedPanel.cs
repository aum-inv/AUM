using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OM.Lib.Controls.Panels
{
    public class DottedPanel : Panel
    {
        public DottedPanel()
        {
            this.Paint += Panel_Paint;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                      Color.WhiteSmoke, 1, ButtonBorderStyle.Dotted, // left
                      Color.WhiteSmoke, 1, ButtonBorderStyle.Dotted, // top
                      Color.WhiteSmoke, 1, ButtonBorderStyle.Dotted, // right
                      Color.WhiteSmoke, 1, ButtonBorderStyle.Dotted);// bottom
        }


    }
}
