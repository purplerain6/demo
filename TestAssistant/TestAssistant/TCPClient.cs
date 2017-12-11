using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    //客户端
    public class TCPClient
    {
        public TcpClient client;//客户端
        private Thread client_th;//接收信息线程
        //绑定IP和端口
        public void Bind(string IP, string PORT)
        {
            connect_s(IP, PORT);//连接到服务器
        }
        //连接到服务器
        public void connect_s(string ip, string port)
        {
            client = new TcpClient(ip, Convert.ToInt32(port));//客户端信息
            //获取本地主机IP与本地端口
            string ip_port = client.Client.LocalEndPoint.ToString();
            string IP = ip_port.Substring(0, ip_port.IndexOf(":"));
            string PORT = ip_port.Substring(ip_port.IndexOf(":") + 1);
            //界面显示
            //Form1.mainForm.settbRemoteIP(IP);
           //Form1.mainForm.settbRemotePort(PORT);
            //获取客户端发送用的IP和端口
            //  Console.WriteLine(client.Client.LocalEndPoint.ToString());
            //开启接收信息线程
            ThreadStart threadStart = new ThreadStart(AcceptMsg);
            client_th = new Thread(threadStart);
            client_th.Start();
        }
        //接收信息线程
        private void AcceptMsg()
        {
            NetworkStream ns = client.GetStream();//获取接收流
            //字组处理
            while (true)
            {
                try
                {
                    string message = "";
                    byte[] bytes = new byte[1024];
                    int bytesread = ns.Read(bytes, 0, bytes.Length);//写入bytes数组
                   // if (Form1.mainForm.getCheckbox1().Checked)
                    {
                        //ASCzhuan 16jinzhi 多余的加0补齐
                        for (int i = 0; i < bytesread; i++)
                        {
                            if (bytes[i].ToString("X2").Length == 1)
                                message += "0" + bytes[i].ToString("X2");
                            else
                                message += bytes[i].ToString("X2");
                        }
                        //将接收到的十六进制数据两个一组加空格
                        message = Regex.Replace(message, @".{2}", "$0 ");
                    }
                   // else
                    {
                        message = Encoding.Default.GetString(bytes, 0, bytesread);
                    }
                    //显示
                    //Form1.mainForm.showMessage(message);
                    ns.Flush();
                    ////ns.Close();
                    //监听断开的客户端
                    if (client.Client.Poll(-1, SelectMode.SelectRead))
                    {
                        int nRead = client.Available;
                        if (nRead == 0)
                        {
                            //socket连接已断开
                            MessageBox.Show("远程服务器断开了连接");
                            //Form1.mainForm.setCobobox();
                            //Form1.mainForm.setButton("连接");
                            break;
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("与服务器断开连接了");
                    break;
                }
            }
        }
        //发送数据
        public void Send(string ip, string port, string msg)
        {
            try
            {
                if (client == null)
                    return;
                NetworkStream sendStream = client.GetStream();//获取发送流
                Byte[] sendBytes = Encoding.Default.GetBytes(msg);
                sendStream.Write(sendBytes, 0, sendBytes.Length);//发送数据
                sendStream.Flush();
                ////sendStream.Close();
            }
            catch
            {
                MessageBox.Show("远程服务器断开了连接");
            }
        }
        //关闭客户端
        public void close()
        {
            //关闭客户端和线程
            if (client != null)
            {
                client.Close();
                client_th.Abort();
            }
        }
        /// <summary>
        /// 十六进制发送
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="msg"></param>
        public void sendbyHEX(string ip, string port, string msg)
        {
            try
            {
                //sendStream.Close();
                msg = msg.ToUpper(); //.ToUpper将文本中的小写先转成大写              
                string[] b = msg.Split(' ');//建一个数组以空格为界分开
                for (int i = 0; i < b.Length; i++)
                {
                    if (client == null)
                        return;
                    NetworkStream sendStream = client.GetStream();//获取发送流
                    // Byte[] sendBytes = Encoding.Default.GetBytes(msg);
                    msg = b[i];
                    if (msg.Length % 2 != 0)//判断奇偶性
                    {
                        msg = msg.Substring(0, msg.Length - 1) + "0" + msg.Substring(msg.Length - 1);
                    }
                    byte[] send = HEXstring_to_bytys(msg);//将字符串转换为字节数组
                    sendStream.Write(send, 0, send.Length);//发送数据
                    sendStream.Flush();
                }
            }
            catch
            {
                MessageBox.Show("远程服务器断开了连接");
            }
        }
        /// <summary>
        /// 十六进制字符串转字节数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private byte[] HEXstring_to_bytys(string str)
        {
            String str1 = "0123456789ABCDEF";
            char[] hexs = str.ToCharArray();//将字符串转换为字符数组;
            byte[] bytes;
            bytes = new byte[str.Length / 2];
            int n;
            for (int i = 0; i < bytes.Length; i++)
            {
                n = str1.IndexOf(hexs[2 * i]) * 16;
                n += str1.IndexOf(hexs[2 * i + 1]);
                bytes[i] = (byte)(n & 0xff);
            }
            return bytes;
        }
    }
}
