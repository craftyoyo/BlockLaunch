using System;
using System.Collections.Generic;
using System.Linq;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Minecraft
{
    public class LaunchManager
    {
        public string JvmArguments(string nativePath)
        {
            return @"-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump -Xmx1G -XX:+UseConcMarkSweepGC -XX:-UseAdaptiveSizePolicy -Xmn128M ""-Djava.library.path=" +
                    nativePath + @""" -cp";
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

        public string MinecraftArguments(VersionInformation ver, Profile selectedProfile)
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
            return arguments;
        }

        public string Properties(Profile profile)
        {
            return profile.Properties != null ? JsonConvert.SerializeObject(profile.Properties) : "[]";
        }
    }
}
