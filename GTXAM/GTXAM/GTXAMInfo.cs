using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GTXAM
{
    public static class GTXAMInfo
    {
        public static XmlDocument Codes = null;
        public static void SetPlatform(string platform)
        {
            GI.GIInfo.Platform = platform;
        }
    }
}
