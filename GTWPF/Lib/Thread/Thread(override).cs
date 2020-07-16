using GI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTWPF.Lib.Thread
{
    public class Thread_override
    {
        public static void Load()
        {
            //重写runonui 函数
            GI.Lib.Thread_Lib.Thread_Function_RunOnUI.runonui = (xc) =>
            {
                MainWindow.MainApp.Dispatcher.Invoke(async () =>
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
                        throw new Exceptions.RunException(Exceptions.EXID.未知, "此版本不再支持字符串启动函数");

                });
                return 0;
            };
        }
    }
}
