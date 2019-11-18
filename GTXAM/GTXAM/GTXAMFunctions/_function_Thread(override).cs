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
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        object fun = Variable.GetTrueVariable<object>(xc, "fun");
                        if (fun is IFunction)
                            Function.FuncStarter(fun as IFunction, Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables), out var v);
                        else
                            Function.FuncStarter(fun.ToString(), Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables), out Variable v);
                    });
                return 0;
            };
        }
    }
}
