using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json.Linq;

namespace BlockLaunch.Classes.Minecraft
{
    public class AssetManager
    {
        public const string AssetServer = "http://resources.download.minecraft.net/";
        public const string AssetInformations = "https://s3.amazonaws.com/Minecraft.Download/indexes/";

        public Tuple<Dictionary<string, string>, List<string>> Assets(string version)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory + @"minecraft\assets\objects\";
            var wc = new WebClient {Proxy = null};
            var content = wc.DownloadString(AssetInformations + version + ".json");
            var resultPaths = new Dictionary<string, string>();
            var nameList = new List<string>();
            foreach (var item in (JObject) JObject.Parse(content)["objects"])
            {
                var path = item.Key;
                var hash = item.Value.ToObject<AssetObject>().GetHash();
                var beginningOfHash = hash.Substring(0, 2);
                try
                {
                    resultPaths.Add(AssetServer + beginningOfHash + "/" + hash, folder + beginningOfHash + @"\" + hash);
                    nameList.Add(path);
                }
                catch (ArgumentException)
                {
                    // Key already in dictionary. Why Mojang is using 1 file for 2 sounds and add them twice in the asset file?
                    // continue;
                }
                
            }
            var result = new Tuple<Dictionary<string, string>, List<string>>(resultPaths, nameList);
            return result;
        } 
    }
}
