using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Mantra.Chakra.App
{
    public partial class TradingDiaryForm : Form
    {
        public TradingDiaryForm()
        {
            InitializeComponent();

            this.KeyDown += TradingDiaryForm_KeyDown;
        }

        private void TradingDiaryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    if (p != null)
                    {
                        p.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Image = Clipboard.GetImage();
                    }
                  
                }
            }
        }

        PictureBox p = null;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            p = pictureBox1;

            p.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            p = pictureBox2;

            p.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
            p = null;            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
            p = null;
        }
    }
}
