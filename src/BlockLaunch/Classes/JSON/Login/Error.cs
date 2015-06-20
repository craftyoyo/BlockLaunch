using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.JSON.Login
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorString { get; set; }
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("cause")]
        public string Cause { get; set; }
    }
}
