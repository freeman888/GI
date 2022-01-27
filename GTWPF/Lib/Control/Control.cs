using GI;
using System.Collections.Generic;

namespace GTWPF
{
    partial class WPFLib
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
            }


            public class BubbleClassTemplate : GClassTemplate
            {
                public BubbleClassTemplate() : base("Bubble", "Control")
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
                public TipClassTemplate() : base("Tip", "Control")
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
                public EditTextTemplate() : base("EditText", "Control")
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
                public GridClassTemplate() : base("GridFlat", "Control")
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
                public SwitcherClassTemplate() : base("Switcher", "Control")
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
                public ScrollFlatTemplate() : base("ScrollFlat", "Control")
                {
                    Istr_xcname = "name";
                    csctor = (xc) =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "name").ToString();
                        return new GasControl.ContentControl.ScrollFlat() { Name = text };
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
