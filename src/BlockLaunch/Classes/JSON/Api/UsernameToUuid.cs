using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Api
{
    public class UsernameToUuid
    {   
        [JsonProperty("id")]
        public string Uuid { get; set; }
        [JsonProperty("name")]
        public string Username { get; set; }
    }
}
