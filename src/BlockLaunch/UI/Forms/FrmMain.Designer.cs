namespace BlockLaunch.UI.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.lblWelcomeBack = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.cmdShowUUID = new System.Windows.Forms.Button();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpMain = new System.Windows.Forms.TabPage();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.cmdAddProfil = new System.Windows.Forms.Button();
            this.ckbProfiles = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            this.lblDownloadInfo = new System.Windows.Forms.Label();
            this.lblSelectVersion = new System.Windows.Forms.Label();
            this.ckbVersions = new System.Windows.Forms.ComboBox();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.tbpUpdates = new System.Windows.Forms.TabPage();
            this.wkbMinecraftUpdates = new WebKit.WebKitBrowser();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabLogSelection = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabBL = new System.Windows.Forms.TabPage();
            this.rtbLogBl = new System.Windows.Forms.RichTextBox();
            this.tabMinecraft = new System.Windows.Forms.TabPage();
            this.rtbLogMinecraft = new System.Windows.Forms.RichTextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tslMain = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.tbcMain.SuspendLayout();
            this.tbpMain.SuspendLayout();
            this.tbpUpdates.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabLogSelection.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabBL.SuspendLayout();
            this.tabMinecraft.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Image = global::BlockLaunch.Properties.Resources.DefaultHead;
            this.ptbAvatar.Location = new System.Drawing.Point(6, 6);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(64, 64);
            this.ptbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar.TabIndex = 0;
            this.ptbAvatar.TabStop = false;
            // 
            // lblWelcomeBack
            // 
            this.lblWelcomeBack.AutoSize = true;
            this.lblWelcomeBack.Location = new System.Drawing.Point(76, 15);
            this.lblWelcomeBack.Name = "lblWelcomeBack";
            this.lblWelcomeBack.Size = new System.Drawing.Size(130, 13);
            this.lblWelcomeBack.TabIndex = 1;
            this.lblWelcomeBack.Text = "Willkommen zurück, null :)";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(76, 38);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(128, 13);
            this.lblCurrentVersion.TabIndex = 2;
            this.lblCurrentVersion.Text = "Ausgewählte Version: null";
            // 
            // cmdShowUUID
            // 
            this.cmdShowUUID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdShowUUID.Location = new System.Drawing.Point(6, 76);
            this.cmdShowUUID.Name = "cmdShowUUID";
            this.cmdShowUUID.Size = new System.Drawing.Size(200, 23);
            this.cmdShowUUID.TabIndex = 3;
            this.cmdShowUUID.Text = "Zeige UUID";
            this.cmdShowUUID.UseVisualStyleBackColor = true;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpMain);
            this.tbcMain.Controls.Add(this.tbpUpdates);
            this.tbcMain.Controls.Add(this.tabLogs);
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(635, 383);
            this.tbcMain.TabIndex = 4;
            // 
            // tbpMain
            // 
            this.tbpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMain.Controls.Add(this.cmdSettings);
            this.tbpMain.Controls.Add(this.cmdAddProfil);
            this.tbpMain.Controls.Add(this.ckbProfiles);
            this.tbpMain.Controls.Add(this.lblProfile);
            this.tbpMain.Controls.Add(this.pgbDownload);
            this.tbpMain.Controls.Add(this.lblDownloadInfo);
            this.tbpMain.Controls.Add(this.lblSelectVersion);
            this.tbpMain.Controls.Add(this.ckbVersions);
            this.tbpMain.Controls.Add(this.cmdLogin);
            this.tbpMain.Controls.Add(this.ptbAvatar);
            this.tbpMain.Controls.Add(this.cmdShowUUID);
            this.tbpMain.Controls.Add(this.lblWelcomeBack);
            this.tbpMain.Controls.Add(this.lblCurrentVersion);
            this.tbpMain.Location = new System.Drawing.Point(4, 22);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMain.Size = new System.Drawing.Size(627, 357);
            this.tbpMain.TabIndex = 0;
            this.tbpMain.Text = "Startseite";
            // 
            // cmdSettings
            // 
            this.cmdSettings.Location = new System.Drawing.Point(8, 282);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(608, 25);
            this.cmdSettings.TabIndex = 13;
            this.cmdSettings.Text = "Einstellungen";
            this.cmdSettings.UseVisualStyleBackColor = true;
            // 
            // cmdAddProfil
            // 
            this.cmdAddProfil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAddProfil.Location = new System.Drawing.Point(431, 66);
            this.cmdAddProfil.Name = "cmdAddProfil";
            this.cmdAddProfil.Size = new System.Drawing.Size(189, 23);
            this.cmdAddProfil.TabIndex = 12;
            this.cmdAddProfil.Text = "Profil hinzufügen";
            this.cmdAddProfil.UseVisualStyleBackColor = true;
            // 
            // ckbProfiles
            // 
            this.ckbProfiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbProfiles.FormattingEnabled = true;
            this.ckbProfiles.Location = new System.Drawing.Point(479, 39);
            this.ckbProfiles.Name = "ckbProfiles";
            this.ckbProfiles.Size = new System.Drawing.Size(137, 21);
            this.ckbProfiles.TabIndex = 11;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(440, 42);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(33, 13);
            this.lblProfile.TabIndex = 10;
            this.lblProfile.Text = "Profil:";
            // 
            // pgbDownload
            // 
            this.pgbDownload.Location = new System.Drawing.Point(12, 150);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(608, 23);
            this.pgbDownload.TabIndex = 8;
            this.pgbDownload.Visible = false;
            // 
            // lblDownloadInfo
            // 
            this.lblDownloadInfo.AutoSize = true;
            this.lblDownloadInfo.Location = new System.Drawing.Point(244, 134);
            this.lblDownloadInfo.Name = "lblDownloadInfo";
            this.lblDownloadInfo.Size = new System.Drawing.Size(23, 13);
            this.lblDownloadInfo.TabIndex = 7;
            this.lblDownloadInfo.Text = "null";
            this.lblDownloadInfo.Visible = false;
            // 
            // lblSelectVersion
            // 
            this.lblSelectVersion.AutoSize = true;
            this.lblSelectVersion.Location = new System.Drawing.Point(428, 15);
            this.lblSelectVersion.Name = "lblSelectVersion";
            this.lblSelectVersion.Size = new System.Drawing.Size(45, 13);
            this.lblSelectVersion.TabIndex = 6;
            this.lblSelectVersion.Text = "Version:";
            // 
            // ckbVersions
            // 
            this.ckbVersions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbVersions.FormattingEnabled = true;
            this.ckbVersions.Location = new System.Drawing.Point(479, 12);
            this.ckbVersions.Name = "ckbVersions";
            this.ckbVersions.Size = new System.Drawing.Size(137, 21);
            this.ckbVersions.TabIndex = 5;
            // 
            // cmdLogin
            // 
            this.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLogin.Location = new System.Drawing.Point(8, 313);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(608, 36);
            this.cmdLogin.TabIndex = 4;
            this.cmdLogin.Text = "Einloggen";
            this.cmdLogin.UseVisualStyleBackColor = true;
            // 
            // tbpUpdates
            // 
            this.tbpUpdates.Controls.Add(this.wkbMinecraftUpdates);
            this.tbpUpdates.Location = new System.Drawing.Point(4, 22);
            this.tbpUpdates.Name = "tbpUpdates";
            this.tbpUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdates.Size = new System.Drawing.Size(627, 357);
            this.tbpUpdates.TabIndex = 2;
            this.tbpUpdates.Text = "News - Updates";
            this.tbpUpdates.UseVisualStyleBackColor = true;
            // 
            // wkbMinecraftUpdates
            // 
            this.wkbMinecraftUpdates.AllowDownloads = false;
            this.wkbMinecraftUpdates.AllowNavigation = false;
            this.wkbMinecraftUpdates.AllowNewWindows = false;
            this.wkbMinecraftUpdates.BackColor = System.Drawing.Color.White;
            this.wkbMinecraftUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wkbMinecraftUpdates.Location = new System.Drawing.Point(3, 3);
            this.wkbMinecraftUpdates.Name = "wkbMinecraftUpdates";
            this.wkbMinecraftUpdates.Size = new System.Drawing.Size(621, 351);
            this.wkbMinecraftUpdates.TabIndex = 0;
            this.wkbMinecraftUpdates.Url = new System.Uri("http://mcupdate.tumblr.com/", System.UriKind.Absolute);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabLogSelection);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(627, 357);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // tabLogSelection
            // 
            this.tabLogSelection.Controls.Add(this.tabAll);
            this.tabLogSelection.Controls.Add(this.tabBL);
            this.tabLogSelection.Controls.Add(this.tabMinecraft);
            this.tabLogSelection.Location = new System.Drawing.Point(0, 0);
            this.tabLogSelection.Name = "tabLogSelection";
            this.tabLogSelection.SelectedIndex = 0;
            this.tabLogSelection.Size = new System.Drawing.Size(630, 357);
            this.tabLogSelection.TabIndex = 1;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.rtbLog);
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(622, 331);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "Alle";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(627, 331);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            this.rtbLog.WordWrap = false;
            // 
            // tabBL
            // 
            this.tabBL.Controls.Add(this.rtbLogBl);
            this.tabBL.Location = new System.Drawing.Point(4, 22);
            this.tabBL.Name = "tabBL";
            this.tabBL.Padding = new System.Windows.Forms.Padding(3);
            this.tabBL.Size = new System.Drawing.Size(622, 331);
            this.tabBL.TabIndex = 1;
            this.tabBL.Text = "BlockLaunch";
            this.tabBL.UseVisualStyleBackColor = true;
            // 
            // rtbLogBl
            // 
            this.rtbLogBl.Location = new System.Drawing.Point(1, 0);
            this.rtbLogBl.Name = "rtbLogBl";
            this.rtbLogBl.Size = new System.Drawing.Size(626, 329);
            this.rtbLogBl.TabIndex = 0;
            this.rtbLogBl.Text = "";
            // 
            // tabMinecraft
            // 
            this.tabMinecraft.Controls.Add(this.rtbLogMinecraft);
            this.tabMinecraft.Location = new System.Drawing.Point(4, 22);
            this.tabMinecraft.Name = "tabMinecraft";
            this.tabMinecraft.Size = new System.Drawing.Size(622, 331);
            this.tabMinecraft.TabIndex = 2;
            this.tabMinecraft.Text = "Minecraft";
            this.tabMinecraft.UseVisualStyleBackColor = true;
            // 
            // rtbLogMinecraft
            // 
            this.rtbLogMinecraft.Location = new System.Drawing.Point(1, 0);
            this.rtbLogMinecraft.Name = "rtbLogMinecraft";
            this.rtbLogMinecraft.Size = new System.Drawing.Size(626, 332);
            this.rtbLogMinecraft.TabIndex = 0;
            this.rtbLogMinecraft.Text = "";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMain});
            this.status.Location = new System.Drawing.Point(0, 380);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(633, 22);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // tslMain
            // 
            this.tslMain.Name = "tslMain";
            this.tslMain.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(633, 402);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "BlockLaunch - v0.1 Alpha - Hauptmenü";
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.tbcMain.ResumeLayout(false);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            this.tbpUpdates.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogSelection.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabBL.ResumeLayout(false);
            this.tabMinecraft.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.Label lblWelcomeBack;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Button cmdShowUUID;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpMain;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.TabPage tbpUpdates;
        private System.Windows.Forms.Label lblSelectVersion;
        private System.Windows.Forms.ComboBox ckbVersions;
        private System.Windows.Forms.ProgressBar pgbDownload;
        private System.Windows.Forms.Label lblDownloadInfo;
        private WebKit.WebKitBrowser wkbMinecraftUpdates;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel tslMain;
        private System.Windows.Forms.ComboBox ckbProfiles;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Button cmdAddProfil;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.TabControl tabLogSelection;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabBL;
        private System.Windows.Forms.RichTextBox rtbLogBl;
        private System.Windows.Forms.TabPage tabMinecraft;
        private System.Windows.Forms.RichTextBox rtbLogMinecraft;
    }
}

