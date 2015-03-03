using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockLaunch.UI.Dialogs
{
    public partial class Dialog : Form
    {
        private readonly StatusMode _mode;
        private readonly string _title;
        private readonly string _statusTitle;
        private readonly string _description;
        private readonly string _details;
        private readonly string _ok;
        private readonly string _cancel;

        public enum StatusMode
        {
            Error,
            Info
        }

        public Dialog(StatusMode mode, string title, string statusTitle, string statusDescription, string ok, string cancel, string details = null)
        {
            InitializeComponent();
            _mode = mode;
            _title = title;
            _statusTitle = statusTitle;
            _description = statusDescription;
            _details = details;
            _cancel = cancel;
            _ok = ok;
        }

        private void ecpDetails_ExpandCollapse(object sender, MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs e)
        {
            Size = e.IsExpanded ? new Size(513, 413) : new Size(513, 220);
        }

        private void Dialog_Shown(object sender, EventArgs e)
        {
            lblDescription.Text = _description;
            lblTitle.Text = _statusTitle;
            if (String.IsNullOrEmpty(_details))
            {
                ecpDetails.Visible = false;
                Size = new Size(513, 178);
            }
            richTextBox1.Text = _details;
            Text = _title;
            cmdCancel.Text = _cancel;
            cmdOk.Text = _ok;
            picStatus.Image = _mode == StatusMode.Error ? Properties.Resources.Error : Properties.Resources.Info;
            if (_mode == StatusMode.Error)
            {
                System.Media.SystemSounds.Hand.Play();
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }
    }
}
