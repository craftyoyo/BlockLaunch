using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockLaunch_Optifine
{
    public class VersionInformation
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("releaseTime")]
        public string ReleaseTime { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("minecraftArguments")]
        public string ArgumentTemplate { get; set; }
        [JsonProperty("minimumLauncherVersion")]
        public int MinimumLauncherVersion { get; set; }
        [JsonProperty("assets")]
        public string AssetVersion { get; set; }
        [JsonProperty("libraries")]
        public List<Libraries> Librarieses { get; set; }
        [JsonProperty("inheritsFrom")]
        public string ParentVersion { get; set; }
        [JsonProperty("mainClass")]
        public string MainClass { get; set; }
    }
    public class Libraries
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rules")]
        public List<Rules> Rules { get; set; }
        [JsonProperty("natives")]
        public Natives Natives { get; set; }
    }
    public class Rules
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("os")]
        public Os OperatingSystem { get; set; }
    }
    public class Os
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Natives
    {
        [JsonProperty("linux")]
        public string Linux { get; set; }
        [JsonProperty("windows")]
        public string Windows { get; set; }
        [JsonProperty("osx")]
        public string OsX { get; set; }
    }
    public class Extract
    {
        [JsonProperty("exclude")]
        public List<string> Exclude { get; set; }
    }
}