using System.Collections.Generic;

namespace GI
{
    public interface ILib
    {
        Dictionary<string, Variable> myThing { get; set; }
        Dictionary<string, Variable> otherThing { get; set; }

        List<string> waittoadd { get; set; }
    }
    public partial class Lib
    {
        
        public class UserLib : ILib
        {


            //mything 自己的库函数和类，otherThing get到的库函数和类，waittoadd等所有的类库的自己的库函数和类加载好后，在遍历加载需要get的到otherThing里面
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();
            public List<string> waittoadd { get; set; } = new List<string>();







        }



    }
}
