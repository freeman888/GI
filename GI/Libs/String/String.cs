using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static GI.Function;

namespace GI
{
    partial class Lib
    {
        public class String_Lib : ILib
        {
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();
            public List<string> waittoadd { get; set; } = new List<string>();


            public String_Lib()
            {
                myThing.Add("StringAdd", new Variable(new String_Function_Add()));
                myThing.Add("StringIsEqual", new Variable(new String_Function_IsEqual()));
            }

           



            #region 连接字符串

            public class String_Function_Add : Function
            {
                public String_Function_Add()
                {
                    str_xcname = "params";
                    poslib = "String";
                }
                public override object Run(Hashtable xc)
                {
                    var array = Variable.GetTrueVariable<Glist>(xc, "params");
                    string s = "";
                    foreach (object o in array)
                        s = s + (o as Variable).value.ToString();
                    return new Variable(s);
                }
            }


            #endregion

            //判断是否相等
            public class String_Function_IsEqual : Function
            {
                public String_Function_IsEqual()
                {
                    IInformation = "judge if the two string is same";
                    str_xcname = "s1,s2";
                    poslib = "String";
                }
                public override object Run(Hashtable xc)
                {
                    return new Variable(xc.GetVariable<object>("s1").ToString() == xc.GetVariable<object>("s2").ToString());
                }
            }
        }
    }
}
