using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockLaunch.Classes.JSON;
using ICSharpCode.SharpZipLib.Zip;

namespace BlockLaunch.Classes.Minecraft
{
    public class NativeManager
    {
        public List<string> Natives(List<Libraries> libraries)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory + @"minecraft\libraries\";
            var arch = Environment.Is64BitOperatingSystem ? "64" : "32";
            var result = new List<string>();
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
                var name = libInfo[1];
                var version = libInfo[2];
                var native = string.Empty;
                if (lib.Natives != null && lib.Natives.Windows != null)
                {
                    native = lib.Natives.Windows.Replace("${arch}", arch);
                }
                string jarFile;
                if (!String.IsNullOrEmpty(native))
                {
                    jarFile = folder + package + @"\" + name + @"\" + version + @"\" + name + "-" + version +
                                 "-" + native + ".jar";
                }
                else
                {
                    continue;
                }
                result.Add(jarFile);
            }
            return result;
        } 

        public string ExtractNatives(VersionInformation versionInformation)
        {
            var natives = Natives(versionInformation.Librarieses);
            var folder = AppDomain.CurrentDomain.BaseDirectory + @"minecraft\versions\" + versionInformation.Id + @"\" +
                         versionInformation.Id + @"-natives-" + CurrentTimeString();
            foreach (var native in natives)
            {
                ExtractJar(native, folder);
                if (Directory.Exists(folder + @"\META-INF"))
                {
                    Directory.Delete(folder + @"\META-INF", true);
                }
            }
            return folder;
        }

        private void ExtractJar(string jarFile, string destionation)
        {
            var fz = new FastZip();
            fz.ExtractZip(jarFile, destionation, "");
        }

        private string CurrentTimeString()
        {
            var result = DateTime.Now.ToString("yyyy-M-dd-HH-mm-ss");
            return result.Replace("-", "");
        }

    }
}
