using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockLaunch.Classes.Language
{
    public class LanguageTemplate
    {
        // Language Information's
        public string LanguageName { get; set; }
        public string Country { get; set; }
        public string CountryShortcut { get; set; }

        #region Translation
        public string Home { get; set; }
        public string WelcomeBack { get; set; }
        public string SelectedVersion { get; set; }
        public string LoginAndPlay { get; set; }
        public string Settings { get; set; }
        public string AddProfile { get; set; }
        #endregion
    }
}
