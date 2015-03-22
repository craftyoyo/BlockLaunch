using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlockLaunch.Classes.JSON;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework.Interfaces;

namespace BlockLaunch.Classes
{
    public class ThemeHelper
    {
        public static Color ContrastColor(Color color)
        {
            var a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            var d = a < 0.5 ? 0 : 255;
            return Color.FromArgb(d, d, d);
        }

        [Obsolete("setBackColor is unused. Please remove this argument!")]
        public static void ApplyTheme(Control parent, Config config, bool setBackColor)
        {
            ApplyTheme(parent, config);
        }

        public static void ApplyTheme(Control parent, Config config)
        {
            var theme = (MetroThemeStyle)Enum.Parse(typeof(MetroThemeStyle), config.Theme);
            var style = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), config.Style);
            if (parent.GetType().IsSubclassOf(typeof(MetroForm)))
            {
                var frm = (MetroForm)parent;
                frm.Theme = theme;
                frm.Style = style;
                frm.Refresh();
            }
            Color contrastColor;
            if (theme == MetroThemeStyle.Light || theme == MetroThemeStyle.Default)
            {
                contrastColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                contrastColor = Color.FromArgb(17, 17, 17);
            }
            var col = ContrastColor(contrastColor);
            foreach (var control in parent.Controls.OfType<IMetroControl>())
            {
                control.Style = style;
                control.Theme = theme;
                if (control.GetType() == typeof(MetroLabel))
                {
                    var lbl = (MetroLabel)control;
                    lbl.UseCustomBackColor = true;
                    lbl.UseCustomForeColor = true;
                    lbl.ForeColor = col;
                    lbl.BackColor = Color.Transparent;

                }
                else if (control.GetType() == typeof(MetroTabControl))
                {
                    ApplyTheme((Control)control, config);
                }
                else if (control.GetType() == typeof(MetroTabPage))
                {
                    ApplyTheme((Control)control, config);
                }
            }
            foreach (var rtb in parent.Controls.OfType<RichTextBox>())
            {
                rtb.ForeColor = col;
                rtb.BackColor = contrastColor;
            }
            foreach (var grp in parent.Controls.OfType<GroupBox>())
            {
                grp.ForeColor = col;
                grp.BackColor = parent.BackColor;
                ApplyTheme(grp, config);
            }
            parent.Refresh();
        }
    }
}
