using System.Collections;
using System.Collections.Generic;
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
                Iisreffunction = false;
                Istr_xcname = "";
                IInformation = "Async Function\n";
            }
            public string poslib { get; set; }
            public string Istr_xcname { get; set; }
            public bool Iisreffunction { get; set; }
            public string IInformation { get; set; }
            public bool Iisasync { get { return true; } set { } }

            public Task<object> IAsyncRun(Dictionary<string,Variable> xc)
            {
                return Run(xc);
            }

            public object IGetCSValue()
            {
                return this;
            }


            public const string type = "function";

            public string IGetType()
            {
                return type;
            }

            public override string ToString()
            {
                return IGetType();
            }

            public object IRun(Dictionary<string,Variable> xc)
            {
                return new Variable(0);
            }

            public virtual Task<object> Run(Dictionary<string,Variable> xc)
            {
                return null;
            }

            Dictionary<string, Variable> members = new Dictionary<string, Variable>();
            public Variable IGetMember(string name)
            {
                if (members.ContainsKey(name))
                    return members[name];
                else return null;
            }

            public IOBJ IGetParent()
            {
                return null;
            }

        }
    }
}
