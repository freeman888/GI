using System;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.Threading;

namespace GI
{
    public partial class Gasoline
    {

        /*Gasoline的方法*/
        public static Hashtable sarray_Sys_Variables = new Hashtable();
        public static Dictionary<string, Function.Head> sHeads = new Dictionary<string, Function.Head>();




        



        public static void StartGas(Dictionary<string, Function.Head> heads, XmlDocument codes)
        {
            Del.Delate();
            try
            {
                // 1 添加自己的Head
                sHeads.Add("Math", new Function.Math_Head());
                sHeads.Add("Socket", new Function.Socket_Head());
                sHeads.Add("System", new Function.System_Head());
                sHeads.Add("Thread", new Function.Thread_Head());
                sHeads.Add("File", new Function.File_Head());
                sHeads.Add("String", new Function.String_Head());
                sHeads.Add("List", new Function.List_Head());


                // 2 添加其他的Head
                foreach (var i in heads)
                    sHeads.Add(i.Key, i.Value);


                // 3 分析 get fun 外部var 

                foreach (var i in Getfunandvar(codes))
                    sarray_Sys_Variables.Add(i.Key, new Variable(i.Value));

                // 4 设置常量

                sarray_Sys_Variables.Add("true", new Variable(true));

                sarray_Sys_Variables.Add("false", new Variable(false));

            }
            catch (Exception e) {System.Diagnostics. Debug.WriteLine(e); }
            // 5 拉起Main

            Hashtable ht = Variable.GetOwnVariables(sarray_Sys_Variables);
            string str_name = ((sarray_Sys_Variables["Main"] as Variable).value as Function).str_xcname;
            string[] vs = Environment.GetCommandLineArgs();
            var arrayList = new Glist();
            foreach (string vv in vs)
                arrayList.Add(new Variable(vv));
            ht.Add(str_name, new Variable((arrayList)));
            Function.FuncStarter("Main", ht, out Variable v);


        }

        static Dictionary<string, IFunction> Getfunandvar(XmlDocument codes)
        {
            var functions = new Dictionary<string, IFunction>();
            if (!codes.HasChildNodes) Gdebug.WriteLine("bugging");
            XmlNode root = codes.ChildNodes[1];
            int minversion = Convert.ToInt32(root.Attributes["minversion"].InnerText);
            if (minversion > GIInfo.GIVersion) Gdebug.ThrowWrong("version not support");

            foreach (XmlNode i in root.ChildNodes)
            {
                var code = i;
                string name = code.Name;
                if (name == "get")
                {
                    string value = code.Attributes["value"].InnerText;
                    sHeads[value].AddFunctions(functions);
                }
                else if (name == "deffun")
                {
                    Function.New_User_Function new_User_Function = new Function.New_User_Function(code);
                    functions.Add(new_User_Function.name, new_User_Function);
                }
                else if (name == "var")
                {
                    Gasoline.sarray_Sys_Variables.Add(code.GetAttribute("value"), new Variable(0));
                }
                else
                {
                    throw new Exception("未知外围标签");
                }

            }

            return functions;

        }

    }
}
