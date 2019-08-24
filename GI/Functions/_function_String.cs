using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    partial class Function
    {
        public class String_Head:Head
        {
            //注册
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {

                h.Add("String.Add", new String_Function_Add());
                h.Add("String.Find", new String_Function_Find());
                h.Add("String.Split", new String_Function_Split());
                h.Add("String.SubString", new String_Function_SubString());
                h.Add("String.IsEqual", new String_Function_IsEqual());
                h.Add("String.Replace", new DFunction
                {
                    IInformation = "replace the old string with the new in the str",
                    str_xcname = "str,old,new",
                    dRun = (xc) =>
{
    var str = xc.GetCSVariable<string>("str");
    var old = xc.GetCSVariable<string>("old");
    var _new = xc.GetCSVariable<string>("new");
    return new Variable(str.Replace(old, _new));
}
                });
            }

            #region 连接字符串

            public class String_Function_Add:Function
            {
                public String_Function_Add()
                {
                    str_xcname = "params";
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

            #region 寻找
            public class String_Function_Find : Function
            {
                public String_Function_Find()
                {
                    IInformation = @"it has two reload
[first(string)]:the base stirng
[second(string)]:the string you wanner find in base string
[third(number)]:do not always need.the start position t find";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {
                    var list = xc.GetCSVariable<Glist>("params");
                    Gdebug.WriteLine(list.Count.ToString());
                    if (list.Count == 2)
                    {
                        string s1 = list[0].value.ToString();
                        string s2 = list[1].value.ToString();
                        return new Variable(s1.IndexOf(s2));
                    }
                    else if (list.Count == 3)
                    {
                        string s1 = list[0].value.ToString();
                        string s2 = list[1].value.ToString();
                        int i = Convert.ToInt32(list[2].value);
                        return new Variable(s1.IndexOf(s2, i));
                    }
                    else throw new Exception("参数错误");
                }
            }

            #endregion

            public class String_Function_Split : Function
            {
                public String_Function_Split()
                {
                    IInformation = "split s1 by s2 abd return a list";
                    str_xcname = "s1,s2";
                }
                public override object Run(Hashtable xc)
                {
                    string s1 = Variable.GetTrueVariable<object>(xc, "s1").ToString();
                    string s2 = Variable.GetTrueVariable<object>(xc, "s2").ToString();
                    ArrayList array = new ArrayList(s1.Split(new string[] { s2},StringSplitOptions.RemoveEmptyEntries));
                    var list = new Glist();
                    foreach(object o in array)
                    {
                        list.Add(new Variable(o));
                    }
                    return new Variable(list);
                }
            }

            public class String_Function_SubString : Function
            {
                public String_Function_SubString()
                {
                    IInformation = "sub s1 from s and the length is sure";
                    str_xcname = "s1,s,len";
                }
                public override object Run(Hashtable xc)
                {
                    string s1 = Variable.GetTrueVariable<object>(xc, "s1").ToString();
                    int s = Convert.ToInt32(Variable.GetTrueVariable<object>(xc, "s"));
                    int len = Convert.ToInt32(Variable.GetTrueVariable<object>(xc, "len"));
                    return new Variable(s1.Substring(s,len));
                }
            }


            public class String_Function_IsEqual : Function
            {
                public String_Function_IsEqual()
                {
                    IInformation = "judge if the two string is same";
                    str_xcname = "s1,s2";
                }
                public override object Run(Hashtable xc)
                {
                    return new Variable(xc.GetVariable<object>("s1").ToString() == xc.GetVariable<object>("s2").ToString());
                }
            }
        }
    }
}
