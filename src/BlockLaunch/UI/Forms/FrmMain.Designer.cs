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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tbpUpdates = new System.Windows.Forms.TabPage();
            this.wkbMinecraftUpdates = new WebKit.WebKitBrowser();
            this.ofdOptifine = new System.Windows.Forms.OpenFileDialog();
            this.tbcMain = new MetroFramework.Controls.MetroTabControl();
            this.tbpMain = new MetroFramework.Controls.MetroTabPage();
            this.picAccounts = new System.Windows.Forms.PictureBox();
            this.picSkins = new System.Windows.Forms.PictureBox();
            this.picSession = new System.Windows.Forms.PictureBox();
            this.picAuth = new System.Windows.Forms.PictureBox();
            this.cmdCopyProfile = new MetroFramework.Controls.MetroButton();
            this.pgbDownload = new BlockLaunch.UI.Controls.InfoProgressBar();
            this.cmdSettings = new MetroFramework.Controls.MetroButton();
            this.cmdLogin = new MetroFramework.Controls.MetroButton();
            this.cmdAddProfil = new MetroFramework.Controls.MetroButton();
            this.ckbProfiles = new MetroFramework.Controls.MetroComboBox();
            this.lblProfile = new MetroFramework.Controls.MetroLabel();
            this.ckbVersions = new MetroFramework.Controls.MetroComboBox();
            this.lblSelectVersion = new MetroFramework.Controls.MetroLabel();
            this.lblCurrentVersion = new MetroFramework.Controls.MetroLabel();
            this.lblWelcomeBack = new MetroFramework.Controls.MetroLabel();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.cmdRefreshProfile = new MetroFramework.Controls.MetroButton();
            this.cmdShowUUID = new MetroFramework.Controls.MetroButton();
            this.tabLogs = new MetroFramework.Controls.MetroTabPage();
            this.tabLogSelection = new MetroFramework.Controls.MetroTabControl();
            this.tabAll = new MetroFramework.Controls.MetroTabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabBL = new MetroFramework.Controls.MetroTabPage();
            this.rtbLogBl = new System.Windows.Forms.RichTextBox();
            this.tabMinecraft = new MetroFramework.Controls.MetroTabPage();
            this.rtbLogMinecraft = new System.Windows.Forms.RichTextBox();
            this.tabTools = new MetroFramework.Controls.MetroTabPage();
            this.grpOptifine = new System.Windows.Forms.GroupBox();
            this.cmdRunInstaller = new MetroFramework.Controls.MetroButton();
            this.cmdBrowse = new MetroFramework.Controls.MetroButton();
            this.txbFile = new MetroFramework.Controls.MetroTextBox();
            this.lblOptifine = new MetroFramework.Controls.MetroLabel();
            this.rtbLogInstaller = new System.Windows.Forms.RichTextBox();
            this.grpConverter = new System.Windows.Forms.GroupBox();
            this.cmdConvertVersion = new MetroFramework.Controls.MetroButton();
            this.rtbLogConvert = new System.Windows.Forms.RichTextBox();
            this.toolInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tbpUpdates.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.tabLogs.SuspendLayout();
            this.tabLogSelection.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabBL.SuspendLayout();
            this.tabMinecraft.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.grpOptifine.SuspendLayout();
            this.grpConverter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpUpdates
            // 
            this.tbpUpdates.Controls.Add(this.wkbMinecraftUpdates);
            this.tbpUpdates.Location = new System.Drawing.Point(4, 38);
            this.tbpUpdates.Name = "tbpUpdates";
            this.tbpUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdates.Size = new System.Drawing.Size(1038, 681);
            this.tbpUpdates.TabIndex = 2;
            this.tbpUpdates.Text = "News - Updates";
            this.tbpUpdates.UseVisualStyleBackColor = true;
            // 
            // wkbMinecraftUpdates
            // 
            this.wkbMinecraftUpdates.AllowDownloads = false;
            this.wkbMinecraftUpdates.AllowNavigation = false;
            this.wkbMinecraftUpdates.AllowNewWindows = false;
            this.wkbMinecraftUpdates.BackColor = System.Drawing.Color.Transparent;
            this.wkbMinecraftUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wkbMinecraftUpdates.Location = new System.Drawing.Point(3, 3);
            this.wkbMinecraftUpdates.Name = "wkbMinecraftUpdates";
            this.wkbMinecraftUpdates.Size = new System.Drawing.Size(1032, 675);
            this.wkbMinecraftUpdates.TabIndex = 0;
            this.wkbMinecraftUpdates.Url = new System.Uri("http://mcupdate.tumblr.com/", System.UriKind.Absolute);
            // 
            // ofdOptifine
            // 
            this.ofdOptifine.FileName = "OptiFine.jar";
            this.ofdOptifine.Filter = "Executable Jar File (*.jar)|*.jar";
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpMain);
            this.tbcMain.Controls.Add(this.tbpUpdates);
            this.tbcMain.Controls.Add(this.tabLogs);
            this.tbcMain.Controls.Add(this.tabTools);
            this.tbcMain.Location = new System.Drawing.Point(23, 63);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 1;
            this.tbcMain.Size = new System.Drawing.Size(1046, 723);
            this.tbcMain.TabIndex = 16;
            this.tbcMain.UseSelectable = true;
            // 
            // tbpMain
            // 
            this.tbpMain.Controls.Add(this.picAccounts);
            this.tbpMain.Controls.Add(this.picSkins);
            this.tbpMain.Controls.Add(this.picSession);
            this.tbpMain.Controls.Add(this.picAuth);
            this.tbpMain.Controls.Add(this.cmdCopyProfile);
            this.tbpMain.Controls.Add(this.pgbDownload);
            this.tbpMain.Controls.Add(this.cmdSettings);
            this.tbpMain.Controls.Add(this.cmdLogin);
            this.tbpMain.Controls.Add(this.cmdAddProfil);
            this.tbpMain.Controls.Add(this.ckbProfiles);
            this.tbpMain.Controls.Add(this.lblProfile);
            this.tbpMain.Controls.Add(this.ckbVersions);
            this.tbpMain.Controls.Add(this.lblSelectVersion);
            this.tbpMain.Controls.Add(this.lblCurrentVersion);
            this.tbpMain.Controls.Add(this.lblWelcomeBack);
            this.tbpMain.Controls.Add(this.ptbAvatar);
            this.tbpMain.Controls.Add(this.cmdRefreshProfile);
            this.tbpMain.Controls.Add(this.cmdShowUUID);
            this.tbpMain.HorizontalScrollbarBarColor = true;
            this.tbpMain.HorizontalScrollbarHighlightOnWheel = false;
            this.tbpMain.HorizontalScrollbarSize = 10;
            this.tbpMain.Location = new System.Drawing.Point(4, 38);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Size = new System.Drawing.Size(1038, 681);
            this.tbpMain.TabIndex = 4;
            this.tbpMain.Text = "Home Page";
            this.tbpMain.VerticalScrollbarBarColor = true;
            this.tbpMain.VerticalScrollbarHighlightOnWheel = false;
            this.tbpMain.VerticalScrollbarSize = 10;
            // 
            // picAccounts
            // 
            this.picAccounts.Image = global::BlockLaunch.Properties.Resources.redstone_off;
            this.picAccounts.Location = new System.Drawing.Point(1006, 547);
            this.picAccounts.Name = "picAccounts";
            this.picAccounts.Size = new System.Drawing.Size(32, 32);
            this.picAccounts.TabIndex = 23;
            this.picAccounts.TabStop = false;
            this.toolInfo.SetToolTip(this.picAccounts, "Accounts Server: Offline");
            this.picAccounts.Click += new System.EventHandler(this.pic_Click);
            // 
            // picSkins
            // 
            this.picSkins.Image = global::BlockLaunch.Properties.Resources.redstone_off;
            this.picSkins.Location = new System.Drawing.Point(968, 547);
            this.picSkins.Name = "picSkins";
            this.picSkins.Size = new System.Drawing.Size(32, 32);
            this.picSkins.TabIndex = 22;
            this.picSkins.TabStop = false;
            this.toolInfo.SetToolTip(this.picSkins, "Skins Server: Offline");
            this.picSkins.Click += new System.EventHandler(this.pic_Click);
            // 
            // picSession
            // 
            this.picSession.Image = global::BlockLaunch.Properties.Resources.redstone_off;
            this.picSession.Location = new System.Drawing.Point(930, 547);
            this.picSession.Name = "picSession";
            this.picSession.Size = new System.Drawing.Size(32, 32);
            this.picSession.TabIndex = 21;
            this.picSession.TabStop = false;
            this.toolInfo.SetToolTip(this.picSession, "Session Server: Offline");
            this.picSession.Click += new System.EventHandler(this.pic_Click);
            // 
            // picAuth
            // 
            this.picAuth.Image = global::BlockLaunch.Properties.Resources.redstone_off;
            this.picAuth.Location = new System.Drawing.Point(892, 547);
            this.picAuth.Name = "picAuth";
            this.picAuth.Size = new System.Drawing.Size(32, 32);
            this.picAuth.TabIndex = 20;
            this.picAuth.TabStop = false;
            this.toolInfo.SetToolTip(this.picAuth, "Authentification Server: Offline");
            this.picAuth.Click += new System.EventHandler(this.pic_Click);
            // 
            // cmdCopyProfile
            // 
            this.cmdCopyProfile.Location = new System.Drawing.Point(825, 108);
            this.cmdCopyProfile.Name = "cmdCopyProfile";
            this.cmdCopyProfile.Size = new System.Drawing.Size(210, 23);
            this.cmdCopyProfile.TabIndex = 19;
            this.cmdCopyProfile.Text = "Copy profile";
            this.cmdCopyProfile.UseSelectable = true;
            this.cmdCopyProfile.Click += new System.EventHandler(this.cmdCopyProfile_Click);
            // 
            // pgbDownload
            // 
            this.pgbDownload.HideProgressText = false;
            this.pgbDownload.Location = new System.Drawing.Point(3, 585);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.ProgressText = "";
            this.pgbDownload.Size = new System.Drawing.Size(1035, 27);
            this.pgbDownload.TabIndex = 18;
            this.pgbDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdSettings
            // 
            this.cmdSettings.Location = new System.Drawing.Point(3, 618);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(1035, 24);
            this.cmdSettings.TabIndex = 14;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseSelectable = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Location = new System.Drawing.Point(3, 648);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(1035, 30);
            this.cmdLogin.TabIndex = 13;
            this.cmdLogin.Text = "Login and Play";
            this.cmdLogin.UseSelectable = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // cmdAddProfil
            // 
            this.cmdAddProfil.Location = new System.Drawing.Point(825, 79);
            this.cmdAddProfil.Name = "cmdAddProfil";
            this.cmdAddProfil.Size = new System.Drawing.Size(210, 23);
            this.cmdAddProfil.TabIndex = 11;
            this.cmdAddProfil.Text = "Add profile";
            this.cmdAddProfil.UseSelectable = true;
            this.cmdAddProfil.Click += new System.EventHandler(this.cmdAddProfil_Click);
            // 
            // ckbProfiles
            // 
            this.ckbProfiles.DropDownWidth = 149;
            this.ckbProfiles.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ckbProfiles.FormattingEnabled = true;
            this.ckbProfiles.ItemHeight = 19;
            this.ckbProfiles.Location = new System.Drawing.Point(886, 48);
            this.ckbProfiles.Name = "ckbProfiles";
            this.ckbProfiles.Size = new System.Drawing.Size(149, 25);
            this.ckbProfiles.TabIndex = 10;
            this.ckbProfiles.UseSelectable = true;
            this.ckbProfiles.SelectedIndexChanged += new System.EventHandler(this.ckbProfiles_SelectedIndexChanged);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(825, 48);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(54, 19);
            this.lblProfile.TabIndex = 9;
            this.lblProfile.Text = "Profile: ";
            // 
            // ckbVersions
            // 
            this.ckbVersions.DropDownWidth = 149;
            this.ckbVersions.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.ckbVersions.FormattingEnabled = true;
            this.ckbVersions.ItemHeight = 19;
            this.ckbVersions.Location = new System.Drawing.Point(886, 17);
            this.ckbVersions.Name = "ckbVersions";
            this.ckbVersions.Size = new System.Drawing.Size(149, 25);
            this.ckbVersions.TabIndex = 8;
            this.ckbVersions.UseSelectable = true;
            this.ckbVersions.SelectedIndexChanged += new System.EventHandler(this.ckbVersions_SelectedIndexChanged);
            // 
            // lblSelectVersion
            // 
            this.lblSelectVersion.AutoSize = true;
            this.lblSelectVersion.Location = new System.Drawing.Point(825, 17);
            this.lblSelectVersion.Name = "lblSelectVersion";
            this.lblSelectVersion.Size = new System.Drawing.Size(55, 19);
            this.lblSelectVersion.TabIndex = 7;
            this.lblSelectVersion.Text = "Version:";
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(73, 36);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(194, 19);
            this.lblCurrentVersion.TabIndex = 6;
            this.lblCurrentVersion.Text = "Selected Version: unknown 0.0.0";
            // 
            // lblWelcomeBack
            // 
            this.lblWelcomeBack.AutoSize = true;
            this.lblWelcomeBack.Location = new System.Drawing.Point(73, 17);
            this.lblWelcomeBack.Name = "lblWelcomeBack";
            this.lblWelcomeBack.Size = new System.Drawing.Size(134, 19);
            this.lblWelcomeBack.TabIndex = 5;
            this.lblWelcomeBack.Text = "Welcome back, null :)";
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Image = global::BlockLaunch.Properties.Resources.DefaultHead;
            this.ptbAvatar.Location = new System.Drawing.Point(3, 7);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(64, 64);
            this.ptbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar.TabIndex = 4;
            this.ptbAvatar.TabStop = false;
            // 
            // cmdRefreshProfile
            // 
            this.cmdRefreshProfile.Location = new System.Drawing.Point(3, 106);
            this.cmdRefreshProfile.Name = "cmdRefreshProfile";
            this.cmdRefreshProfile.Size = new System.Drawing.Size(201, 23);
            this.cmdRefreshProfile.TabIndex = 3;
            this.cmdRefreshProfile.Text = "Refresh profile";
            this.cmdRefreshProfile.UseSelectable = true;
            this.cmdRefreshProfile.Click += new System.EventHandler(this.cmdRefreshProfile_Click);
            // 
            // cmdShowUUID
            // 
            this.cmdShowUUID.Location = new System.Drawing.Point(3, 77);
            this.cmdShowUUID.Name = "cmdShowUUID";
            this.cmdShowUUID.Size = new System.Drawing.Size(201, 23);
            this.cmdShowUUID.TabIndex = 2;
            this.cmdShowUUID.Text = "Show UUID";
            this.cmdShowUUID.UseSelectable = true;
            this.cmdShowUUID.Click += new System.EventHandler(this.cmdShowUUID_Click);
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabLogSelection);
            this.tabLogs.HorizontalScrollbarBarColor = true;
            this.tabLogs.HorizontalScrollbarHighlightOnWheel = false;
            this.tabLogs.HorizontalScrollbarSize = 10;
            this.tabLogs.Location = new System.Drawing.Point(4, 38);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(1038, 681);
            this.tabLogs.TabIndex = 5;
            this.tabLogs.Text = "Logs";
            this.tabLogs.VerticalScrollbarBarColor = true;
            this.tabLogs.VerticalScrollbarHighlightOnWheel = false;
            this.tabLogs.VerticalScrollbarSize = 10;
            // 
            // tabLogSelection
            // 
            this.tabLogSelection.Controls.Add(this.tabAll);
            this.tabLogSelection.Controls.Add(this.tabBL);
            this.tabLogSelection.Controls.Add(this.tabMinecraft);
            this.tabLogSelection.Location = new System.Drawing.Point(3, 3);
            this.tabLogSelection.Name = "tabLogSelection";
            this.tabLogSelection.SelectedIndex = 2;
            this.tabLogSelection.Size = new System.Drawing.Size(1039, 682);
            this.tabLogSelection.TabIndex = 2;
            this.tabLogSelection.UseSelectable = true;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.rtbLog);
            this.tabAll.HorizontalScrollbarBarColor = true;
            this.tabAll.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAll.HorizontalScrollbarSize = 10;
            this.tabAll.Location = new System.Drawing.Point(4, 38);
            this.tabAll.Name = "tabAll";
            this.tabAll.Size = new System.Drawing.Size(1031, 640);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.VerticalScrollbarBarColor = true;
            this.tabAll.VerticalScrollbarHighlightOnWheel = false;
            this.tabAll.VerticalScrollbarSize = 10;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1025, 633);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // tabBL
            // 
            this.tabBL.Controls.Add(this.rtbLogBl);
            this.tabBL.HorizontalScrollbarBarColor = true;
            this.tabBL.HorizontalScrollbarHighlightOnWheel = false;
            this.tabBL.HorizontalScrollbarSize = 10;
            this.tabBL.Location = new System.Drawing.Point(4, 38);
            this.tabBL.Name = "tabBL";
            this.tabBL.Size = new System.Drawing.Size(1031, 640);
            this.tabBL.TabIndex = 1;
            this.tabBL.Text = "BlockLaunch";
            this.tabBL.VerticalScrollbarBarColor = true;
            this.tabBL.VerticalScrollbarHighlightOnWheel = false;
            this.tabBL.VerticalScrollbarSize = 10;
            // 
            // rtbLogBl
            // 
            this.rtbLogBl.Location = new System.Drawing.Point(3, 3);
            this.rtbLogBl.Name = "rtbLogBl";
            this.rtbLogBl.ReadOnly = true;
            this.rtbLogBl.Size = new System.Drawing.Size(1025, 633);
            this.rtbLogBl.TabIndex = 2;
            this.rtbLogBl.Text = "";
            // 
            // tabMinecraft
            // 
            this.tabMinecraft.Controls.Add(this.rtbLogMinecraft);
            this.tabMinecraft.HorizontalScrollbarBarColor = true;
            this.tabMinecraft.HorizontalScrollbarHighlightOnWheel = false;
            this.tabMinecraft.HorizontalScrollbarSize = 10;
            this.tabMinecraft.Location = new System.Drawing.Point(4, 38);
            this.tabMinecraft.Name = "tabMinecraft";
            this.tabMinecraft.Size = new System.Drawing.Size(1031, 640);
            this.tabMinecraft.TabIndex = 2;
            this.tabMinecraft.Text = "Minecraft";
            this.tabMinecraft.VerticalScrollbarBarColor = true;
            this.tabMinecraft.VerticalScrollbarHighlightOnWheel = false;
            this.tabMinecraft.VerticalScrollbarSize = 10;
            // 
            // rtbLogMinecraft
            // 
            this.rtbLogMinecraft.Location = new System.Drawing.Point(3, 3);
            this.rtbLogMinecraft.Name = "rtbLogMinecraft";
            this.rtbLogMinecraft.ReadOnly = true;
            this.rtbLogMinecraft.Size = new System.Drawing.Size(1025, 633);
            this.rtbLogMinecraft.TabIndex = 2;
            this.rtbLogMinecraft.Text = "";
            // 
            // tabTools
            // 
            this.tabTools.AllowDrop = true;
            this.tabTools.BackColor = System.Drawing.Color.Transparent;
            this.tabTools.Controls.Add(this.grpOptifine);
            this.tabTools.Controls.Add(this.grpConverter);
            this.tabTools.HorizontalScrollbarBarColor = true;
            this.tabTools.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTools.HorizontalScrollbarSize = 10;
            this.tabTools.Location = new System.Drawing.Point(4, 38);
            this.tabTools.Name = "tabTools";
            this.tabTools.Size = new System.Drawing.Size(1038, 681);
            this.tabTools.TabIndex = 6;
            this.tabTools.Text = "Tools";
            this.tabTools.VerticalScrollbarBarColor = true;
            this.tabTools.VerticalScrollbarHighlightOnWheel = false;
            this.tabTools.VerticalScrollbarSize = 10;
            // 
            // grpOptifine
            // 
            this.grpOptifine.BackColor = System.Drawing.Color.Transparent;
            this.grpOptifine.Controls.Add(this.cmdRunInstaller);
            this.grpOptifine.Controls.Add(this.cmdBrowse);
            this.grpOptifine.Controls.Add(this.txbFile);
            this.grpOptifine.Controls.Add(this.lblOptifine);
            this.grpOptifine.Controls.Add(this.rtbLogInstaller);
            this.grpOptifine.Location = new System.Drawing.Point(514, 3);
            this.grpOptifine.Name = "grpOptifine";
            this.grpOptifine.Size = new System.Drawing.Size(512, 346);
            this.grpOptifine.TabIndex = 1;
            this.grpOptifine.TabStop = false;
            this.grpOptifine.Text = "BlockLaunch-OptiFine Installer";
            // 
            // cmdRunInstaller
            // 
            this.cmdRunInstaller.Location = new System.Drawing.Point(9, 50);
            this.cmdRunInstaller.Name = "cmdRunInstaller";
            this.cmdRunInstaller.Size = new System.Drawing.Size(497, 30);
            this.cmdRunInstaller.TabIndex = 7;
            this.cmdRunInstaller.Text = "Install Optifine";
            this.cmdRunInstaller.UseSelectable = true;
            this.cmdRunInstaller.Click += new System.EventHandler(this.cmdRunInstaller_Click);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(375, 21);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(131, 23);
            this.cmdBrowse.TabIndex = 4;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseSelectable = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txbFile
            // 
            this.txbFile.AllowDrop = true;
            this.txbFile.Lines = new string[0];
            this.txbFile.Location = new System.Drawing.Point(99, 21);
            this.txbFile.MaxLength = 32767;
            this.txbFile.Name = "txbFile";
            this.txbFile.PasswordChar = '\0';
            this.txbFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbFile.SelectedText = "";
            this.txbFile.Size = new System.Drawing.Size(270, 23);
            this.txbFile.TabIndex = 6;
            this.txbFile.UseSelectable = true;
            this.txbFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txbFile_DragDrop);
            this.txbFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txbFile_DragEnter);
            // 
            // lblOptifine
            // 
            this.lblOptifine.AutoSize = true;
            this.lblOptifine.Location = new System.Drawing.Point(9, 25);
            this.lblOptifine.Name = "lblOptifine";
            this.lblOptifine.Size = new System.Drawing.Size(84, 19);
            this.lblOptifine.TabIndex = 5;
            this.lblOptifine.Text = "Path to JAR: ";
            // 
            // rtbLogInstaller
            // 
            this.rtbLogInstaller.Location = new System.Drawing.Point(9, 86);
            this.rtbLogInstaller.Name = "rtbLogInstaller";
            this.rtbLogInstaller.ReadOnly = true;
            this.rtbLogInstaller.Size = new System.Drawing.Size(497, 249);
            this.rtbLogInstaller.TabIndex = 4;
            this.rtbLogInstaller.Text = "";
            this.rtbLogInstaller.WordWrap = false;
            // 
            // grpConverter
            // 
            this.grpConverter.BackColor = System.Drawing.Color.Transparent;
            this.grpConverter.Controls.Add(this.cmdConvertVersion);
            this.grpConverter.Controls.Add(this.rtbLogConvert);
            this.grpConverter.Location = new System.Drawing.Point(3, 3);
            this.grpConverter.Name = "grpConverter";
            this.grpConverter.Size = new System.Drawing.Size(505, 346);
            this.grpConverter.TabIndex = 0;
            this.grpConverter.TabStop = false;
            this.grpConverter.Text = "BlockLaunch-Converter";
            // 
            // cmdConvertVersion
            // 
            this.cmdConvertVersion.Location = new System.Drawing.Point(6, 19);
            this.cmdConvertVersion.Name = "cmdConvertVersion";
            this.cmdConvertVersion.Size = new System.Drawing.Size(493, 37);
            this.cmdConvertVersion.TabIndex = 3;
            this.cmdConvertVersion.Text = "Convert selected version";
            this.cmdConvertVersion.UseSelectable = true;
            this.cmdConvertVersion.Click += new System.EventHandler(this.cmdConvertVersion_Click);
            // 
            // rtbLogConvert
            // 
            this.rtbLogConvert.Location = new System.Drawing.Point(6, 62);
            this.rtbLogConvert.Name = "rtbLogConvert";
            this.rtbLogConvert.ReadOnly = true;
            this.rtbLogConvert.Size = new System.Drawing.Size(493, 273);
            this.rtbLogConvert.TabIndex = 2;
            this.rtbLogConvert.Text = "";
            this.rtbLogConvert.WordWrap = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 803);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "BlockLaunch - v0.3 Beta - Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tbpUpdates.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tbpMain.ResumeLayout(false);
            this.tbpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.tabLogs.ResumeLayout(false);
            this.tabLogSelection.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabBL.ResumeLayout(false);
            this.tabMinecraft.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.grpOptifine.ResumeLayout(false);
            this.grpOptifine.PerformLayout();
            this.grpConverter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbpUpdates;
        private WebKit.WebKitBrowser wkbMinecraftUpdates;
        private System.Windows.Forms.OpenFileDialog ofdOptifine;
        private MetroFramework.Controls.MetroTabControl tbcMain;
        private MetroFramework.Controls.MetroTabPage tbpMain;
        private MetroFramework.Controls.MetroButton cmdShowUUID;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private MetroFramework.Controls.MetroButton cmdRefreshProfile;
        private MetroFramework.Controls.MetroLabel lblCurrentVersion;
        private MetroFramework.Controls.MetroLabel lblWelcomeBack;
        private MetroFramework.Controls.MetroComboBox ckbVersions;
        private MetroFramework.Controls.MetroLabel lblSelectVersion;
        private MetroFramework.Controls.MetroButton cmdSettings;
        private MetroFramework.Controls.MetroButton cmdLogin;
        private MetroFramework.Controls.MetroButton cmdAddProfil;
        private MetroFramework.Controls.MetroComboBox ckbProfiles;
        private MetroFramework.Controls.MetroLabel lblProfile;
        private Controls.InfoProgressBar pgbDownload;
        private MetroFramework.Controls.MetroTabPage tabLogs;
        private MetroFramework.Controls.MetroTabControl tabLogSelection;
        private MetroFramework.Controls.MetroTabPage tabAll;
        private System.Windows.Forms.RichTextBox rtbLog;
        private MetroFramework.Controls.MetroTabPage tabBL;
        private System.Windows.Forms.RichTextBox rtbLogBl;
        private MetroFramework.Controls.MetroTabPage tabMinecraft;
        private System.Windows.Forms.RichTextBox rtbLogMinecraft;
        private System.Windows.Forms.ToolTip toolInfo;
        private MetroFramework.Controls.MetroTabPage tabTools;
        private System.Windows.Forms.GroupBox grpOptifine;
        private MetroFramework.Controls.MetroButton cmdRunInstaller;
        private MetroFramework.Controls.MetroButton cmdBrowse;
        private MetroFramework.Controls.MetroTextBox txbFile;
        private MetroFramework.Controls.MetroLabel lblOptifine;
        private System.Windows.Forms.RichTextBox rtbLogInstaller;
        private System.Windows.Forms.GroupBox grpConverter;
        private MetroFramework.Controls.MetroButton cmdConvertVersion;
        private System.Windows.Forms.RichTextBox rtbLogConvert;
        private MetroFramework.Controls.MetroButton cmdCopyProfile;
        private System.Windows.Forms.PictureBox picAuth;
        private System.Windows.Forms.PictureBox picAccounts;
        private System.Windows.Forms.PictureBox picSkins;
        private System.Windows.Forms.PictureBox picSession;
    }
}

