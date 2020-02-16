using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GI
{
    class GTask :  IType
    {
        public const string type = "task";

        public Task<Variable> value;
        public GTask(Task<Variable> o)
        {
            value = o;
        }

        public object IGetCSValue()
        {
            return value;
        }

        public string IGetType()
        {
            return type;
        }

        public override string ToString()
        {
            return "task";
        }
    }
}
