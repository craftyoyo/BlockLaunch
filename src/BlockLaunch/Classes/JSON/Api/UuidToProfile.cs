using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Api
{
    public class UserProperties
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    public class UuidToProfile
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("properties")]
        public List<UserProperties> Properties { get; set; }
    }
}
