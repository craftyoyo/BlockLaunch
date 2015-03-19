using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using BlockLaunch.Classes.JSON;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace BlockLaunch.Optifine
{
    public class Program
    {
        private static readonly AutoResetEvent VersionFound = new AutoResetEvent(false);

        public  static void Main(string[] args)
        {
            Console.Title = "BlockLaunch Optifine Installer";
            if (!TestForValidJar(args))
            {
                Environment.Exit(-1);
            }
            var status = ReadVersion(args[0]);
            if (status != "success")
            {
                Console.WriteLine("Could'nt get version from JAR File!");
                Console.WriteLine("Output: " + status);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Copy vanilla version...");
            var src = Environment.CurrentDirectory + @"\" + string.Format(@"minecraft\versions\{0}", _output1);
            var dest = Environment.CurrentDirectory + @"\" + string.Format(@"minecraft\versions\{0}", _output2);
            DirectoryCopy(src, dest, false);
            CreateFiles(args[0]);
            UpdateJar(_output1, _output2, src + @"\" + _output1 + ".jar", args[0]);
            UpdateJson(_output1, _output2);
        }

        private static bool TestForValidJar(IReadOnlyList<string> args)
        {
            if (args.Count == 0)
            {
                Console.WriteLine("Drag & Drop the Optifine JAR on the EXE File to install Optifine!");
                Console.ReadKey();
                return false;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("The given file don't exists!");
                Console.ReadKey();
                return false;
            }
            if (!File.Exists("BlockLaunch.exe") || !Directory.Exists("minecraft"))
            {
                Console.WriteLine("You didn't place the EXE in the BlockLaunch Directory!");
                Console.ReadKey();
                return false;
            }
            var fi = new FileInfo(args[0]);
            if (fi.Extension == ".jar") return true;
            Console.WriteLine("The given file is not a JAR File!");
            Console.ReadKey();
            return false;
        }

        private static string _output1;
        private static string _output2;

        private static string ReadVersion(string file)
        {
            var java = JavaPath();
            if (java == null) return "jre_notfound";
            var process = new Process();
            var start = new ProcessStartInfo(java)
            {
                CreateNoWindow = true,
                Arguments = @"-jar """ + file + @"""",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };
            process.StartInfo = start;
            process.OutputDataReceived += ProcessOnOutputDataReceived;
            process.ErrorDataReceived += process_ErrorDataReceived;
            Console.WriteLine("Getting version from JAR File...");
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            VersionFound.WaitOne();
            if(!process.HasExited) process.Kill();
            Console.WriteLine("Vanilla version is " + _output1);
            Console.WriteLine("OptiFine version is " + _output2);
            return "success";
        }

        static void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            Console.WriteLine(e.Data);
        } 

        private static void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs dataReceivedEventArgs)
        {
            if (dataReceivedEventArgs.Data == null) return;
            if (dataReceivedEventArgs.Data.StartsWith("Minecraft Version:"))
            {
                var version = dataReceivedEventArgs.Data.Replace("Minecraft Version:", "").Trim();
                _output1 = version;
                VersionFound.Set();
            }
            else if (dataReceivedEventArgs.Data.StartsWith("OptiFine Version:"))
            {
                var version = dataReceivedEventArgs.Data.Replace("OptiFine Version:", "").Trim();
                _output2 = version;
                
            }
            
        }

        private static string JavaPath()
        {
            const string javaKey = @"SOFTWARE\JavaSoft\Java Runtime Environment";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                if (baseKey == null) return null;
                var currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                using (var homeKey = baseKey.OpenSubKey(currentVersion))
                    if (homeKey != null) return homeKey.GetValue("JavaHome") + @"\bin\java.exe";
            }
            return null;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool overrideFile = true)
        {
 
            var dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists) return;
            var dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, overrideFile);
            }
            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    var temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true, overrideFile);
                }
            }
        }

        private static void DirectoryMove(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists) return;
            var dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var temppath = Path.Combine(destDirName, file.Name);
                if (File.Exists(temppath))
                {
                    File.Delete(temppath);
                }
                file.MoveTo(temppath);
            }
            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    var temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryMove(subdir.FullName, temppath, true);
                }
            }
        }

        private static void CreateFiles(string file)
        {
            Console.WriteLine("Copy new libraries...");
            var versionFolder = _output2.Replace("OptiFine_", "");
            var versionFile = _output2.Replace("OptiFine_", "OptiFine-");
            var wc = new WebClient {Proxy = null};
            var libFi = new FileInfo(@"minecraft\libraries\net\minecraft\launchwrapper\1.7\launchwrapper-1.7.jar");
            if (libFi.DirectoryName != null) Directory.CreateDirectory(libFi.DirectoryName);
            wc.DownloadFile("https://libraries.minecraft.net/net/minecraft/launchwrapper/1.7/launchwrapper-1.7.jar", @"minecraft\libraries\net\minecraft\launchwrapper\1.7\launchwrapper-1.7.jar");
            wc.DownloadFile("https://libraries.minecraft.net/net/minecraft/launchwrapper/1.7/launchwrapper-1.7.jar.sha1", @"minecraft\libraries\net\minecraft\launchwrapper\1.7\launchwrapper-1.7.sha");
            var fi = new FileInfo(file);
            Directory.CreateDirectory(@"minecraft\libraries\optifine\OptiFine\" + versionFolder);
            fi.CopyTo(@"minecraft\libraries\optifine\OptiFine\" + versionFolder + @"\" + versionFile + ".jar");
        }

        private static void UpdateJar(string oldVersion, string newVersion, string oldFile, string newFile)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}", newVersion)))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\" +
                                          string.Format(@"minecraft\versions\{0}", newVersion));
            }
            Console.WriteLine("Applying JAR changes...");
            Directory.CreateDirectory(@"work\" + oldVersion);
            Directory.CreateDirectory(@"work\" + newVersion);
            ExtractJar(oldFile, @"work\" + oldVersion);
            ExtractJar(newFile, @"work\" + newVersion);
            Console.WriteLine("Merge both versions...");
            DirectoryMove(@"work\" + newVersion, @"work\" + oldVersion, true);
            Console.WriteLine("Deleting signatures...");
            if (Directory.Exists(@"work\" + oldVersion + @"\META-INF"))
            {
                Directory.Delete(@"work\" + oldVersion + @"\META-INF", true);
            }
            Console.WriteLine("Creating new JAR file...");
            CreateJar(@"work\" + oldVersion, @"work\" + newVersion + ".jar");
        }

        private static void ExtractJar(string file, string destionation)
        {
            if (!Directory.Exists(destionation))
            {
                Directory.CreateDirectory(destionation);
            }
            var fz = new FastZip();
            Console.WriteLine("Extracting jar file " + file);
            fz.ExtractZip(file, destionation, "");
        }

        private static void CreateJar(string sourceFolder, string jar)
        {
            var zip = new FastZip {CreateEmptyDirectories = true};
            zip.CreateZip(jar, sourceFolder, true, "", "");
        }

        private static void UpdateJson(string oldVersion, string newVersion)
        {
            if(!Directory.Exists(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}", newVersion)))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\" +
                                          string.Format(@"minecraft\versions\{0}", newVersion));
            }
            Console.WriteLine("Read JSON file from old version...");
            var fileContent =
                File.ReadAllText(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}\{0}.json", oldVersion));
            Console.WriteLine("Patching JSON...");
            var json = JsonConvert.DeserializeObject<VersionInformation>(fileContent);
            json.Id = newVersion;
            json.MainClass = "net.minecraft.launchwrapper.Launch";
            var lib = new Libraries {Name = "net.minecraft:launchwrapper:1.7"};
            var id = _output2.Replace("OptiFine_", "");
            var optifine = new Libraries {Name = "optifine:OptiFine:" + id};
            json.Librarieses.Add(optifine);
            json.Librarieses.Add(lib);
            json.ArgumentTemplate = json.ArgumentTemplate + " --tweakClass optifine.OptiFineTweaker";
            var newJson = JsonConvert.SerializeObject(json, Formatting.Indented, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            File.WriteAllText(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}\{0}.json", newVersion), newJson);
            File.Move(@"work\" + _output2 + ".jar", Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}\{0}.jar", newVersion));
            File.Delete(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}\{1}.json", newVersion,oldVersion));
            File.Delete(Environment.CurrentDirectory + @"\" +
                                 string.Format(@"minecraft\versions\{0}\{1}.jar", newVersion, oldVersion));
            Console.WriteLine(@"Deleting ""work"" directory");
            Directory.Delete(@"work", true);
        }
    }
}
