using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GI
{
    partial class Function
    {


        public class DFunction : IFunction
        {
            const string type = "function";
            public string str_xcname = "";
            public bool isreffunction = false;
            string IFunction.Istr_xcname { get => str_xcname; set => str_xcname = value; }
            bool IFunction.Iisreffunction { get => isreffunction; set => isreffunction = value; }
            public delegate object DRun(Hashtable xc);
            public DRun dRun;
            public object IRun(Hashtable xc)
            {
                return (dRun(xc));
            }

            public string IInformation { get ; set ; }
            public string IGetType()
            {
                return type;
            }

            public override string ToString()
            {
                return IGetType();
            }
            public object IGetCSValue()
            {
                return this;
            }
            public bool Iisasync { get { return false; } set { } }

            public Task<object> IAsyncRun(Hashtable xc)
            {
                throw new Exception();
            }

        }
    }
}
