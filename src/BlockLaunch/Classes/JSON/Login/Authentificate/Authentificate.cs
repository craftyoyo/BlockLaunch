using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login
{
    public class Agent
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
    }

    public class AuthentificateObject
    {
        [JsonProperty("agent")]
        public Agent Agent { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }

        [JsonProperty("requestUser")]
        public bool GetProperties { get; set; }
    }
}
