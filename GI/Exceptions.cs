using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    public class Exceptions
    {
        /// <summary>
        /// flag to return a methord quickly
        /// </summary>
        public class ReturnException:Exception
        {
            public object toreturn;
        }
        public enum EXID
        {
            未知 = 10001,
            数组越界 = 10002,
            参数错误 = 10003,
            逻辑错误 = 10004,
            更改常量 = 10005,
            类型冲突 = 10006,
            无对应属性 = 10007,
        }
        /// <summary>
        /// 所有错误
        /// </summary>
        public class RunException:Exception
        {
            public RunException(EXID eXID,string inf = "")
            {
                Exid = eXID;
                this.inf = inf;
            }
            public EXID Exid;
            public string inf;

            public override string Message => "[RunException] id:"+Convert.ToInt32(Exid)+" information:"+Exid+"\n"+inf;
        }
    }
}
