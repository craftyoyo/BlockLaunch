using Newtonsoft.Json;

namespace BlockLaunch.Classes.Language
{

    public class Language
    {

        [JsonProperty("language")]
        public string LanguageName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_shortcut")]
        public string CountryShortcut { get; set; }

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

        [JsonProperty("tabpage_tools")]
        public string TabpageTools { get; set; }

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

        [JsonProperty("copy_profile")]
        public string CopyProfile { get; set; }

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

        [JsonProperty("converter")]
        public string Converter { get; set; }

        [JsonProperty("optifine_installer")]
        public string OptifineInstaller { get; set; }

        [JsonProperty("convert_selected_version")]
        public string ConvertSelectedVersion { get; set; }

        [JsonProperty("browse")]
        public string Browse { get; set; }

        [JsonProperty("path_to_jar")]
        public string PathToJar { get; set; }

        [JsonProperty("install_optifine")]
        public string InstallOptifine { get; set; }

        [JsonProperty("crash_report")]
        public string CrashReport { get; set; }

        [JsonProperty("refresh_failed_title")]
        public string RefreshFailedTitle { get; set; }

        [JsonProperty("refresh_failed_status")]
        public string RefreshFailedStatus { get; set; }

        [JsonProperty("refresh_failed_details")]
        public string RefreshFailedDetails { get; set; }

        [JsonProperty("exception_type")]
        public string ExceptionType { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("cause")]
        public string Cause { get; set; }

        [JsonProperty("conversion_required")]
        public string ConversionRequired { get; set; }

        [JsonProperty("conversion_status")]
        public string ConversionStatus { get; set; }

        [JsonProperty("conversion_details")]
        public string ConversionDetails { get; set; }

        [JsonProperty("download_failed_title")]
        public string DownloadFailedTitle { get; set; }

        [JsonProperty("download_failed_status")]
        public string DownloadFailedStatus { get; set; }

        [JsonProperty("download_failed_details")]
        public string DownloadFailedDetails { get; set; }

        [JsonProperty("version_not_installed_title")]
        public string VersionNotInstalledTitle { get; set; }

        [JsonProperty("version_not_installed_status")]
        public string VersionNotInstalledStatus { get; set; }

        [JsonProperty("version_not_installed_details")]
        public string VersionNotInstalledDetails { get; set; }

        [JsonProperty("no_parent_title")]
        public string NoParentTitle { get; set; }

        [JsonProperty("no_parent_status")]
        public string NoParentStatus { get; set; }

        [JsonProperty("no_parent_details")]
        public string NoParentDetails { get; set; }

        [JsonProperty("converter_not_installed_title")]
        public string ConverterNotInstalledTitle { get; set; }

        [JsonProperty("converter_not_installed_status")]
        public string ConverterNotInstalledStatus { get; set; }

        [JsonProperty("installer_not_installed_title")]
        public string InstallerNotInstalledTitle { get; set; }

        [JsonProperty("installer_not_installed_status")]
        public string InstallerNotInstalledStatus { get; set; }

        [JsonProperty("install_tools")]
        public string InstallTools { get; set; }

        [JsonProperty("profile_name_taken_title")]
        public string ProfileNameTakenTitle { get; set; }

        [JsonProperty("profile_name_taken_status")]
        public string ProfileNameTakenStatus { get; set; }

        [JsonProperty("profile_name_taken_details")]
        public string ProfileNameTakenDetails { get; set; }

        [JsonProperty("auth_failed_title")]
        public string AuthFailedTitle { get; set; }

        [JsonProperty("auth_failed_status")]
        public string AuthFailedStatus { get; set; }

        [JsonProperty("auth_failed_details")]
        public string AuthFailedDetails { get; set; }
    }

}
