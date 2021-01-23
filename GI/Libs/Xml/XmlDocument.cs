using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static GI.Function;
using SXml = System.Xml;

namespace GI.Libs.Xml
{
    public class XmlDocument:SXml.XmlDocument,IOBJ
    {

        public XmlDocument()
        {
            
            members = new Dictionary<string, Variable>
            {
                {"Content" , new FVariable
                {
                    ongetvalue = () =>
                    {
                        if(FirstChild.GetType() == typeof(SXml.XmlElement))
                        {
                            return new XmlElement(FirstChild as SXml.XmlElement);
                        }
                        else if(FirstChild.GetType() == typeof(SXml.XmlComment))
                        {
                            return new XmlComment(FirstChild as SXml.XmlComment);
                        }
                        else
                            throw new Exceptions.RunException(Exceptions.EXID.未知);

                    },
                    onsetvalue = (value)=>
                    {
                        RemoveChild(FirstChild);
                        AppendChild((SXml.XmlNode)value.IGetCSValue());
                        return 0;
                    }
                }},
                {"CreatElement" ,new Variable(new MFunction(createlement,this))},
                {"CreatComment" ,new Variable(new MFunction(creatcomment,this))},
                {"Save" , new Variable(new MFunction(save,this))},
                {"Load",new Variable(new MFunction(load,this)) }
            };
        }

        static IFunction createlement = new XmlDocument_Function_CreatElement();
        public class XmlDocument_Function_CreatElement:Function
        {
            public XmlDocument_Function_CreatElement()
            {
                IInformation = "creat an element from xmldocument";
                str_xcname = "name";
            }
            public override object Run(Hashtable xc)
            {
                var xmldocument = xc.GetCSVariableFromSpeType<XmlDocument>("this", "xmldocument");
                var name = xc.GetCSVariable<object>("name").ToString();
                XmlElement xmlElement = new XmlElement(xmldocument.CreateElement(name));
                return new Variable(xmlElement);
            }
        }
        static IFunction creatcomment = new XmlDocument_Function_CreatComment();
        public class XmlDocument_Function_CreatComment:Function
        {
            public XmlDocument_Function_CreatComment()
            {
                IInformation = "creat comment from xmldocument";
                str_xcname = "comment";
            }
            public override object Run(Hashtable xc)
            {
                var xmldocument = xc.GetCSVariableFromSpeType<XmlDocument>("this", "xmldocument");
                var comment = xc.GetCSVariable<object>("comment").ToString();
                XmlComment xmlComment = new XmlComment(xmldocument.CreateComment(comment));
                
                return new Variable(xmlComment);
            }
        }
        static IFunction save = new XmlDocument_Function_Save();
        public class XmlDocument_Function_Save:Function
        {
            public XmlDocument_Function_Save()
            {
                IInformation = "save xml file to a stream";
                str_xcname = "stream";
            }
            public override object Run(Hashtable xc)
            {
                var xmld = xc.GetCSVariableFromSpeType<XmlDocument>("this", "xmldocument");
                var stream = xc.GetCSVariableFromSpeType<System.IO.Stream>("stream", "stream");
                xmld.Save(stream);
                return new Variable(0);
            }
        }
        static IFunction load = new XmlDocument_Function_Load();
        public class XmlDocument_Function_Load:Function
        {
            public XmlDocument_Function_Load()
            {
                IInformation = "load xmldocument from stram";
                str_xcname = "stream";

            }

            public override object Run(Hashtable xc)
            {
                var xmld = xc.GetCSVariableFromSpeType<XmlDocument>("this", "xmldocument");
                var stream = xc.GetCSVariableFromSpeType<System.IO.Stream>("stream", "stream");
                xmld.Load(stream);
                return new Variable(0);
            }
        }
        #region
        Dictionary<string, Variable> members;
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
        #endregion   
        #region
        public const string type = "xmldocument";
        static XmlDocument()
        {
            GType.Sign(type);

        }

        public object IGetCSValue()
        {
            return this;
        }
        public string IGetType()
        {
            return type;
        }

        public override string ToString()
        {
            return type;
        }
        #endregion
    }
}
