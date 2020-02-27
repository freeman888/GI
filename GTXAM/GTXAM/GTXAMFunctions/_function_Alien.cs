using System;
using System.Collections;
using Xamarin.Forms;
using GI;
using static GI.Function;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTXAM.GTXAMFunctions
{
    public partial class GTXAMFunction
    {
        public class Alien_Head:Head
        {
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {

                h.Add("Alien.FlashLight.Open", new AlienFlashLight_Function_Open());
                h.Add("Alien.FlashLight.Close", new AlienFlashLight_Function_Close());
            }
            internal class AlienFlashLight_Function_Open :AFunction
            {
                public AlienFlashLight_Function_Open()
                {
                        
                }
                public async override Task<object> Run(Hashtable xc)
                {
                    await Xamarin.Essentials.Flashlight.TurnOnAsync();
                    return new Variable(0);
                }
                
            }
            internal class AlienFlashLight_Function_Close : AFunction
            {
                public AlienFlashLight_Function_Close()
                {

                }
                public async override Task<object> Run(Hashtable xc)
                {
                    await Xamarin.Essentials.Flashlight.TurnOffAsync();
                    return new Variable(0);
                }

            }
        }
    }
}
