using GI;
using System.Windows;
using System.Xml;

namespace GTWPF
{
    /// <summary>
    /// 控件的虚拟父类
    /// </summary>
    class Control : IOBJ
    {
        UIElement obj;
        public Control(UIElement obj)
        {
            this.obj = obj;
        }
        public object IGetCSValue()
        {
            return obj;
        }

        public Variable IGetMember(string name)
        {
            return null;
        }

        public IOBJ IGetParent()
        {
            return null;
        }

        public string IGetType()
        {
            return "control";
        }

        public static IOBJ GetControlFromXmlElement(XmlElement xmlelement)
        {
            var cname = xmlelement.Name;
            switch (cname)
            {
                case "Bubble":
                    return GasControl.Control.Bubble.GetBubbleFromXml(xmlelement);
                    
                default:
                    throw new Exceptions.RunException(Exceptions.EXID.无对应属性);
                    
            }
        }

    }
}
