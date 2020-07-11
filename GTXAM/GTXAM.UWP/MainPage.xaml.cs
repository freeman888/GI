using System.Xml;

namespace GTXAM.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<code minversion=""1902"">
  <get value=""IO"" />
  <get value=""Page"" />
  <get value=""Control"" />
  <get value=""List"" />
  <get value=""String"" />
  <get value=""Socket"" />
  <get value=""System"" />
  <var value=""chatting"" />
  <deffun funname=""Main"" params=""args"" isref=""False"">
    <var_s varname=""page"" str=""var page = GetMainPage();"" />
    <getres_s str=""var page = GetMainPage();"">
      <arg value=""page"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""GetMainPage"" con=""var"" />
        </fun>
        <params />
      </arg>
    </getres_s>
    <usefun_s str=""Page.AddTool(page,&quot;Writer&quot;,WriterClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.AddTool"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
          <arg value=""Writer"" con=""str"" />
          <arg value=""WriterClick"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""Page.AddTool(page,&quot;Help&quot; ,HelpClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.AddTool"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
          <arg value=""Help"" con=""str"" />
          <arg value=""HelpClick"" con=""var"" />
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
  </deffun>
  <deffun funname=""HelpClick"" params=""page,e"" isref=""False"">
    <usefun_s str=""IO.Tip(&quot;This is a app that is used to show an example of gasoline.If you want more help,you can go to our website for more.\nhttp//www.gasoline.ccaeo.com&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Tip"" con=""var"" />
        </fun>
        <params>
          <arg value=""This is a app that is used to show an example of gasoline.If you want more help,you can go to our website for more.&#xA;http//www.gasoline.ccaeo.com"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""WriterClick"" params=""page,e"" isref=""False"">
    <usefun_s str=""IO.Tip(&quot;Freeman!!! Best Freeman!!!&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Tip"" con=""var"" />
        </fun>
        <params>
          <arg value=""Freeman!!! Best Freeman!!!"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""GetMainPage"" params="""" isref=""False"">
    <var_s varname=""page"" str=""var page = Page.Creat(&quot;联系人&quot;);"" />
    <getres_s str=""var page = Page.Creat(&quot;联系人&quot;);"">
      <arg value=""page"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""联系人"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""grid"" str=""var grid = Control.GridFlat.Creat(&quot;main_gf&quot;);"" />
    <getres_s str=""var grid = Control.GridFlat.Creat(&quot;main_gf&quot;);"">
      <arg value=""grid"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.GridFlat.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""main_gf"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""grid(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""grid"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid(&quot;verticalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""grid"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid(&quot;backgroundcolor&quot;,&quot;azure&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""grid"" con=""var"" />
        </fun>
        <params>
          <arg value=""backgroundcolor"" con=""str"" />
          <arg value=""azure"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <var_s varname=""hfz_bubble"" str=""var hfz_bubble = Control.Bubble.Creat(&quot;hfz&quot;);"" />
    <getres_s str=""var hfz_bubble = Control.Bubble.Creat(&quot;hfz&quot;);"">
      <arg value=""hfz_bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""hfz"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""gblw_bubble"" str=""var gblw_bubble = Control.Bubble.Creat(&quot;gblw&quot;);"" />
    <getres_s str=""var gblw_bubble = Control.Bubble.Creat(&quot;gblw&quot;);"">
      <arg value=""gblw_bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""gblw"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""cxk_bubble"" str=""var cxk_bubble = Control.Bubble.Creat(&quot;cxk&quot;);"" />
    <getres_s str=""var cxk_bubble = Control.Bubble.Creat(&quot;cxk&quot;);"">
      <arg value=""cxk_bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""cxk"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""hlp_bubble"" str=""var hlp_bubble = Control.Bubble.Creat(&quot;hlp&quot;);"" />
    <getres_s str=""var hlp_bubble = Control.Bubble.Creat(&quot;hlp&quot;);"">
      <arg value=""hlp_bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""hlp"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""hfz_bubble(&quot;text&quot;,&quot;寒菲子&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hfz_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""寒菲子"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hfz_bubble(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hfz_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hfz_bubble(&quot;verticalalignment&quot;,&quot;top&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hfz_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""top"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hfz_bubble(&quot;margin&quot;,&quot;5,5,5,5&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hfz_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""margin"" con=""str"" />
          <arg value=""5,5,5,5"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hfz_bubble(&quot;clickevent&quot;,UserClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hfz_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""UserClick"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gblw_bubble(&quot;text&quot;,&quot;隔壁老王&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""gblw_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""隔壁老王"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gblw_bubble(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""gblw_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gblw_bubble(&quot;verticalalignment&quot;,&quot;top&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""gblw_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""top"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gblw_bubble(&quot;margin&quot;,&quot;5,55,5,5&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""gblw_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""margin"" con=""str"" />
          <arg value=""5,55,5,5"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gblw_bubble(&quot;clickevent&quot;,UserClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""gblw_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""UserClick"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""cxk_bubble(&quot;text&quot;,&quot;蔡徐坤&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""cxk_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""蔡徐坤"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""cxk_bubble(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""cxk_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""cxk_bubble(&quot;verticalalignment&quot;,&quot;top&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""cxk_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""top"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""cxk_bubble(&quot;margin&quot;,&quot;5,105,5,5&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""cxk_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""margin"" con=""str"" />
          <arg value=""5,105,5,5"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""cxk_bubble(&quot;clickevent&quot;,UserClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""cxk_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""UserClick"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hlp_bubble(&quot;text&quot;,&quot;何姐姐&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hlp_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""何姐姐"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hlp_bubble(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hlp_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hlp_bubble(&quot;verticalalignment&quot;,&quot;top&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hlp_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""top"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hlp_bubble(&quot;margin&quot;,&quot;5,155,5,5&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hlp_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""margin"" con=""str"" />
          <arg value=""5,155,5,5"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""hlp_bubble(&quot;clickevent&quot;,UserClick);"">
      <arg con=""fun"">
        <fun>
          <arg value=""hlp_bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""UserClick"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(hfz_bubble,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""hfz_bubble"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(gblw_bubble,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""gblw_bubble"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(cxk_bubble,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""cxk_bubble"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(hlp_bubble,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""hlp_bubble"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""page()(grid);"">
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
          <arg value=""grid"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <return_s str=""return (page);"">
      <arg value=""page"" con=""var"" />
    </return_s>
  </deffun>
  <deffun funname=""UserClick"" params=""page,args"" isref=""False"">
    <var_s varname=""bubble"" str=""var bubble = args(0);"" />
    <getres_s str=""var bubble = args(0);"">
      <arg value=""bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""args"" con=""var"" />
        </fun>
        <params>
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""userpage"" str=""var userpage = GetChattingPage(bubble(&quot;text&quot;));"" />
    <getres_s str=""var userpage = GetChattingPage(bubble(&quot;text&quot;));"">
      <arg value=""userpage"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""GetChattingPage"" con=""var"" />
        </fun>
        <params>
          <arg con=""fun"">
            <fun>
              <arg value=""bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""text"" con=""str"" />
            </params>
          </arg>
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""Page.Go(userpage);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Go"" con=""var"" />
        </fun>
        <params>
          <arg value=""userpage"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""GetChattingPage"" params=""name"" isref=""False"">
    <getres_s str=""chatting = name;"">
      <arg value=""chatting"" con=""var"" />
      <arg value=""name"" con=""var"" />
    </getres_s>
    <var_s varname=""root"" str=""var root  = Page.Creat(name);"" />
    <getres_s str=""var root  = Page.Creat(name);"">
      <arg value=""root"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""name"" con=""var"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""grid"" str=""var grid = Control.GridFlat.Creat(&quot;grid&quot;);"" />
    <getres_s str=""var grid = Control.GridFlat.Creat(&quot;grid&quot;);"">
      <arg value=""grid"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.GridFlat.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""grid"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""grid(&quot;backgroundcolor&quot;,&quot;azure&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""grid"" con=""var"" />
        </fun>
        <params>
          <arg value=""backgroundcolor"" con=""str"" />
          <arg value=""azure"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <var_s varname=""messages"" str=""var messages = Control.Tip.Creat(&quot;messages&quot;);"" />
    <getres_s str=""var messages = Control.Tip.Creat(&quot;messages&quot;);"">
      <arg value=""messages"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Tip.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""messages"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""edittext"" str=""var edittext = Control.EditText.Creat(&quot;edit&quot;);"" />
    <getres_s str=""var edittext = Control.EditText.Creat(&quot;edit&quot;);"">
      <arg value=""edittext"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.EditText.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""edit"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""button"" str=""var button = Control.Bubble.Creat(&quot;send&quot;);"" />
    <getres_s str=""var button = Control.Bubble.Creat(&quot;send&quot;);"">
      <arg value=""button"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""send"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""scrollflat"" str=""var scrollflat = Control.ScrollFlat.Creat(&quot;sf&quot;);"" />
    <getres_s str=""var scrollflat = Control.ScrollFlat.Creat(&quot;sf&quot;);"">
      <arg value=""scrollflat"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.ScrollFlat.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""sf"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""Control.GridFlat.SetRow(grid,&quot;1&quot;,&quot;rate&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Control.GridFlat.SetRow"" con=""var"" />
        </fun>
        <params>
          <arg value=""grid"" con=""var"" />
          <arg value=""1"" con=""str"" />
          <arg value=""rate"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""Control.GridFlat.SetRow(grid,&quot;55&quot;,&quot;value&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Control.GridFlat.SetRow"" con=""var"" />
        </fun>
        <params>
          <arg value=""grid"" con=""var"" />
          <arg value=""55"" con=""str"" />
          <arg value=""value"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""scrollflat(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""scrollflat"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""scrollflat(&quot;verticalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""scrollflat"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""scrollflat(&quot;margin&quot;,&quot;5,5,5,5&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""scrollflat"" con=""var"" />
        </fun>
        <params>
          <arg value=""margin"" con=""str"" />
          <arg value=""5,5,5,5"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""scrollflat(&quot;backgroundcolor&quot;,&quot;transparent&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""scrollflat"" con=""var"" />
        </fun>
        <params>
          <arg value=""backgroundcolor"" con=""str"" />
          <arg value=""transparent"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;horizontalalignment&quot;,&quot;right&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""right"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;height&quot;,40);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""height"" con=""str"" />
          <arg value=""40"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;width&quot;,40);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""width"" con=""str"" />
          <arg value=""40"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;fontsize&quot;,16);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""fontsize"" con=""str"" />
          <arg value=""16"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;text&quot;,&quot;▶&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""▶"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""button(&quot;clickevent&quot;,SentMessage);"">
      <arg con=""fun"">
        <fun>
          <arg value=""button"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""SentMessage"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""edittext(&quot;backgroundcolor&quot;,&quot;transparent&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""edittext"" con=""var"" />
        </fun>
        <params>
          <arg value=""backgroundcolor"" con=""str"" />
          <arg value=""transparent"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""edittext(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""edittext"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""edittext(&quot;height&quot;,55);"">
      <arg con=""fun"">
        <fun>
          <arg value=""edittext"" con=""var"" />
        </fun>
        <params>
          <arg value=""height"" con=""str"" />
          <arg value=""55"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""edittext(&quot;fontsize&quot;,24);"">
      <arg con=""fun"">
        <fun>
          <arg value=""edittext"" con=""var"" />
        </fun>
        <params>
          <arg value=""fontsize"" con=""str"" />
          <arg value=""24"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""messages(&quot;horizontalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""messages"" con=""var"" />
        </fun>
        <params>
          <arg value=""horizontalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""messages(&quot;verticalalignment&quot;,&quot;stretch&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""messages"" con=""var"" />
        </fun>
        <params>
          <arg value=""verticalalignment"" con=""str"" />
          <arg value=""stretch"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""messages(&quot;fontsize&quot;,20);"">
      <arg con=""fun"">
        <fun>
          <arg value=""messages"" con=""var"" />
        </fun>
        <params>
          <arg value=""fontsize"" con=""str"" />
          <arg value=""20"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""messages(&quot;text&quot;,name&amp;&quot;可想死你了&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""messages"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg value=""name"" con=""var"" />
              <arg value=""可想死你了"" con=""str"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(edittext,1,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""edittext"" con=""var"" />
          <arg value=""1"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(button,1,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""button"" con=""var"" />
          <arg value=""1"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""scrollflat()(messages);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""scrollflat"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""messages"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""grid()(scrollflat,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""grid"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""scrollflat"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""root()(grid);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""root"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""grid"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <return_s str=""return(root);"">
      <arg value=""root"" con=""var"" />
    </return_s>
  </deffun>
  <deffun funname=""SentMessage"" params=""page,arg"" isref=""False"">
    <var_s varname=""text"" str=""var text = page(&quot;edit&quot;)(&quot;text&quot;);"" />
    <getres_s str=""var text = page(&quot;edit&quot;)(&quot;text&quot;);"">
      <arg value=""text"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params>
              <arg value=""edit"" con=""str"" />
            </params>
          </arg>
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""page(&quot;edit&quot;)(&quot;text&quot;,&quot;&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params>
              <arg value=""edit"" con=""str"" />
            </params>
          </arg>
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value="""" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <var_s varname=""res"" str=""var res = Socket.HttpGet(&quot;http://i.itpk.cn/api.php?question=&quot;&amp;text,&quot;&quot;);"" />
    <getres_s str=""var res = Socket.HttpGet(&quot;http://i.itpk.cn/api.php?question=&quot;&amp;text,&quot;&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Socket.HttpGet"" con=""var"" />
        </fun>
        <params>
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg value=""http://i.itpk.cn/api.php?question="" con=""str"" />
              <arg value=""text"" con=""var"" />
            </params>
          </arg>
          <arg value="""" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[cqname]&quot;,chatting);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[cqname]"" con=""str"" />
          <arg value=""chatting"" con=""var"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[name]&quot;,&quot;你&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[name]"" con=""str"" />
          <arg value=""你"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[date]&quot;,System.GetTime(&quot;time&quot;));"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[date]"" con=""str"" />
          <arg con=""fun"">
            <fun>
              <arg value=""System.GetTime"" con=""var"" />
            </fun>
            <params>
              <arg value=""time"" con=""str"" />
            </params>
          </arg>
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[father]&quot;,&quot;Freeman&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[father]"" con=""str"" />
          <arg value=""Freeman"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[mother]&quot;,&quot;May&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[mother]"" con=""str"" />
          <arg value=""May"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[height]&quot;,&quot;170cm&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[height]"" con=""str"" />
          <arg value=""170cm"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[weight]&quot;,&quot;48kg&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[weight]"" con=""str"" />
          <arg value=""48kg"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[sex]&quot;,&quot;中性&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[sex]"" con=""str"" />
          <arg value=""中性"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[zodiac]&quot;,&quot;处女座&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[zodiac]"" con=""str"" />
          <arg value=""处女座"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[blood]&quot;,&quot;熊猫血&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[blood]"" con=""str"" />
          <arg value=""熊猫血"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[school]&quot;,&quot;文峰中学&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[school]"" con=""str"" />
          <arg value=""文峰中学"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[city1]&quot;,&quot;陇西&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[city1]"" con=""str"" />
          <arg value=""陇西"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <getres_s str=""res = String.Replace(res,&quot;[city2]&quot;,&quot;文峰&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""String.Replace"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
          <arg value=""[city2]"" con=""str"" />
          <arg value=""文峰"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""AddMessage(page,&quot;我 : &quot;&amp;text);"">
      <arg con=""fun"">
        <fun>
          <arg value=""AddMessage"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg value=""我 : "" con=""str"" />
              <arg value=""text"" con=""var"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""AddMessage(page,chatting&amp;&quot; : &quot;&amp;res);"">
      <arg con=""fun"">
        <fun>
          <arg value=""AddMessage"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""String.Add"" con=""var"" />
                </fun>
                <params>
                  <arg value=""chatting"" con=""var"" />
                  <arg value="" : "" con=""str"" />
                </params>
              </arg>
              <arg value=""res"" con=""var"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""AddMessage"" params=""page,mess"" isref=""False"">
    <usefun_s str=""page(&quot;messages&quot;)(&quot;text&quot;,page(&quot;messages&quot;)(&quot;text&quot;)&amp;&quot;\n&quot;&amp;mess);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params>
              <arg value=""messages"" con=""str"" />
            </params>
          </arg>
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg con=""fun"">
            <fun>
              <arg value=""String.Add"" con=""var"" />
            </fun>
            <params>
              <arg con=""fun"">
                <fun>
                  <arg value=""String.Add"" con=""var"" />
                </fun>
                <params>
                  <arg con=""fun"">
                    <fun>
                      <arg con=""fun"">
                        <fun>
                          <arg value=""page"" con=""var"" />
                        </fun>
                        <params>
                          <arg value=""messages"" con=""str"" />
                        </params>
                      </arg>
                    </fun>
                    <params>
                      <arg value=""text"" con=""str"" />
                    </params>
                  </arg>
                  <arg value=""&#xA;"" con=""str"" />
                </params>
              </arg>
              <arg value=""mess"" con=""var"" />
            </params>
          </arg>
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""page(&quot;sf&quot;)(&quot;scrollposition&quot;,&quot;end&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params>
              <arg value=""sf"" con=""str"" />
            </params>
          </arg>
        </fun>
        <params>
          <arg value=""scrollposition"" con=""str"" />
          <arg value=""end"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("UWP_Xamarin");
            LoadApplication(new GTXAM.App());
        }

    }
}
