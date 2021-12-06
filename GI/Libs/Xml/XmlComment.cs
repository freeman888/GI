using System;
using System.Collections.Generic;
using System.Text;

namespace GI.Libs.Xml
{
    public class XmlComment:IOBJ
    {
        System.Xml.XmlComment value;

        public XmlComment(System.Xml.XmlComment value)
        {
            this.value = value;
            members = new Dictionary<string, Variable>
            {
                {"Content" ,new FVariable
                {
                    ongetvalue = ()=>new Gstring(value.Value),
                    onsetvalue = (_value)=>
                    {
                        this.value.Value = _value.ToString();
                        return 0;
                    }
                }
                },

            };

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
        public const string type = "XmlComment";
        static XmlComment()
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
