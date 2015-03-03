namespace BlockLaunch.UI.Forms
{
    partial class FrmSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.ckbShowAlpha = new System.Windows.Forms.CheckBox();
            this.ckbShowBeta = new System.Windows.Forms.CheckBox();
            this.ckbShowSnapshot = new System.Windows.Forms.CheckBox();
            this.nudMemory = new System.Windows.Forms.NumericUpDown();
            this.lblMemory = new System.Windows.Forms.Label();
            this.ckbCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.ckbUseFullscreenMode = new System.Windows.Forms.CheckBox();
            this.cmdSaveSettings = new System.Windows.Forms.Button();
            this.ckbAllowLocalVersions = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comLang = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.chkDontSavePassword = new System.Windows.Forms.CheckBox();
            this.toolDetails = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbShowAlpha
            // 
            this.ckbShowAlpha.AutoSize = true;
            this.ckbShowAlpha.Location = new System.Drawing.Point(6, 20);
            this.ckbShowAlpha.Name = "ckbShowAlpha";
            this.ckbShowAlpha.Size = new System.Drawing.Size(149, 17);
            this.ckbShowAlpha.TabIndex = 0;
            this.ckbShowAlpha.Text = "Alpha-Versionen anzeigen";
            this.ckbShowAlpha.UseVisualStyleBackColor = true;
            // 
            // ckbShowBeta
            // 
            this.ckbShowBeta.AutoSize = true;
            this.ckbShowBeta.Location = new System.Drawing.Point(6, 43);
            this.ckbShowBeta.Name = "ckbShowBeta";
            this.ckbShowBeta.Size = new System.Drawing.Size(144, 17);
            this.ckbShowBeta.TabIndex = 1;
            this.ckbShowBeta.Text = "Beta-Versionen anzeigen";
            this.ckbShowBeta.UseVisualStyleBackColor = true;
            // 
            // ckbShowSnapshot
            // 
            this.ckbShowSnapshot.AutoSize = true;
            this.ckbShowSnapshot.Location = new System.Drawing.Point(6, 66);
            this.ckbShowSnapshot.Name = "ckbShowSnapshot";
            this.ckbShowSnapshot.Size = new System.Drawing.Size(167, 17);
            this.ckbShowSnapshot.TabIndex = 2;
            this.ckbShowSnapshot.Text = "Snapshot-Versionen anzeigen";
            this.ckbShowSnapshot.UseVisualStyleBackColor = true;
            // 
            // nudMemory
            // 
            this.nudMemory.Location = new System.Drawing.Point(123, 89);
            this.nudMemory.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMemory.Name = "nudMemory";
            this.nudMemory.Size = new System.Drawing.Size(63, 20);
            this.nudMemory.TabIndex = 3;
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(6, 91);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(111, 13);
            this.lblMemory.TabIndex = 4;
            this.lblMemory.Text = "Arbeitsspeicher in GB:";
            // 
            // ckbCheckForUpdates
            // 
            this.ckbCheckForUpdates.AutoSize = true;
            this.ckbCheckForUpdates.Location = new System.Drawing.Point(205, 20);
            this.ckbCheckForUpdates.Name = "ckbCheckForUpdates";
            this.ckbCheckForUpdates.Size = new System.Drawing.Size(168, 17);
            this.ckbCheckForUpdates.TabIndex = 5;
            this.ckbCheckForUpdates.Text = "Beim Start auf Updates prüfen";
            this.ckbCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // ckbUseFullscreenMode
            // 
            this.ckbUseFullscreenMode.AutoSize = true;
            this.ckbUseFullscreenMode.Location = new System.Drawing.Point(205, 43);
            this.ckbUseFullscreenMode.Name = "ckbUseFullscreenMode";
            this.ckbUseFullscreenMode.Size = new System.Drawing.Size(146, 17);
            this.ckbUseFullscreenMode.TabIndex = 6;
            this.ckbUseFullscreenMode.Text = "Vollbildmodus verwenden";
            this.ckbUseFullscreenMode.UseVisualStyleBackColor = true;
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSaveSettings.Location = new System.Drawing.Point(15, 62);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(361, 23);
            this.cmdSaveSettings.TabIndex = 7;
            this.cmdSaveSettings.Text = "Einstellungen speichern";
            this.cmdSaveSettings.UseVisualStyleBackColor = true;
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            // 
            // ckbAllowLocalVersions
            // 
            this.ckbAllowLocalVersions.AutoSize = true;
            this.ckbAllowLocalVersions.Location = new System.Drawing.Point(205, 66);
            this.ckbAllowLocalVersions.Name = "ckbAllowLocalVersions";
            this.ckbAllowLocalVersions.Size = new System.Drawing.Size(152, 17);
            this.ckbAllowLocalVersions.TabIndex = 8;
            this.ckbAllowLocalVersions.Text = "Lokale Versionen erlauben";
            this.ckbAllowLocalVersions.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbShowBeta);
            this.groupBox1.Controls.Add(this.ckbAllowLocalVersions);
            this.groupBox1.Controls.Add(this.ckbShowAlpha);
            this.groupBox1.Controls.Add(this.ckbShowSnapshot);
            this.groupBox1.Controls.Add(this.ckbUseFullscreenMode);
            this.groupBox1.Controls.Add(this.nudMemory);
            this.groupBox1.Controls.Add(this.ckbCheckForUpdates);
            this.groupBox1.Controls.Add(this.lblMemory);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 211);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // comLang
            // 
            this.comLang.FormattingEnabled = true;
            this.comLang.Location = new System.Drawing.Point(76, 12);
            this.comLang.Name = "comLang";
            this.comLang.Size = new System.Drawing.Size(293, 21);
            this.comLang.TabIndex = 10;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 15);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 11;
            this.lblLanguage.Text = "Language:";
            // 
            // chkDontSavePassword
            // 
            this.chkDontSavePassword.AutoSize = true;
            this.chkDontSavePassword.Checked = true;
            this.chkDontSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDontSavePassword.Location = new System.Drawing.Point(15, 39);
            this.chkDontSavePassword.Name = "chkDontSavePassword";
            this.chkDontSavePassword.Size = new System.Drawing.Size(248, 17);
            this.chkDontSavePassword.TabIndex = 12;
            this.chkDontSavePassword.Text = "Don\'t save password in config file (recommend)";
            this.toolDetails.SetToolTip(this.chkDontSavePassword, "If you disable this your password is saved as plain text in the config file, wher" +
        "e it can be stolen easily. \r\nOnly check this if you have a long password.");
            this.chkDontSavePassword.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 92);
            this.Controls.Add(this.chkDontSavePassword);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.comLang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "BlockLaunch - v. Alpha - Einstellungen";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbShowAlpha;
        private System.Windows.Forms.CheckBox ckbShowBeta;
        private System.Windows.Forms.CheckBox ckbShowSnapshot;
        private System.Windows.Forms.NumericUpDown nudMemory;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.CheckBox ckbCheckForUpdates;
        private System.Windows.Forms.CheckBox ckbUseFullscreenMode;
        private System.Windows.Forms.Button cmdSaveSettings;
        private System.Windows.Forms.CheckBox ckbAllowLocalVersions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comLang;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.CheckBox chkDontSavePassword;
        private System.Windows.Forms.ToolTip toolDetails;
    }
}