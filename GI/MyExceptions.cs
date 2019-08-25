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
            public Task task;
            public int id;
            public bool breakdone = false;
            public IAsync reruner;
            static List<int> used = new List<int>();
            static Random random = new Random();
            public AsyncException()
            {
                int _id;
                do
                {
                    _id = random.Next(0, 999999999);
                }
                while (used.Contains(_id));
                id = _id;
            }
        }
    }
}
