using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlockLaunch.UI.Controls
{
    public enum ProgressMode
    {
        CustomText,
        Percentage
    }

    public class InfoProgressBar : ProgressBar
    {
        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        private Brush _defaultTextColor = Brushes.Black;
        private Font _defaultFont = new Font(FontFamily.GenericSerif, 10);

        public ProgressMode TextProgressMode { get; set; }
        public string CustomText { get; set; }

        public Font TextFont
        {
            get { return _defaultFont; }
            set { _defaultFont = value; }
        }

        public Brush TextColor
        {
            get { return _defaultTextColor; }
            set { _defaultTextColor = value; }
        }

        public InfoProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rect = ClientRectangle;
            var g = e.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);
            if (Value > 0 && Value <= Maximum)
            {
                var clip = new Rectangle(rect.X, rect.Y, (int)(((float)Value / (float)Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }
            var txt = TextProgressMode == ProgressMode.Percentage ? Value + " %" : CustomText;
            var drawFormat = new StringFormat {Alignment = StringAlignment.Center};
            g.DrawString(txt, TextFont, TextColor, rect, drawFormat);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(Handle, "", "");
            base.OnHandleCreated(e);
        }
    }
}
