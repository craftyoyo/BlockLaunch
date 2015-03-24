using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using BlockLaunch.Classes;
using BlockLaunch.Classes.JSON;
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

        private readonly UpdateManager _updater = new UpdateManager(new Uri("http://kaskade-dev.cwsurf.de/projects/blocklaunch/updates.json"), "<RSAKeyValue><Modulus>wUv6rCdDcaZA4reehYFfZblqa5AVxs8ODyRTNgq2v/aGtiUqY8VSd1rBjRlPjUQY87sDq9T0KZWaOJMQRIxsva5IGrfhf917wA300Db7WudKvVfGQsBb0ng834C0WpNxRDhMtfa4HeDA9YuGUJITPotxgJ6rvrZrkqjUH4RXVkf+4Yy/6dBtOlozxO12xd8fGbNCHa4vsfyI1uKikiFyO0r4h8uzY+x3Fs9O30vuTUOewJrEWlBBodm/BvmiuYbOprsINckGhcLeX4Nq40hoSB0caPXFr1tBcGSS/sQ4z8yOkacWMixHImToecABy+tGVXP4S2xu2yf4IRx0dJLg2y6/vpEl6/2829IvrsVIAJI8Y5X/uFrZweitwKhBRN1OaNa3dTAluEVqBHwAkr0A7fmZsv4Q48KpmHlClnqwW3qscPT59j7WUHUV+Cs2qL1rBHmBhWkHL9oSUA04ztCA6a6pz2D/5Hcs5MYXrS+Im6LdK0C2QG9OrJXZ3W7yTmA3ObDSWuOgT8s+DDof1yMePySAQmHDgklx76mDQ2GFJpjC2o5YH5XpoTMrH5yjvbh6GF2ojSkM5z504I9T0CyfLBRyz7Rydh9FtS5jEwWcp014X5c16LkFF+g4AtxMaFGk3NXIomqlLaUH9d7ON21j5T9nEAqpZLWz0WEauFzIDzPtOLDOvScsqlJl4ekWg4skF2ccVeaVPf03AIx+mmCU1Z4oHdqVTHB9V6vVeAbghwze+Fm9Fh/t2ApxBZIw08cKyXp+LQF0U7856b5aOkQbeM32o2PvCFqf7oa18bHTBLcMziv0OVmQK2gGAsK/LMZRmdfsHVmIatVzEv/q3nZ5uhOGhxYUYImqmZqWUP07IJMEWNc/J4/PLLQZtNG9SABNZnDKFm5Ii5eDpGBW5rA6IDmqZjK1qArFQFFhgc7sPxTucErTT6WlmS1zgZV0imqy44kuZxEQEgffD2HU0F78xI3rBwY5+rcwNYiIqysXRxCuyfD4rP24ruOBCJboY6pV5xJRUhQ1cxgGJ/NYB3F7n8f/RcWgVgFvh5BgZijOoGIrMu1YmZ39PUBmh2qdtmloySQzXfh5j81JTvBQLosJxq0DrFVoBNyiymcUyZkK76sUKd1c97NRF4R/opnNWD6PmgP2VP+h9GGmJQMEfRBkMT818JdLgBHY5xVcrn/+xZVxrxi4+gF7Ahu+EzXt8DPVAKqaHjeoV1oRCczMQCuJNS0Eyivnz68p/UfhD7cWyV7TrCYcN4ONv0jIA2qNIBiomtQxXIiP7XB+9EHQxvxvlQ0DgBySwK3nds1wLCjnQTBoTKyEizKi75J8iKwA8gXqWQpSQ/H3rGJ9cmrRFmhgHw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", new UpdateVersion("0.3.1.0b1"), CultureInfo.CurrentCulture);

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
            var name = LoginManager.GetPlayerName(ApplicationConfig.SelectedProfile.Uuid);
            LoadImage(name ?? ApplicationConfig.SelectedProfile.CachedUsername);
            SearchForUpdates();
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
            if (ApplicationConfig.SelectedProfile == null)
            {
                ApplicationConfig.SelectedProfile = profiles.First();
            }
            AvailableProfiles = profiles;
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
            CachePlayerName(ApplicationConfig.SelectedProfile);
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
            ApplicationConfig.SelectedProfile = login.UserProfile;
            if (OnProfileChanged != null) OnProfileChanged();
            SelectProfile(login.UserProfile);
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
            ApplicationConfig.SelectedProfile = login.UserProfile;
            if (OnProfileChanged != null) OnProfileChanged();
            SelectProfile(login.UserProfile);
            Manager.SaveProfiles(AvailableProfiles);
        }

        private void SelectProfile(Profile profile)
        {
            if (!_playerCachedForThisSession) CachePlayerName(profile);
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
            LoadImage(profile.CachedUsername);
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

        private void SearchForUpdates()
        {
            var message = Manager.LogMessage("Searching for updates...", BlockLaunchManager.LogMode.Information, true,
                ApplicationLanguage);

            AppendBlocklaunchLog(message);
            _updater.IncludeAlpha = false;
            _updater.IncludeBeta = true;
            _updater.IncludeCurrentPcIntoStatistics = false;
            _updater.UseHiddenSearch = true;
            var updaterui = new UpdaterUi(_updater);
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
        }

        
        #endregion

        #region Player-Management
        private void LoadImage(string username)
        {
            var downloader = new WebClient { Proxy = null };
            var byteImage = downloader.DownloadData("http://achievecraft.com/tools/avatar/64/" + username + ".png");
            var ms = new MemoryStream(byteImage);
            var returnImage = Image.FromStream(ms);
            ptbAvatar.Image = returnImage;
        }



        private void CachePlayerName(Profile profile)
        {
            if (_playerCachedForThisSession) return;
            var result = LoginManager.GetPlayerName(profile.Uuid);
            if (result != null)
            {
                _playerCachedForThisSession = true;
            }
        }

        private string GetPlayerName(string uuid)
        {
            var result = LoginManager.GetPlayerName(uuid);
            if (result != null)
            {
                if (result != ApplicationConfig.SelectedProfile.CachedUsername)
                {
                    ApplicationConfig.SelectedProfile.CachedUsername = result;
                    if (OnProfileChanged != null) OnProfileChanged();
                    LoadImage(result);
                    return result;
                }
                return result;
            }

            return ApplicationConfig.SelectedProfile.CachedUsername;
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
            ToggleVisibleOnProgressBar(true);
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
            var options = launchManager.MinecraftArguments(json, ApplicationConfig.SelectedProfile);
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
            ToggleVisibleOnProgressBar(false);
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
            SetDownloadProgressBarText("null");
            ToggleVisibleOnProgressBar(false);
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
            var user = GetPlayerName(ApplicationConfig.SelectedProfile.Uuid);
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
            ApplicationConfig.SelectedProfile.SelectedVersion = new Classes.JSON.Version
            {
                Id = version.Id,
                ReleaseTime = version.ReleaseTime,
                Time = version.Time,
                Type = version.Type,
            };
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
            ApplicationConfig.SelectedProfile = profile;
            CachePlayerName(ApplicationConfig.SelectedProfile);
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
                pgbDownload.Refresh();
            }

        }

        private void ToggleVisibleOnProgressBar(bool visible)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(ToggleVisibleOnProgressBar), visible);
            }
            else
            {
                pgbDownload.Visible = visible;
                pgbDownload.Value = 0;
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
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.StartInfo.Arguments += json.ParentVersion + " " +
                                           ApplicationConfig.SelectedProfile.SelectedVersion.Id;
            process.OutputDataReceived += process_OutputDataReceived;
            process.Start();
            process.BeginOutputReadLine();
            while (!process.HasExited)
            {
                Application.DoEvents();
            }
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
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.StartInfo.Arguments += txbFile.Text;
            process.OutputDataReceived += (obj, args) => AppendInstallerLog(args.Data);
            process.Start();
            process.BeginOutputReadLine();
            while (!process.HasExited)
            {
                Application.DoEvents();
            }
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
