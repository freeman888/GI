using GI;
using System;
using System.Collections.Generic;
using System.Text;
using XF = Xamarin.Forms;

namespace GTXAM.GasControl.Cell
{
    /// <summary>
    /// 控件的虚拟父类
    /// </summary>
    class Cell : IOBJ
    {
        XF.Cell obj;
        public Cell(XF.Cell obj)
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
            return "cell";
        }


    }
}
