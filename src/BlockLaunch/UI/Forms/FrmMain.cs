using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BlockLaunch.Classes;
using BlockLaunch.Classes.JSON;
using BlockLaunch.Classes.JSON.Api;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using BlockLaunch.Classes.JSON.Login.Refresh;
using BlockLaunch.Classes.Language;
using BlockLaunch.Classes.Launcher;
using BlockLaunch.Classes.Minecraft;
using BlockLaunch.UI.Dialogs;
using Microsoft.Win32;
using nUpdate.Updating;
using Newtonsoft.Json;
using MetroFramework.Forms;

namespace BlockLaunch.UI.Forms
{
    public partial class FrmMain : MetroForm
    {
        public const string SkinServer = "https://minotar.net/helm/{0}/64.png";
        #region Values
        public static BlockLaunchManager Manager = BlockLaunchManager.Instance;
        private static Config _config;
        public static Language ApplicationLanguage;
        public static List<Language> AvailableLanguages;
        private static List<Profile> _availableProfiles;
        public static List<Classes.JSON.Version> AvailableVersions;
        public static VersionData LatestVersion;

        private bool _initializing = true;

        public static BindingSource ProfileSource = new BindingSource(typeof(ProfileData), "");
        public static BindingSource VersionSource = new BindingSource(typeof(VersionData), "");

        public delegate void ProfileChanged();

        public event ProfileChanged OnProfileChanged;

        private readonly Language _initializingLanguage = new Language
        {
            LogInfo = "Info",
            LogException = "Exception",
            LogWarning = "Warning",
            LogError = "Error"
        };

        private bool _playerCachedForThisSession;

        private readonly UpdateManager _manager = new UpdateManager(new Uri("http://kaskadekingde.cloudza.org/software/blocklaunch/updates/updates.json"), "<RSAKeyValue><Modulus>sDdtEyE3syjgMAjjAgZZ3ouWr55cfVm2p8R+q0g/y88YENxOTZryV8m1IfkLzMw7/anx5Xp+PePZQtdbHrbUCcwidyLZKrXEsrmqNky5T8/hKsatPenwhMVNwxvMZtCnBKtFQgNgDXg0pGdBPcFhjjlHam2gNWRkDz+/8PevJv5cM4EtbIv6v91EYkOQ0ZJJsst7hOAnc6vQnqM3ILJVE+woTdrzmtrNoh7E4wh8lBLerK9HFsqDccgYTlsdS1C4e4XXyFFt9NkWl0X9LewxWphgQ585NHE1xhWm9hDPnCF+vvIE1GWf/hP+hCZ3JZ2SLSnfMSf546Oq9mUZ3nu+k/Sca7yra56X7do+E7xmcUSM0yheIqK4ZGEbI2BGUnLYQRTR29aDorust8vSq5fc+sLwd7tie8Fpvup0Atex+lcZ8ptuVlsW9vGX3zwTZOOGgD/Y8n8g3ta+XITXHijgxLMQ+6uUSm9m4KNzuBYocDPLarn8kn8BTK83ZAHWjv4D1PP4MnOO1mRkJzhATnrDBXpNriwP8HbUcNXuKsvodceY0ooXRu2W8LCqzW7AbX7gzck3w6/DPAeM5bJzJhr1eCtcFXtUuOe/pohBtwi0bzRrkKYcrEtR+OkXDguKUZ4mPaAic6EYiyuVxu65zu7+tzGMsWl29usORoSwTS+yiq1EojUiUVbb3zx5cZ8CcJkHERoN83ZNDsknO+ldoTazqd0x+gy6JJp/24C18yg55yxdy+uxF2XRxRMFCWGSDwUjpzlU05mc2cqSPfFcY4bP9cA//QxkY/oPw0x1I5HW8GpTm47xuKRSu8TefqBQD2bDP9B3iIHb01H9yGhLnRc1WJoBmo78ZJdovkuRvnMG+X9XPW3BfiLjH+hRwEDoS4Q6gdAdzgvolm2n0Dq4dZ1kUZ9Lm1fVMuzIyBO/pbw9A6gnt9L+1jOejmqO1G9RITJfdZYoJPUQOJh/r3XymBKG9nw2LMk1fWtk4LJo+ATLUQLZtT6IC+ZCwsjopiQ4uyJjR0zXGSJuEeH0Cq7DeINrJXiuBKtOJFxKfK5GEc6uLI4BrHkyV7MHBbcFk5/cCdVyziyQBNN8tUe9PEEcl7K46Dt1OsIY+Ks1r9SGFBZ5tgKvDeYnU3PYkwbk7LRxzHgaS39na5DUQmZZBP4xipQgTIISFrctIs8q//g0PvworHG2sYX6cnxrxAoNru053FesbrZIBhPyEfi1UJpQKrEZT+Wr72DdLadzetH7Gy0wxy8uLGjSdtlMw6sfFtfmGePh9h59VFW6pKxPZQ/EEW/znt41kCmDbbMazETl4pAMWSVpIuexIEpm8HC50Z7gRA7WYxesjIZLQz4PCxUskOFYOQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", new CultureInfo("en"));

        public static Config ApplicationConfig
        {
            get { return _config; }
            set
            {
                _config = value;
                if(value != null)
                    Manager.SaveConfig(_config);
            }
        }

        public static List<Profile> AvailableProfiles
        {
            get { return _availableProfiles; }
            set
            {
                _availableProfiles = value;
                if (_availableProfiles != null)
                {
                    Manager.SaveProfiles(_availableProfiles);
                }
            }
        }


        #endregion

        #region Game-Management

        public void LoadServerStatus()
        {
            const string authentificationServer = "authserver.mojang.com";
            const string accountsServer = "account.mojang.com";
            const string minecraftSession = "session.minecraft.net";
            const string mojangSession = "sessionserver.mojang.com";
            const string skinsServer = "skins.minecraft.net";
            const string statusServer = "http://status.mojang.com/check?service=";

            string status;
            var resultAuth = LoginManager.GetRequest(statusServer + authentificationServer, out status);
            var resultAccount = LoginManager.GetRequest(statusServer + accountsServer, out status);
            var resultMinecraftSession = LoginManager.GetRequest(statusServer + minecraftSession, out status);
            var resultMojangSession = LoginManager.GetRequest(statusServer + mojangSession, out status);
            var resultSkins = LoginManager.GetRequest(statusServer + skinsServer, out status);

            resultAuth = resultAuth.Contains("green") ? "Online" : "Offline";
            resultAccount = resultAccount.Contains("green") ? "Online" : "Offline";
            resultMinecraftSession = resultMinecraftSession.Contains("green") ? "Online" : "Offline";
            resultMojangSession = resultMojangSession.Contains("green") ? "Online" : "Offline";
            resultSkins = resultSkins.Contains("green") ? "Online" : "Offline";

            toolInfo.SetToolTip(picAuth, "Authentification Server: " + resultAuth);
            toolInfo.SetToolTip(picAccounts, "Accounts Server: " + resultAccount);
            toolInfo.SetToolTip(picSession, "Minecraft Session Server: " + resultMinecraftSession + Environment.NewLine + "Mojang Session Server: " + resultMojangSession);
            toolInfo.SetToolTip(picSkins, "Skins Server: " + resultSkins);

            picAuth.Image = resultAuth == "Online" ? Properties.Resources.redstone_on : Properties.Resources.redstone_off;
            picAccounts.Image = resultAccount == "Online" ? Properties.Resources.redstone_on : Properties.Resources.redstone_off;
            picSession.Image = resultMojangSession == "Online" ? Properties.Resources.redstone_on : Properties.Resources.redstone_off;
            picSkins.Image = resultSkins == "Online" ? Properties.Resources.redstone_on : Properties.Resources.redstone_off;
        }
        #endregion

        #region Constructor
        // Constructor
        public FrmMain()
        {
            InitializeComponent();
            ckbProfiles.DataSource = ProfileSource;
            ckbProfiles.ValueMember = "UserProfile";
            ckbProfiles.DisplayMember = "ProfileName";
            ckbVersions.DataSource = VersionSource;
            ckbVersions.ValueMember = "Version";
            ckbVersions.DisplayMember = "TypeAndName";
            OnProfileChanged += ProfileHasChanged;
            
        }
        #endregion

        #region Form-Events
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manager = null;
            ApplicationConfig = null;
            ApplicationLanguage = null;
            GC.Collect();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var message = Manager.LogMessage("Initializing BlockLaunch...", BlockLaunchManager.LogMode.Information, true,
                _initializingLanguage);
            AppendBlocklaunchLog(message);
            LoadConfig();
            message = Manager.LogMessage("Loading language...", BlockLaunchManager.LogMode.Information, true,
                _initializingLanguage);
            AppendBlocklaunchLog(message);
            LoadLanguage();
            message = Manager.LogMessage("Loading theme & style...", BlockLaunchManager.LogMode.Information, true,
               _initializingLanguage);
            AppendBlocklaunchLog(message);
            ThemeHelper.ApplyTheme(this, ApplicationConfig);
            message = Manager.LogMessage("Loading versions...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);
            AppendBlocklaunchLog(message);
            LoadVersions();
            LoadCustomVersions();
            message = Manager.LogMessage("Loading profiles...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);
            AppendBlocklaunchLog(message);
            LoadProfiles();
            message = Manager.LogMessage("Loading server status...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);
            AppendBlocklaunchLog(message);
            LoadServerStatus();
            message = Manager.LogMessage("Caching player name & loading profile image...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);
            AppendBlocklaunchLog(message);
            LoadImage(ApplicationConfig.SelectedProfile);
            SearchForUpdates(false);
            _initializing = false;
        }
        #endregion

        #region Profile-Management

        private void LoadProfiles()
        {
            var profiles = Manager.LoadProfiles();
            if (profiles == null || profiles.Count == 0)
            {
                CreateNewProfile();
                profiles = Manager.LoadProfiles();
            }
            AvailableProfiles = profiles;
            FindAndSetProfile(ApplicationConfig.SelectedProfileString);
            if (ApplicationConfig.SelectedProfile == null)
            {
                ApplicationConfig.SelectedProfile = profiles.First();
            }
            if (!ApplicationConfig.SavePassword && !_playerCachedForThisSession)
            {
                var profile = ApplicationConfig.SelectedProfile;
                ChangeProfile(ref profile);
            }
            else if (ApplicationConfig.SavePassword && ApplicationConfig.SelectedProfile.Password == null)
            {
                var profile = ApplicationConfig.SelectedProfile;
                ChangeProfile(ref profile);
            }

            if (AvailableProfiles != null)
            {
                foreach (var data in AvailableProfiles)
                {
                    var addItemToList = true;
                    if (ProfileSource.Count != 0)
                    {
                        if (ProfileSource.Cast<object>().Select((t, i) => (ProfileData)ProfileSource.List[i]).Any(currentData => currentData.UserProfile == data && currentData.ProfileName == data.ProfileName))
                        {
                            addItemToList = false;
                        }
                    }
                    if (!addItemToList) continue;
                    var profileData = new ProfileData(data.ProfileName, data);
                    ProfileSource.Add(profileData);
                }
            }
            ckbProfiles.SelectedValue = ApplicationConfig.SelectedProfile;
            CacheProfile(ApplicationConfig.SelectedProfile);
            SelectProfile(ApplicationConfig.SelectedProfile);
            Manager.SaveProfiles(AvailableProfiles);
        }

        private static void RemoveProfile(Profile profile)
        {
            var profileToRemove = AvailableProfiles.Find(profileX => profileX.ProfileName == profile.ProfileName);
            if (profile == null)
                throw new ArgumentNullException("profile");
            if (profileToRemove == null)
                throw new ArgumentNullException("profile", @"Couldn't find profile that matches profile");
            var indexToRemove = -1;
            for (var i = 0; i < AvailableProfiles.Count; i++)
            {
                var currentData = AvailableProfiles[i];
                if (currentData.ProfileName != profileToRemove.ProfileName || currentData != profileToRemove) continue;
                indexToRemove = i;
                break;
            }
            if (indexToRemove == -1)
            {
                throw new ArgumentException("profile was not found in the list");
            }
            if (ProfileSource.Count != 0)
            {
                ProfileSource.RemoveAt(indexToRemove);
            }
            AvailableProfiles.Remove(profile);
        }

        private void ChangeProfile(ref Profile profile)
        {
            var login = new FrmLogin(ApplicationLanguage, AvailableProfiles, FrmLogin.LoginMode.EditProfile, profile);
            login.ShowDialog();
            profile.CachedUsername = login.UserProfile.CachedUsername;
            profile.AccessToken = login.UserProfile.AccessToken;
            profile.Password = login.UserProfile.Password;
            if (OnProfileChanged != null) OnProfileChanged();
            Manager.SaveProfiles(AvailableProfiles);
            ApplicationConfig.SelectedProfile = profile;
        }

        private void CreateNewProfile()
        {
            var login = new FrmLogin(ApplicationLanguage, AvailableProfiles);
            login.ShowDialog();
            if (login.UserProfile == null)
            {
                return;
            }
            if (AvailableProfiles == null)
            {
                AvailableProfiles = new List<Profile>();
            }
            _playerCachedForThisSession = false;
            AvailableProfiles.Add(login.UserProfile);
            var data = new ProfileData(login.UserProfile.ProfileName, login.UserProfile);
            ProfileSource.Add(data);
            CacheProfile(login.UserProfile);
            SelectProfile(login.UserProfile);
            if (OnProfileChanged != null) OnProfileChanged();
            Manager.SaveProfiles(AvailableProfiles);
        }

        private void CopyProfile()
        {
            var login = new FrmLogin(ApplicationLanguage, AvailableProfiles, FrmLogin.LoginMode.CopyProfile, ApplicationConfig.SelectedProfile);
            login.ShowDialog();
            if (login.UserProfile == null)
            {
                return;
            }
            if (AvailableProfiles == null)
            {
                AvailableProfiles = new List<Profile>();
            }
            _playerCachedForThisSession = false;
            AvailableProfiles.Add(login.UserProfile);
            var data = new ProfileData(login.UserProfile.ProfileName, login.UserProfile);
            ProfileSource.Add(data);
            CacheProfile(login.UserProfile);
            SelectProfile(login.UserProfile);
            if (OnProfileChanged != null) OnProfileChanged();
          
            Manager.SaveProfiles(AvailableProfiles);
        }

        private void SelectProfile(Profile profile)
        {
            if (!_playerCachedForThisSession) CacheProfile(profile);
            if (!_dontChange)
            {
                ckbProfiles.SelectedValue = profile;
            }

            lblWelcomeBack.Text = ApplicationLanguage.WelcomeBack.Replace("%player", profile.CachedUsername);
            if (profile.SelectedVersion == null)
            {
                profile.SelectedVersion = LatestVersion.Version;
            }
            var index = FindIndexVersion(profile.SelectedVersion);
            ApplicationConfig.SelectedProfile = profile;
            ckbVersions.SelectedIndex = index;
            if (_initializing)
            {
                ckbVersions_SelectedIndexChanged(this, null);
            }
            LoadImage(profile);
            cmdLogin.Enabled = true;
        }

        public void ProfileHasChanged()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ProfileHasChanged));
                return;
            }
            var profileInList = FindOldProfile(ApplicationConfig.SelectedProfile);
            if (profileInList == null)
                return;
            RemoveProfile(profileInList);
            profileInList = ApplicationConfig.SelectedProfile;
            var data = new ProfileData(profileInList.ProfileName, profileInList);
            if (ItemAlreadyAdded(profileInList)) return;
            AvailableProfiles.Add(profileInList);
            ProfileSource.Add(data);
        }

        private static Profile FindOldProfile(Profile newProfile)
        {
            var result = AvailableProfiles.Find(x => x.ProfileName == newProfile.ProfileName);
            return result;
        }

        private static bool ItemAlreadyAdded(Profile profile)
        {
            return (from object t in ProfileSource select (ProfileData)ProfileSource[0]).Any(data => data.UserProfile == profile);
        }
        #endregion

        #region Version-Management
        private static int FindIndexVersion(Classes.JSON.Version ver)
        {
            for (var i = 0; i < VersionSource.Count; i++)
            {
                var data = (VersionData)VersionSource[i];
                if (VersionEqual(data.Version, ver))
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool VersionEqual(Classes.JSON.Version ver1, Classes.JSON.Version ver2)
        {
            if (ver2.Equals(LatestVersion.Version))
            {
                return LatestVersion.Version.Id == ver1.Id && LatestVersion.Version.Type == ver1.Type;
            }
            return ver1.Id == ver2.Id && ver1.Type == ver2.Type && ver1.ReleaseTime == ver2.ReleaseTime;
        }

        private static void LoadVersions()
        {
            var versionManager = new VersionManager();
            var versions = versionManager.AvailableVersions();
            AvailableVersions = versions.VersionList;
            var latest = versions.VersionList.Find(id => id.Id == versions.Latest.Release && id.Type == "release");
            var latestData = new VersionData("(Latest) " + latest.Id, latest);
            LatestVersion = latestData;
            VersionSource.Add(latestData);
            foreach (var ver in versions.VersionList)
            {
                if (!ApplicationConfig.ShowAlpha && ver.Type == "old_alpha") continue;
                if (!ApplicationConfig.ShowBeta && ver.Type == "old_beta") continue;
                if (!ApplicationConfig.ShowSnapshot && ver.Type == "snapshot") continue;
                var type = "";
                switch (ver.Type)
                {
                    case "old_alpha":
                        type = "(Alpha)";
                        break;
                    case "old_beta":
                        type = "(Beta)";
                        break;
                    case "snapshot":
                        type = "(Snapshot)";
                        break;
                    case "release":
                        type = "(Release)";
                        break;
                }
                var name = type + " " + ver.Id;
                var data = new VersionData(name, ver);
                VersionSource.Add(data);
            }
        }

        private void LoadCustomVersions()
        {
            if (!Directory.Exists(@"minecraft\versions")) return;
            var di = new DirectoryInfo(@"minecraft\versions");
            foreach (var dir in di.GetDirectories())
            {
                if (!File.Exists(dir.FullName + @"\" + dir.Name + ".json") ||
                    !File.Exists(dir.FullName + @"\" + dir.Name + ".jar")) continue;
                var fileContent = File.ReadAllText(dir.FullName + @"\" + dir.Name + ".json");
                var json = JsonConvert.DeserializeObject<VersionInformation>(fileContent);
                if (json.Id != dir.Name) continue;
                if (VersionAlreadyAdded(json)) continue;
                var ver = new Classes.JSON.Version
                {
                    Id = json.Id,
                    ReleaseTime = json.ReleaseTime,
                    Time = json.Time,
                    Type = json.Type
                };
                var data = new VersionData("(" + json.Type + ") " + json.Id, ver);
                VersionSource.Add(data);
                AvailableVersions.Add(ver);
            }
        }

        private bool VersionAlreadyAdded(VersionInformation vf)
        {
            return AvailableVersions.Any(ver => ver.Id == vf.Id);
        }

        #endregion

        #region Launcher-Management
        private void LoadLanguage()
        {
            var languages = Manager.LoadLanguages();
            AvailableLanguages = languages;
            var validLang = languages.Any(item => item.CountryShortcut == ApplicationConfig.Language);
            if (validLang == false)
            {
                var message = Manager.LogMessage(
                    "Language " + ApplicationConfig.Language + " does not exists (anymore)",
                    BlockLaunchManager.LogMode.Error, true, _initializingLanguage);
                AppendBlocklaunchLog(message);
                ApplicationConfig.Language = languages.First().CountryShortcut;
                ApplicationLanguage = languages.First();
                ApplyLanguage("null", "null");
            }
            else
            {
                foreach (var lang in languages.Where(lang => lang.CountryShortcut == ApplicationConfig.Language))
                {
                    ApplicationLanguage = lang;
                }
            }
            ApplyLanguage("null", "null");
        }

        private void LoadConfig()
        {
            if (!Manager.ConfigExists())
            {
                Manager.GenerateConfigFile();
            }
            if (!Manager.ConfigAccessable())
            {
                var message = Manager.LogMessage("Failed to access config file. Reason: Access denied.", BlockLaunchManager.LogMode.Error, true, _initializingLanguage);
                AppendBlocklaunchLog(message);
                var errorDialog = new Dialog(Dialog.StatusMode.Error, "Error", "Failed to load config",
                    "Failed to load config because the access denied!", _initializingLanguage, "Please try delete your config and start the launcher again.");
                errorDialog.ShowDialog();
                Environment.Exit(5);
            }
            ApplicationConfig = Manager.LoadConfig();
        }

        private void SearchForUpdates(bool showDialog)
        {
            var message = Manager.LogMessage("Searching for updates...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);

            AppendBlocklaunchLog(message);
            _manager.IncludeAlpha = false;
            _manager.IncludeBeta = true;
            _manager.IncludeCurrentPcIntoStatistics = false;
            var updaterui = new UpdaterUI(_manager, SynchronizationContext.Current, !showDialog);
            updaterui.ShowUserInterface();
        }

        private void AppendBlocklaunchLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendBlocklaunchLog), message);
            }
            else
            {
                rtbLog.AppendText(message + Environment.NewLine);
                rtbLogBl.AppendText(message + Environment.NewLine);
            }

        }

        private void AppendConverterLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendConverterLog), message);
            }
            else
            {
                rtbLogConvert.AppendText(message + Environment.NewLine);
            }
        }

        private void AppendInstallerLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendInstallerLog), message);
            }
            else
            {
                rtbLogInstaller.AppendText(message + Environment.NewLine);
            }
        }

        private void AppendMinecraftLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMinecraftLog), message);
            }
            else
            {
                rtbLog.AppendText(message + Environment.NewLine);
                rtbLogMinecraft.AppendText(message + Environment.NewLine);
            }

        }

        private void ApplyLanguage(string gameVersion, string player)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                          Assembly.GetExecutingAssembly().GetName().Version.Minor;
            Text = ApplicationLanguage.Title.Replace("%ver", version) + @" - " + ApplicationLanguage.MainMenuTitle;
            tbpMain.Text = ApplicationLanguage.TabpageHome;
            tbpUpdates.Text = ApplicationLanguage.TabpageUpdates;
            tabLogs.Text = ApplicationLanguage.TabpageLogs;
            tabBL.Text = ApplicationLanguage.TabpageLogsBlocklaunch;
            tabTools.Text = ApplicationLanguage.TabpageTools;
            tabAll.Text = ApplicationLanguage.TabpageLogsAll;
            tabMinecraft.Text = ApplicationLanguage.TabpageLogsMinecraft;
            tabTools.Text = ApplicationLanguage.TabpageTools;
            grpOptifine.Text = ApplicationLanguage.OptifineInstaller;
            grpConverter.Text = ApplicationLanguage.Converter;
            cmdConvertVersion.Text = ApplicationLanguage.ConvertSelectedVersion;
            cmdBrowse.Text = ApplicationLanguage.Browse;
            lblOptifine.Text = ApplicationLanguage.PathToJar;
            cmdRunInstaller.Text = ApplicationLanguage.InstallOptifine;
            lblWelcomeBack.Text = ApplicationLanguage.WelcomeBack.Replace("%player", player);
            lblSelectVersion.Text = ApplicationLanguage.Version;
            cmdShowUUID.Text = ApplicationLanguage.ShowUuid;
            lblCurrentVersion.Text = ApplicationLanguage.SelectedVersion.Replace("%game_ver", gameVersion);
            lblProfile.Text = ApplicationLanguage.Profile;
            cmdSettings.Text = ApplicationLanguage.Settings;
            cmdLogin.Text = ApplicationLanguage.LoginAndPlay;
            cmdRefreshProfile.Text = ApplicationLanguage.RefreshProfile;
            cmdAddProfil.Text = ApplicationLanguage.AddProfile;
            cmdCopyProfile.Text = ApplicationLanguage.CopyProfile;
        }

        
        #endregion

        #region Player-Management

        private void LoadImage(Profile profile)
        {
            var downloader = new WebClient { Proxy = null };
            var byteImage = downloader.DownloadData(string.Format(SkinServer, profile.CachedProfile.Name));
            var ms = new MemoryStream(byteImage);
            var skinImage = Image.FromStream(ms);
            ms.Dispose();
            ptbAvatar.Image = skinImage;
        }

        private void CacheProfile(Profile profile)
        {
            if (profile.CachedProfile != null) return;
            var result = LoginManager.GetProfile(profile.Uuid);
            if (result != null)
            {
                var resultInstance = JsonConvert.DeserializeObject<UuidToProfile>(result);
                _playerCachedForThisSession = true;
                profile.CachedProfile = resultInstance;
                profile.CachedProfileString = Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
            }
            else
            {
                if (profile.CachedProfileString != null)
                {
                    var jsonString = Encoding.UTF8.GetString(Convert.FromBase64String(profile.CachedProfileString));      
                    var resultInstance = JsonConvert.DeserializeObject<UuidToProfile>(jsonString);
                    profile.CachedProfile = resultInstance;
                    _playerCachedForThisSession = true;
                }
            }
        }

        #endregion

        #region Login

        private static string JavaPath()
        {
            const string javaKey = @"SOFTWARE\JavaSoft\Java Runtime Environment";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                if (baseKey == null) return null;
                var currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                using (var homeKey = baseKey.OpenSubKey(currentVersion))
                    if (homeKey != null) return homeKey.GetValue("JavaHome") + @"\bin\javaw.exe";
            }
            return null;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            cmdLogin.Enabled = false;
            var loginThread = new Thread(LoginAndPlay);
            loginThread.Start();
        }

        private bool _downloadedMomentsAgo;

        private void LoginAndPlay()
        {
            Invoke(new Action(rtbLogMinecraft.Clear));
            SetDownloadProgressBarText("Preparing...");
            var javaw = JavaPath();
            var loginManager = new LoginManager();
            var args = new Refresh
            {
                AccessToken = ApplicationConfig.SelectedProfile.AccessToken,
                ClientToken = ApplicationConfig.SelectedProfile.ClientToken,
            };
            var result = loginManager.Refresh(args);
            if (!result.Status)
            {
                if (ApplicationConfig.SavePassword && ApplicationConfig.SelectedProfile.Password != null)
                {
                    var login = new FrmLogin(ApplicationLanguage, AvailableProfiles, FrmLogin.LoginMode.EditProfile,
                        ApplicationConfig.SelectedProfile);
                    login.SilentLogin(ApplicationConfig.SelectedProfile.Email,
                        ApplicationConfig.SelectedProfile.Password);
                    ApplicationConfig.SelectedProfile = login.UserProfile;
                    if (OnProfileChanged != null) OnProfileChanged();
                }
                else
                {
                    if (result.Error.ErrorString == "ForbiddenOperationException")
                    {
                        var message = Manager.LogMessage("Invalid session. User need to login.",
                            BlockLaunchManager.LogMode.Warning, true, ApplicationLanguage);
                        AppendBlocklaunchLog(message);
                        var profile = ApplicationConfig.SelectedProfile;
                        ChangeProfile(ref profile);
                    }
                    else
                    {
                        string message;
                        if (String.IsNullOrEmpty(result.Error.Cause))
                        {
                            message = ApplicationLanguage.ExceptionType + result.Error.ErrorString + Environment.NewLine +
                                      ApplicationLanguage.ErrorMessage +
                                      result.Error.ErrorMessage;
                        }
                        else
                        {
                            message = ApplicationLanguage.ExceptionType + result.Error.ErrorString + Environment.NewLine +
                                      ApplicationLanguage.ErrorMessage +
                                      result.Error.ErrorMessage + Environment.NewLine + ApplicationLanguage.Cause + result.Error.Cause;
                        }
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.RefreshFailedTitle,
                            ApplicationLanguage.RefreshFailedStatus, ApplicationLanguage.RefreshFailedDetails,
                            ApplicationLanguage, message);
                        errorDialog.ShowDialog();
                        return;
                    }
                }

            }
            else
            {
                ApplicationConfig.SelectedProfile.AccessToken = result.oRefreshResponse.AccessToken;
                if (OnProfileChanged != null) OnProfileChanged();
            }

            var infos = VersionInstalled(ApplicationConfig.SelectedProfile.SelectedVersion.Id) ? VersionManager.ReadVersionInfos(ApplicationConfig.SelectedProfile.SelectedVersion.Id) : new VersionManager().VersionInfos(ApplicationConfig.SelectedProfile.SelectedVersion.Id);

            if (infos.ParentVersion != null)
            {
                var error = new Dialog(Dialog.StatusMode.Info, ApplicationLanguage.ConversionRequired,
                    ApplicationLanguage.ConversionStatus,
                    ApplicationLanguage.ConversionDetails, ApplicationLanguage);
                error.ShowDialog();
                SetPage(tabTools);
                return;
            }
            if (!VersionInstalled(ApplicationConfig.SelectedProfile.SelectedVersion.Id) && infos.ParentVersion == null)
            {
                CreateDefaultDirectorys(ApplicationConfig.SelectedProfile.SelectedVersion.Id);
                DownloadVersion(ApplicationConfig.SelectedProfile.SelectedVersion);
                _downloadedMomentsAgo = true;
            }
            if (!_downloadedMomentsAgo)
            {
                DownloadLibraries(ApplicationConfig.SelectedProfile.SelectedVersion);
                if (_cancel)
                {
                    _cancel = false;
                    var error = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.DownloadFailedTitle,
                        ApplicationLanguage.DownloadFailedStatus,
                        ApplicationLanguage.DownloadFailedDetails, ApplicationLanguage);
                    error.ShowDialog();
                    return;
                }
                _downloadedMomentsAgo = true;
            }
            if (!File.Exists(@"minecraft\launcher_profiles.json"))
            {
                File.Create(@"minecraft\launcher_profiles.json");
            }
            var home = AppDomain.CurrentDomain.BaseDirectory + "minecraft";
            var versionsDir = home + @"\versions";
            var versionDir = versionsDir + @"\" + ApplicationConfig.SelectedProfile.SelectedVersion.Id;
            var versionInformation = File.ReadAllText(versionDir + @"\" + ApplicationConfig.SelectedProfile.SelectedVersion.Id + ".json");
            var json = JsonConvert.DeserializeObject<VersionInformation>(versionInformation);
            var nativeFolder = new NativeManager().ExtractNatives(json);
            var launchManager = new LaunchManager();
            var jvmArgs = launchManager.JvmArguments(nativeFolder);
            var dependencies = launchManager.Dependencies(json);
            var options = launchManager.MinecraftArguments(json, ApplicationConfig.SelectedProfile, ApplicationConfig);
            var arguments = jvmArgs + " " + dependencies + " " + options;
            var java = new Process();
            var javaStart = new ProcessStartInfo(javaw)
            {
                Arguments = arguments,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = home
            };
            java.StartInfo = javaStart;
            java.ErrorDataReceived += (sender, e) =>
            {
                AppendMinecraftLog(e.Data);
            };
            java.OutputDataReceived += (sender, e) => AppendMinecraftLog(e.Data);
            java.Start();
            java.BeginOutputReadLine();
            java.BeginErrorReadLine();
            ToggleFormVisiblity(false);
            SetDownloadProgressBarText("");
            SetProgressBarValue(0, 100);
            java.WaitForExit();
            ToggleFormVisiblity(true);
            Directory.Delete(nativeFolder, true);
            if (java.ExitCode != 0)
            {
                const string startTag = "---- Minecraft Crash Report ----";
                const string endTag = "#@!@#";
                var text = GetTextFromControl(rtbLogMinecraft);
                var pos1 = text.IndexOf(startTag, StringComparison.Ordinal) + startTag.Length;
                var pos2 = text.IndexOf(endTag, StringComparison.Ordinal);
                if (pos1 == -1 || pos2 == -1)
                {
                    EnableLoginButton(true);
                    return;
                }
                var match = text.Substring(pos1, pos2 - pos1);
                match = startTag + match;
                match = match.TrimEnd();
                GenerateCrashReportTab(match);
            }
            EnableLoginButton(true);
        }

        private void GenerateCrashReportTab(string crash)
        {
            var page = new TabPage(ApplicationLanguage.CrashReport + DateTime.Now.ToString("HH:mm:ss"));
            var crashBox = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true };
            page.Controls.Add(crashBox);
            AddPage(page);
            SetText(crashBox, crash);
            SetPage(page);
            page.Leave += page_Leave;
        }

        private void page_Leave(object sender, EventArgs e)
        {
            var page = sender as TabPage;
            if (page == null) return;
            page.Controls.Clear();
            tbcMain.TabPages.Remove(page);
            page.Dispose();
        }
        #endregion

        #region Download
        private void DownloadVersion(Classes.JSON.Version ver)
        {
            var downloadManager = new DownloadManager();
            downloadManager.OnDownloadStarted += downloadManager_OnDownloadStarted;
            downloadManager.OnDownloadFinished += downloadManager_OnDownloadFinished;
            downloadManager.DownloadVersion(ver);
        }

        private void DownloadLibraries(Classes.JSON.Version ver)
        {
            var downloadManager = new DownloadManager();
            downloadManager.OnDownloadStarted += downloadManager_OnDownloadStarted;
            downloadManager.OnDownloadFinished += downloadManager_OnDownloadFinished;
            downloadManager.DownloadLibraries(ver);
        }

        private void downloadManager_OnDownloadFinished(object sender, DownloadManager.DownloadFinishedArgs e)
        {
            SetProgressBarValue(e.DownloadedFileCount, e.TotalFiles);
        }

        private bool _cancel;

        private void downloadManager_OnDownloadStarted(object sender, DownloadManager.DownloadStartedArgs e)
        {
            switch (e.FileType)
            {
                case "version":
                    SetDownloadProgressBarText("Downloading version informations...");
                    break;
                case "lib":
                    SetDownloadProgressBarText("Downloading librarie " + e.DownloadedFile);
                    break;
                case "lib_sha":
                    SetDownloadProgressBarText("Downloading SHA1 Hash from librarie " + e.DownloadedFile);
                    break;
                case "failed_can_continue":
                    AppendMinecraftLog(e.DownloadedFile);
                    break;
                case "failed":
                    AppendMinecraftLog(e.DownloadedFile);
                    _cancel = true;
                    break;
                case "asset":
                    SetDownloadProgressBarText("Downloading asset " + e.DownloadedFile);
                    break;
                case "finished":
                    SetDownloadProgressBarText("Download finished!");
                    break;
            }
        }
        #endregion

        #region Launch
        private static void CreateDefaultDirectorys(string id)
        {
            Directory.CreateDirectory("minecraft");
            Directory.CreateDirectory(@"minecraft\versions");
            Directory.CreateDirectory(@"minecraft\versions\" + id);
            Directory.CreateDirectory(@"minecraft\libraries");
            Directory.CreateDirectory(@"minecraft\assets");
        }

        private static bool VersionInstalled(string id)
        {
            var home = AppDomain.CurrentDomain.BaseDirectory + "minecraft";
            var versionsDir = home + @"\versions";
            var versionDir = versionsDir + @"\" + id;
            if (!Directory.Exists(home))
            {
                Directory.CreateDirectory(home);
                return false;
            }
            if (!Directory.Exists(versionsDir))
            {
                Directory.CreateDirectory(versionsDir);
                return false;
            }
            if (!Directory.Exists(versionDir))
            {
                Directory.CreateDirectory(versionDir);
                return false;
            }
            if (!File.Exists(versionDir + @"\" + id + ".json") || !File.Exists(versionDir + @"\" + id + ".jar"))
            {
                return false;
            }
            try
            {
                var content = File.ReadAllText(versionDir + @"\" + id + ".json");
                var json = JsonConvert.DeserializeObject<VersionInformation>(content);
                if (json.Id != id)
                {
                    return false;
                }
                return true;
            }
            catch (JsonException)
            {
                return false;
            }

        }
        #endregion

        #region Click-Events
        private void cmdSettings_Click(object sender, EventArgs e)
        {
            var settings = new FrmSettings(ApplicationConfig, ApplicationLanguage, AvailableLanguages);
            settings.ShowDialog();
            if (settings.NewConfig != null && !ApplicationConfig.Equals(settings.NewConfig))
            {
                foreach (var item in AvailableLanguages.Where(item => item.CountryShortcut == settings.NewConfig.Language))
                {
                    ApplicationLanguage = item;
                }
                ApplicationConfig = settings.NewConfig;
                var ver = ApplicationConfig.SelectedProfile.SelectedVersion.Type + " " +
                          ApplicationConfig.SelectedProfile.SelectedVersion.Id;
                ApplyLanguage(ver, ApplicationConfig.SelectedProfile.CachedUsername);
                ThemeHelper.ApplyTheme(this, ApplicationConfig);
            }
        }

        private void cmdShowUUID_Click(object sender, EventArgs e)
        {
            var user = ApplicationConfig.SelectedProfile.CachedProfile.Name;
            var result = MessageBox.Show(
                @"UUID: " + ApplicationConfig.SelectedProfile.Uuid + Environment.NewLine + ApplicationLanguage.Username + user + Environment.NewLine + Environment.NewLine +
                ApplicationLanguage.CopyUuid, ApplicationLanguage.PlayerInformation, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Clipboard.SetText(ApplicationConfig.SelectedProfile.Uuid);
            }
        }

        private void cmdRefreshProfile_Click(object sender, EventArgs e)
        {
            SelectProfile(ApplicationConfig.SelectedProfile);
        }

        private void cmdAddProfil_Click(object sender, EventArgs e)
        {
            CreateNewProfile();
        }


        private void cmdCopyProfile_Click(object sender, EventArgs e)
        {
            CopyProfile();
        }
        #endregion

        #region SelectedIndexChanged-Events
        private void ckbVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var version = (Classes.JSON.Version)ckbVersions.SelectedValue;
            if (version == ApplicationConfig.SelectedProfile.SelectedVersion) return;
            if (version == null)
            {
                ckbVersions.SelectedIndex = 0;
                return;
            }
            ApplicationConfig.SelectedProfile.SelectedVersion = version;
            if (OnProfileChanged != null) OnProfileChanged();
            lblCurrentVersion.Text = ApplicationLanguage.SelectedVersion.Replace("%game_ver", version.Type + " " + version.Id);
            Manager.SaveProfiles(AvailableProfiles);
            _downloadedMomentsAgo = false;
        }

        private bool _dontChange;


        private void ckbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            var profile = (Profile)ckbProfiles.SelectedValue;
            if (profile == null) return; // Wait until profile has been readded to BindingSource
            if (profile == ApplicationConfig.SelectedProfile) return;
            if (!ApplicationConfig.SavePassword)
            {
                if (!_playerCachedForThisSession)
                {
                    ChangeProfile(ref profile);
                }
            }
            else
            {
                var login = new LoginManager();
                var ao = new AuthentificateObjects { Email = profile.Email, Password = profile.Password };
                var result = login.Authentificate(ao);
                if (!result.Status)
                {
                    ChangeProfile(ref profile);
                }
            }
            
            CacheProfile(profile);
            ApplicationConfig.SelectedProfile = profile;
            _dontChange = true;
            SelectProfile(ApplicationConfig.SelectedProfile);
            Manager.SaveProfiles(AvailableProfiles);
        }
        #endregion

        #region Invoke-Methods
        private void SetProgressBarValue(int value, int maximum)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int>(SetProgressBarValue), value, maximum);
            }
            else
            {
                pgbDownload.Maximum = maximum;
                pgbDownload.Value = value;
            }
        }

        private void SetDownloadProgressBarText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetDownloadProgressBarText), text);
            }
            else
            {
                pgbDownload.HideProgressText = false;
                pgbDownload.ProgressText = text;
                pgbDownload.Refresh();
            }

        }

        private void AddPage(TabPage tp)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TabPage>(AddPage), tp);
            }
            else
            {
                tbcMain.TabPages.Add(tp);
            }
        }

        private void SetPage(TabPage tp)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TabPage>(SetPage), tp);
            }
            else
            {
                tbcMain.SelectedTab = tp;
            }
        }

        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
            else
            {
                control.Text = text;
            }
        }

        private string GetTextFromControl(Control control)
        {
            if (control.InvokeRequired)
            {
                return (string)control.Invoke(new Func<string>(() => GetTextFromControl(control)));
            }
            return control.Text;
        }

        private void ToggleFormVisiblity(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(ToggleFormVisiblity), value);
            }
            else
            {
                Visible = value;
            }
        }

        private void EnableLoginButton(bool value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(EnableLoginButton), value);
            }
            else
            {
                cmdLogin.Enabled = value;
            }
        }
        #endregion

        #region Tools

        private void cmdConvertVersion_Click(object sender, EventArgs e)
        {
            if (!VersionInstalled(ApplicationConfig.SelectedProfile.SelectedVersion.Id))
            {
                var errorDialog = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.VersionNotInstalledTitle,
                     ApplicationLanguage.VersionNotInstalledStatus, ApplicationLanguage.VersionNotInstalledDetails,
                    ApplicationLanguage);
                errorDialog.ShowDialog();
                return;
            }
            var json = VersionManager.ReadVersionInfos(ApplicationConfig.SelectedProfile.SelectedVersion.Id);
            if (json.ParentVersion == null)
            {
                var errorDialog = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.NoParentTitle,
                   ApplicationLanguage.NoParentStatus, ApplicationLanguage.NoParentDetails,
                    ApplicationLanguage);
                errorDialog.ShowDialog();
                return;
            }
            if (!File.Exists(@"tools\block_converter.exe"))
            {
                var errorDialog = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.ConverterNotInstalledTitle,
                    ApplicationLanguage.ConverterNotInstalledStatus, ApplicationLanguage.InstallTools,
                    ApplicationLanguage);
                errorDialog.ShowDialog();
            }
            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"tools\block_converter.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.StartInfo.Arguments += json.ParentVersion + " " +
                                           ApplicationConfig.SelectedProfile.SelectedVersion.Id;
            process.OutputDataReceived += process_OutputDataReceived;
            process.Start();
            process.BeginOutputReadLine();
        }

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            AppendConverterLog(e.Data);
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (ofdOptifine.ShowDialog() == DialogResult.OK)
            {
                txbFile.Text = ofdOptifine.FileName;
            }
        }

        private void cmdRunInstaller_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"tools\block_optifine_installer.exe"))
            {
                var errorDialog = new Dialog(Dialog.StatusMode.Error, ApplicationLanguage.InstallerNotInstalledTitle,
                    ApplicationLanguage.InstallerNotInstalledStatus, ApplicationLanguage.InstallTools,
                    ApplicationLanguage);
                errorDialog.ShowDialog();
            }
            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"tools\block_optifine_installer.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.StartInfo.Arguments += txbFile.Text;
            process.OutputDataReceived += (obj, args) => AppendInstallerLog(args.Data);
            process.Start();
            process.BeginOutputReadLine();
        }
        #endregion

        #region Drag & Drop
        private void txbFile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void txbFile_DragDrop(object sender, DragEventArgs e)
        {
            var fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in fileList.Where(item => item.EndsWith(".jar") || item.EndsWith(@".jar""")))
            {
                txbFile.Text = item;
                break;
            }
            if (String.IsNullOrEmpty(txbFile.Text))
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }
        #endregion

        private void pic_Click(object sender, EventArgs e)
        {
            LoadServerStatus();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                SearchForUpdates(true);
            }
        }

        private void FindAndSetProfile(string uuid)
        {
            var found = false;
            foreach (var profile in AvailableProfiles.Where(p => p.Uuid == uuid))
            {
                ApplicationConfig.SelectedProfile = profile;
                found = true;
            }
            if (!found)
            {
                ApplicationConfig.SelectedProfile = AvailableProfiles.First();
            }
        }

    }
    #region DataBinding-Classes

    public class ProfileData
    {
        public string ProfileName { get; set; }
        public Profile UserProfile { get; set; }

        public ProfileData(string username, Profile profile)
        {
            ProfileName = username;
            UserProfile = profile;
        }
    }

    public class VersionData
    {
        public string TypeAndName { get; set; }
        public Classes.JSON.Version Version { get; set; }

        public VersionData(string name, Classes.JSON.Version version)
        {
            TypeAndName = name;
            Version = version;
        }
    }
    #endregion
}
