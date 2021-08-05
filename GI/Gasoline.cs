using System;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using static GI.Lib;
using System.Threading.Tasks;

namespace GI
{
    public partial class Gasoline
    {

        /*Gasoline的方法*/
        public static Hashtable sarray_Sys_Variables = new Hashtable();

        //总lib库
        public static Dictionary<string, ILib> libs = new Dictionary<string, ILib>();


        



        

        /// <summary>
        /// 拉起main请单另拉起,加载用户代码请单另加载
        /// </summary>
        /// <param name="heads"></param>
        /// <param name="codes"></param>
        public  static void StartGas(Dictionary<string,ILib> heads)
        {
            //1加载所有通用Lib
            libs.Add("System", new System_Lib());
            libs.Add("String", new String_Lib());
            libs.Add("Math", new Math_Lib());
            libs.Add("List", new List_Lib());
            libs.Add("Socket", new Socket_Lib());
            libs.Add("Thread", new Thread_Lib());
            libs.Add("File", new File_Lib());
            libs.Add("Xml", new Xml_Lib());
            //2加载平台Lib
            foreach (var i in heads)
                libs.Add(i.Key, i.Value);

            
            //3加载库依赖
            foreach (var lib in libs)
            {
                foreach (string s_delib in lib.Value.waittoadd)
                {

                    var delib = libs[s_delib];
                    foreach (var i in delib.myThing)
                        if(!lib.Value.otherThing.ContainsKey(i.Key))
                            lib.Value.otherThing.Add(i.Key, i.Value);
                }
                lib.Value.otherThing.Add("true", new Variable(true));
                lib.Value.otherThing.Add("false", new Variable(false));
            }
            //await StartMain();


        }

        public static async Task StartMain()
        {

            //4拉起Main
            IFunction mainfunc = null;
            foreach (var lib in libs)
            {
                foreach (var libmems in lib.Value.myThing)
                {
                    if (libmems.Key == "Main")
                    {
                        var res = libmems.Value.value.IGetCSValue();
                        mainfunc = libmems.Value.value.IGetCSValue() as IFunction;
                    }
                }
            }

            if (mainfunc != null)
            {
                //string str_name = ((sarray_Sys_Variables["Main"] as Variable).value as IFunction).Istr_xcname;
                string[] vs = Environment.GetCommandLineArgs();
                var arrayList = new Glist();
                foreach (string vv in vs)
                    arrayList.Add(new Variable(vv));
                await Function.NewAsyncFuncStarter(mainfunc, new Variable(arrayList));
            }
        }

        public static void Loadgasxml(XmlDocument codes)
        {
            //加载用户代码
            Getfunandvar(codes);

        }

        static void Getfunandvar(XmlDocument codes)
        {
            if (!codes.HasChildNodes) Gdebug.WriteLine("bugging");
            XmlNode root = null;
            foreach(XmlNode i in codes.ChildNodes)
            {
                if (i.Name == "code")
                    root = i;
            }
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
                            var parent = x_cls.GetAttribute("parent");
                            var iscvf = x_cls.GetAttribute("cvf");

                            gClassTemplate.iscvf = Convert.ToBoolean( iscvf);
                            gClassTemplate.LoadContent(x_cls.ChildNodes);
                            gClassTemplate.parentclassname = parent;
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
