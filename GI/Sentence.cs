using System;
using System.Collections;
using System.Collections.Generic;
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
                    default:
                    throw new Exception("bug");
                }
            }

            return list;
        }

        public virtual void Run(Hashtable h) { }
        
        public string mycode = "";


        /// <summary>
        /// 新建引用语句
        /// </summary>
        public class New_Sentence_Newref : Sentence
        {
            private string refname = "null";
            public New_Sentence_Newref(XmlNode me)
            {
                mycode = me.GetAttribute("str");

                refname = me.GetAttribute("varname");

            }
            public override void Run(Hashtable htxc)
            {
                try
                {
                    htxc.Add(refname, new Variable(0));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message+Environment.NewLine+"位置:"+mycode);
                }
            }
        }
        public class New_Sentence_Return : Sentence
        {
            Variable.Resulter resulter;
            public New_Sentence_Return(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Variable.Resulter(me.FirstChild as XmlNode);

            }
            public override void Run(Hashtable htcs)
            {
                try
                {
                    throw new MyExceptions.ReturnException() { toreturn = resulter.Run(htcs) };
                }
                catch (Exception ex)
                {
                    if(ex.GetType() == typeof(MyExceptions.ReturnException))
                    {
                        throw ex;
                    }
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        [Attribute.HasChildSentences]
        public class New_Sentence_if : Sentence
        {
            public string boolname;
            public Variable.Resulter resulter;
            public Sentence[] thensentences, elsesentences;
            public ArrayList elseifsentences = new ArrayList();
            public bool realif;

            public New_Sentence_if(XmlNode me)
            {
                if (me.Name == "elif")
                {
                    resulter = new Variable.Resulter(me.FirstChild.FirstChild as XmlNode);
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
                            resulter = new Variable.Resulter(code.FirstChild.FirstChild as XmlNode);
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

            
            
            public override void Run(Hashtable h)
            {
                try
                {
                    Hashtable hashtable = Variable.GetOwnVariables(h);
                    realif = Convert.ToBoolean(resulter.Run(h).value);
                    if (realif)
                    {
                        foreach (Sentence then in thensentences)
                        {
                            then.Run(hashtable);
                        }
                        return;
                    }
                    foreach (New_Sentence_if s in elseifsentences)
                    {
                        s.Run(h);
                        if (s.realif)
                        {
                            return;
                        }
                    }

                    if (!realif && elsesentences != null)
                    {
                        foreach (Sentence e in elsesentences)
                        {
                            e.Run(hashtable);
                        }
                    }

                }
                catch (MyExceptions.ReturnException ex)
                {
                    throw ex;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        public class New_Sentence_GiveResult : Sentence
        {
            Variable.Resulter resulter,togive;

            public New_Sentence_GiveResult(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Variable.Resulter(me.ChildNodes[1] as XmlNode);
                togive = new Variable.Resulter(me.ChildNodes[0] as XmlNode);
            }
            public override void Run(Hashtable h)
            {
                try
                {
                    Variable result = resulter.Run(h);
                    Variable togivee = togive.Run(h);
                    togivee.value = result.value;
                 }   
                catch(Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
            
        }
        public class New_Sentence_Usefunction : Sentence
        {
            Variable.Resulter resulter;

            public New_Sentence_Usefunction(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Variable.Resulter(me.FirstChild as XmlNode);
            }
            public override void Run(Hashtable h)
            {
                try
                {
                    Variable result = resulter.Run(h);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        [Attribute.HasChildSentences]
        public class New_Sentence_while : Sentence
        {
            public Variable.Resulter resulter;
            public Sentence[] childsentences;

            public New_Sentence_while(XmlNode me)
            {
                mycode = me.GetAttribute("str");
                resulter = new Variable.Resulter(me.FirstChild.FirstChild as XmlNode);
                childsentences = Sentence.GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
            }
            public override void Run(Hashtable h)
            {
                try
                {
                    Hashtable hashtable = h;
                    bool realif = Convert.ToBoolean(resulter.Run(hashtable).value);
                    while(realif)
                    {
                        Hashtable hh = Variable.GetOwnVariables(hashtable);
                        foreach(Sentence s in childsentences)
                        {
                            s.Run(hh);
                        }
                        realif = Convert.ToBoolean(resulter.Run(hashtable).value);
                    }
                    
                }
                catch (MyExceptions.ReturnException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        [Attribute.HasChildSentences]
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
            public override void Run(Hashtable h)
            {
                try
                {
                    Hashtable hashtable = Variable.GetOwnVariables(h);
                    try
                    {
                        foreach(var s in trysentences)
                        {
                            s.Run(hashtable);
                        }
                    }
                    catch (MyExceptions.ReturnException ex)
                    {
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        if (var_new)
                            hashtable.Add(exname, new Variable(ex.Message));
                        else
                            hashtable[exname] = new Variable(ex.Message);
                        foreach (var s in catchsentences)
                            s.Run(hashtable);
                    }
                }
                catch (MyExceptions.ReturnException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
        [Attribute.HasChildSentences]
        public class New_Sentence_foreach : Sentence
        {
            Variable.Resulter resulter;
            string fzvar;//待赋值变量
            public Sentence[] childsentences;
            bool var_new = false;

            public New_Sentence_foreach(XmlNode me)
            {
                fzvar = me.GetAttribute("var_togive");
                mycode = me.GetAttribute("str");
                var_new = Convert.ToBoolean(me.GetAttribute("var_new"));
                resulter = new Variable.Resulter(me.FirstChild.FirstChild as XmlNode);
                childsentences = GetSentencesFormXml(me.ChildNodes[1].ChildNodes).ToArray();
            }
            public override void Run(Hashtable h)
            {
                try
                {
                    Hashtable hashtable = Variable.GetOwnVariables(h);
                    Variable ss = resulter.Run(hashtable);
                    foreach (var item in (ss.value as Glist))
                    {
                        Hashtable nhashtable = Variable.GetOwnVariables(h);
                        if (var_new)
                            nhashtable.Add(fzvar, item);
                        else
                            nhashtable[fzvar] = item;
                        foreach (Sentence s in childsentences)
                            s.Run(nhashtable);
                    }
                }
                catch (MyExceptions.ReturnException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + Environment.NewLine + "位置:" + mycode);
                }
            }
        }
    }
}