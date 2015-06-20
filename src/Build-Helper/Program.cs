using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace BuildHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainDir = args[0];
            var targetDirectory = args[0] + @"\Libs";
            var targetInfo = new DirectoryInfo(targetDirectory);
            if (!targetInfo.Exists)
            {
                Console.WriteLine("The given directory " + targetDirectory + " does not exists!");
                Environment.Exit(-2);
            }
            Directory.SetCurrentDirectory(mainDir);
            MoveWebkit(args);
            MoveTools(args);
            MoveFiles(args, "*.dll");
            Console.WriteLine("Success!");
        }

        public static void MoveTools(string[] args)
        {
            if (File.Exists(@"Libs\block_converter.exe") && File.Exists(@"Libs\block_optifine_installer.exe") && File.Exists(@"Libs\Newtonsoft.Json.dll") && File.Exists(@"Libs\ICSharpCode.SharpZipLib.dll"))
            {
                if (!Directory.Exists(@"bin\" + args[1] + @"\tools"))
                {
                    Directory.CreateDirectory(@"bin\" + args[1] + @"\tools");
                }
                File.Copy(@"Libs\block_converter.exe", @"bin\" + args[1] + @"\tools\block_converter.exe", true);
                File.Copy(@"Libs\block_optifine_installer.exe",
                    @"bin\" + args[1] + @"\tools\block_optifine_installer.exe", true);
                File.Copy(@"Libs\Newtonsoft.Json.dll", @"bin\" + args[1] + @"\tools\Newtonsoft.Json.dll", true);
                File.Copy(@"Libs\ICSharpCode.SharpZipLib.dll", @"bin\" + args[1] + @"\tools\ICSharpCode.SharpZipLib.dll", true);
            }
            else
            {
                Console.WriteLine("Both tools (Optifine-Installer & Converter) or required libs doesn't exists! Aborting...");
                Environment.Exit(-2);
            }
            if (File.Exists(@"bin\" + args[1] + @"\WebKitBrowser.dll"))
            {
                File.Delete(@"bin\" + args[1] + @"\WebKitBrowser.dll");
            }
        }

        public static void MoveFiles(string[] args, string pattern)
        {
            var work = args[0] + @"\bin\" + args[1];
            var dlls = Directory.GetFiles(work, pattern, SearchOption.TopDirectoryOnly);
            foreach (var dll in dlls)
            {
                var fi = new FileInfo(dll);
                var dest = work + @"\libs\" + fi.Name;
                if (File.Exists(dest))
                {
                    try
                    {
                        File.Delete(dest);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Failed to move " + dest + ". Skipping file...");
                        continue;
                    }
                    
                }
                File.Move(dll, dest);
            }
        }

        public static void MoveWebkit(string[] args)
        {
            var targetDirectory = args[0] + @"\Libs";
            var type = args[1];
            if (Directory.Exists(@"bin\" + type + @"\libs\webkit"))
            {
                return;
            }
            Directory.CreateDirectory(@"bin\" + type + @"\libs");
            if (!File.Exists(@"Libs\Webkit.zip"))
            {

                Console.WriteLine("Webkit.zip does not exists! Aborting...");
                Environment.Exit(-2);
            }

            Extract(@"Libs\Webkit.zip", "Webkit");
            Directory.Move("Webkit", @"bin\" + type + @"\libs\webkit");
        }

        public static void Extract(string srcFile, string dstPath)
        {
            if (!Directory.Exists(dstPath))
            {
                Directory.CreateDirectory(dstPath);
            }
            var fastZip = new FastZip();
            fastZip.ExtractZip(srcFile, dstPath, "");
        }
    }
}
