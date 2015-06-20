using System;
using System.Text;

namespace BlockLaunch.Classes
{
    public class Base64Manager
    {
        public string StringToBase64(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var result = Convert.ToBase64String(bytes);
            return result;
        }

        public string StringFromBase64(string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            var result = Encoding.UTF8.GetString(bytes);
            return result;
        }
    }
}
