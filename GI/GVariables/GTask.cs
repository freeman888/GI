using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GI
{
    class GTask :  IType
    {
        public const string type = "task";

        public Task value;
        public GTask(Task o)
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
            return ToString();
        }
    }
}
