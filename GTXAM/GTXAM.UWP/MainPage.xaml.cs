using System.Xml;

namespace GTXAM.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<code minversion=""2007"">
  <lib name=""App1"">
    <get value=""IO"" />
    <get value=""Control"" />
    <get value=""Page"" />
    <get value=""List"" />
    <get value=""File"" />
    <var value=""web"" />
    <get value=""Xml"" />
    <get value=""System"" />
    <get value=""Thread"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <var_s varname=""s"" str=""var s = PickFile(&quot;文本文档|*.txt&quot;);"" />
      <getres_s str=""var s = PickFile(&quot;文本文档|*.txt&quot;);"">
        <arg value=""s"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""PickFile"" con=""var"" />
          </fun>
          <params>
            <arg value=""文本文档|*.txt"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""WriteLine(s:ReadText());"">
        <arg con=""fun"">
          <fun>
            <arg value=""WriteLine"" con=""var"" />
          </fun>
          <params>
            <arg con=""fun"">
              <fun>
                <arg value=""ReadText"" con=""mem"">
                  <arg value=""s"" con=""var"" />
                </arg>
              </fun>
              <params />
            </arg>
          </params>
        </arg>
      </usefun_s>
    </deffun>
    <deffun funname=""Mainad"" params=""aargs"" isref=""False"">
      <var_s varname=""stackflat"" str=""var stackflat = StackFlat(&quot;sf&quot;);"" />
      <getres_s str=""var stackflat = StackFlat(&quot;sf&quot;);"">
        <arg value=""stackflat"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""StackFlat"" con=""var"" />
          </fun>
          <params>
            <arg value=""sf"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <var_s varname=""tip1"" str=""var tip1 = Tip(&quot;tip1&quot;);"" />
      <getres_s str=""var tip1 = Tip(&quot;tip1&quot;);"">
        <arg value=""tip1"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Tip"" con=""var"" />
          </fun>
          <params>
            <arg value=""tip1"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <getres_s str=""tip1:Text = &quot;tip1&quot;;"">
        <arg value=""Text"" con=""mem"">
          <arg value=""tip1"" con=""var"" />
        </arg>
        <arg value=""tip1"" con=""str"" />
      </getres_s>
      <var_s varname=""tip2"" str=""var tip2 = Tip(&quot;tip2&quot;);"" />
      <getres_s str=""var tip2 = Tip(&quot;tip2&quot;);"">
        <arg value=""tip2"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Tip"" con=""var"" />
          </fun>
          <params>
            <arg value=""tip2"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <getres_s str=""tip2:Text = &quot;tip2&quot;;"">
        <arg value=""Text"" con=""mem"">
          <arg value=""tip2"" con=""var"" />
        </arg>
        <arg value=""tip2"" con=""str"" />
      </getres_s>
      <usefun_s str=""stackflat:Add(tip1);"">
        <arg con=""fun"">
          <fun>
            <arg value=""Add"" con=""mem"">
              <arg value=""stackflat"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""tip1"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""stackflat:Add(tip2);"">
        <arg con=""fun"">
          <fun>
            <arg value=""Add"" con=""mem"">
              <arg value=""stackflat"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""tip2"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <getres_s str=""stackflat:Orientation = &quot;horizontal&quot;;"">
        <arg value=""Orientation"" con=""mem"">
          <arg value=""stackflat"" con=""var"" />
        </arg>
        <arg value=""horizontal"" con=""str"" />
      </getres_s>
      <var_s varname=""page"" str=""var page = Page(&quot;title&quot;);"" />
      <getres_s str=""var page = Page(&quot;title&quot;);"">
        <arg value=""page"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Page"" con=""var"" />
          </fun>
          <params>
            <arg value=""title"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""page:SetContent(stackflat);"">
        <arg con=""fun"">
          <fun>
            <arg value=""SetContent"" con=""mem"">
              <arg value=""page"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""stackflat"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""PageLoad(page);"">
        <arg con=""fun"">
          <fun>
            <arg value=""PageLoad"" con=""var"" />
          </fun>
          <params>
            <arg value=""page"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""WriteLine(stackflat);"">
        <arg con=""fun"">
          <fun>
            <arg value=""WriteLine"" con=""var"" />
          </fun>
          <params>
            <arg value=""stackflat"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
    <deffun funname=""Mainss"" params=""args"" isref=""False"">
      <var_s varname=""file"" str=""var file = FileOpen(&quot;X:\\projects\\freestudio\\App1\\App1.gca&quot;,&quot;open&quot;);"" />
      <getres_s str=""var file = FileOpen(&quot;X:\\projects\\freestudio\\App1\\App1.gca&quot;,&quot;open&quot;);"">
        <arg value=""file"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""FileOpen"" con=""var"" />
          </fun>
          <params>
            <arg value=""X:\projects\freestudio\App1\App1.gca"" con=""str"" />
            <arg value=""open"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <var_s varname=""xml"" str=""var xml = XmlDocument();"" />
      <getres_s str=""var xml = XmlDocument();"">
        <arg value=""xml"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""XmlDocument"" con=""var"" />
          </fun>
          <params />
        </arg>
      </getres_s>
      <usefun_s str=""WriteLine(xml);"">
        <arg con=""fun"">
          <fun>
            <arg value=""WriteLine"" con=""var"" />
          </fun>
          <params>
            <arg value=""xml"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""xml:Load(file);"">
        <arg con=""fun"">
          <fun>
            <arg value=""Load"" con=""mem"">
              <arg value=""xml"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""file"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""file:Close();"">
        <arg con=""fun"">
          <fun>
            <arg value=""Close"" con=""mem"">
              <arg value=""file"" con=""var"" />
            </arg>
          </fun>
          <params />
        </arg>
      </usefun_s>
      <usefun_s str=""xml:Content:SetAttribute(&quot;text&quot;,&quot;helloworld&quot;);"">
        <arg con=""fun"">
          <fun>
            <arg value=""SetAttribute"" con=""mem"">
              <arg value=""Content"" con=""mem"">
                <arg value=""xml"" con=""var"" />
              </arg>
            </arg>
          </fun>
          <params>
            <arg value=""text"" con=""str"" />
            <arg value=""helloworld"" con=""str"" />
          </params>
        </arg>
      </usefun_s>
      <var_s varname=""child1"" str=""var child1 = xml:Content:GetChild(0);"" />
      <getres_s str=""var child1 = xml:Content:GetChild(0);"">
        <arg value=""child1"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""GetChild"" con=""mem"">
              <arg value=""Content"" con=""mem"">
                <arg value=""xml"" con=""var"" />
              </arg>
            </arg>
          </fun>
          <params>
            <arg value=""0"" con=""num"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""xml:Content:RemoveChild(child1);"">
        <arg con=""fun"">
          <fun>
            <arg value=""RemoveChild"" con=""mem"">
              <arg value=""Content"" con=""mem"">
                <arg value=""xml"" con=""var"" />
              </arg>
            </arg>
          </fun>
          <params>
            <arg value=""child1"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""xml:Save(FileOpen(&quot;X:\\projects\\freestudio\\App1\\App1.gca&quot;,&quot;creat&quot;));"">
        <arg con=""fun"">
          <fun>
            <arg value=""Save"" con=""mem"">
              <arg value=""xml"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg con=""fun"">
              <fun>
                <arg value=""FileOpen"" con=""var"" />
              </fun>
              <params>
                <arg value=""X:\projects\freestudio\App1\App1.gca"" con=""str"" />
                <arg value=""creat"" con=""str"" />
              </params>
            </arg>
          </params>
        </arg>
      </usefun_s>
    </deffun>
    <deffun funname=""Mains"" params=""args"" isref=""False"">
      <var_s varname=""page"" str=""var page = Page(&quot;page&quot;);"" />
      <getres_s str=""var page = Page(&quot;page&quot;);"">
        <arg value=""page"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Page"" con=""var"" />
          </fun>
          <params>
            <arg value=""page"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""page:AddTool(&quot;click&quot;,Click);"">
        <arg con=""fun"">
          <fun>
            <arg value=""AddTool"" con=""mem"">
              <arg value=""page"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""click"" con=""str"" />
            <arg value=""Click"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <getres_s str=""web  = WebView(&quot;wb&quot;);"">
        <arg value=""web"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""WebView"" con=""var"" />
          </fun>
          <params>
            <arg value=""wb"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <getres_s str=""web:Url = &quot;\\\\Mac\Home\Downloads\codemirror-5.59.1\gasoline\zzzz.html&quot;;"">
        <arg value=""Url"" con=""mem"">
          <arg value=""web"" con=""var"" />
        </arg>
        <arg value=""\\Mac\Home\Downloads\codemirror-5.59.1\gasoline\zzzz.html"" con=""str"" />
      </getres_s>
      <getres_s str=""web:Margin = List(0,100,0,0);"">
        <arg value=""Margin"" con=""mem"">
          <arg value=""web"" con=""var"" />
        </arg>
        <arg con=""fun"">
          <fun>
            <arg value=""List"" con=""var"" />
          </fun>
          <params>
            <arg value=""0"" con=""num"" />
            <arg value=""100"" con=""num"" />
            <arg value=""0"" con=""num"" />
            <arg value=""0"" con=""num"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""page:SetContent(web);"">
        <arg con=""fun"">
          <fun>
            <arg value=""SetContent"" con=""mem"">
              <arg value=""page"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""web"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""PageLoad(page);"">
        <arg con=""fun"">
          <fun>
            <arg value=""PageLoad"" con=""var"" />
          </fun>
          <params>
            <arg value=""page"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
      <usefun_s str=""WriteLine(web);"">
        <arg con=""fun"">
          <fun>
            <arg value=""WriteLine"" con=""var"" />
          </fun>
          <params>
            <arg value=""web"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
    <deffun funname=""Click"" params=""page,e"" isref=""False"">
      <usefun_s str=""web:InvokeJS(&quot;setValue&quot;,&quot;ok&quot;);"">
        <arg con=""fun"">
          <fun>
            <arg value=""InvokeJS"" con=""mem"">
              <arg value=""web"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""setValue"" con=""str"" />
            <arg value=""ok"" con=""str"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
  </lib>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("UWP_Xamarin");
            LoadApplication(new GTXAM.App());
        }

    }
}
