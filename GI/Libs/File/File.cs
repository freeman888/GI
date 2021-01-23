using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GI
{
   
    partial class Lib
    {
        public class File_Lib :ILib
        {
            public File_Lib()
            {
                myThing.Add("ReadGaa", new Variable( new File_Function_ReadGaa()));
                myThing.Add("FileOpen", new Variable(new File_Function_FileOpen()));
            }

            public class File_Function_ReadGaa:Function
            {
                public File_Function_ReadGaa()
                {
                    poslib = "File";
                    str_xcname = "gaaname,filepath";
                    IInformation = "[gaaname] the gaa(lib) where file exists.\n[filepath] the file path in the gaa";
                }

                public override object Run(Hashtable xc)
                {
                    string gaaname = xc.GetCSVariable<object>("gaaname").ToString();
                    string filepath = xc.GetCSVariable<object>("filepath").ToString();
                    GI.GStream stream = new GStream(GI.GStream.gaas[gaaname].GetEntry(gaaname + "/file/" + filepath).Open());
                    return new Variable(stream);

                }
            }
            public class File_Function_FileOpen : Function
            {
                public File_Function_FileOpen()
                {
                    poslib = "File";
                    str_xcname = "filepath,mode";
                    IInformation = "不推荐此方法，平台差异性过大，读取文件，获得stream\nmode:open,creat,append";
                }

                public override object Run(Hashtable xc)
                {
                    string filepath = xc.GetCSVariable<object>("filepath").ToString();
                    string mode = xc.GetCSVariable<object>("mode").ToString();
                    FileMode fmode;
                    switch (mode)
                    {
                        case "open":
                            fmode = FileMode.Open;
                            break;
                        case "creat":
                            fmode = FileMode.Create;
                            break;
                        case "append":
                            fmode = FileMode.Append;
                            break;
                        default:
                            throw new Exceptions.RunException(Exceptions.EXID.参数错误, "无对应参数");
                    }

                    GI.GStream stream = new GStream(new FileStream(filepath,fmode));
                    return new Variable(stream);

                }
            }


            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }
    }
}
