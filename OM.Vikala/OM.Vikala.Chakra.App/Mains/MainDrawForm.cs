using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
    public partial class MainDrawForm : Form
    {
        Bitmap bitmap;
        public MainDrawForm(Bitmap bitmap)
        {
            InitializeComponent();
            this.bitmap = bitmap;

            this.Load += MainDrawForm_Load;
        }

        private void MainDrawForm_Load(object sender, EventArgs e)
        {
            picCanvas.Image = bitmap;

            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;
        }

        // The "size" of an object for mouse over purposes.
        private const int object_radius = 3;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        private const int over_dist_squared = object_radius * object_radius;

        // The points that make up the line segments.
        //private List<Point> Pt1 = new List<Point>();
        //private List<Point> Pt2 = new List<Point>();
        //private List<Pen> PenList = new List<Pen>();

        // Points for the new line.
        private bool IsDrawing = false;
        private Point NewPt1, NewPt2;

        private Pen selectedPen = new Pen(Color.Red, 1.0f);
        private string selectedDrawType = "L";
        private List<DrawedInfo> drawedInfos = new List<DrawedInfo>();
        string dashStyle = "Solid";
        string widthStyle = "1.0";

        private bool IsCanDraw = false;
        private void picCanvas_MouseMove_NotDown(object sender, MouseEventArgs e)
        {
            Cursor new_cursor = Cursors.Cross;

            // See what we're over.
            Point hit_point;
            int segment_number;

            if (MouseIsOverEndpoint(e.Location, out segment_number, out hit_point))
                new_cursor = Cursors.Arrow;
            else if (MouseIsOverSegment(e.Location, out segment_number))
                new_cursor = Cursors.Hand;

            // Set the new cursor.
            if (picCanvas.Cursor != new_cursor)
                picCanvas.Cursor = new_cursor;
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Point hit_point;
            int segment_number;

            if (MouseIsOverEndpoint(e.Location, out segment_number, out hit_point))
            {
                // Start moving this end point.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDown;
                picCanvas.MouseMove += picCanvas_MouseMove_MovingEndPoint;
                picCanvas.MouseUp += picCanvas_MouseUp_MovingEndPoint;

                // Remember the segment number.
                MovingSegment = segment_number;

                // See if we're moving the start end point.
                MovingStartEndPoint = drawedInfos[segment_number].pt1.Equals(hit_point);

                // Remember the offset from the mouse to the point.
                OffsetX = hit_point.X - e.X;
                OffsetY = hit_point.Y - e.Y;
            }
            else if (MouseIsOverSegment(e.Location, out segment_number))
            {
                // Start moving this segment.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDown;
                picCanvas.MouseMove += picCanvas_MouseMove_MovingSegment;
                picCanvas.MouseUp += picCanvas_MouseUp_MovingSegment;

                // Remember the segment number.
                MovingSegment = segment_number;

                // Remember the offset from the mouse to the segment's first point.
                OffsetX = drawedInfos[segment_number].pt1.X - e.X;
                OffsetY = drawedInfos[segment_number].pt1.Y - e.Y;
            }
            else
            {
                // Start drawing a new segment.
                picCanvas.MouseMove -= picCanvas_MouseMove_NotDown;
                picCanvas.MouseMove += picCanvas_MouseMove_Drawing;
                picCanvas.MouseUp += picCanvas_MouseUp_Drawing;

                IsDrawing = true;
                NewPt1 = new Point(e.X, e.Y);
                NewPt2 = new Point(e.X, e.Y);
            }
        }

        #region "Drawing"

        // We're drawing a new segment.
        private void picCanvas_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            // Save the new point.
            NewPt2 = new Point(e.X, e.Y);

            // Redraw.
            picCanvas.Refresh();
        }

        // Stop drawing.
        private void picCanvas_MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            IsDrawing = false;

            // Reset the event handlers.
            picCanvas.MouseMove -= picCanvas_MouseMove_Drawing;
            picCanvas.MouseMove += picCanvas_MouseMove_NotDown;
            picCanvas.MouseUp -= picCanvas_MouseUp_Drawing;

            Pen p = new Pen(selectedPen.Color, selectedPen.Width);
            p.DashStyle = selectedPen.DashStyle;
            if (IsCanDraw)
                drawedInfos.Add(new DrawedInfo(NewPt1, NewPt2, p, selectedDrawType, tstb.Text));
            // Redraw.
            picCanvas.Refresh();
        }

        #endregion // Drawing

        #region "Moving End Point"

        // The segment we're moving or the segment whose end point we're moving.
        private int MovingSegment = -1;

        // The end point we're moving.
        private bool MovingStartEndPoint = false;

        // The offset from the mouse to the object being moved.
        private int OffsetX, OffsetY;

        // We're moving an end point.
        private void picCanvas_MouseMove_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Move the point to its new location.
            if (MovingStartEndPoint)
                drawedInfos[MovingSegment].pt1 =
                    new Point(e.X + OffsetX, e.Y + OffsetY);
            else
                drawedInfos[MovingSegment].pt2 =
                    new Point(e.X + OffsetX, e.Y + OffsetY);

            // Redraw.
            picCanvas.Refresh();
        }

        // Stop moving the end point.
        private void picCanvas_MouseUp_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            picCanvas.MouseMove += picCanvas_MouseMove_NotDown;
            picCanvas.MouseMove -= picCanvas_MouseMove_MovingEndPoint;
            picCanvas.MouseUp -= picCanvas_MouseUp_MovingEndPoint;

            // Redraw.
            picCanvas.Refresh();
        }

        #endregion // Moving End Point

        #region "Moving Segment"

        // We're moving a segment.
        private void picCanvas_MouseMove_MovingSegment(object sender, MouseEventArgs e)
        {
            // See how far the first point will move.
            int new_x1 = e.X + OffsetX;
            int new_y1 = e.Y + OffsetY;

            int dx = new_x1 - drawedInfos[MovingSegment].pt1.X;
            int dy = new_y1 - drawedInfos[MovingSegment].pt1.Y;

            if (dx == 0 && dy == 0) return;

            // Move the segment to its new location.
            drawedInfos[MovingSegment].pt1 = new Point(new_x1, new_y1);
            drawedInfos[MovingSegment].pt2 = new Point(
                drawedInfos[MovingSegment].pt2.X + dx,
                drawedInfos[MovingSegment].pt2.Y + dy);

            // Redraw.
            picCanvas.Refresh();
        }

        // Stop moving the segment.
        private void picCanvas_MouseUp_MovingSegment(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            picCanvas.MouseMove += picCanvas_MouseMove_NotDown;
            picCanvas.MouseMove -= picCanvas_MouseMove_MovingSegment;
            picCanvas.MouseUp -= picCanvas_MouseUp_MovingSegment;

            picCanvas.Refresh();
        }

        #endregion // Moving End Point

        // See if the mouse is over an end point.
        private bool MouseIsOverEndpoint(Point mouse_pt, out int segment_number, out Point hit_pt)
        {
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                // Check the starting point.
                if (FindDistanceToPointSquared(mouse_pt, drawedInfos[i].pt1) < over_dist_squared)
                {
                    // We're over this point.
                    segment_number = i;
                    hit_pt = drawedInfos[i].pt1;
                    return true;
                }

                // Check the end point.
                if (FindDistanceToPointSquared(mouse_pt, drawedInfos[i].pt2) < over_dist_squared)
                {
                    // We're over this point.
                    segment_number = i;
                    hit_pt = drawedInfos[i].pt2;
                    return true;
                }
            }

            segment_number = -1;
            hit_pt = new Point(-1, -1);
            return false;
        }

        // See if the mouse is over a line segment.
        private bool MouseIsOverSegment(Point mouse_pt, out int segment_number)
        {
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                // See if we're over the segment.
                PointF closest;
                if (FindDistanceToSegmentSquared(
                    mouse_pt
                    , drawedInfos[i].pt1
                    , drawedInfos[i].pt2
                    , out closest)
                        < over_dist_squared)
                {
                    // We're over this segment.
                    segment_number = i;
                    return true;
                }
            }

            segment_number = -1;
            return false;
        }

        // Calculate the distance squared between two points.
        private int FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            int dx = pt1.X - pt2.X;
            int dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        private void MainDrawForm_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void MainDrawForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MainDrawForm_KeyUp(object sender, KeyEventArgs e)
        {            
            if (MovingSegment < 0) return;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("선택된 도형 삭제.", "삭제하시겠습니까?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    drawedInfos.RemoveAt(MovingSegment);
                }
            }
            picCanvas.Refresh();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pnlContent.Width, pnlContent.Height);
                pnlContent.DrawToBitmap(bmp, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pnlContent.Width, pnlContent.Height);
                pnlContent.DrawToBitmap(bmp, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

                Clipboard.SetImage(bmp);

                MessageBox.Show("저장되었습니다.");
            }
            catch(Exception ex)
            {
            }           
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {               
               pd.Print();
            }
            pd.Dispose();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(pnlContent.Width, pnlContent.Height);
            pnlContent.DrawToBitmap(bmp, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

            e.Graphics.DrawImage(bmp, 0, 0);
        }
        private double FindDistanceToSegmentSquared(Point pt, Point p1, Point p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return dx * dx + dy * dy;
            }

            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return dx * dx + dy * dy;
        }

        // Draw the lines.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {            
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "L") continue;
                e.Graphics.DrawLine(drawedInfos[i].pen, drawedInfos[i].pt1, drawedInfos[i].pt2);
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "L") continue;
                var pt = drawedInfos[i].pt1;                
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "L") continue;
                var pt = drawedInfos[i].pt2;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }
            
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "R") continue;
                e.Graphics.DrawRectangle(drawedInfos[i].pen
                    , drawedInfos[i].pt1.X
                    , drawedInfos[i].pt1.Y
                    , (drawedInfos[i].pt2.X - drawedInfos[i].pt1.X)
                    , (drawedInfos[i].pt2.Y - drawedInfos[i].pt1.Y));
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "R") continue;
                var pt = drawedInfos[i].pt1;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "R") continue;
                var pt = drawedInfos[i].pt2;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }


            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "C") continue;
                e.Graphics.DrawEllipse(drawedInfos[i].pen
                    , drawedInfos[i].pt1.X
                    , drawedInfos[i].pt1.Y
                    , (drawedInfos[i].pt2.X - drawedInfos[i].pt1.X)
                    , (drawedInfos[i].pt2.Y - drawedInfos[i].pt1.Y));
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "C") continue;
                var pt = drawedInfos[i].pt1;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "C") continue;
                var pt = drawedInfos[i].pt2;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }

            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "T") continue;
                e.Graphics.DrawString(drawedInfos[i].text
                    , this.Font
                    , Brushes.Black
                    , drawedInfos[i].pt1.X
                    , drawedInfos[i].pt1.Y);
            }
            for (int i = 0; i < drawedInfos.Count; i++)
            {
                if (drawedInfos[i].type != "T") continue;
                var pt = drawedInfos[i].pt1;
                Rectangle rect = new Rectangle(
                    pt.X - object_radius, pt.Y - object_radius,
                    2 * object_radius + 1, 2 * object_radius + 1);
                e.Graphics.FillEllipse(Brushes.White, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);
            }

            if (IsDrawing && IsCanDraw)
            {
                if (selectedDrawType == "L")
                {
                   e.Graphics.DrawLine(selectedPen, NewPt1, NewPt2);
                }

                if (selectedDrawType == "R")
                {
                    e.Graphics.DrawRectangle(selectedPen
                        , NewPt1.X
                        , NewPt1.Y
                        , (NewPt2.X - NewPt1.X)
                        , (NewPt2.Y - NewPt1.Y));
                }

                if (selectedDrawType == "C")
                {
                    e.Graphics.DrawEllipse(selectedPen
                        , NewPt1.X
                        , NewPt1.Y
                        , (NewPt2.X - NewPt1.X)
                        , (NewPt2.Y - NewPt1.Y));
                }

                if (selectedDrawType == "T")
                {
                    e.Graphics.DrawString(tstb.Text
                        , this.Font
                        , Brushes.Black
                        , NewPt1.X
                        , NewPt1.Y);
                }
            }
        }

        private void DashStyle_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;
            dashStyle = selectedItem.Text;

            foreach (ToolStripItem item in tsddb_DashStyle.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu_item = item as ToolStripMenuItem;

                    if (selectedItem == menu_item) selectedItem.Checked = true;
                    else menu_item.Checked = false;
                }
            }

            var tDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (dashStyle == "Dash") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (dashStyle == "Dot") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (dashStyle == "DashDot") tDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            var width = Convert.ToSingle(widthStyle);

            selectedPen.DashStyle = tDashStyle;
            selectedPen.Width = Convert.ToSingle(width);
        }

        private void WidthStyle_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;
            widthStyle = selectedItem.Text;

            foreach (ToolStripItem item in tsddb_WidthStyle.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu_item = item as ToolStripMenuItem;

                    if (selectedItem == menu_item) selectedItem.Checked = true;
                    else menu_item.Checked = false;
                }
            }

            var tDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (dashStyle == "Dash") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (dashStyle == "Dot") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (dashStyle == "DashDot") tDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            var width = Convert.ToSingle(widthStyle);

            selectedPen.DashStyle = tDashStyle;
            selectedPen.Width = Convert.ToSingle(width);
        }

        private void tsb_Cursor_Click(object sender, EventArgs e)
        {
            IsCanDraw = false;
        }
       

        private void tsb_Pen_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;

            IsCanDraw = true;

            tsb_Cursor.Checked =
            tsb_L_Red.Checked =
            tsb_L_Blue.Checked =
            tsb_L_Black.Checked =
            tsb_L_Magenta.Checked =
            tsb_R_Red.Checked =
            tsb_R_Blue.Checked =
            tsb_R_Black.Checked =
            tsb_R_Magenta.Checked =
            tsb_C_Red.Checked =
            tsb_C_Blue.Checked =
            tsb_C_Black.Checked =
            tsb_C_Magenta.Checked =
            tsb_T_Black.Checked = false;

            var tDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (dashStyle == "Dash") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (dashStyle == "Dot") tDashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (dashStyle == "DashDot") tDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            var width = Convert.ToSingle(widthStyle);

            selectedPen = new Pen(tsb.ForeColor, width);

            selectedPen.DashStyle = tDashStyle;

            if (tsb.Name.IndexOf("_L_") > 0)
                selectedDrawType = "L";
            else if (tsb.Name.IndexOf("_R_") > 0)
                selectedDrawType = "R";
            else if (tsb.Name.IndexOf("_C_") > 0)
                selectedDrawType = "C";
            else if (tsb.Name.IndexOf("_T_") > 0)
                selectedDrawType = "T";

            tsb.Checked = true;
        }

        private void tsb_Remove_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;

            string type = tsb.Tag.ToString();

            for (int i = drawedInfos.Count - 1; i >= 0; i--)
            {
                var d = drawedInfos[i];
                if (type == "A")
                {
                    drawedInfos.RemoveAt(i);
                    continue;
                }
                else if (d.type == type)
                {
                    drawedInfos.RemoveAt(i);
                }
            }           

            picCanvas.Refresh();
        }
    }
    class DrawedInfo
    {
        public DrawedInfo()
        { }

        public DrawedInfo(Point pt1, Point pt2, Pen pen, string type, string text)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
            this.pen = pen;
            this.type = type;
            this.text = text;
        }
        public Point pt1 = new Point(0, 0);
        public Point pt2 = new Point(0, 0);
        public Pen pen = Pens.Red;
        public string type = "L";
        public string text = "";

    }
}
