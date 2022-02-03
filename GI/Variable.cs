using System;
using System.Collections;
using System.Threading.Tasks;
using System.Xml;

namespace GI
{




    public partial class Variable
    {

        public class BaseResulter:Resulter
        {
            public BaseResulter(XmlNode node) : base(node) { }

            internal Resulter[] resulters { get => childresulters; }
        }

        /// <summary>
        /// 获取不干扰原变量表的新变量表
        /// </summary>
        /// <param name="basehashtable">原变量表</param>
        /// <returns>新变量表</returns>
        public static Hashtable GetOwnVariables(string poslib)
        {
            if (string.IsNullOrEmpty(poslib))
                return new Hashtable { { "true", new Variable(true) }, { "false", new Variable(false) } };


            var basehashtable = Gasoline.libs[poslib];

            var hashtable = new Hashtable();
            foreach (var inbase in basehashtable.myThing)
                hashtable.Add(inbase.Key, inbase.Value);
            foreach (var inbase in basehashtable.otherThing)
                hashtable.Add(inbase.Key, inbase.Value);
            return hashtable;
        }

        public static Hashtable GetOwnVariables(Hashtable basehashtable)
        {
            var hashtable = new Hashtable();
            foreach (DictionaryEntry inbase in basehashtable)
            {
                hashtable.Add(inbase.Key, inbase.Value);
            }
            return hashtable;
        }




        public static T GetTrueVariable<T>(Hashtable oldhs, string variablename)
        {
            T t = (T)((Variable)oldhs[variablename]).value;
            return t;
        }

        public Variable(IOBJ o)
        {
            value = o;
        }
        public Variable(int i)
        {
            value = new Gnumber(Convert.ToDouble(i));
        }
        public Variable(double d)
        {
            value = new Gnumber(d);
        }
        public Variable(string s)
        {
            value = new Gstring(s);
        }
        public Variable(bool b)
        {
            value = new Gbool(b);
        }
        public Variable(object o)
        {

            if (o is IOBJ)
                value = o as IOBJ;
            else if (o is int)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is double)
                value = new Gnumber(Convert.ToDouble(o));
            else if (o is string)
                value = new Gstring(o.ToString());
            else if (o is bool)
                value = new Gbool(Convert.ToBoolean(o));
            else if (o is Task<Variable>)
                value = new GTask(o as Task<Variable>);
            else
                value = new Gunknown(o);
        }

        public bool isconst = false;

        private IOBJ m_value;

        public virtual IOBJ value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (isconst)
                {
                    throw new Exceptions.RunException(Exceptions.EXID.更改常量, "常量不允许赋值");
                }
                else
                {
                    m_value = value;
                }
            }
        }

    }
    /// <summary>
    /// 是个Variable的空壳，里面的东西应该重新实现
    /// </summary>
    public class FVariable : Variable
    {
        public static IOBJ obj = new Gnumber(0);
        public Func<IOBJ, int> onsetvalue = null;
        public Func<IOBJ> ongetvalue = null;
        public FVariable() : base(obj)
        { }

        public override IOBJ value
        {
            get
            {
                if (ongetvalue != null) return ongetvalue.Invoke();
                else return base.value;
            }
            set { onsetvalue?.Invoke(value); base.value = value; }
        }
    }
}