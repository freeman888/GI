using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GI;
using Xamarin.Forms;
using static GI.Function;
using ddbug = System.Diagnostics.Debug;

namespace GTXAM.GasControl.Page
{
    public class Page : Xamarin.Forms.ContentPage, IOBJ
    {

        public Page(string title)
        {
            Title = title;

            Content = new Control.Tip { Text = "Welcome to use Gasoline.Page" } ;

            members = new Dictionary<string, Variable>
            {
                {"SetContent",new Variable(new MFunction(setcontent,this)) },
                {"SetTitle",new Variable(new MFunction(settitle,this)) },
                {"AddTool",new Variable(new MFunction(addtool,this)) }
            };

        }


        internal void AddTool(string text, object click_event)
        {
            var toolbar = new ToolbarItem
            {
                Text = text,
                Order = ToolbarItemOrder.Secondary
            };
            toolbar.Clicked += async (s, e) =>
            {
                if (click_event != null)
                {
                    if (click_event is IFunction)
                    {
                        IFunction function = click_event as IFunction;
                        string[] sss = function.Istr_xcname.Split(',');
                        if (sss.Length == 2)
                        {
                            await Function.NewAsyncFuncStarter(function, new Variable(this),new Variable(e));
                        }
                    }
                    else
                    {
                        IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, click_event.ToString());
                        string[] sss = function.Istr_xcname.Split(',');
                        if (sss.Length == 2)
                        {
                            await Function.NewAsyncFuncStarter(function,new Variable(this),new Variable(e));
                        }
                    }
                }
            };
            ToolbarItems.Add(toolbar);
        }

        public void SetContent(Xamarin.Forms.View control)
        {
            Content = control;
        }

        #region
        
        public string poslib { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        
        #endregion

        #region 实现IType
        const string type = "page,function";
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

        

        static Page()
        {
            GType.Sign("page");
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

        public IOBJ IGetParent()
        {
            return null;
        }

        #endregion

        //member function

        static IFunction setcontent = new  Page_Function_SetContent();
        public class Page_Function_SetContent : Function
        {
            public Page_Function_SetContent()
            {
                str_xcname = "control";
            }
            public override object Run(Hashtable xc)
            {
                var page1 = Variable.GetTrueVariable<GasControl.Page.Page>(xc, "this");
                page1.Content = xc.GetCSVariableFromSpeType<View>("control", "control");
                return new Variable(0);
            }

        }

        static IFunction settitle = new Page_Function_SetTitle();
        public class Page_Function_SetTitle : Function
        {
            public Page_Function_SetTitle()
            {
                str_xcname = "title";
            }
            public override object Run(Hashtable xc)
            {
                GasControl.Page.Page page = xc.GetCSVariableFromSpeType<GTXAM.GasControl.Page.Page>("this", "page");
                string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                page.Title = title;
                return new Variable(0);
            }
        }

        static IFunction addtool = new Page_Function_AddTool();
        public class Page_Function_AddTool : Function
        {
            public Page_Function_AddTool()
            {
                str_xcname = "text,clickevent";
            }

            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariable<GTXAM.GasControl.Page.Page>("this");
                var text = xc.GetCSVariable<object>("text").ToString();
                var clickevent = xc.GetCSVariable<object>("clickevent");

                page.AddTool(text, clickevent);

                return new Variable(0);
            }
        }
    }
}
