using System;
using System.IO;

namespace Optifine_Installer
{
    public class Program
    {
        public const string Version = "1.8.1-OptiFine_HD_U_C6";
        public const string LibraryName = "OptiFine-1.8.1_HD_U_C6";

        public static void Main(string[] args)
        {
            Console.WriteLine(@"Current Optifine Installer Version: " + Version);
            var installRootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(installRootDirectory + @"Minecraft\versions\" + Version))
            {
                Directory.CreateDirectory(installRootDirectory + @"Minecraft\versions\" + Version);
            }
            if (File.Exists(installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".jar")) { File.Delete(installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".jar"); }
            if (File.Exists(installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".json")) { File.Delete(installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".json"); }
            var optifineDirectory = Version.Replace("-OptiFine", "");
            WriteResourceFile(Properties.Resources.OptifineJar, installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".jar");
            WriteResourceFile(Properties.Resources.OptifineJson, installRootDirectory + @"Minecraft\versions\" + Version + @"\" + Version + @".json");
            WriteResourceFile(Properties.Resources.OptifineLibrary, installRootDirectory + @"Minecraft\libraries\optifine\OptiFine\" + optifineDirectory + @"\" + LibraryName + @".jar");
            WriteResourceFile(Properties.Resources.LaunchWrapperJar, installRootDirectory + @"Minecraft\libraries\net\minecraft\launchwrapper\1.7\launchwrapper-1.7.jar");
            WriteResourceFile(Properties.Resources.LaunchWrapperSha, installRootDirectory + @"Minecraft\libraries\net\minecraft\launchwrapper\1.7\launchwrapper-1.7.jar.sha");
            Console.WriteLine(@"Finished!");
            GC.Collect();
            Environment.Exit(0);
        }

        private static void WriteResourceFile(byte[] bytes, string path)
        {
            var fi = new FileInfo(path);
            if (!Directory.Exists(fi.DirectoryName))
                Directory.CreateDirectory(fi.DirectoryName);
            try
            {
                Console.WriteLine(@"Extracting: " + path);
                File.WriteAllBytes(path, bytes);
            }
            catch (IOException io)
            {
                Console.WriteLine(io.ToString());
                Console.ReadKey();
            }
        }
    }
}
