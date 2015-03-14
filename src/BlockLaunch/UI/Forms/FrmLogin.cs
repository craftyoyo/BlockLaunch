using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using BlockLaunch.Classes.JSON;
using BlockLaunch.Classes.JSON.Api;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using BlockLaunch.Classes.Language;
using BlockLaunch.Classes.Minecraft;
using BlockLaunch.UI.Dialogs;
using Newtonsoft.Json;

namespace BlockLaunch.UI.Forms
{
    public partial class FrmLogin : Form
    {

        private static Language _language;
        private static bool _createProfile;
        public Profile UserProfile;
        private static bool _cancelOk;
        private static List<Profile> _profiles; 

        public FrmLogin(Language language, List<Profile> profiles ,bool createNewProfile = true, Profile oldProfile = null)
        {
            InitializeComponent();
            _language = language;
            _createProfile = createNewProfile;
            UserProfile = oldProfile;
            _profiles = profiles;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (_createProfile)
            {
                if (_profiles != null)
                {
                    var foundProfile = _profiles.Find(x => x.ProfileName == txbProfileName.Text);
                    if (foundProfile != null)
                    {
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, "Profile-Name already taken.",
                            "Profile-Name already taken!", "A profile with the same profile name already exists!",
                            _language.Ok, _language.Cancel);
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
                if (_createProfile)
                {
                    string tmp;
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
                }
                else
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
                    "Failed to login to your minecraft account!", "See details for more informations.", _language.Ok,
                    _language.Cancel, message);
                errorDialog.ShowDialog();
                _cancelOk = true;
            }
           
        }

        public void SilentLogin(string email, string password)
        {
            if (_createProfile)
            {
                if (_profiles != null)
                {
                    var foundProfile = _profiles.Find(x => x.ProfileName == txbProfileName.Text);
                    if (foundProfile != null)
                    {
                        var errorDialog = new Dialog(Dialog.StatusMode.Error, "Profile-Name already taken.",
                            "Profile-Name already taken!", "A profile with the same profile name already exists!",
                            _language.Ok, _language.Cancel);
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
                if (_createProfile)
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
                    "Failed to login to your minecraft account!", "See details for more informations.", _language.Ok,
                    _language.Cancel, message);
                errorDialog.ShowDialog();
                _cancelOk = true;
            }
        }

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
            if (!_createProfile && UserProfile != null)
            {
                txbProfileName.Text = UserProfile.ProfileName;
                txbUser.Text = UserProfile.Email;
                txbProfileName.ReadOnly = true;
            }
            
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Equals((sender as Button), cmdLogin))
            {
                if (!_cancelOk) return;
                _cancelOk = false;
                e.Cancel = true;
            }
            
        }

        private void linkBuyMinecraft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://minecraft.net/store/minecraft");
        }

    }
}
