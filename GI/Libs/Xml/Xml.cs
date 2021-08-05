﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    partial class Lib
    {
        public class Xml_Lib:ILib
        {
            public Xml_Lib()
            {
                myThing.Add("XmlDocument", new Variable(new XmlDocumentClassTemplate()));
            }


            public class XmlDocumentClassTemplate : GClassTemplate
            {
                

                public XmlDocumentClassTemplate() : base("xmldocument", "Xml")
                {
                    Istr_xcname = "";
                    csctor = (xc) =>
                    {
                        return new GI.Libs.Xml.XmlDocument();
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