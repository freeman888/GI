﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace GI
{
    public static class MyExFuncs
    {
        public static string GetAttribute(this XmlNode xmlNode, string name)
        {
            return xmlNode.Attributes[name].InnerText;
        }
        public static T GetVariable<T>(this Hashtable hashtable,string varname)
        {

            T t = (T)((Variable)hashtable[varname]).value;
            return t;
        }

        public static T GetCSVariable<T>(this Hashtable hashtable,string varname)
        {
            IOBJ io = ((Variable)hashtable[varname]).value;
            return (T)io.IGetCSValue();


        }

        public static T GetCSVariableFromSpeType<T>(this Hashtable hashtable, string varname,string typename)
        {
            IOBJ io = ((Variable)hashtable[varname]).value;
            return (T) (io.IGetMember(typename).value).IGetCSValue();


        }
    }
}  
