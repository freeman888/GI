using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GI
{
    public class Lib
    {
        public interface ILib
        {
            void Load();
            Dictionary<string, Variable> myThing { get; set; }
            Dictionary<string, Variable> otherThing { get; set; }

            List<string> waittoadd { get; set; }
        }
        public class UserLib : ILib
        {


            //mything 自己的库函数和类，otherThing get到的库函数和类，waittoadd等所有的类库的自己的库函数和类加载好后，在遍历加载需要get的到otherThing里面
            public Dictionary<string, Variable> myThing { get; set; }
            public Dictionary<string, Variable> otherThing { get; set; }
            public List<string> waittoadd { get; set; }

            public void Load(){ }




            public class IO_Lib : ILib
            {


                public void Load()
                {
                    myThing.Add("debug", new Variable(new IO_Function_Write()));
                }
                public Dictionary<string, Variable> myThing { get; set; }
                public Dictionary<string, Variable> otherThing { get; set; }

                public List<string> waittoadd { get; set; }
                public class IO_Function_Write : Function
                {
                    public IO_Function_Write()
                    {
                        str_xcname = "text";
                        IInformation = "[text]:the text to be written to the console page;\nusing this methord to write text to tip user.";
                    }
                    public override object Run(Hashtable xc)
                    {
                        string text = ((Variable)xc["text"]).value.ToString();
                        Debug.WriteLine(text);
                        return new Variable(this);
                    }
                }
            }


        }
    }
}
