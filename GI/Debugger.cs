using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GI
{

    class Debugger
    {
        public static void Chatwithclient(Dictionary<string, Variable> htxc)
        {
            var localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2590);
            SendMessage("[+]catch a breakpoint,use the command to control your app.send help to get the command help.");
            UdpClient udpcRecv = new UdpClient(localIpep);
            while (true)
            {


                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref localIpep);
                    string message = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
                    if (message == "help")
                    {
                        SendMessage("[+]show environment variables : sev\n" +
                            "[+]show loaded libs : sll\n" +
                            "[+]continue");
                    }
                    else if (message == "continue")
                        return;
                    else if (message == "sev")
                    {
                        ArrayList alt = new ArrayList(htxc.Keys);
                        alt.Sort();
                        foreach (string i in alt)
                            SendMessage(string.Format("[+] {0} \t\t\t\t\t\t\t{1}", i, ((Variable)htxc[i]).value.ToString()));

                        //foreach (DictionaryEntry i in htxc)
                        //    SendMessage("[+] " + i.Key + " : "+ ((Variable)i.Value ).value.ToString());
                    }
                    else if (message == "sll")
                    {
                        foreach (var i in Gasoline.libs)
                        {
                            SendMessage("[+] " + i.Key);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
        public static void SendMessage(string obj)
        {
            try
            {
                string message = obj;
                byte[] sendbytes = Encoding.Unicode.GetBytes(message);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2589); // 发送到的IP地址和端口号
                var udpcSend = new UdpClient();
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                udpcSend.Close();
            }
            catch { }
        }
    }

}
