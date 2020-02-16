using System;
using System.Collections.Generic;
using System.Text;
using GI;

namespace GTXAM
{
    class _function_Thread_override_
    {
        internal static void Load()
        {
            Function.Thread_Head.Thread_Function_RunOnUI.runonui = (xc) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async() =>
                    {
                        var param = xc.GetCSVariable<Glist>("params");
                        var fun = param[0].value;
                        Variable[] variables = new Variable[param.Count - 1];
                        for (int i = 1; i < param.Count; i++)
                        {
                            variables[i-1] = param[i];
                        }
                        if (fun is IFunction)
                            await Function.AsyncFuncStarter(fun as IFunction, Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
                        else
                            await Function.AsyncFuncStarter(fun.ToString(), Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables),variables);
                    });
                return 0;
            };
        }
    }
}
