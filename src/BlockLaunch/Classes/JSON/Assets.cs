using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AssetObject
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }

        public string GetHash()
        {
            return Hash;
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
