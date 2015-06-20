using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlockLaunch.Classes.JSON.Api
{

    public class Skin
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Cape
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Textures
    {

        [JsonProperty("SKIN")]
        public Skin Skin { get; set; }

        [JsonProperty("CAPE")]
        public Cape Cape { get; set; }
    }

    public class ProfileTextures
    {

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        [JsonProperty("profileName")]
        public string ProfileName { get; set; }

        [JsonProperty("isPublic")]
        public string IsPublic { get; set; }

        [JsonProperty("textures")]
        public Textures Textures { get; set; }
    }

}
