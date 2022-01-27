using System;
using System.Collections.Generic;
using static GI.Function;

namespace GI
{
    partial class Lib
    {
        public class List_Lib : ILib
        {
            public List_Lib()
            {
                myThing.Add("List", new Variable(new ListClassTemplate()));
                myThing.Add("Range", new Variable(new DFunction
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
                }));
            }

            public class ListClassTemplate : GClassTemplate
            {
                public ListClassTemplate() : base("List", "System")
                {
                    Istr_xcname = "params";
                    csctor = (xc) =>
                    {
                        return (xc["params"] as Variable).value;
                    };
                }
            }



            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion

        }
    }
}
