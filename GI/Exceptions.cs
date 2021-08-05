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
        public class ReturnException:Exception,ISysException
        {
            public object toreturn;
        }
        /// <summary>
        /// flag to break the foreach or while
        /// </summary>
        public class BreakException:Exception,ISysException
        {

        }
        /// <summary>
        /// flag to continue the foreach or while
        /// </summary>
        public class ContinueException:Exception,ISysException
        {

        }
        /// <summary>
        /// flag to recognize the exception used by system sentences
        /// </summary>
        public interface ISysException
        { }
        public enum EXID
        {
            未知 = 100010,
            数组越界 = 100020,
            参数错误 = 100030,
            逻辑错误 = 100040,
            更改常量 = 100050,
            类型冲突 = 100060,
            无对应属性 = 100070,
            异步异常 = 100080,
            非异步函数调用异步方法 = 100081 ,
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
