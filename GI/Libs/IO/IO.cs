using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GI
{
    public partial class Lib
    {
        public class IO_Lib : ILib
        {


            public IO_Lib()
            {
                myThing.Add("debug", new Variable(new IO_Function_Debug()));
            }
           
            public class IO_Function_Debug : Function
            {
                public IO_Function_Debug()
                {
                    poslib = "IO";
                    str_xcname = "text";
                    IInformation = "[text]:the text to be written to the debug page;\nusing this methord to write text to tip user.";
                }
                public override object Run(Hashtable xc)
                {
                    string text = ((Variable)xc["text"]).value.ToString();
                    Debug.WriteLine(text);
                    return new Variable(this);
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
