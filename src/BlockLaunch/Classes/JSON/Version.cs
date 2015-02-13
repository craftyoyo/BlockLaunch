using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    public class Latest
    {
        [JsonProperty("release")]
        public string Release { get; set; }
        [JsonProperty("snapshot")]
        public string Snapshot { get; set; }
    }

    public class Version
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("releaseTime")]
        public string ReleaseTime { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Versions
    {
        [JsonProperty("versions")]
        public List<Version> VersionList { get; set; }
        [JsonProperty("latest")]
        public Latest Latest { get; set; }
    }
}
