using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace GI
{
    partial class Function
    {
        public class Thread_Head:Head
        {
            public override void AddFunctions(System.Collections.Generic.Dictionary<string, IFunction> h)
            {
                h.Add("Thread.Start", new Thread_Function_Start());
                h.Add("Thread.Sleep", new Thread_Function_Sleep());
                h.Add("Thread.RunOnUI", new Thread_Function_RunOnUI());
            }

            #region 开始

            public class Thread_Function_Start : Function
            {
                public Thread_Function_Start()
                {
                    IInformation = "Start a new thread .When not in UI thread ,you cannot change the UI Control";
                    str_xcname = "fun";
                }
                public override object Run(Hashtable xc)
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        object fun = Variable.GetTrueVariable<object>(xc, "fun");
                        if(fun is IFunction)
                            FuncStarter(fun as IFunction, Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),out var v);
                        else
                            FuncStarter(fun.ToString(), Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables), out Variable v);
                    }));
                    thread.Start();
                    return new Variable(thread);
                }
            }

            #endregion
            public class Thread_Function_Sleep : Function
            {
                public Thread_Function_Sleep()
                {
                    IInformation = "Sleep ms";
                    str_xcname = "time";
                }
                public override object Run(Hashtable xc)
                {
                    var time = Convert.ToInt32(xc.GetCSVariable<object>("time"));
                    Thread.Sleep(time);
                    return new Variable(0);
                }
            }
            public class Thread_Function_RunOnUI : Function
            {
                public static Func<Hashtable, int> runonui;
                public Thread_Function_RunOnUI()
                {
                    IInformation = "run on ui thread";
                    str_xcname = "fun";
                }
                public override object Run(Hashtable xc)
                {
                    runonui?.Invoke(xc);
                    return new Variable(0);
                }
                
            }

        }
    }
}
