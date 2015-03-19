/**
 * Convert's minecraft version's that use "inheritsFrom" in their JSON file
 * to a BlockLaunch compatible version format (because i'm too lazy to implement inheritsFrom :P)
 */

using System;
using System.IO;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json;

namespace BlockLaunch.Converter
{
    public class Program
    {
        public static string dir = Environment.CurrentDirectory + @"\";

        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments! Usage: [name].exe [version1] [version2]");
                return;
            }
            if (args.Length > 2)
            {
                Console.WriteLine("Too many arguments! Usage: [name].exe [version1] [version2]");
                return;
            }
            var version1 = args[0];
            var version2 = args[1];
            if (!VersionInstalled(version1) || !VersionInstalled(version2))
            {
                Console.WriteLine("One or both version(s) is/are not installed!");
                return;
            }
            Console.WriteLine("Preparing conversion...");
            var versionJsonFile1 = dir + string.Format(@"minecraft\versions\{0}\{0}.json", version1);
            var content1 = File.ReadAllText(versionJsonFile1);
            var json1 = JsonConvert.DeserializeObject<VersionInformation>(content1);
            var versionJsonFile2 = dir + string.Format(@"minecraft\versions\{0}\{0}.json", version2);
            var content2 = File.ReadAllText(versionJsonFile2);
            var json2 = JsonConvert.DeserializeObject<VersionInformation>(content2);
            Console.WriteLine(@"Removing ""inheritsFrom"" value from " + version2);
            json2.ParentVersion = null;
            Console.WriteLine(@"Copy libraries from " + version1);
            for (var i = 0; i < json1.Librarieses.Count; i++)
            {
                var lib = json1.Librarieses[i];
                var modifiedLib = new Libraries
                {
                    Name = lib.Name,
                    Natives = lib.Natives,
                    Rules = lib.Rules
                };
                json2.Librarieses.Add(modifiedLib);
            }
            Console.WriteLine("Serializing new JSON...");
            var newJson = JsonConvert.SerializeObject(json2, Formatting.Indented,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            File.WriteAllText(versionJsonFile2, newJson);
            Console.WriteLine("Done!");
        }

        public static bool VersionInstalled(string version)
        {
            var versionDir = dir + string.Format(@"minecraft\versions\{0}", version);
            var versionJarFile = dir + string.Format(@"minecraft\versions\{0}\{0}.jar", version);
            var versionJsonFile = dir + string.Format(@"minecraft\versions\{0}\{0}.json", version);
            if (!Directory.Exists(versionDir) || !File.Exists(versionJarFile) || !File.Exists(versionJsonFile))
            {
                Console.WriteLine(version + " isn't installed!");
                return false;
            }
            var content = File.ReadAllText(versionJsonFile);
            try
            {
                var json = JsonConvert.DeserializeObject<VersionInformation>(content);
                if (json.Id != version)
                {
                    Console.WriteLine(version + " has a invalid JSON file!");
                }
                return json.Id == version;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine(version + " has a invalid JSON file!");
                Console.WriteLine(ex.ToString());
                return false;
            }
            
            
        }
    }
}
