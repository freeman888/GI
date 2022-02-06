using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{
    public class Sentence
    {



        /// <summary>
        ///  GetSentencesFormXml
        /// </summary>
        /// <param name="codes">the container of sentences</param>
        /// <returns>List that containes the sentences</returns>
        public static List<Sentence> GetSentencesFormXml(XmlNodeList codes)
        {
            List<Sentence> list = new List<Sentence>();
            foreach (var i in codes)
            {
                XmlNode sentence = i as XmlNode;
                string sname = sentence.Name;
                switch (sname)
                {
                    case "if_s":
                        list.Add(new Sentence.New_Sentence_if(sentence));
                        break;
                    case "while_s":
                        list.Add(new Sentence.New_Sentence_while(sentence));
                        break;
                    case "foreach_s":
                        list.Add(new Sentence.New_Sentence_foreach(sentence));
                        break;
                    case "try_s":
                        list.Add(new Sentence.New_Sentence_try(sentence));
                        break;
                    case "var_s":
                        list.Add(new Sentence.New_Sentence_Newref(sentence));
                        break;
                    case "usefun_s":
                        list.Add(new Sentence.New_Sentence_Usefunction(sentence));
                        break;
                    case "getres_s":
                        list.Add(new Sentence.New_Sentence_GiveResult(sentence));
                        break;
                    case "return_s":
                        list.Add(new Sentence.New_Sentence_Return(sentence));
                        break;
                    case "breakpoint":
                        list.Add(new Sentence.New_Sentence_BreakPoint(sentence));
                        break;
                    case "break_s":
                        list.Add(new New_Sentence_Break(sentence));
                        break;
                    case "continue_s":
                        list.Add(new New_Sentence_Continue(sentence));
                        break;
                    default:
                        throw new Exceptions.RunException(Exceptions.EXID.未知, "bug");
                }
            }

            return list;
        }

        public virtual Task Run(Dictionary<string, Variable> h) { return null; }

        public string mycode = "";


        public class New_Sentence_Newref : Sentence
        {
            private string refname = "null";
            public New_Sentence_Newref(XmlNode me)
            {
                mycode = me.GetAttribute("str");

                refname = me.GetAttribute("varname");

            }
            public async override Task Run(Dictionary<string, Variable> htxc)
            {
                try
                {
                    htxc.Add(refname, new Variable(0));
                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
                return;
            }
        }
        public class New_Sentence_BreakPoint : Sentence
        {
            public New_Sentence_BreakPoint(XmlNode me)
            {


            }
            public async override Task Run(Dictionary<string, Variable> htxc)
            {
                try
                {

                    Debugger.Chatwithclient(htxc);

                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
                return;
            }
        }
        public class New_Sentence_Return : Sentence
        {
            Resulter resulter;
            public New_Sentence_Return(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Resulter(me.FirstChild as XmlNode);

            }
            public async override Task Run(Dictionary<string, Variable> htcs)
            {
                try
                {
                    throw new Exceptions.ReturnException() { toreturn = await resulter.Run(htcs) };
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Exceptions.ReturnException))
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_Break : Sentence
        {
            public New_Sentence_Break(XmlNode me)
            {
                mycode = me.GetAttribute("str");

            }
            public async override Task Run(Dictionary<string,Variable> htcs)
            {
                try
                {
                    throw new Exceptions.BreakException();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Exceptions.BreakException))
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_Continue : Sentence
        {
            public New_Sentence_Continue(XmlNode me)
            {
                mycode = me.GetAttribute("str");

            }
            public async override Task Run(Dictionary<string,Variable> htcs)
            {
                try
                {
                    throw new Exceptions.ContinueException();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Exceptions.ContinueException))
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_if : Sentence
        {
            public string boolname;
            public Resulter resulter;
            public Sentence[] thensentences, elsesentences;
            public ArrayList elseifsentences = new ArrayList();
            public bool realif;

            public New_Sentence_if(XmlNode me)
            {
                if (me.Name == "elif")
                {
                    resulter = new Resulter(me.FirstChild.FirstChild as XmlNode);
                    thensentences = GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
                }

                else if (me.Name == "if_s")
                {
                    mycode = me.GetAttribute("str");
                    foreach (XmlNode i in me.ChildNodes)
                    {
                        XmlNode code = i as XmlNode;
                        if (code.Name == "then")
                        {
                            resulter = new Resulter(code.FirstChild.FirstChild as XmlNode);
                            thensentences = GetSentencesFormXml(code.ChildNodes[1].ChildNodes).ToArray();
                        }
                        else if (code.Name == "else")
                        {
                            elsesentences = GetSentencesFormXml(code.FirstChild.ChildNodes).ToArray();
                        }
                        else if (code.Name == "elif")
                        {
                            New_Sentence_if new_Sentence_If = new New_Sentence_if(code);
                            elseifsentences.Add(new_Sentence_If);
                        }
                    }
                }
            }



            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Dictionary<string,Variable> hashtable = Variable.GetOwnVariables(h);
                    realif = Convert.ToBoolean((await resulter.Run(h)).value);
                    if (realif)
                    {
                        foreach (Sentence then in thensentences)
                        {
                            await then.Run(hashtable);
                        }
                        return;
                    }
                    foreach (New_Sentence_if s in elseifsentences)
                    {
                        await s.Run(h);
                        if (s.realif)
                        {
                            return;
                        }
                    }

                    if (!realif && elsesentences != null)
                    {
                        foreach (Sentence e in elsesentences)
                        {
                            await e.Run(hashtable);
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }

                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_GiveResult : Sentence
        {
            Resulter resulter, togive;

            public New_Sentence_GiveResult(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Resulter(me.ChildNodes[1] as XmlNode);
                togive = new Resulter(me.ChildNodes[0] as XmlNode);
            }
            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Variable result = await resulter.Run(h);

                    Variable togivee = await togive.Run(h);
                    togivee.value = result.value;
                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }

        }
        public class New_Sentence_Usefunction : Sentence
        {
            Resulter resulter;

            public New_Sentence_Usefunction(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Resulter(me.FirstChild);
            }
            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Variable result = await resulter.Run(h);
                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_while : Sentence
        {
            public Resulter resulter;
            public Sentence[] childsentences;

            public New_Sentence_while(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Resulter(me.FirstChild.FirstChild as XmlNode);
                childsentences = Sentence.GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
            }
            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Dictionary<string,Variable> hashtable = h;
                    bool realif = Convert.ToBoolean((await resulter.Run(hashtable)).value);
                    while (realif)
                    {
                        Dictionary<string,Variable> hh = Variable.GetOwnVariables(hashtable);
                        foreach (Sentence s in childsentences)
                        {
                            try
                            {
                                await s.Run(hh);
                            }
                            catch (Exceptions.BreakException)
                            {
                                break;
                            }
                            catch (Exceptions.ContinueException)
                            {
                                continue;
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        realif = Convert.ToBoolean((await resulter.Run(hashtable)).value);
                    }

                }

                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_try : Sentence
        {
            public string exname;
            public Sentence[] trysentences, catchsentences;
            bool var_new = false;

            public New_Sentence_try(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                var_new = Convert.ToBoolean((me.ChildNodes[1] as XmlNode).GetAttribute("var_new"));
                trysentences = Sentence.GetSentencesFormXml(me.ChildNodes[0].ChildNodes).ToArray();
                catchsentences = GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
                exname = (me.ChildNodes[1] as XmlNode).GetAttribute("except");


            }
            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Dictionary<string,Variable> hashtable = Variable.GetOwnVariables(h);
                    try
                    {
                        foreach (var s in trysentences)
                        {
                            await s.Run(hashtable);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is Exceptions.ISysException)
                        {
                            throw ex;
                        }
                        if (var_new)
                            hashtable.Add(exname, new Variable(ex.Message));
                        else
                            hashtable[exname] = new Variable(ex.Message);
                        foreach (var s in catchsentences)
                            await s.Run(hashtable);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_foreach : Sentence
        {
            Resulter resulter;
            string fzvar;//待赋值变量
            public Sentence[] childsentences;
            bool var_new = false;

            public New_Sentence_foreach(XmlNode me)
            {
                fzvar = me.GetAttribute("var_togive");
                mycode = me.GetAttribute("str");
                var_new = Convert.ToBoolean(me.GetAttribute("var_new"));
                resulter = new Resulter(me.FirstChild.FirstChild as XmlNode);
                childsentences = GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
            }
            public async override Task Run(Dictionary<string,Variable> h)
            {
                try
                {
                    Dictionary<string,Variable> hashtable = Variable.GetOwnVariables(h);
                    Variable ss = await resulter.Run(hashtable);
                    foreach (var item in (ss.value as Glist))
                    {
                        try
                        {
                            Dictionary<string,Variable> nhashtable = Variable.GetOwnVariables(h);
                            if (var_new)
                                nhashtable.Add(fzvar, item);
                            else
                                nhashtable[fzvar] = item;
                            foreach (Sentence s in childsentences)
                                await s.Run(nhashtable);
                        }
                        catch (Exceptions.BreakException)
                        {
                            break;
                        }
                        catch (Exceptions.ContinueException)
                        {
                            continue;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is Exceptions.ISysException)
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
    }
}