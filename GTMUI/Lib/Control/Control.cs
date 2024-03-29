﻿using GI;
using GTXAM.GasControl.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTXAM
{
    partial class Lib
    {
        public class Control_Lib : GI.Lib.ILib
        {

            public Control_Lib()
            {
                myThing.Add("Bubble", new Variable(new BubbleClassTemplate()));
                myThing.Add("Tip", new Variable(new TipClassTemplate()));
                myThing.Add("EditText", new Variable(new EditTextTemplate()));
                myThing.Add("GridFlat", new Variable(new GridClassTemplate()));
                myThing.Add("Switcher", new Variable(new SwitcherClassTemplate()));
                myThing.Add("ScrollFlat", new Variable(new ScrollFlatTemplate()));
                myThing.Add("Image", new Variable(new ImageClassTemplate()));
                myThing.Add("TextCell", new Variable(new TextCellClassTemplate()));
                myThing.Add("ListFlat", new Variable(new ListFlatClassTemplate()));
                myThing.Add("WebView", new Variable(new WebViewClassTemplate()));
                myThing.Add("StackFlat", new Variable(new StackFlatClassTemplate()));
            }


            public class BubbleClassTemplate : GClassTemplate
            {
                public BubbleClassTemplate() : base("bubble", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.Control.Bubble() { Name = text };
                    };

                }
            }

            public class TipClassTemplate : GClassTemplate
            {
                public TipClassTemplate() : base("tip", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.Control.Tip() { Name = text };
                    };
                }
            }

            public class EditTextTemplate : GClassTemplate
            {
                public EditTextTemplate() : base("edittext", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.Control.EditText() { Name = text };
                    };
                }
            }

            public class GridClassTemplate : GClassTemplate
            {
                public GridClassTemplate() : base("gridflat", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.ContentControl.GridFlat() { Name = text };
                    };
                }
            }

            public class SwitcherClassTemplate : GClassTemplate
            {
                public SwitcherClassTemplate() : base("switcher", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.Control.Switcher() { Name = text };
                    };
                }
            }

            public class ScrollFlatTemplate : GClassTemplate
            {
                public ScrollFlatTemplate() : base("scrollflat", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.ContentControl.ScrollFlat() { Name = text };
                    };
                }
            }

            public class ImageClassTemplate : GClassTemplate
            {
                public ImageClassTemplate() : base("image", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string name = xc.GetCSVariable<object>("name").ToString();
                        return new GasControl.Control.Image { Name = name };
                    };
                }
            }

            public class TextCellClassTemplate : GClassTemplate
            {
                public TextCellClassTemplate() : base("textcell", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string name = xc.GetCSVariable<object>("name").ToString();
                        return new GasControl.Control._TextCell { Name = name };
                    };
                }
            }

            public class ListFlatClassTemplate : GClassTemplate
            {
                public ListFlatClassTemplate() : base("textcell", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string name = xc.GetCSVariable<object>("name").ToString();
                        return new GasControl.ContentControl.ListFlat { Name = name };
                    };
                }
            }
            public class WebViewClassTemplate : GClassTemplate
            {
                public WebViewClassTemplate() : base("webview", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string name = xc.GetCSVariable<object>("name").ToString();
                        return new GasControl.Control.WebView { Name = name };
                    };
                }
            }
            public class StackFlatClassTemplate : GClassTemplate
            {
                public StackFlatClassTemplate() : base("stackflat", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string name = xc.GetCSVariable<object>("name").ToString();
                        return new GasControl.ContentControl.StackFlat { Name = name };
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
