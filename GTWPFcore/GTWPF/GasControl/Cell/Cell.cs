using GI;
using System.Windows;

namespace GTWPF.GasControl.Cell
{

    /// <summary>
    /// 控件的虚拟父类
    /// </summary>
    class Cell : IOBJ
    {
        UIElement obj;
        public Cell(UIElement obj)
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
            return "Cell";
        }

    }
}

