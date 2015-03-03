using Newtonsoft.Json;

namespace BlockLaunch.Classes.Language
{
    public class Language
    {
        // Language Information's
        [JsonProperty("language")]
        public string LanguageName { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_shortcut")]
        public string CountryShortcut { get; set; }

        #region Translation

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("main_menu_title")]
        public string MainMenuTitle { get; set; }
        [JsonProperty("settings_title")]
        public string SettingsTitle { get; set; }
        [JsonProperty("login_title")]
        public string LoginTitle { get; set; }
        [JsonProperty("cancel")]
        public string Cancel { get; set; }
        [JsonProperty("ok")]
        public string Ok { get; set; }
        [JsonProperty("tabpage_home")]
        public string TabpageHome { get; set; }
        [JsonProperty("tabpage_updates")]
        public string TabpageUpdates { get; set; }
        [JsonProperty("tabpage_logs")]
        public string TabpageLogs { get; set; }
        [JsonProperty("tabpage_logs_all")]
        public string TabpageLogsAll { get; set; }
        [JsonProperty("tabpage_logs_blocklaunch")]
        public string TabpageLogsBlocklaunch { get; set; }
        [JsonProperty("tabpage_logs_minecraft")]
        public string TabpageLogsMinecraft { get; set; }

        [JsonProperty("welcome_back")]
        public string WelcomeBack { get; set; }
        [JsonProperty("selected_version")]
        public string SelectedVersion { get; set; }
        [JsonProperty("show_uuid")]
        public string ShowUuid { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("profile")]
        public string Profile { get; set; }
        [JsonProperty("settings")]
        public string Settings { get; set; }
        [JsonProperty("loginAndPlay")]
        public string LoginAndPlay { get; set; }
        [JsonProperty("add_profile")]
        public string AddProfile { get; set; }

        [JsonProperty("log_info")]
        public string LogInfo { get; set; }
        [JsonProperty("log_warning")]
        public string LogWarning { get; set; }
        [JsonProperty("log_error")]
        public string LogError { get; set; }
        [JsonProperty("log_exception")]
        public string LogException { get; set; }

        [JsonProperty("refresh_profile")]
        public string RefreshProfile { get; set; }
        [JsonProperty("dont_save_password")]
        public string DontSavePassword { get; set; }
        [JsonProperty("dont_save_password_details")]
        public string DontSavePasswordDetails { get; set; }
        [JsonProperty("save_settings")]
        public string SaveSettings { get; set; }
        [JsonProperty("copy_uuid")]
        public string CopyUuid { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("player_information")]
        public string PlayerInformation { get; set; }

        [JsonProperty("need_an_account")]
        public string NeedAnAccount { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("profile_name")]
        public string ProfileName { get; set; }
        #endregion
    }
}