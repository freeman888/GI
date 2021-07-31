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

        public static IOBJ GetControlFromXmlElement(GTWPF.GasControl.Page.GasPage basepage, XmlElement xmlelement)
        {
            var cname = xmlelement.Name;
            IOBJ control = null;
            switch (cname)
            {
                case "Bubble":
                    control =  GasControl.Control.Bubble.GetBubbleFromXml(xmlelement);
                    break;
                case "EditText":
                    control = GasControl.Control.EditText.GetEditTextFromXml(xmlelement);
                    break;
                case "Image":
                    control =  GasControl.Control.Image.GetImageFromXml(xmlelement);
                    break;
                case "Switcher":
                    control =  GasControl.Control.Switcher.GetSwitcherFromXml(xmlelement);break;
                case "TextCell":
                    control =  GasControl.Control.TextCell.GetTextCellFromXml(xmlelement);break;
                case "Tip":
                    control =  GasControl.Control.Tip.GetTipFromXml(xmlelement);break;
                case "WebView":
                    control =  GasControl.Control.WebView.GetWebViewFromXml(xmlelement);break;
                case "GridFlat":
                    control =  GasControl.ContentControl.GridFlat.GetGridFlatFromXml(basepage, xmlelement);break;
                case "ListFlat":
                    control =  GasControl.ContentControl.ListFlat.GetListFlatFromXml(basepage, xmlelement);break;
                case "ScrollFlat":
                    control = GasControl.ContentControl.ScrollFlat.GetScrollFlatFromXml(basepage, xmlelement);break;
                case "StackFlat":
                    control = GasControl.ContentControl.StackFlat.GetStackFlatFromXml(basepage, xmlelement); break;
                default:
                    throw new Exceptions.RunException(Exceptions.EXID.无对应属性);
                    

            }
            if(control != null)
            {
                basepage.controls.Add(xmlelement.GetAttribute("Name"), control);
            }
            return control;
        }

    }
    
}
