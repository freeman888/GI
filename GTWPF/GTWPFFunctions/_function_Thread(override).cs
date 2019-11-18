using GI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTWPF
{
    internal class _function_Thread_override_
    {
        public static void Load()
        { 
            //重写runonui 函数
            GI.Function.Thread_Head.Thread_Function_RunOnUI.runonui = (xc) =>
            {
                MainWindow.MainApp.Dispatcher.Invoke(() =>
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
