using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GI
{
   
    partial class Lib
    {
        public class File_Lib :ILib
        {
            public File_Lib()
            {
                myThing.Add("ReadGaa", new Variable( new File_Function_ReadGaa()));
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

            

            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }
    }
}
