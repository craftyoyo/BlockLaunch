using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Config
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("heigth")]
        public int Heigth { get; set; }
        [JsonProperty("showAlpha")]
        public bool ShowAlpha { get; set; }
        [JsonProperty("showBeta")]
        public bool ShowBeta { get; set; }
        [JsonProperty("showSnapshot")]
        public bool ShowSnapshot { get; set; }
        [JsonProperty("selectedProfile")]
        public Profile SelectedProfile { get; set; }
    }
}
