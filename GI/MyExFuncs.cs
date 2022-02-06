using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace GI
{
    public static class MyExFuncs
    {
        public static string GetAttribute(this XmlNode xmlNode, string name)
        {
            if (xmlNode.Attributes[name] == null)
                return "";
            return xmlNode.Attributes[name].InnerText;
        }
        public static T GetVariable<T>(this Dictionary<string,Variable> hashtable, string varname)
        {

            T t = (T)((Variable)hashtable[varname]).value;
            return t;
        }

        public static T GetCSVariable<T>(this Dictionary<string,Variable> hashtable, string varname)
        {
            IOBJ io = ((Variable)hashtable[varname]).value;
            return (T)io.IGetCSValue();


        }

        public static T GetCSVariableFromSpeType<T>(this Dictionary<string,Variable> hashtable, string varname, string typename)
        {
            var io = ((Variable)hashtable[varname]).value;
            var a = 10;
            while (io.IGetType() != typename)
            {
                if (io.IGetType() == "")
                    throw new Exceptions.RunException(Exceptions.EXID.未知, "找不到该名称的真实对象");
                else
                    if (io != null) io = io.IGetParent();
                else throw new Exceptions.RunException(Exceptions.EXID.未知, "找不到该名称的真实对象");


            }
            return (T)io.IGetCSValue();



        }
    }
}
