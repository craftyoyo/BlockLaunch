using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace BlockLaunch.UI.Controls
{
    public class InfoProgressBar : MetroProgressBar
    {
        public string ProgressText { get; set; }
        public Color ForeColorProgress { get; set; }

        private double ProgressBarWidth
        {
            get { return (((double)Value / Maximum) * ClientRectangle.Width); }
        }

        private  void DrawProgressContinuous(Graphics graphics)
        {
            graphics.FillRectangle(MetroPaint.GetStyleBrush(Style), 0, 0, (int)ProgressBarWidth, ClientRectangle.Height);
        }

        protected override void OnPaintForeground(PaintEventArgs e)
        {
            if (ProgressBarStyle == ProgressBarStyle.Continuous)
            {            
                DrawProgressContinuous(e.Graphics);
            }
            else if (ProgressBarStyle == ProgressBarStyle.Blocks)
            {
               throw new NotSupportedException("This style is not supported!");
            }
            else if (ProgressBarStyle == ProgressBarStyle.Marquee)
            {
                throw new NotSupportedException("This style is not supported!");
            }
            DrawProgressText(e.Graphics);
            using (var p = new Pen(MetroPaint.BorderColor.ProgressBar.Normal(Theme)))
            {
                var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(p, borderRect);
            }
            OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }

        private void DrawProgressText(IDeviceContext graphics)
        {
            if (HideProgressText) return;
            TextRenderer.DrawText(graphics, ProgressText, MetroFonts.ProgressBar(FontSize, FontWeight), ClientRectangle, ForeColorProgress, MetroPaint.GetTextFormatFlags(TextAlign));
        }
    }
}
