using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using BlockLaunch.Classes;
using BlockLaunch.Classes.JSON;
using BlockLaunch.Classes.JSON.Api;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using BlockLaunch.Classes.Language;
using BlockLaunch.Classes.Minecraft;
using BlockLaunch.UI.Dialogs;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace BlockLaunch.UI.Forms
{
    public partial class FrmLogin : MetroForm
    {
        #region Values
        public enum LoginMode
        {
            CopyProfile,
            EditProfile,
            CreateProfile
        }

        private static Language _language;
        private static LoginMode _mode;
        public Profile UserProfile;
        private static bool _cancelOk;
        private static List<Profile> _profiles;
        #endregion

        #region Constructor
        public FrmLogin(Language language, List<Profile> profiles , LoginMode mode = LoginMode.CreateProfile, Profile oldProfile = null)
        {
            InitializeComponent();
            _language = language;
            _mode = mode;
            UserProfile = oldProfile;
            _profiles = profiles;
        }
        #endregion

        #region Form-Events
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                          Assembly.GetExecutingAssembly().GetName().Version.Minor;
            Text = _language.Title.Replace("%ver", version) + @" - " + _language.LoginTitle;
            cmdLogin.Text = _language.Login;
            lblEmail.Text = _language.Email;
            lblPassword.Text = _language.Password;
            lblProfilName.Text = _language.ProfileName;
            linkBuyMinecraft.Text = _language.NeedAnAccount;
            switch (_mode)
            {
                case LoginMode.CreateProfile:
                    break;
                case LoginMode.CopyProfile:
                    if (UserProfile == null) break;
                    txbProfileName.Text = "";
                    txbProfileName.ReadOnly = false;
                    txbUser.Text = UserProfile.Email;
                    txbUser.ReadOnly = true;
                    txbPassword.Text = UserProfile.Password;
                    txbPassword.ReadOnly = false;
                    break;
                case LoginMode.EditProfile:
                    if (UserProfile == null) break;
                    txbProfileName.Text = UserProfile.ProfileName;
                    txbUser.Text = UserProfile.Email;
                    txbProfileName.ReadOnly = true;
                    break;
            }
            ThemeHelper.ApplyTheme(this, FrmMain.ApplicationConfig);

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (!_cancelOk) return;
                _cancelOk = false;
                e.Cancel = true;
        }
        #endregion

        #region Login-Methods
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (_mode == LoginMode.CreateProfile || _mode == LoginMode.CopyProfile)
            {
                if (_profiles != null)
                {
                    var foundProfile = _profiles.Find(x => x.ProfileName == txbProfileName.Text);
                    if (foundProfile != null)
                    {
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, "Profile-Name already taken.",
                            "Profile-Name already taken!", "A profile with the same profile name already exists!",
                            _language);
                        errorDialog.ShowDialog();
                        _cancelOk = true;
                        return;
                    }
                }
            }
            var parameter = new AuthentificateObjects
            {
                Email = txbUser.Text,
                Password = txbPassword.Text
            };
            var login = new LoginManager();
            var result = login.Authentificate(parameter);
            if (result.Status)
            {
                if (_mode == LoginMode.CreateProfile || _mode == LoginMode.CopyProfile)
                {
                    string tmp;
                    if (result.AuthResponse.SelectedProfile == null && result.AuthResponse.AvailableProfiles == null)
                    {
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, "Invalid mojang account",
                            "It seems you didn't bought minecraft!", "Please buy minecraft under http://minecraft.net",
                            _language);
                        errorDialog.ShowDialog();
                        _cancelOk = false;
                        return;
                    }
                    var jsonUuid =
                        JsonConvert.DeserializeObject<UsernameToUuid>(
                            LoginManager.GetRequest("https://api.mojang.com/users/profiles/minecraft/" +
                                                    result.AuthResponse.SelectedProfile.Name, out tmp));
                    string pass = null;
                    if (FrmMain.ApplicationConfig.SavePassword)
                    {
                        pass = txbPassword.Text;
                    }
                    var profile = new Profile
                    {
                        Password = pass,
                        Email = parameter.Email,
                        ClientToken = result.AuthResponse.ClientToken,
                        AccessToken = result.AuthResponse.AccessToken,
                        ProfileName = txbProfileName.Text,
                        SelectedVersion = null,
                        Properties = result.AuthResponse.MinecraftUser.Properties,
                        Uuid = jsonUuid.Uuid,
                        CachedUsername = result.AuthResponse.SelectedProfile.Name
                    };
                    UserProfile = profile;
                    _cancelOk = true;
                }
                else if (_mode == LoginMode.EditProfile)
                {
                    UserProfile.AccessToken = result.AuthResponse.AccessToken;
                    UserProfile.ClientToken = result.AuthResponse.ClientToken;
                    UserProfile.Properties = result.AuthResponse.MinecraftUser.Properties;
                    string pass = null;
                    if (FrmMain.ApplicationConfig.SavePassword)
                    {
                        pass = txbPassword.Text;
                    }
                    UserProfile.Password = pass;
                    _cancelOk = true;
                }

            }
            else
            {
                string message;
                if (String.IsNullOrEmpty(result.Error.Cause))
                {
                    message = "Exception Type: " + result.Error.ErrorString + Environment.NewLine + "Error Message: " +
                              result.Error.ErrorMessage;
                }
                else
                {
                    message = "Exception Type: " + result.Error.ErrorString + Environment.NewLine + "Error Message: " +
                              result.Error.ErrorMessage + Environment.NewLine + "Cause: " + result.Error.Cause;
                }

                var errorDialog = new Dialog(Dialog.StatusMode.Error, _language.AuthFailedTitle,
                   _language.AuthFailedStatus, _language.AuthFailedDetails, _language, message);
                errorDialog.ShowDialog();
                _cancelOk = true;
            }

        }

        public void SilentLogin(string email, string password)
        {
            if (_mode == LoginMode.CreateProfile)
            {
                if (_profiles != null)
                {
                    var foundProfile = _profiles.Find(x => x.ProfileName == txbProfileName.Text);
                    if (foundProfile != null)
                    {
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, "Profile-Name already taken.",
                            "Profile-Name already taken!", "A profile with the same profile name already exists!",
                            _language);
                        errorDialog.ShowDialog();
                        _cancelOk = true;
                        return;
                    }
                }
            }
            var parameter = new AuthentificateObjects
            {
                Email = email,
                Password = password
            };
            var login = new LoginManager();
            var result = login.Authentificate(parameter);
            if (result.Status)
            {
                if (_mode == LoginMode.CreateProfile)
                {
                    string tmp;
                    var jsonUuid =
                        JsonConvert.DeserializeObject<UsernameToUuid>(
                            LoginManager.GetRequest("https://api.mojang.com/users/profiles/minecraft/" +
                                                    result.AuthResponse.SelectedProfile.Name, out tmp));
                    string pass = null;
                    if (FrmMain.ApplicationConfig.SavePassword)
                    {
                        pass = password;
                    }
                    var profile = new Profile
                    {
                        Password = pass,
                        Email = parameter.Email,
                        ClientToken = result.AuthResponse.ClientToken,
                        AccessToken = result.AuthResponse.AccessToken,
                        ProfileName = txbProfileName.Text,
                        SelectedVersion = null,
                        Properties = result.AuthResponse.MinecraftUser.Properties,
                        Uuid = jsonUuid.Uuid,
                        CachedUsername = result.AuthResponse.SelectedProfile.Name
                    };
                    UserProfile = profile;
                }
                else
                {
                    UserProfile.AccessToken = result.AuthResponse.AccessToken;
                    UserProfile.ClientToken = result.AuthResponse.ClientToken;
                    UserProfile.Properties = result.AuthResponse.MinecraftUser.Properties;
                    string pass = null;
                    if (FrmMain.ApplicationConfig.SavePassword)
                    {
                        pass = password;
                    }
                    UserProfile.Password = pass;
                }

            }
            else
            {
                string message;
                if (String.IsNullOrEmpty(result.Error.Cause))
                {
                    message = "Exception Type: " + result.Error.ErrorString + Environment.NewLine + "Error Message: " +
                              result.Error.ErrorMessage;
                }
                else
                {
                    message = "Exception Type: " + result.Error.ErrorString + Environment.NewLine + "Error Message: " +
                              result.Error.ErrorMessage + Environment.NewLine + "Cause: " + result.Error.Cause;
                }

                var errorDialog = new Dialog(Dialog.StatusMode.Error, "Authentification failed!",
                    "Failed to login to your minecraft account!", "See details for more informations.", _language, message);
                errorDialog.ShowDialog();
                _cancelOk = true;
            }
        }
        #endregion

        #region Buy Minecraft Link
        private void linkBuyMinecraft_Click(object sender, EventArgs e)
        {
            Process.Start("https://minecraft.net/store/minecraft");
        }
        #endregion
    }
}
