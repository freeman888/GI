using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            internal Task task;
            internal int id;
            internal bool breakdone = false;
            internal IAsync reruner;
        }
    }
}
