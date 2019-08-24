using System;
using System.Collections;
using System.Threading;

namespace GI
{
    partial class Function
    {
        public class Thread_Head:Head
        {
            public override void AddFunctions(System.Collections.Generic.Dictionary<string, IFunction> h)
            {
                h.Add("Thread.Start", new Thead_Function_Start());
            }

            #region 开始

            public class Thead_Function_Start : Function
            {
                public Thead_Function_Start()
                {
                    IInformation = "Start a new thread .When not in UI thread ,you cannot change the UI Control";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {
                    //ArrayList arrayList = Variable.GetTrueVariable<Array_Head.Array_Function_CreatNew.Array_Function_MyArray>(xc, "params").array;
                    //FuncAnalyse.ParamsAnalyser.ParamsAnalyse();

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
        }
    }
}
