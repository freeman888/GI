using System;
using System.Collections;
using System.Text;
using System.Xml;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GI
{




    public class Variable
    {





        public class Resulter
        {
            int condition;
            Variable ret_veriable;
            Resulter[] childresulters;
            Resulter functionresulter;
            string  ret_variablename;
            

            /// <summary>
            /// 构造Resulter 从Xml
            /// </summary>
            /// <param name="me">arg</param>
            public Resulter(XmlNode me)
            {
                string con = me.GetAttribute("con");
                if(con == "var")
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
                else if(con == "str")
                {
                    string value = me.GetAttribute("value");
                    ret_veriable = new Variable(value) {  isconst = true};
                    condition = 1;
                }
                else if(con == "num")
                {
                    string value = me.GetAttribute("value");
                    ret_veriable = new Variable(Convert.ToDouble(value)) {  isconst = true};
                    condition = 1;
                }
                else if(con == "fun")
                {
                    functionresulter = new Resulter(me.FirstChild.FirstChild);
                    List<Resulter> list = new List<Resulter>();
                    foreach(XmlNode i in me.ChildNodes[1].ChildNodes)
                    {
                        list.Add(new Resulter(i));
                    }
                    childresulters = list.ToArray();
                    condition = 3;
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

                    string xcname = truefunction.Istr_xcname;

                    Hashtable temphashtable;
                    ArrayList tempavariables = new ArrayList();
                    foreach (Resulter resulter in childresulters)
                    {
                        tempavariables.Add(await resulter.Run(basehashtable));
                    }

                    if (truefunction.Iisreffunction)
                    {
                        temphashtable = SetvariablesnameByRef(xcname, tempavariables);
                    }
                    else
                    {
                        temphashtable = Setvariablesname(xcname, tempavariables);
                    }
                    if(truefunction.Iisasync)
                    {
                        return (Variable) await (truefunction as IFunction).IAsyncRun(temphashtable);
                    }
                    return (Variable)(truefunction as IFunction).IRun(temphashtable);
                }
                else
                {
                    return new Variable(-1);
                }
            }


            public static Hashtable Setvariablesname(string xcname, ArrayList tempvariables)
            {

                var hashtable = GetOwnVariables(Gasoline.sarray_Sys_Variables);
                ArrayList newvariables = new ArrayList();
                foreach (Variable v in tempvariables)
                {
                    newvariables.Add(new Variable(v.value));
                }
                if (xcname.Replace(" ","") == "")
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
                if (xc_names.Length != tempvariables.Count)
                    throw new Exception("参数传递错误");
                for (int i = 0; i < xc_names.Length; i++)
                {
                    hashtable.Add(xc_names[i], newvariables[i]);
                }
                return hashtable;

            }

            public static Hashtable SetvariablesnameByRef(string xcname, ArrayList tempvariables)
            {

                var hashtable = GetOwnVariables(Gasoline.sarray_Sys_Variables);

                if (xcname == "")
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

        

        /// <summary>
        /// 获取不干扰原变量表的新变量表
        /// </summary>
        /// <param name="basehashtable">原变量表</param>
        /// <returns>新变量表</returns>
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

        public Variable(IType o)
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

            if (o is IType)
                value = o as IType;
            else if (o is int)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is double)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is string)
                value = new Gstring(o.ToString());
            else if (o is bool)
                value = new Gbool(Convert.ToBoolean(o));
            else
                value = new Gunknown(o);
        }

        public bool isconst = false;

        private IType m_value;

        public IType value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (isconst)
                {
                    throw new Exception("常量不允许赋值");
                }
                else
                {
                    m_value = value;
                }
            }
        }

    }
}