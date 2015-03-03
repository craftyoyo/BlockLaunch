using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login.Refresh
{
    public class Refresh
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }
    }
}
