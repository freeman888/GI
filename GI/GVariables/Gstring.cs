using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static GI.Function;

namespace GI
{
    public class Gstring : IOBJ,IConvertible
    {
        public const string type = "String";
        string value;
        static Gstring()
        {
            GType.Sign(type);
        }

        static IFunction find = new String_Function_Find();
        static IFunction split = new String_Function_Split();
        static IFunction sub = new String_Function_SubString();
        static IFunction replace = new DFunction
        {
            IInformation = "replace the old string with the new in the str",
            str_xcname = "old,new",
            dRun = (xc) =>
            {
                var str = xc.GetCSVariable<object>("this").ToString();
                var old = xc.GetCSVariable<object>("old").ToString();
                var _new = xc.GetCSVariable<object>("new").ToString();
                return new Variable(str.Replace(old, _new));
            }
        };
        static IFunction findlast = new String_Function_FindLast();
        public Gstring(string v)
        {
            value = v;
            members = new Dictionary<string, Variable>
            {

                    {"Find",new Variable(new MFunction( find,this) )},
                    {"Split",new Variable(new MFunction( split,this) )},
                    {"SubString",new Variable(new MFunction(sub,this)) },
                    {"Replace",new Variable(new MFunction( replace,this)) },
                {"FindLast",new Variable(new MFunction(findlast,this)) }

            };

        }
        string IOBJ.IGetType()
        {
            return type;
        }
        public object IGetCSValue()
        {
            return value;
        }
        public override string ToString()
        {
            return value;
        }

        public TypeCode GetTypeCode()
        {
            return value.GetTypeCode();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)value).ToBoolean(provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return ((IConvertible)value).ToByte(provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return ((IConvertible)value).ToChar(provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)value).ToDateTime(provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)value).ToDecimal(provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)value).ToDouble(provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)value).ToInt16(provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)value).ToInt32(provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)value).ToInt64(provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)value).ToSByte(provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)value).ToSingle(provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return value.ToString(provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)value).ToType(conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)value).ToUInt16(provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)value).ToUInt32(provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)value).ToUInt64(provider);
        }
        
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

        Dictionary<string, Variable> members;

        #region 寻找
        public class String_Function_Find : Function
        {
            public String_Function_Find()
            {
                IInformation = @"it has two reload
[first(string)]:the base stirng
[second(string)]:the string you wanner find in base string
[third(number)]:do not always need.the start position t find";
                str_xcname = "params";
                poslib = "System";
            }
            public override object Run(Hashtable xc)
            {
                var list = xc.GetCSVariable<Glist>("params");
                Gdebug.WriteLine(list.Count.ToString());
                if (list.Count == 1)
                {
                    string s1 = xc.GetCSVariable<object>("this").ToString();
                    string s2 = list[0].value.ToString();
                    return new Variable(s1.IndexOf(s2));
                }
                else if (list.Count == 2)
                {
                    string s1 = xc.GetCSVariable<object>("this").ToString();
                    string s2 = list[0].value.ToString();
                    int i = Convert.ToInt32(list[1].value);
                    return new Variable(s1.IndexOf(s2, i));
                }
                else throw new Exceptions.RunException(Exceptions.EXID.参数错误, "参数错误");
            }
        }

        public class String_Function_FindLast:Function
        {
            public String_Function_FindLast()
            {
                IInformation = "";
                str_xcname = "str";
            }
            public override object Run(Hashtable xc)
            {
                var list = xc.GetCSVariable<Glist>("params");
                Gdebug.WriteLine(list.Count.ToString());
                if (list.Count == 1)
                {
                    string s1 = xc.GetCSVariable<object>("this").ToString();
                    string s2 = list[0].value.ToString();
                    return new Variable(s1.LastIndexOf(s2));
                }
                else if (list.Count == 2)
                {
                    string s1 = xc.GetCSVariable<object>("this").ToString();
                    string s2 = list[0].value.ToString();
                    int i = Convert.ToInt32(list[1].value);
                    return new Variable(s1.LastIndexOf(s2, i));
                }
                else throw new Exceptions.RunException(Exceptions.EXID.参数错误, "参数错误");
            }
        }

        #endregion

        public class String_Function_Split : Function
        {
            public String_Function_Split()
            {
                IInformation = "split s1 by s2 abd return a list";
                str_xcname = "s2";
                poslib = "System";
            }
            public override object Run(Hashtable xc)
            {
                string s1 = Variable.GetTrueVariable<object>(xc, "this").ToString();
                string s2 = Variable.GetTrueVariable<object>(xc, "s2").ToString();
                ArrayList array = new ArrayList(s1.Split(new string[] { s2 }, StringSplitOptions.RemoveEmptyEntries));
                var list = new Glist();
                foreach (object o in array)
                {
                    list.Add(new Variable(o));
                }
                return new Variable(list);
            }
        }

        public class String_Function_SubString : Function
        {
            public String_Function_SubString()
            {
                IInformation = "sub s1 from s and the length is sure";
                str_xcname = "s,len";
                poslib = "System";
            }
            public override object Run(Hashtable xc)
            {
                string s1 = Variable.GetTrueVariable<object>(xc, "this").ToString();
                int s = Convert.ToInt32(Variable.GetTrueVariable<object>(xc, "s"));
                int len = Convert.ToInt32(Variable.GetTrueVariable<object>(xc, "len"));
                return new Variable(s1.Substring(s, len));
            }
        }
    }
}
