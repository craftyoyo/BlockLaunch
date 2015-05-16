using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON.Api;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    public class Profile
    {
        [JsonProperty("profile_name")]
        public string ProfileName { get; set; }
        [JsonProperty("cached_username")]
        public string CachedUsername { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("lastAccesstoken")]
        public string AccessToken { get; set; }
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }
        [JsonProperty("properties")]
        public List<Propertie> Properties { get; set; }
        [JsonProperty("selectedVersion")]
        public Version SelectedVersion { get; set; }
        [JsonProperty("cachedProfile")]
        public string CachedProfileString { get; set; }
        [JsonIgnore]
        public UuidToProfile CachedProfile { get; set; }
    }
}
