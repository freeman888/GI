using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace GI
{
    partial class Function
    {
        public class File_Head:Head
        {
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {

                h.Add("File.Write", new File_Function_Write());
                h.Add("File.Read", new File_Function_Read());
            }

            public class File_Function_Write:Function
            {

                public File_Function_Write()
                {
                    str_xcname = "filepath,text";
                    IInformation =
@"[filepath(string)]:the path where you want to write
[text(string)]:what to write in your file.
Wirte text to a file";
                }

                public override object Run(Hashtable xc)
                {
                    string filepath = Variable.GetTrueVariable<object>(xc, "filepath").ToString();
                    string text = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(text);
                    streamWriter.Close();
                    return new Variable(0);
                }
            }

            public class File_Function_Read : Function
            {

                public File_Function_Read()
                {
                    str_xcname = "file";
                    IInformation =
@"[filepath(string)]:where the file is
[return(string)]:return what in this file
Read what in this file";
                }

                public override object Run(Hashtable xc)
                {
                    string filepath = Variable.GetTrueVariable<object>(xc, "filepath").ToString();
                    StreamReader streamReader = new StreamReader(filepath);
                    string s = streamReader.ReadToEnd();
                    streamReader.Close();
                    return new Variable(s);
                }
            }
        }
    }
}
