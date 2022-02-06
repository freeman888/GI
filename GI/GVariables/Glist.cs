using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GI.Function;

namespace GI
{
    public class Glist : List<Variable>, IOBJ, IFunction
    {
        public Glist()
        {
            members = new Dictionary<string, Variable>
            {
                {"Add",new Variable(new MFunction(add,this))},
                {"Find",new Variable(new MFunction(find,this)) },
                {"Get",new Variable(new MFunction(get,this)) },
                {"Remove",new Variable(new MFunction(remove,this)) },
                {"RemoveAt",new Variable(new MFunction(removeat,this)) },
                {"GetLength",new Variable(new MFunction(getlength,this)) }
            };

        }
        const string type = "List";
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

        public object IRun(Dictionary<string,Variable> xc)
        {
            var param = xc.GetCSVariable<Glist>("params");
            if (param.Count == 1)
            {
                return this[Convert.ToInt32(param[0].value)];
            }
            else if (param.Count == 0)
            {
                return new Variable(new DFunction() { str_xcname = "obj", dRun = (_xc) => { Add(new Variable((_xc["obj"] as Variable).value)); return new Variable(this); } });
            }
            else if (param.Count == 2)
            {
                int index = Convert.ToInt32(param[0].value);
                Variable obj = param[1];
                this[index] = obj;
                return new Variable(this);
            }
            throw new Exceptions.RunException(Exceptions.EXID.参数错误, "参数错误");
        }

        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Dictionary<string,Variable> xc)
        {
            throw new Exception();
        }
        public string poslib { get; set; }
        #endregion
        #region 实现Itype
        static Glist()
        {
            GType.Sign("List");
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


        static IFunction get = new List_Function_Get();
        public class List_Function_Get : Function
        {
            public List_Function_Get()
            {
                str_xcname = "index";
                IInformation =
@"[list(list)]:list
[index(number)]:the index of the object you wanner to get.It starts from 0.
[return]:the object in the list";
            }
            public override object Run(Dictionary<string,Variable> xc)
            {
                var res = xc.GetCSVariable<Glist>("this")[Convert.ToInt32(xc.GetVariable<object>("index"))];
                return res;
            }
        }

        static IFunction add = new List_Function_Add();
        public class List_Function_Add : Function
        {
            public List_Function_Add()
            {
                IInformation = @"add obj to the list";
                str_xcname = "obj";
            }
            public override object Run(Dictionary<string,Variable> xc)
            {
                var res = xc.GetCSVariable<Glist>("this");
                res.Add(new Variable((xc["obj"] as Variable).value));
                return new Variable(0);
            }

        }
        static IFunction find = new List_Function_Find();
        public class List_Function_Find : Function
        {
            public List_Function_Find()
            {
                IInformation = @"this methord should input two or three param
when two:
[first(list)]
[second]:the object you want to find in the list
[return(number)]:the index of the object in this list
when three
[first(list)]
[second]:the object you want to find in the list
[third(number)]:start position to find
[return(number)]:the index of the object in this list";
                str_xcname = "params";
            }
            public override object Run(Dictionary<string,Variable> xc)
            {
                var param = xc.GetCSVariable<Glist>("params");

                var list = xc.GetCSVariableFromSpeType<Glist>("this", "List");
                Variable obj = param[0];
                if (param.Count == 1)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].value.IGetCSValue() == null)
                        {
                            if (list[i].value.Equals(obj.value))
                                return new Variable(i);
                        }
                        else
                        {

                            if (list[i].value.IGetCSValue().Equals(obj.value.IGetCSValue()))
                                return new Variable(i);
                        }
                    }
                    return new Variable(-1);
                }
                else if (param.Count == 2)
                {
                    int start = Convert.ToInt32(param[1].value);
                    for (int i = start; i < list.Count; i++)
                    {
                        if (list[i].value.IGetCSValue() == null)
                        {
                            if (list[i].value.Equals(obj.value))
                                return new Variable(i);
                        }
                        else
                        {

                            if (list[i].value.IGetCSValue().Equals(obj.value.IGetCSValue()))
                                return new Variable(i);
                        }
                    }
                    return new Variable(-1);
                }
                else throw new Exceptions.RunException(Exceptions.EXID.参数错误, "参数错误");
            }
        }
        static IFunction remove = new List_Function_Remove();
        public class List_Function_Remove : Function
        {
            public List_Function_Remove()
            {
                IInformation = "remove the object from the list";
                str_xcname = "obj";
            }
            public override object Run(Dictionary<string,Variable> xc)
            {
                var list = xc.GetCSVariableFromSpeType<Glist>("this", "List");
                var tor = xc["obj"] as Variable;
                int tori = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].value.IGetCSValue() == null)
                    {
                        if (list[i].value.Equals(tor.value))
                            tori = i;
                    }
                    else
                    {
                        if (list[i].value.IGetCSValue().Equals(tor.value.IGetCSValue()))
                        {
                            tori = i;
                        }
                    }
                }
                if (tori != -1)
                {
                    list.RemoveAt(tori);
                }
                return new Variable(0);
            }
        }
        static IFunction removeat = new List_Function_RemoveAt();
        public class List_Function_RemoveAt : Function
        {
            public List_Function_RemoveAt()
            {
                IInformation = "remove the object of the index from the list";
                str_xcname = "index";
            }
            public override object Run(Dictionary<string,Variable> xc)
            {
                var res = xc.GetCSVariableFromSpeType<Glist>("list", "List");
                int i = Convert.ToInt32(xc.GetVariable<object>("index"));
                res.RemoveAt(i);
                return new Variable(0);
            }
        }
        IFunction getlength = new DFunction
        {
            str_xcname = "",
            isreffunction = false,
            IInformation =
@"[list(list)]:the list you want to get length
[return(number)]:length",
            dRun = (_xc) =>
            {
                return new Variable(_xc.GetCSVariableFromSpeType<Glist>("this", "List").Count);
            }
        };

    }
}
