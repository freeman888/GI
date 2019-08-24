using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static GI.Function;

namespace GI
{
    public class Glist : List<Variable>,IType,IFunction
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
            throw new Exception("参数错误");
        }
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

    }
}
