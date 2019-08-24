using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace GI
{

    [Attribute.GasType("function")]
    public interface IFunction:IType
    {
        object IRun(Hashtable xc);
        string Istr_xcname { get; set; }
        bool Iisreffunction { get; set; }
        string IInformation { get; set; }
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
        public class New_User_Function : Function
        {
            public Sentence[] sentences;
            public string name;
            public New_User_Function(string fname, string fxc)
            {
                str_xcname = fxc; name = fname;
            }

            public New_User_Function(XmlNode code)
            {
                name = code.GetAttribute("funname");
                str_xcname = code.GetAttribute("params");
                isreffunction = Convert.ToBoolean(code.GetAttribute("isref"));
                List<Sentence> list =Sentence. GetSentencesFormXml(code.ChildNodes);

                sentences = list.ToArray();




            }

            public override object Run(Hashtable htxc)
            {
                try
                {
                    foreach (Sentence s in sentences)
                    {
                        s.Run(htxc);
                    }
                }
                catch (MyExceptions.ReturnException ex)
                {
                    return ex.toreturn;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return null;
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