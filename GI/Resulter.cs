using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace GI
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


                var hashtable = Variable. GetOwnVariables(poslib);

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

                var hashtable =Variable. GetOwnVariables(poslib);

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

    
}