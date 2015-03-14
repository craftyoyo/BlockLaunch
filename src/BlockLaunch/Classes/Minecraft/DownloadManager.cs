using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using BlockLaunch.Classes.JSON;
using Newtonsoft.Json;

namespace BlockLaunch.Classes.Minecraft
{
    public class DownloadManager
    {
        public delegate void DownloadStarted(object sender, DownloadStartedArgs e);

        public delegate void DownloadFinished(object sender, DownloadFinishedArgs e);

        public event DownloadStarted OnDownloadStarted;
        public event DownloadFinished OnDownloadFinished;

        public class DownloadStartedArgs : EventArgs
        {
            public DownloadStartedArgs(string downloadedFile, string fileType)
            {
                DownloadedFile = downloadedFile;
                FileType = fileType;
            }
            public string DownloadedFile { get; set; }
            public string FileType { get; set; }
        }

        public class DownloadFinishedArgs : EventArgs
        {
            public DownloadFinishedArgs(int count, int total)
            {
                DownloadedFileCount = count;
                TotalFiles = total;
            }
            public int DownloadedFileCount { get; set; }
            public int TotalFiles { get; set; }
        }

        public void DownloadVersion(JSON.Version ver)
        {
            DownloadVersionFiles(ver);
            DownloadLibraries(ver);
            var verinfo = new VersionManager().VersionInfos(ver.Id);
            DownloadAssets(verinfo);
            var args = new DownloadStartedArgs(null, "finished");
            if (OnDownloadStarted != null) OnDownloadStarted(this, args);
        }

        public void DownloadVersionFiles(JSON.Version ver)
        {
            var versionHome = @"minecraft\versions\" + ver.Id;
            if (Directory.Exists(versionHome))
            {
                Directory.Delete(versionHome, true);
            }
            var infos = new VersionManager().VersionInfos(ver.Id);
            var versionManager = new VersionManager();
            var dictVer = versionManager.VersionDownloadPath(ver.Id);
            var jsonPath = new List<string>(dictVer.Values)[0];
            var jarPath = new List<string>(dictVer.Keys)[0];
            var downloader = new WebClient { Proxy = null };
            var fi = new FileInfo(versionHome + @"\" + ver.Id + ".json");
            if (fi.DirectoryName != null && !Directory.Exists(fi.DirectoryName))
            {
                if (fi.DirectoryName != null) Directory.CreateDirectory(fi.DirectoryName);
            }
            fi = new FileInfo(@"minecraft\assets\indexes\" + infos.AssetVersion + ".json");
            if (fi.DirectoryName != null && !Directory.Exists(fi.DirectoryName))
            {
                if (fi.DirectoryName != null) Directory.CreateDirectory(fi.DirectoryName);
            }
            var args = new DownloadStartedArgs(ver.Id + ".json", "version");
            var endArgs = new DownloadFinishedArgs(1, 3);
            if (OnDownloadStarted != null) OnDownloadStarted(this, args);
            downloader.DownloadFile(jsonPath, versionHome + @"\" + ver.Id + ".json");
            if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
            args = new DownloadStartedArgs(ver.Id + ".jar", "version");
            endArgs = new DownloadFinishedArgs(2, 3);
            if (OnDownloadStarted != null) OnDownloadStarted(this, args);
            downloader.DownloadFile(jarPath, versionHome + @"\" + ver.Id + ".jar");
            if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
            args = new DownloadStartedArgs(ver.Id + ".assets.json", "version");
            endArgs = new DownloadFinishedArgs(3, 3);
            if (OnDownloadStarted != null) OnDownloadStarted(this, args);
            downloader.DownloadFile("https://s3.amazonaws.com/Minecraft.Download/indexes/" + infos.AssetVersion + ".json", @"minecraft\assets\indexes\" + infos.AssetVersion + ".json");
            if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
        }

        public void DownloadLibraries(JSON.Version ver)
        {
            var verInfo = File.ReadAllText(string.Format(@"minecraft\versions\{0}\{0}.json", ver.Id));
            var json = JsonConvert.DeserializeObject<VersionInformation>(verInfo);
            var libManager = new LibrarieManager();
            
            var downloadPaths = libManager.LibrarieWebPaths(json.Librarieses);
            var localPaths = libManager.LibrarieLocalPaths(json.Librarieses, false);
            var count = downloadPaths.Count*2;
            var downloadedFiles = 1;
            for (var i = 0; i < downloadPaths.Count; i++)
            {
                var jarLocal = new List<string>(localPaths.Keys)[i];
                var shaLocal = new List<string>(localPaths.Values)[i];
                var jarWeb = new List<string>(downloadPaths.Keys)[i];
                var shaWeb = new List<string>(downloadPaths.Values)[i];
                var fileNameJar = jarLocal.Split('\\').Last();
                var fileNameSha = shaLocal.Split('\\').Last();
                var fi = new FileInfo(jarLocal);
                if (fi.DirectoryName != null) Directory.CreateDirectory(fi.DirectoryName);
                var args = new DownloadStartedArgs(fileNameJar, "lib");
                var endArgs = new DownloadFinishedArgs(downloadedFiles, count);
                if (OnDownloadStarted != null) OnDownloadStarted(this, args);
                using (var downloader = new WebClient {Proxy = null})
                {
                    try
                    {
                        downloader.DownloadFile(jarWeb, jarLocal);
                        if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
                        args = new DownloadStartedArgs(fileNameSha, "lib_sha");
                        if (OnDownloadStarted != null) OnDownloadStarted(this, args);
                        downloader.DownloadFile(shaWeb, shaLocal);
                        endArgs = new DownloadFinishedArgs(downloadedFiles + 1, count);
                        if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
                    }
                    catch (WebException)
                    {
                        if (File.Exists(jarLocal))
                        {
                            var fail = new DownloadStartedArgs(
                                "Couldn't download " + jarWeb + " but local copy exists!", "failed_can_continue");
                            if (OnDownloadStarted != null) OnDownloadStarted(this, fail);
                            continue;
                        }
                        else
                        {
                            var fail = new DownloadStartedArgs(
                                "Couldn't download " + jarWeb, "failed");
                            if (OnDownloadStarted != null) OnDownloadStarted(this, fail);
                            break;
                        }
                    }
                    
                }
                
                downloadedFiles += 2;
            }
        }

        public void DownloadAssets(VersionInformation ver)
        {
            var downloader = new WebClient { Proxy = null };
            var assetManager = new AssetManager();
            var assets = assetManager.Assets(ver.AssetVersion);
            var nameList = assets.Item2;
            var downloadPaths = assets.Item1;
            var count = downloadPaths.Count;
            var downloadedFiles = 1;
            for (var i = 0; i < assets.Item2.Count; i++)
            {
                var localPath = new List<string>(downloadPaths.Values)[i];
                var webPath = new List<string>(downloadPaths.Keys)[i];
                var fi = new FileInfo(localPath);
                if (fi.DirectoryName != null) Directory.CreateDirectory(fi.DirectoryName);
                var args = new DownloadStartedArgs(nameList[i], "asset");
                var endArgs = new DownloadFinishedArgs(downloadedFiles, count);
                if (OnDownloadStarted != null) OnDownloadStarted(this, args);
                downloader.DownloadFile(webPath, localPath);
                if (OnDownloadFinished != null) OnDownloadFinished(this, endArgs);
                downloadedFiles++;
            }
        }
    }
}
