using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GI
{
    partial class Function 
    {

        public class System_Head : Head
        {
            //注册
            public override void AddFunctions( System.Collections.Generic.Dictionary<string, IFunction> h)
            {
                h.Add("System.GetType", new System_Function_Gettype());
                h.Add("System.Exit", new System_Function_Exit());
                h.Add("System.Const", new System_Function_Const());
                h.Add("const", new System_Function_Const());
                h.Add("System.GetInterpreterVersion", new DFunction {IInformation ="get the version of interpreter", dRun = (xc) =>new Variable(GIInfo.GIVersion)});
                h.Add("System.GetInterpreter", new DFunction {  IInformation = "get the name of interpreter",dRun = (xc) => new Variable("GI") });
                h.Add("System.GetPlatform", new DFunction { IInformation = "get the paltform", dRun = (xc) => new Variable(GIInfo.Platform) });
                #region 获取时间
                h.Add("System.GetTime", new DFunction
                {
                    IInformation = @"get the time.
[val(string)]:
y or year
m or month
d or day
h or hour
min or minute
s or second
date
time",
                    str_xcname = "val",
                    dRun = (xc) =>
                    {
                        DateTime dateTime = DateTime.Now;
                        string val = Variable.GetTrueVariable<object>(xc, "val").ToString().ToLower();
                        switch (val)
                        {
                            case "y":
                            case "year":
                            return new Variable(dateTime.Year);


                            case "m":
                            case "month":
                            return new Variable(dateTime.Month);

                            case "d":
                           
                            case "day":
                            return new Variable(dateTime.Day);

                            case "h":
                            
                            case "hour":
                            return new Variable(dateTime.Hour);

                            case "min":
                            
                            case "minute":
                            return new Variable(dateTime.Minute);

                            case "s":
                            
                            case "second":
                            return new Variable(dateTime.Second);

                            case "date":
                            return new Variable(dateTime.ToLongDateString());

                            case "time":
                            return new Variable(dateTime.ToLongTimeString());

                            default:
                            return null;
                        }
                    }
                });
                #endregion
                h.Add("Debug", new DFunction { IInformation = "output when debugging", str_xcname = "str" , dRun = (xc) => { Gdebug.WriteLine(xc.GetVariable<object>("str").ToString()); return new Variable(0); } });
                h.Add("Help", new DFunction
                {
                    IInformation = "return the help of \'in\'",
                    str_xcname = "in",
                    dRun = (xc) =>
                    {
                        object o = xc.GetCSVariable<object>("in");
                        if (o is IFunction)
                        {
                            var function = o as IFunction;
                            return new Variable($"function \n param : {function.Istr_xcname} \n is a reffun : {function.Iisreffunction} \n information : {function.IInformation}");
                        }
                        return new Variable(0);
                    }
                });
                h.Add("async", new Asyncfunc());
                h.Add("await", new System_Function_Await());
                h.Add("wait", new System_Function_Wait());
            }
            //注册结束
            public class Asyncfunc:AFunction
            { }

            #region 获取类型
            public class System_Function_Gettype : Function
            {
                public System_Function_Gettype()
                {
                    IInformation = "get the type of variable";
                    str_xcname = "variable";
                }
                public override object Run(Hashtable xc)
                {
                    object obj = (xc["variable"] as Variable).value;
                    return new Variable((obj as IOBJ).IGetType());
                }
            }
            #endregion
            #region 退出
            public class System_Function_Exit : Function
            {
                public System_Function_Exit()
                {
                    IInformation = "exit this app";
                    str_xcname = "";
                }
                public override object Run(Hashtable xc)
                {
                    Environment.Exit(0);
                    return new Variable(0);
                }
            }
            #endregion
            #region 设置常量
            public class System_Function_Const : Function
            {
                public System_Function_Const()
                {
                    IInformation = "set the variable as a constant,which cannot be changed again";
                    str_xcname = "variable";
                    isreffunction = true;
                }
                public override object Run(Hashtable xc)
                {
                    (xc["variable"] as Variable).isconst = true;
                    return new Variable(0);
                }
            }
            #endregion
            public class System_Function_Await:AFunction
            {
                public System_Function_Await()
                {
                    Istr_xcname = "task";
                    IInformation = "wait the task while not block the current thread";
                }

                public async override Task<object> Run(Hashtable xc)
                {
                    
                    try
                    {
                        var task = xc.GetCSVariable<Task<Variable>>("task");
                        return(await task);
                    }
                    catch
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.异步异常);
                    }
                }
            }
                
            public class System_Function_Wait:Function
            {
                public System_Function_Wait()
                {
                    str_xcname = "task";
                    IInformation = "block the current thread to wait the task done";
                }
                public override object Run(Hashtable xc)
                {
                    var res = xc.GetCSVariable<Task<Variable>>("task");
                    res.Wait();
                    Debug.WriteLine("done");
                    return new Variable(0);
                    //return xc.GetCSVariable<Task<Variable>>("task").Result;
                }
            }
        }
    }

    
}
