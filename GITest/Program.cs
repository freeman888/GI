using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GI;

namespace GITest
{
    class Interaction
    {
        [STAThread]
        public static void Main()
        {
            Console.Write($" In Gasoline interactive mode \n Gasoline interpreter : GI \t version : {GI.GIInfo.GIVersion} \t Loading...");
            LoadInterpreter();
            Console.Write("Done");
            var aline  = Console.ReadLine();
        }

        private static void LoadInterpreter()
        {
            var str = "IO.Write(123);";
            string value = gasc.Out.IModeGas2IL(str, gasc.Out.Mode.Sentence);
            
        }
    }
}
