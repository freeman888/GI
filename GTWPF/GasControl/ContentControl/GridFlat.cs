using GTWPF.GasControl.Control;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections;
using GI;
using System.Threading.Tasks;
using static GI.Function;

namespace GTWPF.GasControl.ContentControl
{

   

    /// <summary>
    /// Gasoline 网格布局
    /// </summary>
    public class GridFlat : Grid, ISetter, IOBJ, IGetter
    {

        public GridFlat()
        {
            #region
            members = new Dictionary<string, Variable>
            {
                {"Width" ,new FVariable{
                    ongetvalue = ()=>new Gnumber(Width),
                    onsetvalue = (value)=>{Width =Convert.ToDouble( value); return 0; }}},
                {"Height" ,new FVariable
                {
                    ongetvalue = ()=>new Gnumber(Height),
                    onsetvalue = (value)=>{Height = Convert.ToDouble(value);return 0; }
                }},
                {"Horizontal",new FVariable
                {
                    ongetvalue = ()=> new Gstring( HorizontalAlignment.ToString()),
                    onsetvalue = (value) =>{
                        if (value.ToString() == "center")
                            HorizontalAlignment = HorizontalAlignment.Center;
                        else if (value.ToString() == "left")
                            HorizontalAlignment = HorizontalAlignment.Left;
                        else if (value.ToString() == "right")
                            HorizontalAlignment = HorizontalAlignment.Right;
                        else if (value.ToString() == "stretch")
                            HorizontalAlignment = HorizontalAlignment.Stretch;
                        return 0;
                    }
                } },
                {"Vertical",new FVariable{
                ongetvalue = ()=>new Gstring(VerticalAlignment.ToString()),
                onsetvalue = (value)=>
                {
                    if (value.ToString() == "center")
                        VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        VerticalAlignment = VerticalAlignment.Top;
                    return 0;
                }
                } },
                {"Margin",new FVariable{
                ongetvalue =() => new Glist{new Variable(Margin.Left) ,new Variable(Margin.Top),new Variable(Margin.Right),new Variable(Margin.Bottom)},
                onsetvalue = (value)=>
                {
                    var list = value.IGetCSValue() as Glist;
                    Margin = new Thickness(
                        Convert.ToDouble( list[0].value),Convert.ToDouble(list[1].value),Convert.ToDouble(list[2].value),Convert.ToDouble(list[3].value)
                          );
                    return 0;
                }

                } },
                {"Visibility",new FVariable{
                    ongetvalue = () =>
                    {
                        string s = "null";
            switch (Visibility)
            {
                case Visibility.Collapsed: s = "gone"; break;
                case Visibility.Hidden: s = "hidden"; break;
                case Visibility.Visible: s = "visible"; break;
            }
            return new Gstring(s);
                    },
                    onsetvalue = (value)=>
                    {
                        if (value.ToString() == "gone")
                Visibility = Visibility.Collapsed;
            else if (value.ToString() == "hidden")
                Visibility = Visibility.Hidden;
            else if (value.ToString() == "visible")
                Visibility = Visibility.Visible;
                        return 0;
                    }
                } },
                
                
               
                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(Background.ToString()),
                    onsetvalue = (value)=>
                    {
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                        return 0;
                    }
                } },

                {"Add",new Variable(new MFunction(add,this)) },
                {"AddRow",new Variable(new MFunction(addrow,this)) },
                {"AddColume",new Variable(new MFunction(addcolume,this)) }




            };
            
            parent = new GTWPF.Control(this);
            #endregion
        }

        #region 实现IGetter

        object IGetter.IGetWidth()
        {
            return Width;
        }

        object IGetter.IGetHeight()
        {
            return Height;
        }

        object IGetter.IGetHorizontalAlignment()
        {
            return HorizontalAlignment.ToString();
        }

        object IGetter.IGetVerticalAlignment()
        {
            return VerticalAlignment.ToString();
        }

        object IGetter.IGetMargin()
        {
            string s = String.Format("{0},{0},{0},{0}", Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
            return s;
        }

        object IGetter.IGetVisibility()
        {
            string s = "null";
            switch (Visibility)
            {
                case Visibility.Collapsed: s = "gone"; break;
                case Visibility.Hidden: s = "hidden"; break;
                case Visibility.Visible: s = "visible"; break;
            }
            return s;
        }

        object IGetter.IGetText()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 fontsize 属性");
        }

        object IGetter.IGetPadding()
        {

            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 padding 属性");
        }

        object IGetter.IGetBackgroundColor()
        {
            return Background.ToString();
        }

        object IGetter.IGetForegroundColor()
        {

            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 foregroundcolor 属性");
        }

        object IGetter.IFindID(string id)
        {
            if (id == Name)
                return this;
            else
            {
                foreach (IGetter i in Children)
                {
                    object o = i.IFindID(id);
                    if (o != null)
                        return o;
                }
                return null;
            }
        }

        public object IGetScrollPosition()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }

        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion



       
        public object IGetCSValue()
        {
            return this;
        }
       


        #region 实现ISettet


        void ISetter.ISetWidth(object value)
        {
            Width = Convert.ToDouble(value);
        }

        void ISetter.ISetHeight(object value)
        {
            Height = Convert.ToDouble(value);
        }

        void ISetter.ISetHorizontalAlignment(object value)
        {
            if (value.ToString() == "center")
                HorizontalAlignment = HorizontalAlignment.Center;
            else if (value.ToString() == "left")
                HorizontalAlignment = HorizontalAlignment.Left;
            else if (value.ToString() == "right")
                HorizontalAlignment = HorizontalAlignment.Right;
            else if (value.ToString() == "stretch")
                HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        void ISetter.ISetVerticalAlignment(object value)
        {
            if (value.ToString() == "center")
                VerticalAlignment = VerticalAlignment.Center;
            else if (value.ToString() == "bottom")
                VerticalAlignment = VerticalAlignment.Bottom;
            else if (value.ToString() == "stretch")
                VerticalAlignment = VerticalAlignment.Stretch;
            else if (value.ToString() == "top")
                VerticalAlignment = VerticalAlignment.Top;

        }

        void ISetter.ISetMargin(object value)
        {
            double a1, a2, a3, a4;
            string[] vs = value.ToString().Split(',');
            a1 = Convert.ToDouble(vs[0]);
            a2 = Convert.ToDouble(vs[1]);
            a3 = Convert.ToDouble(vs[2]);
            a4 = Convert.ToDouble(vs[3]);
            Margin = new Thickness(a1, a2, a3, a4);
        }

        void ISetter.ISetVisibility(object value)
        {
            if (value.ToString() == "gone")
                Visibility = Visibility.Collapsed;
            else if (value.ToString() == "hidden")
                Visibility = Visibility.Hidden;
            else if (value.ToString() == "visible")
                Visibility = Visibility.Visible;
        }

        void ISetter.ISetText(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 fontsize 属性");
        }

        void ISetter.ISetPadding(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 padding 属性");
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }

        void ISetter.ISetForegroundColor(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 foreground 属性");
        }

        void ISetter.ISetClickEvent(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "此控件没有 click 事件");
        }


        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }

        void ISetter.ISetTogged(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion

        #region 实现IType
        const string type = "GridFlat";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static GridFlat()
        {
            GType.Sign("GridFlat");
        }
        #endregion

        Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        GTWPF.Control parent;
        public IOBJ IGetParent()
        {
            return parent;
        }

        //memfunction

        static IFunction add = new Function_Add();
        public class Function_Add:Function
        {
            public Function_Add()
            {
                str_xcname = "con,row,column";
                poslib = "Control";
            }

            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "GridFlat");
                var con = xc.GetCSVariableFromSpeType<UIElement>("con", "Control");
                var row = Convert.ToInt32( xc.GetCSVariable<object>("row"));
                var column =Convert.ToInt32( xc.GetCSVariable<object>("column"));
                SetRow(con, row);
                SetColumn(con, column);
                grid.Children.Add(con);
                return new Variable(0);
            }
        }

        static IFunction addrow = new Function_AddRow();
        public class Function_AddRow:Function
        {
            public Function_AddRow()
            {
                str_xcname = "value,config";
                poslib = "Control";

            }
            public override object Run(Hashtable xc)

            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "GridFlat");
                var value = Convert.ToDouble(xc.GetCSVariable<object>("value"));
                var config = xc.GetCSVariable<object>("config").ToString();
                if (config == "value")
                {
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Pixel) });
                }
                else if (config == "rate")
                {
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Star) });
                }
                else if (config == "auto")
                {
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Auto) });
                }

                return new Variable(0);

            }


        }

        static IFunction addcolume = new Function_AddColumn();
        public class Function_AddColumn : GI.Function
        {
            public Function_AddColumn()
            {
                IInformation = "set the column definition .\n[config(string)]:value ,rate ,auto";
                str_xcname = "value,config";
            }
            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "GridFlat");
                double value = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "value"));
                string config = Variable.GetTrueVariable<object>(xc, "config").ToString();

                if (config == "value")
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Pixel) });
                }
                else if (config == "rate")
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Star) });
                }
                else if (config == "auto")
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Auto) });
                }

                return new Variable(0);
            }
        }




    }
}
