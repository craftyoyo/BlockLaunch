using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON;

namespace BlockLaunch.Classes.Minecraft
{
    public class LibrarieManager
    {
        public const string LibrarieServer = "https://libraries.minecraft.net/";

        public Dictionary<string, string> LibrarieWebPaths(List<Libraries> libraries)
        {
           
            var arch = Environment.Is64BitOperatingSystem ? "64" : "32";
            var result = new Dictionary<string, string>();
            foreach (var lib in libraries)
            {
                var skipFile = false;
                if (lib.Rules != null)
                {
                    foreach (var rule in lib.Rules.Where(rule => rule.Action != null && rule.OperatingSystem != null))
                    {
                        if (rule.OperatingSystem.Name == "windows" && rule.Action == "disallow")
                        {
                            skipFile = true;
                        }
                        if (rule.Action == "allow" && rule.OperatingSystem.Name != "windows")
                        {
                            skipFile = true;
                        }
                    }
                }
                if (skipFile) continue;
                var libInfo = lib.Name.Split(':');
                var package = libInfo[0];
                package = package.Replace(".", "/");
                var name = libInfo[1];
                var version = libInfo[2];
                var native = "";
                if (lib.Natives != null && lib.Natives.Windows != null)
                {
                    native = lib.Natives.Windows.Replace("${arch}", arch);
                }
                string jarFile;
                string shaFile;
                if (String.IsNullOrEmpty(native))
                {
                   jarFile = LibrarieServer + package + "/" + name + "/" + version + "/" + name + "-" + version +
                                  ".jar";
                    shaFile = jarFile + ".sha1";
                }
                else
                {
                     jarFile = LibrarieServer + package + "/" + name + "/" + version + "/" + name + "-" + version +
                                  "-" + native + ".jar";
                     shaFile = jarFile + ".sha1";
                }
                result.Add(jarFile, shaFile);
            }
            return result;
        }

        public Dictionary<string, string> LibrarieLocalPaths(List<Libraries> libraries, bool launching)
        {
        
            var launchChar = @"""";
            if (!launching)
            {
                launchChar = "";
            }
            var folder = AppDomain.CurrentDomain.BaseDirectory + @"minecraft\libraries\";
            var arch = Environment.Is64BitOperatingSystem ? "64" : "32";
            var result = new Dictionary<string, string>();
            foreach (var lib in libraries)
            {
                var skipFile = false;
                if (lib.Rules != null)
                {
                    foreach (var rule in lib.Rules.Where(rule => rule.Action != null && rule.OperatingSystem != null))
                    {
                        if (rule.OperatingSystem.Name == "windows" && rule.Action == "disallow")
                        {
                            skipFile = true;
                        }
                        if (rule.Action == "allow" && rule.OperatingSystem.Name != "windows")
                        {
                            skipFile = true;
                        }
                    }
                }
                if (skipFile) continue;
                var libInfo = lib.Name.Split(':');
                var package = libInfo[0].Replace(".", @"\");
                var name = libInfo[1];
                var version = libInfo[2];
                var native = "";
                if (lib.Natives != null && lib.Natives.Windows != null)
                {
                    native = lib.Natives.Windows.Replace("${arch}", arch);
                }
                string jarFile;
                string shaFile;
                if (String.IsNullOrEmpty(native))
                {
                    jarFile = launchChar + folder + package + @"\" + name + @"\" + version + @"\" + name + "-" + version +
                                   ".jar" + launchChar;
                    shaFile = jarFile + ".sha";
                }
                else
                {
                    jarFile = launchChar + folder + package + @"\" + name + @"\" + version + @"\" + name + "-" + version +
                                 "-" + native + ".jar" + launchChar;
                    shaFile = jarFile + ".sha";
                }
                result.Add(jarFile, shaFile);
            }
            return result;
        } 
    }
}
