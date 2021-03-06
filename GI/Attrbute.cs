﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    public class Attribute
    {
        /// <summary>
        /// 标志含有子语句的语句
        /// </summary>
        internal class HasChildSentencesAttribute : System.Attribute
        {
        }

        internal class GasTypeAttribute: System. Attribute
        {
            private static List<string> types = new List<string>();
            private List<string> mytype = new List<string>();
            public GasTypeAttribute(string rtype,params string[] lasttypes)
            {
                if(rtype != null)
                {
                    if (types.Contains(rtype))
                        throw new Exception("类型冲突:" + rtype);
                    types.Add(rtype);
                    mytype.Add(rtype);
                }
                foreach (var item in lasttypes)
                    mytype.Add(item);

            }
        }
    }
}
