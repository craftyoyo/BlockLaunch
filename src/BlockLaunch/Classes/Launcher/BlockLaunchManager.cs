using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Launcher
{
    public sealed class BlockLaunchManager
    {
        private static BlockLaunchManager _instance;

        public enum LogMode
        {
            None,
            Information,
            Warning,
            Error,
            Exception
        }

        public static BlockLaunchManager Instance
        {
            get
            {
                 return _instance ?? (_instance = new BlockLaunchManager());
            }
        }

        

        #region Config
        public Config LoadConfig()
        {
            string json;
            using (var fs = new FileStream("config.json", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (var sw = new StreamReader(fs))
                {
                    json = sw.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<Config>(json);
        }

        public List<Profile> LoadProfiles()
        {
            if (!File.Exists("profiles.json")) return null;
            string json;
            using (var fs = new FileStream("profiles.json", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (var sw = new StreamReader(fs))
                {
                    json = sw.ReadToEnd();
                }
            }
            return JsonConvert.DeserializeObject<List<Profile>>(json);
        }

        public void SaveConfig(Config config)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            using (var fs = new FileStream("config.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(json);
                }
            }
        }

        public void SaveProfiles(List<Profile> profiles)
        {
            var json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
            using (var fs = new FileStream("profiles.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(json);
                }
            }
            
        }

        public bool ConfigAccessable()
        {
            var requiredPermission = new FileIOPermission(FileIOPermissionAccess.AllAccess,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"));
            try
            {
                requiredPermission.Demand();
                return true;
            }
            catch (SecurityException)
            {
                return false;
            }
        }

        public bool ConfigExists()
        {
            return File.Exists("config.json");
        }

        public void GenerateConfigFile()
        {
            using (var fs = new FileStream("config.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var sw = new StreamWriter(fs))
                {
                    var defaultConfig = new Config()
                    {
                        SavePassword = false,
                        Language = "EN",
                        SelectedProfile = null,
                        ShowAlpha = false,
                        ShowBeta = false,
                        ShowSnapshot = false
                    };
                    var json = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);
                    sw.Write(json);
                }
            }
        }
        #endregion

        public string LogMessage(string message, LogMode mode, bool appendTime, Language.Language selectedLanguage)
        {
            var modifiedMessage = message;
            switch (mode)
            {
                case LogMode.None:
                    break;
                case LogMode.Information:
                    modifiedMessage = "[" + selectedLanguage.LogInfo + "] " + modifiedMessage;
                    break;
                case LogMode.Warning:
                    modifiedMessage = "[" + selectedLanguage.LogWarning + "] " + modifiedMessage;
                    break;
                case LogMode.Error:
                    modifiedMessage = "[" + selectedLanguage.LogError + "] " + modifiedMessage;
                    break;
                case LogMode.Exception:
                    modifiedMessage = "[" + selectedLanguage.LogException + "] " + modifiedMessage;
                    break;
                default:
                    // ReSharper disable once LocalizableElement
                    throw new InvalidEnumArgumentException("LogMode is not a valid Log Mode!");
            }
            if (appendTime)
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                modifiedMessage = "[" + time + "] " + modifiedMessage;
            }
            if (modifiedMessage == message)
            {
                throw new ArgumentException("Modified Message equals given message. If you use LogMode.None set appendTime to true.");
            }
            return modifiedMessage;
        }

        public List<Language.Language> LoadLanguages()
        {
            if (!Directory.Exists("languages"))
            {
                Directory.CreateDirectory("languages");
                WriteByteArray(@"languages\de.json",Properties.Resources.DELang);
                WriteByteArray(@"languages\en.json", Properties.Resources.ENLang);
            }
            var langFiles = Directory.GetFiles("languages");
            if (!langFiles.Any())
            {
                WriteByteArray(@"languages\de.json", Properties.Resources.DELang);
                WriteByteArray(@"languages\en.json", Properties.Resources.ENLang);
                langFiles = Directory.GetFiles("languages");
            }
            var result = langFiles.Select(File.ReadAllText).Select(JsonConvert.DeserializeObject<Language.Language>).ToList();
            return result;
        }

        private static void WriteByteArray(string fileName, byte[] bytes)
        {
            if (!File.Exists(fileName))
            {
                using (File.Create(fileName)) {}
            }
                
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write, FileShare.Read);
            var binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(bytes);
            binaryWriter.Close();
            fileStream.Close();
        }
    }
}
