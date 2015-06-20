using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login.Refresh
{
    public class RefreshResponse
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }
        [JsonProperty("selectedProfile")]
        public MojangProfile Profile { get; set; }
    }
}
