using System.Security.AccessControl;

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
            this.lblWelcomeBack = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.cmdShowUUID = new System.Windows.Forms.Button();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpMain = new System.Windows.Forms.TabPage();
            this.pgbDownload = new BlockLaunch.UI.Controls.InfoProgressBar();
            this.cmdRefreshProfile = new System.Windows.Forms.Button();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.cmdAddProfil = new System.Windows.Forms.Button();
            this.ckbProfiles = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.lblSelectVersion = new System.Windows.Forms.Label();
            this.ckbVersions = new System.Windows.Forms.ComboBox();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
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
            this.tabTools = new System.Windows.Forms.TabPage();
            this.grpOptifine = new System.Windows.Forms.GroupBox();
            this.rtbLogInstaller = new System.Windows.Forms.RichTextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.lblOptifine = new System.Windows.Forms.Label();
            this.cmdRunInstaller = new System.Windows.Forms.Button();
            this.grpConverter = new System.Windows.Forms.GroupBox();
            this.rtbLogConvert = new System.Windows.Forms.RichTextBox();
            this.cmdConvertVersion = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofdOptifine = new System.Windows.Forms.OpenFileDialog();
            this.tbcMain.SuspendLayout();
            this.tbpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.tbpUpdates.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabLogSelection.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabBL.SuspendLayout();
            this.tabMinecraft.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.grpOptifine.SuspendLayout();
            this.grpConverter.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcomeBack
            // 
            this.lblWelcomeBack.AutoSize = true;
            this.lblWelcomeBack.Location = new System.Drawing.Point(76, 15);
            this.lblWelcomeBack.Name = "lblWelcomeBack";
            this.lblWelcomeBack.Size = new System.Drawing.Size(110, 13);
            this.lblWelcomeBack.TabIndex = 1;
            this.lblWelcomeBack.Text = "Welcome back, null :)";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(76, 38);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(109, 13);
            this.lblCurrentVersion.TabIndex = 2;
            this.lblCurrentVersion.Text = "Selected Version: null";
            // 
            // cmdShowUUID
            // 
            this.cmdShowUUID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdShowUUID.Location = new System.Drawing.Point(6, 76);
            this.cmdShowUUID.Name = "cmdShowUUID";
            this.cmdShowUUID.Size = new System.Drawing.Size(200, 23);
            this.cmdShowUUID.TabIndex = 3;
            this.cmdShowUUID.Text = "Show UUID";
            this.cmdShowUUID.UseVisualStyleBackColor = true;
            this.cmdShowUUID.Click += new System.EventHandler(this.cmdShowUUID_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpMain);
            this.tbcMain.Controls.Add(this.tbpUpdates);
            this.tbcMain.Controls.Add(this.tabLogs);
            this.tbcMain.Controls.Add(this.tabTools);
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1008, 705);
            this.tbcMain.TabIndex = 4;
            // 
            // tbpMain
            // 
            this.tbpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMain.Controls.Add(this.pgbDownload);
            this.tbpMain.Controls.Add(this.cmdRefreshProfile);
            this.tbpMain.Controls.Add(this.cmdSettings);
            this.tbpMain.Controls.Add(this.cmdAddProfil);
            this.tbpMain.Controls.Add(this.ckbProfiles);
            this.tbpMain.Controls.Add(this.lblProfile);
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
            this.tbpMain.Size = new System.Drawing.Size(1000, 679);
            this.tbpMain.TabIndex = 0;
            this.tbpMain.Text = "Home Page";
            // 
            // pgbDownload
            // 
            this.pgbDownload.CustomText = "";
            this.pgbDownload.Location = new System.Drawing.Point(6, 570);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(986, 30);
            this.pgbDownload.TabIndex = 15;
            this.pgbDownload.TextFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgbDownload.TextProgressMode = BlockLaunch.UI.Controls.ProgressMode.CustomText;
            this.pgbDownload.Visible = false;
            // 
            // cmdRefreshProfile
            // 
            this.cmdRefreshProfile.Location = new System.Drawing.Point(6, 105);
            this.cmdRefreshProfile.Name = "cmdRefreshProfile";
            this.cmdRefreshProfile.Size = new System.Drawing.Size(200, 23);
            this.cmdRefreshProfile.TabIndex = 14;
            this.cmdRefreshProfile.Text = "Refresh profile";
            this.cmdRefreshProfile.UseVisualStyleBackColor = true;
            this.cmdRefreshProfile.Click += new System.EventHandler(this.cmdRefreshProfile_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.Location = new System.Drawing.Point(6, 606);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(986, 25);
            this.cmdSettings.TabIndex = 13;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdAddProfil
            // 
            this.cmdAddProfil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAddProfil.Location = new System.Drawing.Point(783, 76);
            this.cmdAddProfil.Name = "cmdAddProfil";
            this.cmdAddProfil.Size = new System.Drawing.Size(209, 23);
            this.cmdAddProfil.TabIndex = 12;
            this.cmdAddProfil.Text = "Add profile";
            this.cmdAddProfil.UseVisualStyleBackColor = true;
            this.cmdAddProfil.Click += new System.EventHandler(this.cmdAddProfil_Click);
            // 
            // ckbProfiles
            // 
            this.ckbProfiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbProfiles.FormattingEnabled = true;
            this.ckbProfiles.Location = new System.Drawing.Point(831, 42);
            this.ckbProfiles.Name = "ckbProfiles";
            this.ckbProfiles.Size = new System.Drawing.Size(161, 21);
            this.ckbProfiles.TabIndex = 11;
            this.ckbProfiles.SelectedIndexChanged += new System.EventHandler(this.ckbProfiles_SelectedIndexChanged);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(792, 45);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(39, 13);
            this.lblProfile.TabIndex = 10;
            this.lblProfile.Text = "Profile:";
            // 
            // lblSelectVersion
            // 
            this.lblSelectVersion.AutoSize = true;
            this.lblSelectVersion.Location = new System.Drawing.Point(780, 18);
            this.lblSelectVersion.Name = "lblSelectVersion";
            this.lblSelectVersion.Size = new System.Drawing.Size(45, 13);
            this.lblSelectVersion.TabIndex = 6;
            this.lblSelectVersion.Text = "Version:";
            // 
            // ckbVersions
            // 
            this.ckbVersions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbVersions.FormattingEnabled = true;
            this.ckbVersions.Location = new System.Drawing.Point(831, 15);
            this.ckbVersions.Name = "ckbVersions";
            this.ckbVersions.Size = new System.Drawing.Size(161, 21);
            this.ckbVersions.TabIndex = 5;
            this.ckbVersions.SelectedIndexChanged += new System.EventHandler(this.ckbVersions_SelectedIndexChanged);
            // 
            // cmdLogin
            // 
            this.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLogin.Location = new System.Drawing.Point(6, 637);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(986, 36);
            this.cmdLogin.TabIndex = 4;
            this.cmdLogin.Text = "Login && Play";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
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
            // tbpUpdates
            // 
            this.tbpUpdates.Controls.Add(this.wkbMinecraftUpdates);
            this.tbpUpdates.Location = new System.Drawing.Point(4, 22);
            this.tbpUpdates.Name = "tbpUpdates";
            this.tbpUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdates.Size = new System.Drawing.Size(1000, 679);
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
            this.wkbMinecraftUpdates.Size = new System.Drawing.Size(994, 673);
            this.wkbMinecraftUpdates.TabIndex = 0;
            this.wkbMinecraftUpdates.Url = new System.Uri("http://mcupdate.tumblr.com/", System.UriKind.Absolute);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabLogSelection);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1000, 679);
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
            this.tabLogSelection.Size = new System.Drawing.Size(1004, 683);
            this.tabLogSelection.TabIndex = 1;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.rtbLog);
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(996, 657);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1000, 657);
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
            this.tabBL.Size = new System.Drawing.Size(996, 657);
            this.tabBL.TabIndex = 1;
            this.tabBL.Text = "BlockLaunch";
            this.tabBL.UseVisualStyleBackColor = true;
            // 
            // rtbLogBl
            // 
            this.rtbLogBl.Location = new System.Drawing.Point(1, 0);
            this.rtbLogBl.Name = "rtbLogBl";
            this.rtbLogBl.ReadOnly = true;
            this.rtbLogBl.Size = new System.Drawing.Size(995, 661);
            this.rtbLogBl.TabIndex = 0;
            this.rtbLogBl.Text = "";
            // 
            // tabMinecraft
            // 
            this.tabMinecraft.Controls.Add(this.rtbLogMinecraft);
            this.tabMinecraft.Location = new System.Drawing.Point(4, 22);
            this.tabMinecraft.Name = "tabMinecraft";
            this.tabMinecraft.Size = new System.Drawing.Size(996, 657);
            this.tabMinecraft.TabIndex = 2;
            this.tabMinecraft.Text = "Minecraft";
            this.tabMinecraft.UseVisualStyleBackColor = true;
            // 
            // rtbLogMinecraft
            // 
            this.rtbLogMinecraft.Location = new System.Drawing.Point(1, 0);
            this.rtbLogMinecraft.Name = "rtbLogMinecraft";
            this.rtbLogMinecraft.ReadOnly = true;
            this.rtbLogMinecraft.Size = new System.Drawing.Size(999, 661);
            this.rtbLogMinecraft.TabIndex = 0;
            this.rtbLogMinecraft.Text = "";
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.grpOptifine);
            this.tabTools.Controls.Add(this.grpConverter);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(1000, 679);
            this.tabTools.TabIndex = 3;
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // grpOptifine
            // 
            this.grpOptifine.Controls.Add(this.rtbLogInstaller);
            this.grpOptifine.Controls.Add(this.cmdBrowse);
            this.grpOptifine.Controls.Add(this.txbFile);
            this.grpOptifine.Controls.Add(this.lblOptifine);
            this.grpOptifine.Controls.Add(this.cmdRunInstaller);
            this.grpOptifine.Location = new System.Drawing.Point(503, 7);
            this.grpOptifine.Name = "grpOptifine";
            this.grpOptifine.Size = new System.Drawing.Size(489, 256);
            this.grpOptifine.TabIndex = 1;
            this.grpOptifine.TabStop = false;
            this.grpOptifine.Text = "BlockLaunch-OptiFine Installer";
            // 
            // rtbLogInstaller
            // 
            this.rtbLogInstaller.Location = new System.Drawing.Point(9, 54);
            this.rtbLogInstaller.Name = "rtbLogInstaller";
            this.rtbLogInstaller.Size = new System.Drawing.Size(474, 161);
            this.rtbLogInstaller.TabIndex = 4;
            this.rtbLogInstaller.Text = "";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(375, 22);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(108, 23);
            this.cmdBrowse.TabIndex = 3;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txbFile
            // 
            this.txbFile.AllowDrop = true;
            this.txbFile.Location = new System.Drawing.Point(90, 24);
            this.txbFile.Name = "txbFile";
            this.txbFile.Size = new System.Drawing.Size(279, 20);
            this.txbFile.TabIndex = 2;
            this.txbFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txbFile_DragDrop);
            this.txbFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txbFile_DragEnter);
            // 
            // lblOptifine
            // 
            this.lblOptifine.AutoSize = true;
            this.lblOptifine.Location = new System.Drawing.Point(6, 27);
            this.lblOptifine.Name = "lblOptifine";
            this.lblOptifine.Size = new System.Drawing.Size(70, 13);
            this.lblOptifine.TabIndex = 1;
            this.lblOptifine.Text = "Path to JAR: ";
            // 
            // cmdRunInstaller
            // 
            this.cmdRunInstaller.Location = new System.Drawing.Point(6, 221);
            this.cmdRunInstaller.Name = "cmdRunInstaller";
            this.cmdRunInstaller.Size = new System.Drawing.Size(477, 29);
            this.cmdRunInstaller.TabIndex = 0;
            this.cmdRunInstaller.Text = "Install Optifine";
            this.cmdRunInstaller.UseVisualStyleBackColor = true;
            this.cmdRunInstaller.Click += new System.EventHandler(this.cmdRunInstaller_Click);
            // 
            // grpConverter
            // 
            this.grpConverter.Controls.Add(this.rtbLogConvert);
            this.grpConverter.Controls.Add(this.cmdConvertVersion);
            this.grpConverter.Location = new System.Drawing.Point(9, 7);
            this.grpConverter.Name = "grpConverter";
            this.grpConverter.Size = new System.Drawing.Size(488, 256);
            this.grpConverter.TabIndex = 0;
            this.grpConverter.TabStop = false;
            this.grpConverter.Text = "BlockLaunch-Converter";
            // 
            // rtbLogConvert
            // 
            this.rtbLogConvert.Location = new System.Drawing.Point(6, 54);
            this.rtbLogConvert.Name = "rtbLogConvert";
            this.rtbLogConvert.Size = new System.Drawing.Size(476, 196);
            this.rtbLogConvert.TabIndex = 2;
            this.rtbLogConvert.Text = "";
            // 
            // cmdConvertVersion
            // 
            this.cmdConvertVersion.Location = new System.Drawing.Point(6, 19);
            this.cmdConvertVersion.Name = "cmdConvertVersion";
            this.cmdConvertVersion.Size = new System.Drawing.Size(476, 29);
            this.cmdConvertVersion.TabIndex = 1;
            this.cmdConvertVersion.Text = "Convert selected version";
            this.cmdConvertVersion.UseVisualStyleBackColor = true;
            this.cmdConvertVersion.Click += new System.EventHandler(this.cmdConvertVersion_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMain});
            this.status.Location = new System.Drawing.Point(0, 708);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1008, 22);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // tslMain
            // 
            this.tslMain.Name = "tslMain";
            this.tslMain.Size = new System.Drawing.Size(0, 17);
            // 
            // ofdOptifine
            // 
            this.ofdOptifine.FileName = "OptiFine.jar";
            this.ofdOptifine.Filter = "Executable Jar File (*.jar)|*.jar";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "BlockLaunch - v0.1 Alpha - Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.tbpUpdates.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogSelection.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabBL.ResumeLayout(false);
            this.tabMinecraft.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.grpOptifine.ResumeLayout(false);
            this.grpOptifine.PerformLayout();
            this.grpConverter.ResumeLayout(false);
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
        private System.Windows.Forms.Button cmdRefreshProfile;
        private Controls.InfoProgressBar pgbDownload;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.GroupBox grpOptifine;
        private System.Windows.Forms.GroupBox grpConverter;
        private System.Windows.Forms.RichTextBox rtbLogInstaller;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.TextBox txbFile;
        private System.Windows.Forms.Label lblOptifine;
        private System.Windows.Forms.Button cmdRunInstaller;
        private System.Windows.Forms.RichTextBox rtbLogConvert;
        private System.Windows.Forms.Button cmdConvertVersion;
        private System.Windows.Forms.OpenFileDialog ofdOptifine;
    }
}

