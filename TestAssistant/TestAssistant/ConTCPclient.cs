using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestAssistant
{
    /// <summary>
    /// 连接的客户端
    /// </summary>
    public class ConTCPclient
    {
        public TcpClient TcpClient;// 连接的客户端对象
        public string rev;//接收缓冲区
        public string ip;// IP
        public string port;//端口
        public ConTCPclient(TcpClient TcpClient)
        {
            this.TcpClient = TcpClient;
            string ip_port = TcpClient.Client.RemoteEndPoint.ToString();
            this.ip = ip_port.Substring(0, ip_port.IndexOf(":"));
            this.port = ip_port.Substring(ip_port.IndexOf(":") + 1);
        }
        public void RecirveMessage(string msg)
        {
            rev += msg;
        }
        
    }
}
