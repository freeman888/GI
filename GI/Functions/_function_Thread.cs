//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GI
//{
//    partial class Function
//    {
//        public class Thread_Head:Head
//        {
//            public override void AddFunctions(System.Collections.Generic.Dictionary<string, IFunction> h)
//            {
//                h.Add("Thread.Start", new Thread_Function_Start());
//                h.Add("Thread.Sleep", new Thread_Function_Sleep());
//                h.Add("Thread.RunOnUI", new Thread_Function_RunOnUI());
//                h.Add("Task.Run", new Task_Function_TaskRun());
//            }

//            #region 开始

//            public class Thread_Function_Start : Function
//            {
//                public Thread_Function_Start()
//                {
//                    IInformation = "Start a new thread .When not in UI thread ,you cannot change the UI Control";
//                    str_xcname = "params";
//                }
//                public override object Run(Hashtable xc)
//                {
//                    var param = xc.GetCSVariable<Glist>("params");
//                    var fun = param[0].value;
//                    Variable[] variables = new Variable[param.Count - 1];
//                    for (int i = 1; i < param.Count; i++)
//                    {
//                        variables[i-1] = param[i];
//                    }
//                    Thread thread = new Thread(new ThreadStart(() =>
//                    {
//                        if(fun is IFunction)
//                            _ = AsyncFuncStarter(fun as IFunction, Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
//                        else
//                            _ = AsyncFuncStarter(fun.ToString(), Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
//                    }));
//                    thread.Start();
//                    return new Variable(thread);
//                }
//            }

//            #endregion
//            public class Thread_Function_Sleep : Function
//            {
//                public Thread_Function_Sleep()
//                {
//                    IInformation = "Sleep ms";
//                    str_xcname = "time";
//                }
//                public override object Run(Hashtable xc)
//                {
//                    var time = Convert.ToInt32(xc.GetCSVariable<object>("time"));
//                    Thread.Sleep(time);
//                    return new Variable(0);
//                }
//            }
//            public class Thread_Function_RunOnUI : Function
//            {
//                public static Func<Hashtable, int> runonui;
//                public Thread_Function_RunOnUI()
//                {
//                    IInformation = "run on ui thread";
//                    str_xcname = "params";
//                }
//                public override object Run(Hashtable xc)
//                {
//                    runonui?.Invoke(xc);
//                    return new Variable(0);
//                }
                
//            }
            
//            public class Task_Function_TaskRun:AFunction
//            {
//                public Task_Function_TaskRun()
//                {
//                    IInformation = "this is an async function.it will not block the current thread while you will wait the result";
//                    Istr_xcname = "params";
//                }

//                public async override Task<object> Run(Hashtable xc)
//                {
//                    var param = xc.GetCSVariable<Glist>("params");
//                    var fun = param[0].value;
//                    Variable[] variables = new Variable[param.Count - 1];
//                    for (int i = 1; i < param.Count; i++)
//                    {
//                        variables[i-1] = param[i];
//                    }
//                    return await Task.Run(async () =>
//                    {
//                        if (fun is IFunction)
//                           return await AsyncFuncStarter(fun as IFunction, Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
//                        else
//                           return await AsyncFuncStarter(fun.ToString(), Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
//                    });
//                }
//            }
//        }
//    }
//}
