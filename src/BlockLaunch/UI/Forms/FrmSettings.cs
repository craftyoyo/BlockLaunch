using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BlockLaunch.Classes.JSON;
using BlockLaunch.Classes.Language;

namespace BlockLaunch.UI.Forms
{
    public partial class FrmSettings : Form
    {
        public Config NewConfig;

        private readonly List<Language> _languages;
        private readonly BindingSource _source;
        private readonly Config _config;
        private readonly Language _language;

        public FrmSettings(Config config,Language selectedLanguage,List<Language> languageList)
        {
            InitializeComponent();
            _source = new BindingSource {DataSource = typeof (LanguageData)};
            _languages = languageList;
            _config = config;
            _language = selectedLanguage;
        }

        private void cmdSaveSettings_Click(object sender, System.EventArgs e)
        {
            var config = new Config
            {
                SavePassword = !chkDontSavePassword.Checked,
                Language = comLang.SelectedValue.ToString(),
                SelectedProfile = _config.SelectedProfile,
                ShowAlpha = _config.ShowAlpha,
                ShowBeta = _config.ShowBeta,
                ShowSnapshot = _config.ShowSnapshot,
                JvmArguments = txbJvmArguments.Text
            };
            NewConfig = config;
        }

        private void FrmSettings_Load(object sender, System.EventArgs e)
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
            foreach (var data in _languages.Select(item => new LanguageData(item.LanguageName, item.CountryShortcut)))
            {
                _source.Add(data);
            }
            comLang.SelectedValue = _language.CountryShortcut;
            chkDontSavePassword.Checked = !_config.SavePassword;
            txbJvmArguments.Text = _config.JvmArguments;
        }
    }

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
}
