using System;
using System.Collections.Generic;
using System.Text;

namespace GI
{
    public class Lib
    {
        //mything 自己的库函数和类，otherThing get到的库函数和类，waittoadd等所有的类库的自己的库函数和类加载好后，在遍历加载需要get的到otherThing里面
        public Dictionary<string, Variable> myThing = new Dictionary<string, Variable>(),
        otherThing = new Dictionary<string, Variable> { { "true", new Variable(true) }, { "false", new Variable(false) } };
        public List<string> waittoadd = new List<string>();
        



    }
}
