using GI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTXAM
{
    partial class Lib
    {

        class _function_Thread_override_
        {
            internal static void Load()
            {
                GI.Lib.Thread_Lib.Thread_Function_RunOnUI.runonui = (xc) =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        var param = xc.GetCSVariable<Glist>("params");
                        var fun = param[0].value;
                        Variable[] variables = new Variable[param.Count - 1];
                        for (int i = 1; i < param.Count; i++)
                        {
                            variables[i - 1] = param[i];
                        }
                        if (fun is IFunction)
                            await Function.NewAsyncFuncStarter(fun as IFunction, variables);
                        else
                            throw new Exception();
                    });
                    return 0;
                };
            }
        }
    }
}