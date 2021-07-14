using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GI
{
    class Udpsend
    {
        
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private static void SendMessage(object obj)
        {
            try
            {
                string message = (string)obj;
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
