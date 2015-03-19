using System;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Config
    {
        [JsonProperty("selectedLanguage")]
        public string Language { get; set; }
        [JsonProperty("showAlpha")]
        public bool ShowAlpha { get; set; }
        [JsonProperty("showBeta")]
        public bool ShowBeta { get; set; }
        [JsonProperty("showSnapshot")]
        public bool ShowSnapshot { get; set; }
        [JsonProperty("savePassword")]
        public bool SavePassword { get; set; }
        [JsonProperty("jvm_arguments")]
        public string JvmArguments { get; set; }
        [JsonProperty("selectedProfile")]
        public Profile SelectedProfile { get; set; }

        //[JsonProperty("width")]
        //public int Width { get; set; }
        //[JsonProperty("heigth")]
        //public int Heigth { get; set; }
    }

    
}
