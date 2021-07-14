using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using GI;
using static GI.Function;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

namespace GTXAM
{
    public class FilePicker:IOBJ
    {
        internal bool picked = false;
        internal FileResult fileresult;
        internal Stream stream;
        public FilePicker()
        {
            
            members = new Dictionary<string, Variable>
            {
                {"Picked", new FVariable{ ongetvalue = ()=>new Gbool(picked),onsetvalue = (value)=>throw new Exceptions.RunException(Exceptions.EXID.未知)} },
                {"Show" ,new Variable(new MFunction(show,this))},
                {"FileName" ,new FVariable{
                    ongetvalue = ()=>new Gstring(fileresult.FullPath),
                    onsetvalue = (val)=>throw new Exceptions.RunException( Exceptions.EXID.逻辑错误) } },
                {"Stream",new FVariable{ ongetvalue = ()=>new GStream(stream) ,
                onsetvalue = (_)=>throw new Exceptions.RunException( Exceptions.EXID.未知)
                }
                 },
                {"FileType" ,new FVariable{ ongetvalue = ()=> new Gstring(""),onsetvalue = (value)=>{ return 0; } } }
            };
        }
        public static IFunction show = new FilePicker_Function_Show();
        public class FilePicker_Function_Show : AFunction
        {
            public FilePicker_Function_Show()
            {
                IInformation = "show the file pick window";
                Istr_xcname = "";
            }
            public async override Task<object> Run(Hashtable xc)
            {
                try
                {
                    var picker = xc.GetCSVariableFromSpeType<FilePicker>("this", "filepicker");
                    var fileres = await Xamarin.Essentials.FilePicker.PickAsync( PickOptions.Default);
                    if (fileres == null)
                        picker.picked = false;

                    else
                    {
                        picker.picked = true;
                        picker.fileresult = fileres;
                        picker.stream = await fileres.OpenReadAsync();
                    }
                }
                catch(Exception ex)
                {

                    await App.MainApp.MainPage.DisplayAlert("", ex.StackTrace, "cancel");
                }
                return new Variable(0);
                
            }
        }


        #region 实现Itype
        const string type = "filepicker";
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
            GType.Sign("filepicker");
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
