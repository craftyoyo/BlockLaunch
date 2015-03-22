using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BlockLaunch.Classes;
using BlockLaunch.Classes.JSON;
using BlockLaunch.Classes.Language;
using MetroFramework;
using MetroFramework.Forms;

namespace BlockLaunch.UI.Forms
{
    public partial class FrmSettings : MetroForm
    {
        #region Values
        public Config NewConfig;

        private readonly List<Language> _languages;
        private readonly BindingSource _source;
        private readonly BindingSource _themeSource;
        private readonly BindingSource _styleSource;
        private readonly Config _config;
        private readonly Language _language;
        #endregion

        #region Constructor
        public FrmSettings(Config config,Language selectedLanguage,List<Language> languageList)
        {
            InitializeComponent();
            _source = new BindingSource {DataSource = typeof (LanguageData)};
            _themeSource = new BindingSource { DataSource = typeof(ThemeData) };
            _styleSource = new BindingSource { DataSource = typeof(StyleData) };
            ckbStyle.DataSource = _styleSource;
            ckbStyle.DisplayMember = "Display";
            ckbStyle.ValueMember = "Style";
            ckbTheme.DataSource = _themeSource;
            ckbTheme.DisplayMember = "Display";
            ckbTheme.ValueMember = "Theme";
            _languages = languageList;
            _config = config;
            _language = selectedLanguage;
        }
        #endregion

        #region Form-Events
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                          Assembly.GetExecutingAssembly().GetName().Version.Minor;
            Text = _language.Title.Replace("%ver", version) + @" - " + _language.SettingsTitle;
            cmdSaveSettings.Text = _language.SaveSettings;
            chkDontSavePassword.Text = _language.DontSavePassword;
            toolDetails.SetToolTip(chkDontSavePassword, _language.DontSavePasswordDetails);
            comLang.DataSource = _source;
            comLang.ValueMember = "Shortcut";
            comLang.DisplayMember = "Language";
            nudMemory.Value = _config.Memory;
            foreach (var data in _languages.Select(item => new LanguageData(item.LanguageName, item.CountryShortcut)))
            {
                _source.Add(data);
            }
            comLang.SelectedValue = _language.CountryShortcut;
            chkDontSavePassword.Checked = !_config.SavePassword;
            txbJvmArguments.Text = _config.JvmArguments;
            var themeValue = new ThemeData("Default", MetroThemeStyle.Default);
            var styleValue = new StyleData("Default", MetroColorStyle.Default);
            foreach (var data in from MetroThemeStyle theme in Enum.GetValues(typeof(MetroThemeStyle)) let themeStyle = Enum.GetName(typeof(MetroThemeStyle), theme) select new ThemeData(themeStyle, theme))
            {
                if (data.Display == _config.Theme)
                {
                    themeValue = data;
                }
                _themeSource.Add(data);
            }
            foreach (var data in from MetroColorStyle style in Enum.GetValues(typeof(MetroColorStyle)) let styleString = Enum.GetName(typeof(MetroColorStyle), style) select new StyleData(styleString, style))
            {
                if (data.Display == _config.Style)
                {
                    styleValue = data;
                }
                _styleSource.Add(data);
            }
            ckbStyle.SelectedValue = styleValue.Style;
            ckbTheme.SelectedValue = themeValue.Theme;
            ThemeHelper.ApplyTheme(this, _config);
            if (Environment.Is64BitOperatingSystem)
            {
                nudMemory.Maximum = NativeMethods.MaxMemory();
            }
            else
            {
                var maxMemory = NativeMethods.MaxMemory();
                nudMemory.Maximum = maxMemory > 2 ? 2 : maxMemory;
            }
        }
        #endregion

        #region Save Settings
        private void cmdSaveSettings_Click(object sender, EventArgs e)
        {
            var config = new Config
            {
                SavePassword = !chkDontSavePassword.Checked,
                Language = comLang.SelectedValue.ToString(),
                SelectedProfile = _config.SelectedProfile,
                ShowAlpha = _config.ShowAlpha,
                ShowBeta = _config.ShowBeta,
                ShowSnapshot = _config.ShowSnapshot,
                JvmArguments = txbJvmArguments.Text,
                Memory = (int)nudMemory.Value,
                Style = ckbStyle.Text,
                Theme = ckbTheme.Text
            };
            NewConfig = config;
        }
        #endregion
    }

    #region DataBinding-Classes
    public class LanguageData
    {
        public string Language { get; set; }
        public string Shortcut { get; set; }

        public LanguageData(string language, string shortcut)
        {
            Language = language;
            Shortcut = shortcut;
        }
    }

    public class ThemeData
    {
        public string Display { get; set; }
        public MetroThemeStyle Theme { get; set; }

        public ThemeData(string display, MetroThemeStyle theme)
        {
            Display = display;
            Theme = theme;
        }
    }

    public class StyleData
    {
        public string Display { get; set; }
        public MetroColorStyle Style { get; set; }

        public StyleData(string display, MetroColorStyle style)
        {
            Display = display;
            Style = style;
        }
    }
#endregion
}
