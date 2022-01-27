using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{




    public class Variable
    {





        public class Resulter
        {
            int condition;
            Variable ret_veriable;
            protected Resulter[] childresulters;
            Resulter functionresulter;
            string ret_variablename;

            Resulter memfrom; string memname;

            /// <summary>
            /// 构造Resulter 从Xml
            /// </summary>
            /// <param name="me">arg</param>
            public Resulter(XmlNode me)
            {
                string con = me.GetAttribute("con");
                if (con == "var")
                {
                    string value = me.GetAttribute("value");
                    if (value == "")
                    {
                        ret_veriable = null;
                        return;
                    }
                    ret_variablename = value;
                    condition = 2;
                }
                else if (con == "str")
                {
                    string value = me.GetAttribute("value");
                    ret_veriable = new Variable(value) { isconst = true };
                    condition = 1;
                }
                else if (con == "num")
                {
                    string value = me.GetAttribute("value");
                    ret_veriable = new Variable(Convert.ToDouble(value)) { isconst = true };
                    condition = 1;
                }
                else if (con == "fun")
                {
                    functionresulter = new Resulter(me.FirstChild.FirstChild);
                    List<Resulter> list = new List<Resulter>();
                    foreach (XmlNode i in me.ChildNodes[1].ChildNodes)
                    {
                        list.Add(new Resulter(i));
                    }
                    childresulters = list.ToArray();
                    condition = 3;
                }
                else if (con == "mem")
                {
                    memfrom = new Resulter(me.FirstChild);
                    memname = me.GetAttribute("value");
                    condition = 4;
                }
            }
            public async Task<Variable> Run(Hashtable basehashtable)
            {
                if (condition == 1)
                {
                    return ret_veriable;
                }
                else if (condition == 2)
                { return (Variable)basehashtable[ret_variablename]; }
                else if (condition == 3)
                {
                    Variable var_func = await functionresulter.Run(basehashtable);
                    IFunction truefunction = var_func.value as IFunction;

                    //判断使用async 关键字
                    if (truefunction is Lib.System_Lib.Asyncfunc)
                    {
                        var a = childresulters[0].Run(basehashtable);
                        Debug.Write(a);
                        return new Variable(a);

                    }

                    string xcname = truefunction.Istr_xcname;

                    Hashtable temphashtable;
                    ArrayList tempavariables = new ArrayList();
                    foreach (Resulter resulter in childresulters)
                    {
                        tempavariables.Add(await resulter.Run(basehashtable));
                    }

                    if (truefunction.Iisreffunction)
                    {
                        temphashtable = SetvariablesnameByRef(xcname, tempavariables, truefunction.poslib);
                    }
                    else
                    {
                        temphashtable = Setvariablesname(xcname, tempavariables, truefunction.poslib);
                    }
                    if (truefunction.Iisasync)
                    {
                        return (Variable)await truefunction.IAsyncRun(temphashtable);
                    }
                    return (Variable)truefunction.IRun(temphashtable);
                }
                else if (condition == 4)
                {
                    Variable from = await memfrom.Run(basehashtable);
                    return from.value.IGetMember(memname);
                }
                else
                {
                    return new Variable(-1);
                }
            }


            public static Hashtable Setvariablesname(string xcname, ArrayList newvariables, string poslib)
            {


                var hashtable = GetOwnVariables(poslib);

                if (xcname.Replace(" ", "") == "")
                {
                    return hashtable;
                }
                else if (xcname == "params")
                {
                    var variables = new Glist();
                    foreach (Variable v in newvariables)
                        variables.Add(v);
                    hashtable.Add("params", new Variable(variables));
                    return hashtable;
                }
                string[] xc_names = xcname.Split(',');
                if (xc_names.Length != newvariables.Count)
                    throw new Exceptions.RunException(Exceptions.EXID.参数错误, "参数传递错误");
                for (int i = 0; i < xc_names.Length; i++)
                {
                    hashtable.Add(xc_names[i], new Variable(((Variable)newvariables[i]).value) { isconst = ((Variable)newvariables[i]).isconst });
                }
                return hashtable;

            }

            public static Hashtable SetvariablesnameByRef(string xcname, ArrayList tempvariables, string poslib)
            {

                var hashtable = GetOwnVariables(poslib);

                if (string.IsNullOrEmpty(xcname))
                {
                    return hashtable;
                }
                else if (xcname == "params")
                {
                    var variables = new Glist();
                    foreach (Variable v in tempvariables)
                        variables.Add(v);
                    hashtable.Add("params", new Variable(variables));
                    return hashtable;
                }
                string[] xc_names = xcname.Split(',');
                for (int i = 0; i < xc_names.Length; i++)
                {
                    hashtable.Add(xc_names[i], tempvariables[i]);
                }
                return hashtable;

            }
        }

        public class BaseResulter:Resulter
        {
            public BaseResulter(XmlNode node) : base(node) { }

            internal Resulter[] resulters { get => childresulters; }
        }

        /// <summary>
        /// 获取不干扰原变量表的新变量表
        /// </summary>
        /// <param name="basehashtable">原变量表</param>
        /// <returns>新变量表</returns>
        public static Hashtable GetOwnVariables(string poslib)
        {
            if (string.IsNullOrEmpty(poslib))
                return new Hashtable { { "true", new Variable(true) }, { "false", new Variable(false) } };


            var basehashtable = Gasoline.libs[poslib];

            var hashtable = new Hashtable();
            foreach (var inbase in basehashtable.myThing)
                hashtable.Add(inbase.Key, inbase.Value);
            foreach (var inbase in basehashtable.otherThing)
                hashtable.Add(inbase.Key, inbase.Value);
            return hashtable;
        }

        public static Hashtable GetOwnVariables(Hashtable basehashtable)
        {
            var hashtable = new Hashtable();
            foreach (DictionaryEntry inbase in basehashtable)
            {
                hashtable.Add(inbase.Key, inbase.Value);
            }
            return hashtable;
        }




        public static T GetTrueVariable<T>(Hashtable oldhs, string variablename)
        {
            T t = (T)((Variable)oldhs[variablename]).value;
            return t;
        }

        public Variable(IOBJ o)
        {
            value = o;
        }
        public Variable(int i)
        {
            value = new Gnumber(Convert.ToDouble(i));
        }
        public Variable(double d)
        {
            value = new Gnumber(d);
        }
        public Variable(string s)
        {
            value = new Gstring(s);
        }
        public Variable(bool b)
        {
            value = new Gbool(b);
        }
        public Variable(object o)
        {

            if (o is IOBJ)
                value = o as IOBJ;
            else if (o is int)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is double)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is string)
                value = new Gstring(o.ToString());
            else if (o is bool)
                value = new Gbool(Convert.ToBoolean(o));
            else if (o is Task<Variable>)
                value = new GTask(o as Task<Variable>);
            else
                value = new Gunknown(o);
        }

        public bool isconst = false;

        private IOBJ m_value;

        public virtual IOBJ value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (isconst)
                {
                    throw new Exceptions.RunException(Exceptions.EXID.更改常量, "常量不允许赋值");
                }
                else
                {
                    m_value = value;
                }
            }
        }

    }
    /// <summary>
    /// 是个Variable的空壳，里面的东西应该重新实现
    /// </summary>
    public class FVariable : Variable
    {
        public static IOBJ obj = new Gnumber(0);
        public Func<IOBJ, int> onsetvalue = null;
        public Func<IOBJ> ongetvalue = null;
        public FVariable() : base(obj)
        { }

        public override IOBJ value
        {
            get
            {
                if (ongetvalue != null) return ongetvalue.Invoke();
                else return base.value;
            }
            set { onsetvalue?.Invoke(value); base.value = value; }
        }
    }
}