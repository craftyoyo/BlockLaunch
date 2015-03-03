using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using BlockLaunch.Classes.JSON.Api;
using BlockLaunch.Classes.JSON.Login;
using BlockLaunch.Classes.JSON.Login.Authentificate;
using BlockLaunch.Classes.JSON.Login.Refresh;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Minecraft
{
    public class LoginManager
    {
        public const string AuthentificationServer = "https://authserver.mojang.com";

        public AuthentificateParameter Authentificate(AuthentificateObjects ao)
        {
            var clientToken = GenerateClientToken();
            var agent = new Agent
            {
                Name = "Minecraft",
                Version = 14
            };
            var content = new AuthentificateObject
            {
                Agent = agent,
                ClientToken = clientToken,
                Password = ao.Password,
                Username = ao.Email,
                GetProperties = true
            };
            var json = JsonConvert.SerializeObject(content);
            var data = Encoding.UTF8.GetBytes(json);
            var webrequest = WebRequest.CreateHttp(AuthentificationServer + "/authenticate");
            webrequest.ContentType = "application/json";
            webrequest.Method = "POST";
            webrequest.Proxy = null;
            webrequest.ContentLength = data.Length;
            using (var stream = webrequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                var response = (HttpWebResponse) webrequest.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var contentResponse = sr.ReadToEnd();
                var jsonResponse = JsonConvert.DeserializeObject<AuthentificationResponse>(contentResponse);
                var result = new AuthentificateParameter
                {
                    AuthResponse = jsonResponse,
                    Error = null,
                    Status = true
                };
                return result;
            }
            catch (WebException wex)
            {
                string errorContent;
                using (var stream = wex.Response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        errorContent = sr.ReadToEnd();
                    }
                }
                var errorJson = JsonConvert.DeserializeObject<Error>(errorContent);
                var result = new AuthentificateParameter
                {
                    AuthResponse = null,
                    Error = errorJson,
                    Status = false
                };
                
                return result;
            }
            
        }

        public RefreshParameter Refresh(Refresh profileArgs)
        {
            var json = JsonConvert.SerializeObject(profileArgs);
            var data = Encoding.UTF8.GetBytes(json);
            var request = WebRequest.Create(AuthentificationServer + "/refresh");
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Proxy = null;
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var contentResponse = sr.ReadToEnd();
                var jsonResponse = JsonConvert.DeserializeObject<RefreshResponse>(contentResponse);
                var result = new RefreshParameter()
                {
                    oRefreshResponse = jsonResponse,
                    Error = null,
                    Status = true
                };
                return result;
            }
            catch (WebException wex)
            {
                string errorContent;
                using (var stream = wex.Response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        errorContent = sr.ReadToEnd();
                    }
                }
                var errorJson = JsonConvert.DeserializeObject<Error>(errorContent);
                var result = new RefreshParameter()
                {
                    oRefreshResponse = null,
                    Error = errorJson,
                    Status = false
                };

                return result;
            }
        }

        public static string GetRequest(string url, out string status)
        {
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                var response = (HttpWebResponse) request.GetResponse();
                var resStream = response.GetResponseStream();
                var sr = new StreamReader(resStream);
                status = response.StatusDescription;
                return sr.ReadToEnd();
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                var responseS = wex.Response.GetResponseStream();
                var sr = new StreamReader(responseS);
                status = response.StatusDescription;
                return sr.ReadToEnd();
            }
            
        }

        public static string GetPlayerName(string uuid)
        {
            string status;
            var response = GetRequest("https://sessionserver.mojang.com/session/minecraft/profile/" + uuid, out status);
            if (status != "OK")
            {
                // Too many request (Only once per minute)
                return null;
            }
            var json = JsonConvert.DeserializeObject<UuidToProfile>(response);
            return json.Name;
        }

        private static string GenerateClientToken()
        {
            char[] availableCharacters = {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
            };
            var identifier = new char[16];
            var randomData = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }
            for (var idx = 0; idx < identifier.Length; idx++)
            {
                var pos = randomData[idx] % availableCharacters.Length;
                identifier[idx] = availableCharacters[pos];
            }
            return new string(identifier);

        }
    }
}
