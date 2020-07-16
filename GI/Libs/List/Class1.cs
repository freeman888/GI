using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{ 
    partial class Lib
    {
        public class List_Lib:ILib
        {
            public List_Lib()
            {
                   
            }

            public class ListClassTemplate:GClassTemplate
            {
                public ListClassTemplate():base("list","System")
                {
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
