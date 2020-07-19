using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GI
{
    partial class Lib
    {
        public class Socket_Lib : ILib
        {
            public Socket_Lib()
            {
                myThing.Add("HttpGet",new Variable( new Socket_Function_HttpGet()));
                myThing.Add("HttpPost",new Variable( new Socket_Function_HttpPost()));
                
            }


            public class Socket_Function_HttpGet : Function
            {
                public Socket_Function_HttpGet()
                {
                    IInformation = "httpget methord.";
                    str_xcname = "url,param";
                }
                public override object Run(Hashtable xc)
                {
                    string url = Variable.GetTrueVariable<object>(xc, "url").ToString();
                    string param = Variable.GetTrueVariable<object>(xc, "param").ToString();
                    string res = HttpGet(url, param);
                    return new Variable(res);
                }

                public static string HttpGet(string Url, string postDataStr)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                    request.Method = "GET";
                    request.ContentType = "text/html;charset=UTF-8";

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    return retString;
                }
            }

            public class Socket_Function_HttpPost : Function
            {
                public Socket_Function_HttpPost()
                {
                    IInformation = "httppost methord";
                    str_xcname = "url,param";
                }
                public override object Run(Hashtable xc)
                {
                    string url = Variable.GetTrueVariable<object>(xc, "url").ToString();
                    string param = Variable.GetTrueVariable<object>(xc, "param").ToString();
                    string res = HttpPost(url, param);
                    return new Variable(res);
                }

                private static string HttpPost(string Url, string postDataStr)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                    //request.CookieContainer = cookie;
                    Stream myRequestStream = request.GetRequestStream();
                    StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
                    myStreamWriter.Write(postDataStr);
                    myStreamWriter.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    //response.Cookies = cookie.GetCookies(response.ResponseUri);
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();

                    return retString;
                }
            }

            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }
    }
}
