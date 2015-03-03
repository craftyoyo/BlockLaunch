using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login.Authentificate
{
    public class Propertie
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("properties")]
        public List<Propertie> Properties { get; set; } 
    }

    public class AuthentificationResponse
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }
        [JsonProperty("availableProfiles")]
        public List<MojangProfile> AvailableProfiles { get; set; }
        [JsonProperty("selectedProfile")]
        public MojangProfile SelectedProfile { get; set; }
        [JsonProperty("user")]
        public User MinecraftUser { get; set; }
    }

    public class MojangProfile
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("legacy")]
        public bool Legacy { get; set; }
    }
}
