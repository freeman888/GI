﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{

    [Attribute.GasType("function")]
    public interface IFunction:IType
    {
        object IRun(Hashtable xc);
        Task<object> IAsyncRun(Hashtable xc);
        string Istr_xcname { get; set; }
        bool Iisreffunction { get; set; }
        string IInformation { get; set; }
        bool Iisasync { get; set; }
    }
    [Attribute.GasType("function")]

    
    public partial class Function:IFunction
    {
        //实现IFunction
        public object IRun(Hashtable xc)
        {
            return Run(xc);
        }
        string IFunction. Istr_xcname
        {
            get
            {
                return str_xcname;
            }
            set
            {
                str_xcname = value;
            }
        }
        public object IGetCSValue()
        {
            return this;
        }
        bool IFunction. Iisreffunction
        {
            get
            {
                return isreffunction;
            }
            set
            {
                isreffunction = value;
            }
        }
        public string IInformation
        { get ; set; }

        public bool Iisasync { get { return false; } set { }}

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exception();
        }

        /// <summary>
        /// 父类
        /// </summary>
        public class Head
        {
            public virtual void AddFunctions(Dictionary<string,IFunction> h) { }
        }

        public virtual object Run(Hashtable xc)//父方法
        {
            return new object();
        }
        public string str_xcname;
        public bool isreffunction = false;

        //以下为用户自定义函数
        public class New_User_Function : AFunction
        {
            public Sentence[] sentences;
            public string name;
            public New_User_Function(string fname, string fxc)
            {
                Istr_xcname = fxc; name = fname;
            }

            public New_User_Function(XmlNode code)
            {
                name = code.GetAttribute("funname");
                Istr_xcname = code.GetAttribute("params");
                Iisreffunction = Convert.ToBoolean(code.GetAttribute("isref"));
                List<Sentence> list =Sentence. GetSentencesFormXml(code.ChildNodes);

                sentences = list.ToArray();




            }

            public async override Task< object> Run(Hashtable htxc)
            {
                try
                {
                    foreach (Sentence s in sentences)
                    {
                        await s.Run(htxc);
                    }
                }
                catch (Exceptions.ReturnException ex)
                {
                    return ex.toreturn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return new Variable(0);
            }
        }
        
        /// <summary>
        /// 函数启动器（安全）
        /// </summary>
        /// <param name="funname"></param>
        /// <param name="variable"></param>
        /// <param name="ret"></param>
        /// 
        public static void FuncStarter(string funname, Hashtable variable,out Variable ret)
        {
            try
            {
                ret = (Variable) ((Gasoline.sarray_Sys_Variables[funname] as Variable).value as IFunction).IRun(variable);
            }
            catch (Exception ex)
            {
                ret = new Variable(0);
                Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// 函数直接启动器（安全）
        /// </summary>
        /// <param name="function"></param>
        /// <param name="variable"></param>
        /// <param name="ret"></param>
        public static void FuncStarter(IFunction function, Hashtable variable, out Variable ret)
        {
            try
            {
                ret = (Variable)function.IRun(variable);
            }
            catch (Exception ex)
            {
                ret = new Variable(0);
                Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// 异步函数启动 从函数名
        /// </summary>
        /// <param name="funname"></param>
        /// <param name="variable"></param>
        /// <returns></returns>
        public  static Task<object>  AsyncFuncStarter(string funname, Hashtable variable)
        {
            Task<object> ret;
            try
            {
                ret =  ((Gasoline.sarray_Sys_Variables[funname] as Variable).value as IFunction).IAsyncRun(variable);
            }
            catch (Exception ex)
            {
                ret = new Task<object>(() => new Variable(0));
                Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
            }
            return ret;
        }

        /// <summary>
        /// 异步函数启动 从函数
        /// </summary>
        /// <param name="function"></param>
        /// <param name="variable"></param>
        /// <returns></returns>
        public async static Task<object>  AsyncFuncStarter(IFunction function, Hashtable variable)
        {
            Variable ret;
            try
            {
                  ret =   (Variable) await function.IAsyncRun(variable);
            }
            catch (Exception ex)
            {
                ret = new Variable(0);
                Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
            }
            return ret;
        }


        public const string type = "function";

        public string IGetType()
        {
            return type;
        }

        public override string ToString()
        {
            return IGetType();
        }
    }
}