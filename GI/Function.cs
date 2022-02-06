using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{

    [Attribute.GasType("function")]
    public interface IFunction : IOBJ
    {
        object IRun(Dictionary<string,Variable> xc);
        Task<object> IAsyncRun(Dictionary<string, Variable> xc);
        string Istr_xcname { get; set; }
        bool Iisreffunction { get; set; }
        string IInformation { get; set; }
        bool Iisasync { get; set; }

        string poslib { get; set; }
    }


    public partial class Function : IFunction
    {
        //实现IFunction
        public string poslib { get; set; }
        public object IRun(Dictionary<string, Variable> xc)
        {
            return Run(xc);
        }
        string IFunction.Istr_xcname
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
        bool IFunction.Iisreffunction
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
        { get; set; }

        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Dictionary<string, Variable> xc)
        {
            throw new Exception();
        }

        

        public virtual object Run(Dictionary<string, Variable> xc)//父方法
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


            public New_User_Function(XmlNode code, string poslib)
            {
                this.poslib = poslib;
                name = code.GetAttribute("funname");
                Istr_xcname = code.GetAttribute("params");
                Iisreffunction = Convert.ToBoolean(code.GetAttribute("isref"));
                List<Sentence> list = Sentence.GetSentencesFormXml(code.ChildNodes);

                sentences = list.ToArray();




            }

            public async override Task<object> Run(Dictionary<string,Variable> htxc)
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
        /// 构造函数
        /// </summary>
        public class New_Creat_Function : Function
        {
            public Sentence[] sentences;
            public Variable.BaseResulter baseresulter = null;

            public New_Creat_Function(XmlNode code, string poslib)
            {

                this.poslib = poslib;
                str_xcname = code.GetAttribute("params");
                isreffunction = Convert.ToBoolean(code.GetAttribute("isref"));
                Iisasync = false;

                if (code.FirstChild.HasChildNodes)
                {
                    baseresulter = new Variable.BaseResulter(code.FirstChild.FirstChild);
                }

                List<Sentence> list = Sentence.GetSentencesFormXml(code.ChildNodes[1].ChildNodes);

                sentences = list.ToArray();




            }

            public override object Run(Dictionary<string,Variable> htxc)
            {
                try
                {
                    foreach (Sentence s in sentences)
                    {
                        s.Run(htxc).Wait();
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


        public static void NewFuncStarter(IFunction function, out Variable ret, params Variable[] variables)
        {
            try
            {
                Dictionary<string,Variable> variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables), function.poslib);
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
                Dictionary<string,Variable> variable = Variable.Resulter.Setvariablesname(function.Istr_xcname, new ArrayList(variables), function.poslib);
                return await function.IAsyncRun(variable);

            }
            catch (Exception ex)
            {
                throw new Exceptions.RunException(Exceptions.EXID.参数错误, ex.ToString());
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