using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Minecraft
{
    public class VersionManager
    {
        public const string AllVersions = "http://s3.amazonaws.com/Minecraft.Download/versions/versions.json";
        public const string VersionWebPath = "http://s3.amazonaws.com/Minecraft.Download/versions/";
        public WebClient Wc = new WebClient {Proxy = null};


        public Versions AvailableVersions()
        {
            var json = Wc.DownloadString(AllVersions);
            return JsonConvert.DeserializeObject<Versions>(json);
        }

        public Dictionary<string, string> VersionDownloadPath(string version)
        {
            var result = new Dictionary<string, string>
            {
                {VersionWebPath + version + "/" + version + ".jar", VersionWebPath + version + "/" + version + ".json"}
            };
            return result;
        }

        public VersionInformation VersionInfos(string version)
        {
            var json = Wc.DownloadString(VersionWebPath + version + "/" + version + ".json");
            return JsonConvert.DeserializeObject<VersionInformation>(json);
        }

        public VersionInformation ReadVersionInfos(string version)
        {
            var content = File.ReadAllText(@"minecraft\versions\" + version + @"\" + version + ".json");
            return JsonConvert.DeserializeObject<VersionInformation>(content);
        }
    }
}
