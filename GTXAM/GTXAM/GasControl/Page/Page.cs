//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using GI;
//using Xamarin.Forms;
//using ddbug = System.Diagnostics.Debug;

//namespace GTXAM.GasControl.Page
//{
//    public class Page:Xamarin.Forms.ContentPage,IFunction
//    {
        
//        public Page(string title)
//        {
//            Title = title;
            
//            //Content = new Control.Tip { Text = "Welcome to use Gasoline.Page" } ;

//        }
        

//        internal void AddTool(string text, object click_event)
//        {
//            var toolbar = new ToolbarItem
//            {
//                Text = text,
//                Order = ToolbarItemOrder.Secondary
//            };
//            toolbar.Clicked += async (s, e) =>
//            {
//                if (click_event != null)
//                {
//                    if (click_event is IFunction)
//                    {
//                        IFunction function = click_event as IFunction;
//                        Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
//                        string[] sss = function.Istr_xcname.Split(',');
//                        if (sss.Length == 2)
//                        {
//                            hashtable.Add(sss[0], new Variable(this));
//                            hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
//                            await Function.AsyncFuncStarter(function, hashtable);
//                        }
//                    }
//                    else
//                    {
//                        IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, click_event.ToString());
//                        Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
//                        string[] sss = function.Istr_xcname.Split(',');
//                        if (sss.Length == 2)
//                        {
//                            hashtable.Add(sss[0], new Variable(this));
//                            hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
//                            await Function.AsyncFuncStarter(function, hashtable);
//                        }
//                    }
//                }
//            };
//            ToolbarItems.Add(toolbar);
//        }

//        public void SetContent(Xamarin.Forms.View control)
//        {
//            Content = control;
//        }

//        public bool Iisasync { get { return false; } set { } }

//        public Task<object> IAsyncRun(Hashtable xc)
//        {
//            throw new Exception();
//        }
//        #region
//        string IFunction.Istr_xcname
//        {
//            get { return "params"; }
//            set { }
//        }
//        bool IFunction.Iisreffunction
//        {
//            get { return false; }
//            set { }
//        }
//        string IFunction.IInformation
//        {
//            get => "to be added";
//            set => throw new Exception();
//        }
//        public string poslib { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        object IFunction.IRun(Hashtable xc)
//        {

//            var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
//            switch (arrayList.Count)
//            {
//                case 1:
//                    {
//                        return new Variable((Content as Control.IGetter).IFindID((arrayList[0] as Variable).value.ToString()));
//                    }
//                case 0:
//                    {
//                        return new Variable(new Function.DFunction
//                        {
//                            str_xcname = "con",
//                            dRun = (dxc) =>
//                            {
//                                SetContent(Variable.GetTrueVariable<Xamarin.Forms.View>(dxc, "con"));
//                                return new Variable(0);
//                            }
//                        });
//                    }
//            }
//            return new Variable(0);
//        }
//        #endregion

//        #region 实现IType
//        const string type = "page,function";
//        public string IGetType()
//        {
//            return type;
//        }
//        public override string ToString()
//        {
//            return IGetType();
//        }

//        public object IGetCSValue()
//        {
//            return this;
//        }

//        public Variable IGetMember(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public IOBJ IGetParent()
//        {
//            throw new NotImplementedException();
//        }

//        static Page()
//        {
//            GType.Sign("page");
//        }
//        #endregion
//    }
//}
