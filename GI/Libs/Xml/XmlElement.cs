using System;
using System.Collections;
using System.Collections.Generic;
using static GI.Function;

namespace GI.Libs.Xml
{
    public class XmlElement : IOBJ
    {
        System.Xml.XmlElement value;
        public XmlElement(System.Xml.XmlElement value)
        {
            this.value = value;

            members = new Dictionary<string, Variable>
            {
                {"SetAttribute",new Variable( new  MFunction(setattribute,this)) },//如果不存在，则自动创建
                {"GetAttribute" ,new Variable(new MFunction(getattribute,this))},
                {"GetChild"  , new Variable(new MFunction(getchild,this)) },
                {"Count" ,new FVariable{ ongetvalue = ()=>new Gnumber( value.ChildNodes.Count) ,isconst = true} },
                {"AddChild", new Variable(new MFunction(addchild,this)) },
                {"RemoveChild" ,new Variable(new MFunction(removechild,this))},
                {"Name",new FVariable{ongetvalue = ()=>new Gstring(value.Name),onsetvalue = (v)=>throw new Exceptions.RunException(Exceptions.EXID.未知,"不允许赋值" )} }
            };
        }
        static IFunction setattribute = new XmlElement_Function_SetAttribute();
        public class XmlElement_Function_SetAttribute : Function
        {
            public XmlElement_Function_SetAttribute()
            {
                IInformation = "设置属性，不存在则创建属性.";
                str_xcname = "name,value";
            }

            public override object Run(Hashtable xc)
            {
                var xmlElement = xc.GetCSVariableFromSpeType<System.Xml.XmlElement>("this", "XmlElement");
                var name = xc.GetCSVariable<object>("name").ToString();
                var _value = xc.GetCSVariable<object>("value").ToString();
                xmlElement.SetAttribute(name, _value);
                return new Variable(0);
            }
        }
        static IFunction getattribute = new XmlElement_Function_GetAttribute();
        public class XmlElement_Function_GetAttribute : Function
        {
            public XmlElement_Function_GetAttribute()
            {
                IInformation = "获取属性的值";
                str_xcname = "name";
            }
            public override object Run(Hashtable xc)
            {
                var xmlelement = xc.GetCSVariableFromSpeType<System.Xml.XmlElement>("this", "XmlElement");
                var name = xc.GetCSVariable<object>("name").ToString();
                return new Variable(xmlelement.GetAttribute(name));
            }
        }
        static IFunction getchild = new XmlElement_Function_GetChild();
        public class XmlElement_Function_GetChild : Function
        {
            public XmlElement_Function_GetChild()
            {
                IInformation = "获取子元素，可能返回两种类型.";
                str_xcname = "index";
            }
            public override object Run(Hashtable xc)
            {
                var xmlelement = xc.GetCSVariableFromSpeType<System.Xml.XmlElement>("this", "XmlElement");
                var name = Convert.ToInt32(xc.GetCSVariable<object>("index"));
                var res = xmlelement.ChildNodes[name];
                if (res.GetType() == typeof(System.Xml.XmlElement))
                    return new Variable(new XmlElement(res as System.Xml.XmlElement));
                else
                    return new Variable(new XmlComment(res as System.Xml.XmlComment));
            }
        }
        static IFunction addchild = new XmlElement_Function_AddChild();
        public class XmlElement_Function_AddChild : Function
        {
            public XmlElement_Function_AddChild()
            {
                IInformation = "添加子对象.";
                str_xcname = "child";
            }
            public override object Run(Hashtable xc)
            {
                var xmlelement = xc.GetCSVariableFromSpeType<System.Xml.XmlElement>("this", "XmlElement");
                var node = xc.GetCSVariable<System.Xml.XmlNode>("child");
                xmlelement.AppendChild(node);
                return new Variable(0);
            }
        }
        static IFunction removechild = new XmlElement_Function_RemoveChild();
        public class XmlElement_Function_RemoveChild : Function
        {
            public XmlElement_Function_RemoveChild()
            {
                IInformation = "移除对象.";
                str_xcname = "child";
            }
            public override object Run(Hashtable xc)
            {
                var xmlelement = xc.GetCSVariableFromSpeType<System.Xml.XmlElement>("this", "XmlElement");
                var node = xc.GetCSVariable<System.Xml.XmlNode>("child");
                xmlelement.RemoveChild(node);
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
        public const string type = "XmlElement";
        static XmlElement()
        {
            GType.Sign(type);

        }

        public object IGetCSValue()
        {
            return value;
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
