using GTXAM;
using System.Xml;
using Xamarin.Forms.Platform.WPF;

namespace HelloWPF.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<code minversion=""1902"">
  <get value=""IO"" />
  <get value=""Math"" />
  <get value=""Page"" />
  <get value=""Control"" />
  <get value=""String"" />
  <get value=""System"" />
  <deffun funname=""Main"" params=""args"" isref=""False"">
    <var_s varname=""page"" str=""var page = Page.Creat(&quot;随机模拟计算PI（Gasoline异步实例）&quot;);"" />
    <getres_s str=""var page = Page.Creat(&quot;随机模拟计算PI（Gasoline异步实例）&quot;);"">
      <arg value=""page"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""随机模拟计算PI（Gasoline异步实例）"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""bu"" str=""var bu = Control.Bubble.Creat(&quot;b&quot;);"" />
    <getres_s str=""var bu = Control.Bubble.Creat(&quot;b&quot;);"">
      <arg value=""bu"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""b"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""bu(&quot;text&quot;,&quot;Caculate&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bu"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""Caculate"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""bu(&quot;padding&quot;,&quot;10,10,10,10&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bu"" con=""var"" />
        </fun>
        <params>
          <arg value=""padding"" con=""str"" />
          <arg value=""10,10,10,10"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""bu(&quot;clickevent&quot;,Cacu);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bu"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""Cacu"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""page()(bu);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""bu"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""Page.Load(page);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Load"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""IO.Tip(&quot;算法很简单，高中数学课本上的内容，但效率实在太低了，4位都要好长时间&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Tip"" con=""var"" />
        </fun>
        <params>
          <arg value=""算法很简单，高中数学课本上的内容，但效率实在太低了，4位都要好长时间"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""Cacu"" params=""page,e"" isref=""False"">
    <var_s varname=""t1"" str=""var t1 = System.GetTime(&quot;time&quot;);"" />
    <getres_s str=""var t1 = System.GetTime(&quot;time&quot;);"">
      <arg value=""t1"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""System.GetTime"" con=""var"" />
        </fun>
        <params>
          <arg value=""time"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""jqd"" str=""var jqd = 3;"" />
    <getres_s str=""var jqd = 3;"">
      <arg value=""jqd"" con=""var"" />
      <arg value=""3"" con=""num"" />
    </getres_s>
    <var_s varname=""i"" str=""var i = 0;"" />
    <getres_s str=""var i = 0;"">
      <arg value=""i"" con=""var"" />
      <arg value=""0"" con=""num"" />
    </getres_s>
    <var_s varname=""counter"" str=""var counter = 0;"" />
    <getres_s str=""var counter = 0;"">
      <arg value=""counter"" con=""var"" />
      <arg value=""0"" con=""num"" />
    </getres_s>
    <var_s varname=""s"" str=""var  s = Math.Pow(10,jqd+2);"" />
    <getres_s str=""var  s = Math.Pow(10,jqd+2);"">
      <arg value=""s"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Math.Pow"" con=""var"" />
        </fun>
        <params>
          <arg value=""10"" con=""num"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Math.Sum"" con=""var"" />
            </fun>
            <params>
              <arg value=""jqd"" con=""var"" />
              <arg value=""2"" con=""num"" />
            </params>
          </arg>
        </params>
      </arg>
    </getres_s>
    <while_s str=""while(i &lt;= s):"">
      <express>
        <arg con=""fun"">
          <fun>
            <arg value=""Math.SE"" con=""var"" />
          </fun>
          <params>
            <arg value=""i"" con=""var"" />
            <arg value=""s"" con=""var"" />
          </params>
        </arg>
      </express>
      <run>
        <getres_s str=""i = i+1;"">
          <arg value=""i"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Math.Sum"" con=""var"" />
            </fun>
            <params>
              <arg value=""i"" con=""var"" />
              <arg value=""1"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <var_s varname=""x"" str=""var x = Math.Random(0,1000000)/1000000;"" />
        <getres_s str=""var x = Math.Random(0,1000000)/1000000;"">
          <arg value=""x"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Math.Div"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""Math.Random"" con=""var"" />
                </fun>
                <params>
                  <arg value=""0"" con=""num"" />
                  <arg value=""1000000"" con=""num"" />
                </params>
              </arg>
              <arg value=""1000000"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <var_s varname=""y"" str=""var y = Math.Random(0,1000000)/1000000;"" />
        <getres_s str=""var y = Math.Random(0,1000000)/1000000;"">
          <arg value=""y"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Math.Div"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""Math.Random"" con=""var"" />
                </fun>
                <params>
                  <arg value=""0"" con=""num"" />
                  <arg value=""1000000"" con=""num"" />
                </params>
              </arg>
              <arg value=""1000000"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <if_s str=""if((x*x + y*y) &lt;= 1):"">
          <then>
            <express>
              <arg con=""fun"">
                <fun>
                  <arg value=""Math.SE"" con=""var"" />
                </fun>
                <params>
                  <arg con=""fun"">
                    <fun>
                      <arg value=""Math.Sum"" con=""var"" />
                    </fun>
                    <params>
                      <arg con=""fun"">
                        <fun>
                          <arg value=""Math.Mul"" con=""var"" />
                        </fun>
                        <params>
                          <arg value=""x"" con=""var"" />
                          <arg value=""x"" con=""var"" />
                        </params>
                      </arg>
                      <arg con=""fun"">
                        <fun>
                          <arg value=""Math.Mul"" con=""var"" />
                        </fun>
                        <params>
                          <arg value=""y"" con=""var"" />
                          <arg value=""y"" con=""var"" />
                        </params>
                      </arg>
                    </params>
                  </arg>
                  <arg value=""1"" con=""num"" />
                </params>
              </arg>
            </express>
            <run>
              <getres_s str=""counter = counter + 1;"">
                <arg value=""counter"" con=""var"" />
                <arg con=""fun"">
                  <fun>
                    <arg value=""Math.Sum"" con=""var"" />
                  </fun>
                  <params>
                    <arg value=""counter"" con=""var"" />
                    <arg value=""1"" con=""num"" />
                  </params>
                </arg>
              </getres_s>
            </run>
          </then>
        </if_s>
      </run>
    </while_s>
    <if_s str=""if(jqd &gt; 1):"">
      <then>
        <express>
          <arg con=""fun"">
            <fun>
              <arg value=""Math.B"" con=""var"" />
            </fun>
            <params>
              <arg value=""jqd"" con=""var"" />
              <arg value=""1"" con=""num"" />
            </params>
          </arg>
        </express>
        <run>
          <getres_s str=""jqd = jqd+1;"">
            <arg value=""jqd"" con=""var"" />
            <arg con=""fun"">
              <fun>
                <arg value=""Math.Sum"" con=""var"" />
              </fun>
              <params>
                <arg value=""jqd"" con=""var"" />
                <arg value=""1"" con=""num"" />
              </params>
            </arg>
          </getres_s>
        </run>
      </then>
    </if_s>
    <usefun_s str=""IO.Tip(System.GetTime(&quot;time&quot;)&amp;t1);"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Tip"" con=""var"" />
        </fun>
        <params>
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""System.GetTime"" con=""var"" />
                </fun>
                <params>
                  <arg value=""time"" con=""str"" />
                </params>
              </arg>
              <arg value=""t1"" con=""var"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""IO.Tip(String.SubString(4*counter/s,0,jqd));"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Tip"" con=""var"" />
        </fun>
        <params>
          <arg con=""fun"">
            <fun>
              <arg value=""String.SubString"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""Math.Div"" con=""var"" />
                </fun>
                <params>
                  <arg con=""fun"">
                    <fun>
                      <arg value=""Math.Mul"" con=""var"" />
                    </fun>
                    <params>
                      <arg value=""4"" con=""num"" />
                      <arg value=""counter"" con=""var"" />
                    </params>
                  </arg>
                  <arg value=""s"" con=""var"" />
                </params>
              </arg>
              <arg value=""0"" con=""num"" />
              <arg value=""jqd"" con=""var"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
  </deffun>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("WPF_Xamarin");
            Xamarin.Forms.Forms.Init();
            LoadApplication(new GTXAM.App());
        }
    }
}