using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GI
{
    partial class Function
    {
        public class MFunction : IOBJ, IFunction
        {
            IFunction function;
            IOBJ self;
            public MFunction(IFunction function, IOBJ self)
            {
                this.function = function;
                this.self = self;
                poslib = function.poslib;
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

            public string poslib { get; set; }
            public string IGetType()
            {
                return function.IGetType();
            }

            public object IGetCSValue()
            {
                return function.IGetCSValue();
            }

            public string Istr_xcname { get => function.Istr_xcname; set => function.Istr_xcname = value; }
            public bool Iisreffunction { get => function.Iisreffunction; set => function.Iisreffunction = value; }
            public string IInformation { get => function.IInformation; set => function.IInformation = value; }
            public bool Iisasync { get => function.Iisasync; set => function.Iisasync = value; }
            public object IRun(Dictionary<string,Variable> xc)
            {
                xc.Add("this", new Variable(self));
                return function.IRun(xc);
            }

            public Task<object> IAsyncRun(Dictionary<string,Variable> xc)
            {
                xc.Add("this", new Variable(self));
                return function.IAsyncRun(xc);
            }
        }
    }
}
