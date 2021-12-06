using GI;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using static GI.Function;

namespace GTWPF.Lib.IO
{
    public class FilePicker :IOBJ
    {
        internal OpenFileDialog openFileDialog = new OpenFileDialog();
        internal bool picked = false;
        public FilePicker()
        {
            members = new Dictionary<string, Variable>
            {
                {"Picked", new FVariable{ ongetvalue = ()=>new Gbool(picked),onsetvalue = (value)=>throw new Exceptions.RunException(Exceptions.EXID.未知)} },
                {"Show" ,new Variable(new MFunction(show,this))},
                {"FileName" ,new FVariable{
                    ongetvalue = ()=>new Gstring(openFileDialog.FileName),
                    onsetvalue = (val)=>throw new Exceptions.RunException( Exceptions.EXID.逻辑错误) } },
                {"Stream",new FVariable{ ongetvalue = ()=>new GStream(System.IO.File.OpenRead(openFileDialog.FileName)),
                onsetvalue = (_)=>throw new Exceptions.RunException( Exceptions.EXID.未知)
                }
                 },
                {"FileType" ,new FVariable{ ongetvalue = ()=> new Gstring(openFileDialog.Filter),onsetvalue = (value)=>{ openFileDialog.Filter = value.IGetCSValue().ToString(); return 0; } } }
            };
        }
        public static IFunction show = new FilePicker_Function_Show();
        public class FilePicker_Function_Show:Function
        {
            public FilePicker_Function_Show()
            {
                IInformation = "show the file pick window";
                str_xcname = "";
            }
            public override object Run(Hashtable xc)
            {
                var picker = xc.GetCSVariableFromSpeType<FilePicker>("this", "FilePicker");
                picker.picked = picker.openFileDialog.ShowDialog() == true?true:false;
                return new Variable(0);
            }
        }

        #region 实现Itype
        const string type = "FilePicker";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }

        public object IGetCSValue()
        {
            return this;
        }
        static FilePicker()
        {
            GType.Sign("FilePicker");
        }
        #endregion
        #region
        Dictionary<string, Variable> members;
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

        #endregion
    }
}
