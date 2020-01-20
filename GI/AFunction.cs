using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GI
{
    partial class Function
    {
        /// <summary>
        /// 默认为异步函数，且非引用传递
        /// </summary>
        public class AFunction : IFunction
        {
            public AFunction()
            {
                Iisasync = true;
                Iisreffunction = false;
                Istr_xcname = "";
                IInformation = "Async Function\n";
            }
            public string Istr_xcname { get ; set ; }
            public bool Iisreffunction { get ; set ; }
            public string IInformation { get ; set; }
            public bool Iisasync { get { return true;    }   set { }    }

            public Task<object> IAsyncRun(Hashtable xc)
            {
                return Run(xc);
            }

            public object IGetCSValue()
            {
                return this;
            }

            public string IGetType()
            {
                throw new NotImplementedException();
            }

            public object IRun(Hashtable xc)
            {
                throw new NotImplementedException();
            }

            public virtual Task<object> Run(Hashtable xc)
            {
                return null;
            }

            

        }
    }
}
