using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    partial class Function
    {
        public class List_Head : Head
        {
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {
                h.Add("List.Add", new List_Function_Add());
                h.Add("List.Creat", new List_Function_Creat());
                h.Add("List.Find", new List_Function_Find());
                h.Add("List.Get", new List_Function_Get());
                h.Add("List.GetLength", new DFunction
                {
                    str_xcname = "list",
                    isreffunction = false,
                    IInformation =
@"[list(list)]:the list you want to get length
[return(number)]:length",
                    dRun = (_xc) =>
{
    return new Variable(_xc.GetCSVariable<Glist>("list").Count);
}
                });
                h.Add("List.Range", new DFunction
                {

                    str_xcname = "s,e",
                    IInformation =
@"[s(number)]:the start number of the list
[e(number)]:the end number of the list (not contain). 'e' should bigger than 's'
[return(list)]:list
creat a new list contains numbers(sure it can contains more than number)",
                    dRun = (xc) =>
{
    Glist variables = new Glist();
    int s = Convert.ToInt32(xc.GetCSVariable<object>("s")), e = Convert.ToInt32(xc.GetCSVariable<object>("e"));
    for (int i = s; i < e; i++)
    {
        variables.Add(new Variable(i));
    }
    return new Variable(variables);
}
                });
                h.Add("List.Remove", new List_Function_Remove());
                h.Add("List.RemoveAt", new List_Function_RemoveAt());
                

            }

            public class List_Function_Creat:Function
            {
                public List_Function_Creat()
                {
                    str_xcname = "params";
                    IInformation =
@"[params]:what to add to this new list
[return(list)]:return a new list";
                }
                public override object Run(Hashtable xc)
                {
                    return xc["params"];
                }
            }

            public class List_Function_Get:Function
            {
                public List_Function_Get()
                {
                    str_xcname = "list,index";
                    IInformation =
@"[list(list)]:list
[index(number)]:the index of the object you wanner to get.It starts from 0.
[return]:the object in the list";
                }
                public override object Run(Hashtable xc)
                {
                    var res =  xc.GetCSVariable<Glist>("list")[Convert.ToInt32(xc.GetVariable<object>("index"))];
                    return res;
                }
            }
            public class List_Function_Add : Function
            {
                public List_Function_Add()
                {
                    IInformation = @"add obj to the list";
                    str_xcname = "list,obj";
                }
                public override object Run(Hashtable xc)
                {
                    var res = xc.GetCSVariable<Glist>("list");
                    res.Add(new Variable( (xc["obj"] as Variable).value));
                    return new Variable(0);
                }

            }
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
                public override object Run(Hashtable xc)
                {
                    var param = xc.GetCSVariable<Glist>("params");

                    var list = param[0].value.IGetCSValue() as Glist;
                    Variable obj = param[1];
                    if (param.Count == 2)
                    {
                        for (int i = 0;i<list.Count;i++)
                        {
                            if (list[i].value.IGetCSValue().Equals(obj.value.IGetCSValue()))
                                return new Variable(i);
                        }
                        return new Variable(-1);
                    }
                    else if (param.Count == 3)
                    {
                        int start = Convert.ToInt32(param[2].value);
                        for(int i = start;i<list.Count;i++)
                        {
                            if (list[i].value.IGetCSValue().Equals(obj.value.IGetCSValue()))
                                return new Variable(i);
                        }
                        return new Variable(-1);
                    }
                    else throw new Exception("参数错误");
                }
            }
            public class List_Function_Remove : Function
            {
                public List_Function_Remove()
                {
                    IInformation = "remove the object from the list";
                    str_xcname = "list,obj";
                }
                public override object Run(Hashtable xc)
                {
                    var list = xc.GetCSVariable<Glist>("list");
                    var tor  = xc["obj"] as Variable;
                    int tori = -1;
                    for (int i = 1;i<list.Count;i++)
                    {
                        if (list[i].value.IGetCSValue().Equals(tor.value.IGetCSValue()))
                            tori = i;
                    }
                    if(tori != -1)
                    {
                        list.RemoveAt(tori);
                    }
                    return new Variable(0);
                }
            }
            public class List_Function_RemoveAt : Function
            {
                public List_Function_RemoveAt()
                {
                    IInformation = "remove the object of the index from the list";
                    str_xcname = "list,index";
                }
                public override object Run(Hashtable xc)
                {
                    var res = xc.GetCSVariable<Glist>("list");
                    int i = Convert.ToInt32(xc.GetVariable<object>("index"));
                    res.RemoveAt(i);
                    return new Variable(0);
                }
            }

        }
    }
}
