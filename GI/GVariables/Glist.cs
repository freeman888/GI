using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static GI.Function;

namespace GI
{
    public class Glist : List<Variable>,IOBJ,IFunction
    {
        const string type = "list,function";
        #region
        public string Istr_xcname
        {
            get => "params";
            set { }
        }
        public bool Iisreffunction
        {
            get => false;
            set { }
        }
        public string IInformation { get => "to be added"; set => throw new NotImplementedException(); }

        public object IRun(Hashtable xc)
        {
            var param = xc.GetCSVariable<Glist>("params");
            if(param.Count == 1)
            {
                return this[Convert.ToInt32(param[0].value)];
            }
            else if(param.Count == 0)
            {
                return new Variable(new DFunction() { str_xcname = "obj", dRun = (_xc) => { Add ( new Variable(( _xc["obj"] as Variable).value)); return new Variable(this); } });
            }
            else if(param.Count == 2)
            {
                int index = Convert.ToInt32(param[0].value);
                Variable obj = param[1];
                this[index] = obj;
                return new Variable(this);
            }
            throw new Exceptions.RunException( Exceptions.EXID.参数错误,"参数错误");
        }

        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exception();
        }
        public string poslib { get => "System"; set => throw new Exceptions.RunException(Exceptions.EXID.未知); }
        #endregion
        #region 实现Ityoe
        static Glist()
        {
            GType.Sign("list");
        }
        public string IGetType()
        {
            return type;
        }
        public object IGetCSValue()
        {
            return this;
        }
        public override string ToString()
        {
            return IGetType();
        }
        #endregion
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
