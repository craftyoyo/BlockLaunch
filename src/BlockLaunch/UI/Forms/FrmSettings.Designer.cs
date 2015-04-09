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
            this.ckbCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.ckbUseFullscreenMode = new System.Windows.Forms.CheckBox();
            this.ckbAllowLocalVersions = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolDetails = new System.Windows.Forms.ToolTip(this.components);
            this.chkDontSavePassword = new MetroFramework.Controls.MetroCheckBox();
            this.cmdSaveSettings = new MetroFramework.Controls.MetroButton();
            this.lblJvm = new MetroFramework.Controls.MetroLabel();
            this.lblLanguage = new MetroFramework.Controls.MetroLabel();
            this.comLang = new MetroFramework.Controls.MetroComboBox();
            this.txbJvmArguments = new MetroFramework.Controls.MetroTextBox();
            this.lblMemory = new MetroFramework.Controls.MetroLabel();
            this.lblTheme = new MetroFramework.Controls.MetroLabel();
            this.ckbTheme = new MetroFramework.Controls.MetroComboBox();
            this.lblStyle = new MetroFramework.Controls.MetroLabel();
            this.ckbStyle = new MetroFramework.Controls.MetroComboBox();
            this.txbMinecraftArgs = new MetroFramework.Controls.MetroTextBox();
            this.lblMinecraftArgs = new MetroFramework.Controls.MetroLabel();
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
            this.nudMemory.Location = new System.Drawing.Point(140, 123);
            this.nudMemory.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMemory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMemory.Name = "nudMemory";
            this.nudMemory.Size = new System.Drawing.Size(308, 20);
            this.nudMemory.TabIndex = 3;
            this.nudMemory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.groupBox1.Controls.Add(this.ckbCheckForUpdates);
            this.groupBox1.Location = new System.Drawing.Point(958, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 211);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // chkDontSavePassword
            // 
            this.chkDontSavePassword.AutoSize = true;
            this.chkDontSavePassword.Checked = true;
            this.chkDontSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDontSavePassword.Location = new System.Drawing.Point(25, 217);
            this.chkDontSavePassword.Name = "chkDontSavePassword";
            this.chkDontSavePassword.Size = new System.Drawing.Size(276, 15);
            this.chkDontSavePassword.TabIndex = 20;
            this.chkDontSavePassword.Text = "Don\'t save password in config file (recommend)";
            this.toolDetails.SetToolTip(this.chkDontSavePassword, "If you disable this your password is saved as plain text in the config file, wher" +
        "e it can be stolen easily. ");
            this.chkDontSavePassword.UseSelectable = true;
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSaveSettings.Location = new System.Drawing.Point(23, 238);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(423, 23);
            this.cmdSaveSettings.TabIndex = 15;
            this.cmdSaveSettings.Text = "Save settings";
            this.cmdSaveSettings.UseSelectable = true;
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            // 
            // lblJvm
            // 
            this.lblJvm.AutoSize = true;
            this.lblJvm.Location = new System.Drawing.Point(23, 65);
            this.lblJvm.Name = "lblJvm";
            this.lblJvm.Size = new System.Drawing.Size(111, 19);
            this.lblJvm.TabIndex = 16;
            this.lblJvm.Text = "JVM-Arguments: ";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(23, 30);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(73, 19);
            this.lblLanguage.TabIndex = 17;
            this.lblLanguage.Text = "Language: ";
            // 
            // comLang
            // 
            this.comLang.FormattingEnabled = true;
            this.comLang.ItemHeight = 23;
            this.comLang.Location = new System.Drawing.Point(140, 30);
            this.comLang.Name = "comLang";
            this.comLang.Size = new System.Drawing.Size(308, 29);
            this.comLang.TabIndex = 18;
            this.comLang.UseSelectable = true;
            // 
            // txbJvmArguments
            // 
            this.txbJvmArguments.Lines = new string[0];
            this.txbJvmArguments.Location = new System.Drawing.Point(140, 65);
            this.txbJvmArguments.MaxLength = 32767;
            this.txbJvmArguments.Name = "txbJvmArguments";
            this.txbJvmArguments.PasswordChar = '\0';
            this.txbJvmArguments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbJvmArguments.SelectedText = "";
            this.txbJvmArguments.Size = new System.Drawing.Size(308, 23);
            this.txbJvmArguments.TabIndex = 19;
            this.txbJvmArguments.UseSelectable = true;
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(25, 124);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(109, 19);
            this.lblMemory.TabIndex = 21;
            this.lblMemory.Text = "Memory (in GB): ";
            this.lblMemory.WrapToLine = true;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(25, 157);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(56, 19);
            this.lblTheme.TabIndex = 22;
            this.lblTheme.Text = "Theme: ";
            this.lblTheme.WrapToLine = true;
            // 
            // ckbTheme
            // 
            this.ckbTheme.FormattingEnabled = true;
            this.ckbTheme.ItemHeight = 23;
            this.ckbTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.ckbTheme.Location = new System.Drawing.Point(140, 147);
            this.ckbTheme.Name = "ckbTheme";
            this.ckbTheme.Size = new System.Drawing.Size(308, 29);
            this.ckbTheme.TabIndex = 23;
            this.ckbTheme.UseSelectable = true;
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(25, 192);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(43, 19);
            this.lblStyle.TabIndex = 24;
            this.lblStyle.Text = "Style: ";
            this.lblStyle.WrapToLine = true;
            // 
            // ckbStyle
            // 
            this.ckbStyle.FormattingEnabled = true;
            this.ckbStyle.ItemHeight = 23;
            this.ckbStyle.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.ckbStyle.Location = new System.Drawing.Point(140, 182);
            this.ckbStyle.Name = "ckbStyle";
            this.ckbStyle.Size = new System.Drawing.Size(308, 29);
            this.ckbStyle.TabIndex = 25;
            this.ckbStyle.UseSelectable = true;
            // 
            // txbMinecraftArgs
            // 
            this.txbMinecraftArgs.Lines = new string[0];
            this.txbMinecraftArgs.Location = new System.Drawing.Point(170, 94);
            this.txbMinecraftArgs.MaxLength = 32767;
            this.txbMinecraftArgs.Name = "txbMinecraftArgs";
            this.txbMinecraftArgs.PasswordChar = '\0';
            this.txbMinecraftArgs.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbMinecraftArgs.SelectedText = "";
            this.txbMinecraftArgs.Size = new System.Drawing.Size(278, 23);
            this.txbMinecraftArgs.TabIndex = 26;
            this.txbMinecraftArgs.UseSelectable = true;
            // 
            // lblMinecraftArgs
            // 
            this.lblMinecraftArgs.AutoSize = true;
            this.lblMinecraftArgs.Location = new System.Drawing.Point(23, 98);
            this.lblMinecraftArgs.Name = "lblMinecraftArgs";
            this.lblMinecraftArgs.Size = new System.Drawing.Size(141, 19);
            this.lblMinecraftArgs.TabIndex = 27;
            this.lblMinecraftArgs.Text = "Minecraft-Arguments: ";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 272);
            this.Controls.Add(this.lblMinecraftArgs);
            this.Controls.Add(this.txbMinecraftArgs);
            this.Controls.Add(this.ckbStyle);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.ckbTheme);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.chkDontSavePassword);
            this.Controls.Add(this.txbJvmArguments);
            this.Controls.Add(this.comLang);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblJvm);
            this.Controls.Add(this.nudMemory);
            this.Controls.Add(this.cmdSaveSettings);
            this.Controls.Add(this.groupBox1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
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
        private System.Windows.Forms.CheckBox ckbCheckForUpdates;
        private System.Windows.Forms.CheckBox ckbUseFullscreenMode;
        private System.Windows.Forms.CheckBox ckbAllowLocalVersions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolDetails;
        private MetroFramework.Controls.MetroButton cmdSaveSettings;
        private MetroFramework.Controls.MetroLabel lblJvm;
        private MetroFramework.Controls.MetroLabel lblLanguage;
        private MetroFramework.Controls.MetroComboBox comLang;
        private MetroFramework.Controls.MetroTextBox txbJvmArguments;
        private MetroFramework.Controls.MetroCheckBox chkDontSavePassword;
        private MetroFramework.Controls.MetroLabel lblMemory;
        private MetroFramework.Controls.MetroLabel lblTheme;
        private MetroFramework.Controls.MetroComboBox ckbTheme;
        private MetroFramework.Controls.MetroLabel lblStyle;
        private MetroFramework.Controls.MetroComboBox ckbStyle;
        private MetroFramework.Controls.MetroTextBox txbMinecraftArgs;
        private MetroFramework.Controls.MetroLabel lblMinecraftArgs;
    }
}