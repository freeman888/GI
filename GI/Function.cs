using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{

    [Attribute.GasType("function")]
    public interface IFunction:IOBJ
    {
        object IRun(Hashtable xc);
        Task<object> IAsyncRun(Hashtable xc);
        string Istr_xcname { get; set; }
        bool Iisreffunction { get; set; }
        string IInformation { get; set; }
        bool Iisasync { get; set; }

        string poslib { get; set; }
    }

    
    public partial class Function:IFunction
    {
        //实现IFunction
        public string poslib { get ; set ; }
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
            /// <summary>
            /// 自己所在的lib
            /// </summary>
            public Sentence[] sentences;
            public string name;
            

            public New_User_Function(XmlNode code,string poslib)
            {
                this.poslib = poslib;
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



        ///// <summary>
        ///// 函数启动器（安全）
        ///// </summary>
        ///// <param name="funname"></param>
        ///// <param name="variable"></param>
        ///// <param name="ret"></param>
        ///// 
        //public static void FuncStarter(string funname, Hashtable variable, out Variable ret, params Variable[] variables)
        //{

        //    try
        //    {
        //        IFunction function = ((Gasoline.sarray_Sys_Variables[funname] as Variable).value as IFunction);
        //        if (variables.Length != 0)
        //        {
        //            variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables));
        //        }
        //        ret = (Variable)function.IRun(variable);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = new Variable(0);
        //        Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 函数直接启动器（安全）
        ///// </summary>
        ///// <param name="function"></param>
        ///// <param name="variable"></param>
        ///// <param name="ret"></param>
        //public static void FuncStarter(IFunction function, Hashtable variable, out Variable ret,params Variable[] variables)
        //{
        //    try
        //    {
        //        if (variables.Length != 0)
        //        {
        //            variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables));
        //        }
        //        ret = (Variable)function.IRun(variable);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = new Variable(0);
        //        Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 异步函数启动 从函数名
        ///// </summary>
        ///// <param name="funname"></param>
        ///// <param name="variable"></param>
        ///// <returns></returns>
        //public async static Task<object>  AsyncFuncStarter(string funname, Hashtable variable,params Variable[] variables)
        //{
        //    IFunction function = ((Gasoline.sarray_Sys_Variables[funname] as Variable).value as IFunction);
            
        //    object ret;
        //    try
        //    {
        //        if (variables.Length != 0)
        //        {
        //            variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables));
        //        }
        //        ret = await function.IAsyncRun(variable);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = new Task<object>(() => new Variable(0));
        //        Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
        //    }
        //    return ret;
        //}

        ///// <summary>
        ///// 异步函数启动 从函数
        ///// </summary>
        ///// <param name="function"></param>
        ///// <param name="variable"></param>
        ///// <returns></returns>
        //public async static Task<object>  AsyncFuncStarter(IFunction function, Hashtable variable,params Variable[] variables)
        //{
        //    Variable ret;
        //    try
        //    {
        //        if (variables.Length != 0)
        //        {
        //            variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables));
        //        }
        //        ret =   (Variable) await function.IAsyncRun(variable);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = new Variable(0);
        //        Gdebug.ThrowWrong("[-] 错误" + Environment.NewLine + ex.Message);
        //    }
        //    return ret;
        //}

        public static void NewFuncStarter(IFunction function, out Variable ret, params Variable[] variables)
        {
            try
            {
                Hashtable variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables),function.poslib);
                ret = (Variable)function.IRun(variable);
            }
            catch
            {
                throw new Exceptions.RunException(Exceptions.EXID.参数错误);
            }
        }

        public async static Task<object> NewAsyncFuncStarter(IFunction function, params Variable[] variables)
        {
            try
            {
                Hashtable variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables), function.poslib);
                return await function.IAsyncRun(variable);
                
            }
            catch
            {
                throw new Exceptions.RunException(Exceptions.EXID.参数错误);
            }
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


        Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        public IOBJ IGetParent()
        {
            return null;
        }
    }
}