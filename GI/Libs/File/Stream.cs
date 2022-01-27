using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using static GI.Function;

namespace GI
{
    public class GStream : IOBJ
    {
        public static Dictionary<string, ZipArchive> gaas = new Dictionary<string, ZipArchive>();
        public GStream(System.IO.Stream stream)
        {
            value = stream;
            members = new Dictionary<string, Variable>
            {
                {"Close" ,new Variable(new MFunction(close,this))},
                {"ReadText", new Variable(new MFunction(readtext,this)) },
                {"WriteText",new Variable(new MFunction(writetext,this)) }
            };
        }


        static IFunction close = new Stream_Function_Close();
        public class Stream_Function_Close : Function
        {
            public Stream_Function_Close()
            {
                IInformation = "close this stream";
                str_xcname = "";
            }
            public override object Run(Hashtable xc)
            {
                var stream = xc.GetCSVariableFromSpeType<Stream>("this", "Stream");
                stream.Close();
                return new Variable(0);
            }
        }
        static IFunction readtext = new Stream_Function_ReadText();
        public class Stream_Function_ReadText : Function
        {
            public Stream_Function_ReadText()
            {
                IInformation = "read the text from this stream";
                str_xcname = "";
            }
            public override object Run(Hashtable xc)
            {
                var stream = xc.GetCSVariableFromSpeType<Stream>("this", "Stream");
                StreamReader streamReader = new StreamReader(stream);
                return new Variable(streamReader.ReadToEnd());
            }
        }
        static IFunction writetext = new Stream_Function_WriteText();
        public class Stream_Function_WriteText : Function
        {
            public Stream_Function_WriteText()
            {
                IInformation = "write text to this stream";
                str_xcname = "text";
            }
            public override object Run(Hashtable xc)
            {
                var stream = xc.GetCSVariableFromSpeType<Stream>("this", "Stream");
                var text = xc.GetCSVariable<object>("text").ToString();
                var streamwriter = new StreamWriter(stream);
                streamwriter.Write(text);
                streamwriter.Close();
                return new Variable(0);

            }
        }

        #region
        public const string type = "Stream";
        System.IO.Stream value;
        static GStream()
        {
            GType.Sign(type);

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
            return type;
        }
        #endregion
        #region
        Dictionary<string, Variable> members;
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
