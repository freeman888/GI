using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GTXAM
{
    public static class GTXAMInfo
    {

        public static List<XmlDocument> Codes = new List<XmlDocument>();
        public static void SetPlatform(string platform)
        {
            GI.GIInfo.Platform = platform;
        }

        public static Func<string, string,string,string> InputFunction;
        public static string InputResult = "";
        public static bool Inputdone = false;
    }
}
