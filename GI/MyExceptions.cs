using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    public class MyExceptions
    {
        /// <summary>
        /// flag to return a methord quickly
        /// </summary>
        public class ReturnException:Exception
        {
            public object toreturn;
        }
    }
}
