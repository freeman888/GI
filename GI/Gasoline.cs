using System;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;
using static GI.Lib;

namespace GI
{
    public partial class Gasoline
    {

        /*Gasoline的方法*/
        public static Hashtable sarray_Sys_Variables = new Hashtable();
        public static Dictionary<string, Function.Head> sHeads = new Dictionary<string, Function.Head>();

        //总lib库
        public static Dictionary<string, ILib> libs = new Dictionary<string, ILib>();


        



        //public async static void StartGas(Dictionary<string, Function.Head> heads, XmlDocument codes)
        //{
        //    //Del.Delate();
        //    try
        //    {
        //        // 1 添加自己的Head
        //        sHeads.Add("Math", new Function.Math_Head());
        //        sHeads.Add("Socket", new Function.Socket_Head());
        //        sHeads.Add("System", new Function.System_Head());
        //        sHeads.Add("Thread", new Function.Thread_Head());
        //        sHeads.Add("File", new Function.File_Head());
        //        sHeads.Add("String", new Function.String_Head());
        //        sHeads.Add("List", new Function.List_Head());



        //        // 2 添加其他的Head
        //        foreach (var i in heads)
        //            sHeads.Add(i.Key, i.Value);


        //        // 3 分析 get fun 外部var 

        //        foreach (var i in Getfunandvar(codes))
        //            sarray_Sys_Variables.Add(i.Key, new Variable(i.Value));

        //        // 4 设置常量

        //        sarray_Sys_Variables.Add("true", new Variable(true));

        //        sarray_Sys_Variables.Add("false", new Variable(false));

        //    }
        //    catch (Exception e) {System.Diagnostics. Debug.WriteLine(e); }
        //    // 5 拉起Main

        //    Hashtable ht = Variable.GetOwnVariables(sarray_Sys_Variables);
        //    string str_name = ((sarray_Sys_Variables["Main"] as Variable).value as IFunction).Istr_xcname;
        //    string[] vs = Environment.GetCommandLineArgs();
        //    var arrayList = new Glist();
        //    foreach (string vv in vs)
        //        arrayList.Add(new Variable(vv));
        //    ht.Add(str_name, new Variable((arrayList)));
        //    await Function.AsyncFuncStarter("Main", ht);
            

        //}

        public async static void StartGas(Dictionary<string,UserLib> heads,XmlDocument codes)
        {
            //1加载所有通用Lib
            libs.Add("IO", new IO_Lib());
            libs.Add("System", new System_Lib());
            libs.Add("String",new String_Lib());
            libs.Add("Math", new Math_Lib());
            libs.Add("List", new List_Lib());
            libs.Add("Socket", new Socket_Lib());
            libs.Add("Thread", new Thread_Lib());
            //2加载平台Lib
            foreach (var i in heads)
                libs.Add(i.Key, i.Value);

            //加载用户代码
            Getfunandvar(codes);

            //3加载库依赖
            foreach(var lib in libs)
            {
                foreach(string s_delib in lib.Value.waittoadd)
                {
                    
                    var delib = libs[s_delib];
                    foreach (var i in delib.myThing)
                        lib.Value.otherThing.Add(i.Key, i.Value);
                }
                lib.Value.otherThing.Add("true", new Variable(true));
                lib.Value.otherThing.Add("false", new Variable(false));
            }

            //4拉起Main
            IFunction mainfunc = null;
            foreach(var lib in libs)
            {
                foreach(var libmems in lib.Value.myThing)
                {
                    if(libmems.Key == "Main")
                    {
                        var res = libmems.Value.value.IGetCSValue();
                        mainfunc = libmems.Value.value.IGetCSValue() as IFunction;
                    }
                }
            }
            
            if(mainfunc != null)
            {
                //string str_name = ((sarray_Sys_Variables["Main"] as Variable).value as IFunction).Istr_xcname;
                string[] vs = Environment.GetCommandLineArgs();
                var arrayList = new Glist();
                foreach (string vv in vs)
                    arrayList.Add(new Variable(vv));
                await Function.NewAsyncFuncStarter(mainfunc, new Variable(arrayList));
            }
                



            //Hashtable ht = Variable.GetOwnVariables(sarray_Sys_Variables);
            //string str_name = ((sarray_Sys_Variables["Main"] as Variable).value as IFunction).Istr_xcname;
            //string[] vs = Environment.GetCommandLineArgs();
            //var arrayList = new Glist();
            //foreach (string vv in vs)
            //    arrayList.Add(new Variable(vv));
            //ht.Add(str_name, new Variable((arrayList)));
            //await Function.AsyncFuncStarter("Main", ht);
        }

        static void Getfunandvar(XmlDocument codes)
        {
            if (!codes.HasChildNodes) Gdebug.WriteLine("bugging");
            XmlNode root = codes.ChildNodes[1];
            int minversion = Convert.ToInt32(root.Attributes["minversion"].InnerText);
            if (minversion > GIInfo.GIVersion) Gdebug.ThrowWrong("version not support");
            foreach(XmlNode i in root.ChildNodes)
            {
                var code = i;
                string name = code.Name;
                if (name == "lib")
                {
                    string libname = code.GetAttribute("name");
                    if (!libs.ContainsKey(libname))
                        libs.Add(libname, new UserLib());
                    foreach(XmlNode libcontent in code.ChildNodes)
                    {
                        if (libcontent.Name == "get")
                        {
                            libs[libname].waittoadd.Add(libcontent.GetAttribute("value"));

                        }
                        else if (libcontent.Name == "var")
                            libs[libname].myThing.Add(libcontent.GetAttribute("value"), new Variable(0));
                        else if (libcontent.Name == "cls")
                        {
                            var x_cls = libcontent;
                            GClassTemplate gClassTemplate = new GClassTemplate(x_cls.GetAttribute("name"), libname);
                            gClassTemplate.LoadContent(x_cls.ChildNodes);
                            libs[libname].myThing.Add(libcontent.GetAttribute("name"), new Variable(gClassTemplate));
                        }
                        else if (libcontent.Name == "deffun")
                        {
                            Function.New_User_Function new_User_Function = new Function.New_User_Function(libcontent, libname);
                            libs[libname].myThing.Add(libcontent.GetAttribute("funname"), new Variable(new_User_Function));
                        }
                        else throw new Exceptions.RunException(Exceptions.EXID.未知);

                    }
                }
                else throw new Exceptions.RunException(Exceptions.EXID.未知);
            }



        }

    }
}
