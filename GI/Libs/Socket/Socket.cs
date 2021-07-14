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
                myThing.Add("HttpDownload", new Variable(new Socket_Function_HttpDownload()));
                
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

            public class Socket_Function_HttpDownload:Function
            {
                public Socket_Function_HttpDownload()
                {
                    str_xcname = "url,stream";
                    IInformation = "download file from url to stream";
                }
                public override object Run(Hashtable xc)
                {
                    string url = xc.GetCSVariable<object>("url").ToString();
                    Stream stream = xc.GetCSVariableFromSpeType<System.IO.Stream>("stream", "stream");
                    HttpDownloadFile(url, stream);
                    return new Variable(0);
                }
                /// <summary>

                /// Http下载文件

                /// </summary>

                public static void HttpDownloadFile(string url, Stream stream)

                {

                    // 设置参数

                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //发送请求并获取相应回应数据

                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                    //直到request.GetResponse()程序才开始向目标网页发送Post请求

                    Stream responseStream = response.GetResponseStream();
                    //创建本地文件写入流

                    
                    byte[] bArr = new byte[1024];

                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);

                    while (size > 0)

                    {

                        stream.Write(bArr, 0, size);

                        size = responseStream.Read(bArr, 0, (int)bArr.Length);

                    }


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
