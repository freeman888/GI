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
            internal object toreturn;
        }

        public class AsyncException:Exception
        {
            internal IAsync reruner;
        }
    }
}
