using System;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Config
    {
        [JsonProperty("selectedLanguage")]
        public string Language { get; set; }
        [JsonProperty("theme")]
        public string Theme { get; set; }
        [JsonProperty("style")]
        public string Style { get; set; }
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
        [JsonProperty("minecraft_arguments")]
        public string MinecraftArguments { get; set; }
        [JsonProperty("memory")]
        public int Memory { get; set; }
        [JsonProperty("selectedProfile")]
        public string SelectedProfileString { get; set; }
        [JsonIgnore]
        public Profile SelectedProfile { get; set; }
    }

    
}
