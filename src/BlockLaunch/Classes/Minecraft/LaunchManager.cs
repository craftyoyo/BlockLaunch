using System;
using System.Collections.Generic;
using System.Linq;
using BlockLaunch.Classes.JSON;
using BlockLaunch.UI.Forms;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Minecraft
{
    public class LaunchManager
    {
        public string JvmArguments(string nativePath)
        {
            return FrmMain.ApplicationConfig.JvmArguments.Replace("%m", FrmMain.ApplicationConfig.Memory.ToString()) +  @" ""-Djava.library.path=" + nativePath + @""" -cp";
        }

        public string Dependencies(VersionInformation ver)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory + "minecraft";
            var manager = new LibrarieManager();
            var localPaths = manager.LibrarieLocalPaths(ver.Librarieses, true);
            var libs = new List<string>(localPaths.Keys);
            var result = libs.Aggregate("", (current, lib) => current + lib + ";");
            result = result + @"""" + folder + @"\versions\" + ver.Id + @"\" + ver.Id + @".jar" + @""";";
            result = result.Remove(result.Length - 1);
            result = result + " " + ver.MainClass;
            return result;
        }

        public string MinecraftArguments(VersionInformation ver, Profile selectedProfile, Config config)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory + "minecraft";
            var arguments =
                ver.ArgumentTemplate.Replace("${auth_player_name}", selectedProfile.CachedUsername)
                    .Replace("${version_name}", selectedProfile.SelectedVersion.Id)
                    .Replace("${game_directory}", @"""" + folder + @"""")
                    .Replace("${assets_root}", @"""" + folder + @"\assets""")
                    .Replace("${assets_index_name}", ver.AssetVersion)
                    .Replace("${auth_uuid}", selectedProfile.Uuid)
                    .Replace("${auth_access_token}", selectedProfile.AccessToken)
                    .Replace("${user_properties}", Properties(selectedProfile))
                    .Replace("${user_type}", "mojang");
            arguments = arguments + " " + config.MinecraftArguments;
            return arguments;
        }

        public string Properties(Profile profile)
        {
            return profile.Properties != null ? JsonConvert.SerializeObject(profile.Properties) : "[]";
        }
    }
}
