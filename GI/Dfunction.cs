using System;
using System.Collections;
using System.Collections.Generic;
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
            public string poslib { get; set; }
            string IFunction.Istr_xcname { get => str_xcname; set => str_xcname = value; }
            bool IFunction.Iisreffunction { get => isreffunction; set => isreffunction = value; }
            public delegate object DRun(Dictionary<string,Variable> xc);
            public DRun dRun;
            public object IRun(Dictionary<string,Variable> xc)
            {
                return (dRun(xc));
            }

            public string IInformation { get; set; }
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

            public Task<object> IAsyncRun(Dictionary<string,Variable> xc)
            {
                throw new Exception();
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
