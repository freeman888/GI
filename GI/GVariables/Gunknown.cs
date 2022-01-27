using System.Collections.Generic;

namespace GI
{
    class Gunknown : IOBJ
    {
        public const string type = "Unknown";

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
            return value.ToString();
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
