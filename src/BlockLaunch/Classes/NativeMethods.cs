using System;
using System.Linq;
using System.Management;

namespace BlockLaunch.Classes
{
    public class NativeMethods
    {
        public static decimal MaxMemory()
        {
            const string query = "SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem";
            var searcher = new ManagementObjectSearcher(query);
            var result = (from ManagementObject wniPart in searcher.Get() select Convert.ToDecimal(wniPart.Properties["TotalVisibleMemorySize"].Value) into sizeinKb select sizeinKb / 1024 into sizeinMb select sizeinMb / 1024).FirstOrDefault();
            return Math.Round(result, 1);
        }
    }
}
