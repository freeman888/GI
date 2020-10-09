using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GI;
using Xamarin.Forms;

namespace GTXAM.GasControl.Control
{
    public class _TextCell:TextCell,IName,IOBJ
    {
        public object event_click;

        public _TextCell()
        {

            
            Tapped += Bubble_Clicked;

            #region
            members = new Dictionary<string, Variable>
            {
              {"Text",new FVariable{
                    ongetvalue = ()=> new Gstring(Text.ToString()),
                    onsetvalue = (value)=>
                    {
                        Text = value.ToString();
                        return 0;
                    }
                } },
                {"Detail",new FVariable{ ongetvalue = ()=> new Gstring(Detail.ToString()), onsetvalue = (value) =>
                {
                    Detail = value.ToString();
                    return 0;
                }
                } },
                {"DetailColor",new FVariable
                {
                    ongetvalue = ()=>new Gstring( DetailColor.ToString()),
                    onsetvalue = (value)=>
                    {
                        DetailColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                        return 0;
                    }
                } },
               {"Foreground",new FVariable{ ongetvalue =()=>new Gstring(TextColor.ToString()),
                onsetvalue = (value)=>
                {
                    TextColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                    return 0;
                } } },
                {"Clickevent",new FVariable
                {
                    ongetvalue = ()=>event_click as IOBJ
                    ,onsetvalue = (value)=>
                    {
                        event_click = value;
                        return 0;
                    }
                } }





            };
            parent = new Cell.Cell(this);
            #endregion
        }

        private async void Bubble_Clicked(object sender, EventArgs e)
        {




            var p = Parent;
            while (!(p is Page.Page))
            {
                p = (p as Element).Parent;
            }
            if (event_click != null && p != null)
            {
                if (event_click is IFunction)
                {
                    IFunction function = event_click as IFunction;
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        await Function.NewAsyncFuncStarter(function, new Variable(p), new Variable(e));
                    }
                }
                else
                {
                    IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, event_click.ToString());
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        await Function.NewAsyncFuncStarter(function, new Variable(p), new Variable(e));
                    }
                }
            }
        }

        #region 实现IName
        public string Name { get; set; }
        #endregion
        #region 实现IType
        const string type = "textcell";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }

        public object IGetCSValue()
        {
            return this;
        }

        static _TextCell()
        { 
            GType.Sign("textcell");
        }
        #endregion


        #region
        Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        Cell.Cell parent;
        public IOBJ IGetParent()
        {
            return parent;
        }

        #endregion
    }
}
