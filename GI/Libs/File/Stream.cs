using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace GI
{
    public class GStream : IOBJ
    {
        public static Dictionary<string,ZipArchive> gaas = new Dictionary<string, ZipArchive>();

        #region
        public const string type = "stream";
        System.IO.Stream value;
        static GStream()
        {
            GType.Sign(type);
        }
        public GStream(System.IO.Stream stream)
        {
            value = stream;
        }
        public object IGetCSValue()
        {
            return value;
        }
        public string IGetType()
        {
            return type;
        }

        public override string ToString()
        {
            return value.ToString();
        }
        #endregion
        #region
        Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        public IOBJ IGetParent()
        {
            return null;
                 
        }
        #endregion   
    }
}
