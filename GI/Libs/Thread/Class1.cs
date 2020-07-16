using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GI.Function;

namespace GI
{
   partial class Lib
    {
        public class Thread_Lib:ILib
        {
            public Thread_Lib()
            {
                myThing.Add("StartThread",new Variable( start));
                myThing.Add("Sleep", new Variable(sleep));
                myThing.Add("RunOnUI", new Variable(runonui));
                myThing.Add("StartTask", new Variable(taskrun));            }
            IFunction start = new Thread_Function_Start();
            public class Thread_Function_Start : Function
            {
                public Thread_Function_Start()
                {
                    IInformation = "Start a new thread .When not in UI thread ,you cannot change the UI Control";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {
                    var param = xc.GetCSVariable<Glist>("params");
                    var fun = param[0].value;
                    Variable[] variables = new Variable[param.Count - 1];
                    for (int i = 1; i < param.Count; i++)
                    {
                        variables[i - 1] = param[i];
                    }
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        if (fun is IFunction)
                            _ = Function.NewAsyncFuncStarter(fun as IFunction, variables);
                        else
                            throw new Exceptions.RunException(Exceptions.EXID.未知, "此版本不支持字符串拉起函数");
                    }));
                    thread.Start();
                    return new Variable(thread);
                }
            }
            IFunction sleep = new Thread_Function_Sleep();
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
            IFunction runonui = new Thread_Function_RunOnUI();
            public class Thread_Function_RunOnUI : Function
            {
                public static Func<Hashtable, int> runonui;
                public Thread_Function_RunOnUI()
                {
                    IInformation = "run on ui thread";
                    str_xcname = "params";
                }
                public override object Run(Hashtable xc)
                {
                    runonui?.Invoke(xc);
                    return new Variable(0);
                }

            }
            IFunction taskrun = new Task_Function_TaskRun();
            public class Task_Function_TaskRun : AFunction
            {
                public Task_Function_TaskRun()
                {
                    IInformation = "this is an async function.it will not block the current thread while you will wait the result";
                    Istr_xcname = "params";
                }

                public async override Task<object> Run(Hashtable xc)
                {
                    var param = xc.GetCSVariable<Glist>("params");
                    var fun = param[0].value;
                    Variable[] variables = new Variable[param.Count - 1];
                    for (int i = 1; i < param.Count; i++)
                    {
                        variables[i - 1] = param[i];
                    }
                    return await Task.Run(async () =>
                    {
                        if (fun is IFunction)
                            return await NewAsyncFuncStarter(fun as IFunction, variables);
                        else
                            throw new Exceptions.RunException(Exceptions.EXID.未知, "此版本不支持字符串拉起函数");
                    });
                 }   
            }
            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }

    }
}
