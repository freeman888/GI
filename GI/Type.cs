using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{
    public static class GType
    {
        public static List<string> types = new List<string>();
        public static bool Sign(string type)
        {
            if (types.Contains(type))
                throw new Exceptions.RunException(Exceptions.EXID.类型冲突, "类型冲突 :" + type);
            types.Add(type);
            return true;
        }

        public static IOBJ GetSpecialParentFromType(IOBJ source, string type)
        {

            IOBJ i = source;
            while (i.IGetType() != type && i.IGetParent() != null)
                i = i.IGetParent();
            if (i.IGetType() != type)
                return null;
            else
                return i;
        }
    }
    public interface IOBJ
    {
        string IGetType();
        string ToString();

        /// <summary>
        /// Gasoline类将不用返回实例
        /// </summary>
        /// <returns>Gasoline类返回null，请先用IGetParent获取类型</returns>
        object IGetCSValue();
        Variable IGetMember(string name);

        /// <summary>
        /// 返回null为没有父对象
        /// </summary>
        /// <returns>父对象</returns>
        IOBJ IGetParent();



    }

    public class GClass : IOBJ
    {
        public object IGetCSValue()
        {
            return null;
        }

        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        public IOBJ IGetParent()
        {
            return parent;
        }

        public string IGetType()
        {
            return type;
        }

        string type;
        internal Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        internal IFunction ctor;
        internal IOBJ parent = null;

       

        public GClass(string type, string parent,Hashtable xc)
        {
            this.type = type;
            if(!string.IsNullOrEmpty(parent))
            {
                var ct_parent =  xc.GetCSVariable<GClassTemplate>(parent);
                this.parent = ct_parent.CreatFromClassTemplate(xc);
            }
        }
    }

    /// <summary>
    /// C#原生类也应该创建，只需要手动设置成员
    /// </summary>
    public class GClassTemplate : IOBJ,IFunction
    {
        static GClassTemplate()
        {
            GType.Sign("ClassTemplate");
        }
        internal string classname, parentclassname;
        public string poslib { get => "System"; set => throw new Exceptions.RunException(Exceptions.EXID.未知); }
        internal List<string> membernames = new List<string>();
        internal Dictionary<string,IFunction> memberfuncs = new Dictionary<string,IFunction>();
        internal IFunction ctor;
        public GClassTemplate(string _type,string poslib,string _parent = "") 
            
        {
            classname = _type;
            parentclassname = _parent;
            this.poslib = poslib;
        }

        /// <summary>
        /// C#原生类勿调用此方法
        /// </summary>
        /// <param name="childNodes"></param>
        internal void LoadContent(XmlNodeList childNodes)
        {
            foreach(XmlNode i in childNodes)
            {
                if (i.Name == "member")
                    membernames.Add(i.GetAttribute("value"));
                else if (i.Name == "memfun" && i.GetAttribute("funname") == "init")
                {
                    Function.New_User_Function new_User_Function = new Function.New_User_Function(i,poslib);
                    ctor = new_User_Function;
                }
                else if (i.Name == "memfun")
                {
                    Function.New_User_Function new_User_Function = new Function.New_User_Function(i,poslib);
                    memberfuncs.Add(i.GetAttribute("funname"), new_User_Function);
                }
                else throw new Exceptions.RunException(Exceptions.EXID.未知);
            }
        }

        /// <summary>
        /// 注意，这个xc是已经处理过的xc
        /// </summary>
        /// <param name="xc"></param>
        /// <returns></returns>
        public object IRun(Hashtable xc)
        {
            return new Variable(CreatFromClassTemplate(xc));
        }

        /// <summary>
        /// C#原生类请实现该委托
        /// </summary>
        internal Func<Hashtable, IOBJ> csctor = null;

        /// <summary>
        /// 注意，这个xc是已经处理过的xc,应该有构造函数的参数,不含对象本身
        /// </summary>
        /// <param name="xc"></param>
        /// <returns></returns>
        public IOBJ CreatFromClassTemplate(Hashtable xc)
        {
            if (csctor != null)
            {
                return csctor.Invoke(xc);
            }
            else
            {
                IOBJ parent;
                if (!string.IsNullOrEmpty(parentclassname))
                    parent = xc.GetCSVariable<GClassTemplate>(parentclassname);
                GClass gClass = new GClass(classname, parentclassname, xc);
                gClass.ctor = this.ctor;
                foreach (var i in membernames) gClass.members.Add(i, new Variable(0));
                foreach (var i in memberfuncs) gClass.members.Add(i.Key, new Variable(new Function.MFunction(i.Value,gClass)));
                xc.Add("this", new Variable(gClass));
                ctor.IRun(xc);
                return gClass;
            }
        }

        #region
        public string Istr_xcname { get => ctor.Istr_xcname; set => ctor.Istr_xcname = value; }
        public bool Iisreffunction { get => ctor.Iisreffunction; set => ctor.Iisreffunction = value; }
        public string IInformation { get => ctor.IInformation; set => ctor.IInformation = value; }
        public bool Iisasync { get => ctor.Iisasync; set => ctor.Iisasync = value; }

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exceptions.RunException(Exceptions.EXID.异步异常);
        }

        public object IGetCSValue()
        {
            return this;
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

        public string IGetType()
        {
            return "ClassTemplate";
        }


       

        #endregion



    }
}
