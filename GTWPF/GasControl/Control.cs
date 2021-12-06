using GI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            return "Control";
        }


    }
}
