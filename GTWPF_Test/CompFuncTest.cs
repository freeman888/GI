using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GI;
using static GI.Function;

namespace GTWPF_Test
{
    internal class CompileLibTest : ILib
    {
        public Dictionary<string, Variable> myThing
        {
            get => new Dictionary<string, Variable>
        {
            {"Maind", new Variable(new Main_CompiledFunc()) }
        };
            set => throw new Exception();
        }
        public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();
        public List<string> waittoadd
        {
            get => new List<string> { "IO", "System" };
            set => throw new NotImplementedException();
        }

        private class Main_CompiledFunc : AFunction
        {
            public Main_CompiledFunc()
            {
                this.Iisreffunction = false;
                this.Istr_xcname = "args";
                this.poslib = "Test";
            }

            public async override Task<object> Run(Dictionary<string,Variable> xc)
            {

                #region usefun_s WriteLine("Hello World gasoline compiled");

                #region arg fun
                //funname
                #region arg var
                Variable var1 = xc["WriteLine"] as Variable;
                #endregion
                //params
                #region arg str
                Variable var2 = new Variable("Hello World gasoline compiled");
                #endregion
                var func1 = var1.value as IFunction;
                var _ = func1.IRun(Resulter.Setvariablesname(func1.Istr_xcname, new ArrayList { var2 }, func1.poslib));

                #endregion

                #endregion

                #region var_s var t1 = GetTime("second");
                xc.Add("t1",new Variable(0));
                #endregion

                #region getres_s var t1 = GetTime("second");
                //togive
                #region arg var
                Variable var3 = xc["t1"] as Variable;

                #endregion 
                //from
                #endregion

                return new Variable(0);
            }
        }

    }
}
