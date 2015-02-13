using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    public class Profile
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("selectedVersion")]
        public Version SelectedVersion { get; set; }
    }
}
