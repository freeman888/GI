using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    public static class GType
    {
        public static List<string> types = new List<string>();
        public static bool Sign(string type)
        {
            if (types.Contains(type))
                throw new Exceptions.RunException( Exceptions.EXID.类型冲突,"类型冲突 :" + type);
            types.Add(type);
            return true;
        }
    }
    public interface IType
    {
        string IGetType();
        string ToString();
        object IGetCSValue();
    }
}
