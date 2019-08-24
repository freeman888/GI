using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    class Gunknown : IType
    {
        public const string type = "unknown";

        public object value;
        public Gunknown(object o)
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
