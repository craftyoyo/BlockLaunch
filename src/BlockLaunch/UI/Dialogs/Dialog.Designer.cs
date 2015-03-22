namespace BlockLaunch.UI.Dialogs
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            this.ecpDetails = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblTitle = new MetroFramework.Controls.MetroLabel();
            this.lblDescription = new MetroFramework.Controls.MetroLabel();
            this.cmdCancel = new MetroFramework.Controls.MetroButton();
            this.cmdOk = new MetroFramework.Controls.MetroButton();
            this.ecpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // ecpDetails
            // 
            this.ecpDetails.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.ecpDetails.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.ecpDetails.Controls.Add(this.richTextBox1);
            this.ecpDetails.ExpandedHeight = 223;
            this.ecpDetails.IsExpanded = false;
            this.ecpDetails.Location = new System.Drawing.Point(23, 170);
            this.ecpDetails.Name = "ecpDetails";
            this.ecpDetails.Size = new System.Drawing.Size(473, 36);
            this.ecpDetails.TabIndex = 3;
            this.ecpDetails.Text = "Details";
            this.ecpDetails.UseAnimation = false;
            this.ecpDetails.ExpandCollapse += new System.EventHandler<MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs>(this.ecpDetails_ExpandCollapse);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBox1.Location = new System.Drawing.Point(0, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(470, 178);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // picStatus
            // 
            this.picStatus.Location = new System.Drawing.Point(23, 63);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(64, 64);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 0;
            this.picStatus.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitle.Location = new System.Drawing.Point(98, 63);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 25);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Status Title";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDescription.Location = new System.Drawing.Point(98, 88);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 19);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Status Description";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(278, 141);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(106, 23);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseSelectable = true;
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(390, 141);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(109, 23);
            this.cmdOk.TabIndex = 9;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseSelectable = true;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 211);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ecpDetails);
            this.Controls.Add(this.picStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dialog";
            this.Text = "title";
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.Shown += new System.EventHandler(this.Dialog_Shown);
            this.ecpDetails.ResumeLayout(false);
            this.ecpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picStatus;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecpDetails;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MetroFramework.Controls.MetroLabel lblTitle;
        private MetroFramework.Controls.MetroLabel lblDescription;
        private MetroFramework.Controls.MetroButton cmdCancel;
        private MetroFramework.Controls.MetroButton cmdOk;
    }
}