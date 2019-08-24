using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    /// <summary>
    /// 可以是函数，可以是语句
    /// </summary>
    internal interface IAsync
    {
        object IReRun(Hashtable xc, int id);
    }
    
}
