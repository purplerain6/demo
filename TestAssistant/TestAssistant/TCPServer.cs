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
    //服务器
    public class TCPServer
    {
        //变量
        private ThreadStart start;
        private Thread listenThread;//监听连入客户端线程
        private Thread client_th;//接收信息线程
        static private bool m_bListening = false;//开启服务标志
        static private System.Net.IPAddress MyIP;//本机IP
        public TcpListener listener;//服务器
        public string[] rev = new string[100];//接收缓冲区
        public ConTCPclient[] clientArray = new ConTCPclient[100];//定义客户端数组存储客户端信息
        int clientNumber = 0;//记录已连接的客户数量
        //TcpClient client;//连入的客户端
        //string[] clientgroup = new string[50];//
        //开启服务器
        public void Bind(string ip, string port)
        {
            //绑定IP和端口
            MyIP = System.Net.IPAddress.Parse(ip);
            listener = new TcpListener(MyIP, Convert.ToInt32(port));
            listener.Start(); //打开服务器
            //开启监听客户端线程
            start = new ThreadStart(startListen);
            listenThread = new Thread(start);
            m_bListening = true;
            listenThread.Start();
        }
        //监听连入客户端线程
        private void startListen()
        {
            //接收数据
            //while (listener.Pending())
            while (m_bListening)
            {
                //测试是否有数据
                try
                {
                    TcpClient client = listener.AcceptTcpClient();//连入的客户端

                    //TcpClient client = listener.AcceptTcpClient();
                    ClientConnected(client.Client.RemoteEndPoint.ToString());

                    clientArray[clientNumber] = new ConTCPclient(client);
                    clientNumber++;//记录连接的客户端数量
                    //开启接收信息线程
                    ParameterizedThreadStart threadStart = new ParameterizedThreadStart(AcceptMsg);
                    client_th = new Thread(threadStart);
                    client_th.Start(client);
                }
                // catch
                catch (Exception re)
                {
                    Console.Write(re.ToString());

                }

            }
            //listener.Stop();        
        }


        /// <summary>  
        ///接收信息线程
        /// </summary>  
        private void AcceptMsg(object arg)
        {
            TcpClient client_ins = (TcpClient)arg;//获取连接的客户端，方便获取断开连接的情况
            NetworkStream ns = client_ins.GetStream();//获取客户端发送的字节流
            //StreamReader sr = new StreamReader(ns);//流读写器
            //字组处理
            while (m_bListening)
            {
                //if (client == null || client.Available < 1)
                //{
                //  //  clientNumber = 0;
                //    Thread.Sleep(200);
                //    continue;
                //}
                try
                {
                    string message = "";
                    byte[] bytes = new byte[1024];
                    int bytesread = ns.Read(bytes, 0, bytes.Length);//写入bytes数组
                    //if (Form1.mainForm.getCheckbox1().Checked)
                    {

                        //ASCzhuan 16jinzhi 多余的加0补齐
                        for (int i = 0; i < bytesread; i++)
                        {
                            //if (bytes[i].ToString("X2").Length == 1)
                            //    message += "0" + bytes[i].ToString("X2");
                            //else
                            message += bytes[i].ToString("X2");
                        }
                        //将接收到的十六进制数据两个一组加空格
                        RecieveMsg(client_ins, message);
                        Mainform.mainForm.orderform.starthandle(client_ins.Client.RemoteEndPoint.ToString(),message);
                        string Regexmessage = Regex.Replace(message, @".{2}", "$0 ");
                        //显示
                        Console.WriteLine(client_ins.Client.RemoteEndPoint.ToString() + "   " + Regexmessage);
                    }
                    //else
                    //{
                    //    message = Encoding.Default.GetString(bytes, 0, bytesread);
                    //}
                    //Form1.mainForm.showMessage(message);
                    ns.Flush();
                    //ns.Close();            
                    //监听断开的客户端
                    if (client_ins.Client.Poll(-1, SelectMode.SelectRead))
                    {
                        int nRead = client_ins.Available;
                        if (nRead == 0)
                        {
                            //socket连接已断开
                            remove(client_ins);
                            //MessageBox.Show("客户端断开连接了");
                            ClientDisconnected(client_ins.Client.RemoteEndPoint.ToString());
                            break;
                        }
                    }
                }
                // catch
                catch (Exception re)
                {
                    Console.Write(re.ToString());
                    break;
                }
            }
        }

       
        /// <summary>
        /// 连接的客户端接收信息
        /// </summary>
        /// <param name="client_ins"></param>
        /// <param name="message"></param>
        private void RecieveMsg(TcpClient client_ins, string message)
        {
            for (int i = 0; i < clientNumber; i++)
            {
                if (clientArray[i].TcpClient == client_ins)
                    clientArray[i].RecirveMessage(message);
            }
        }


        //发送信息
        public void Send(string msg, string IP_PORT)
        {
            //检测是否有连入的客户端
            if (clientNumber == 0)
            {
                MessageBox.Show("没有连接的客户端！");
                return;
            }

            //  for (int i = 0; i < clientNumber; i++)
            {
                //if (clientArray[i] != null)
                {
                    TcpClient client = getClient(IP_PORT);
                    if (client == null)
                        return;
                    NetworkStream sendStream = client.GetStream();//获取发送数据流                   
                    //Byte[] sendBytes = Encoding.Default.GetBytes(msg);发送字符串
                    byte[] sendBytes = HEXstring_to_bytys(msg);//发送16进制
                    sendStream.Write(sendBytes, 0, sendBytes.Length);//发送数据
                    sendStream.Flush();
                    //sendStream.Close();
                }
            }
        }

        /// <summary>
        /// 获取对应IP&端口对应的客户端对象
        /// </summary>
        /// <param name="IP_PORT"></param>
        /// <returns></returns>
        private TcpClient getClient(string IP_PORT)
        {
            for (int i = 0; i < clientNumber; i++)
            {
                if (clientArray[i].TcpClient.Client.RemoteEndPoint.ToString().Equals(IP_PORT))
                {
                    return clientArray[i].TcpClient;
                }
            }
            return null;
        }
        //关闭服务器
        public void close()
        {
            if (listener != null)
            {
                //关闭服务器
                m_bListening = false;
                listener.Server.Close();
                listener.Stop();
                listener = null;
                //关闭线程
                if (client_th != null)
                    client_th.Abort();
                listenThread.Abort();
                //清空客户端信息
                for (int i = 0; i < clientNumber; i++)
                {
                    if (clientArray[i] != null)
                        clientArray[i].TcpClient.Close();
                }
                clientNumber = 0;
                //Mainform.mainForm.frockform.setDisconnected();
            }
        }
        /// <summary>
        /// 十六进制发送
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="IP_PORT"></param>
        public void sendbyHEX(string msg, string IP_PORT)
        { //检测是否有连入的客户端
            if (clientNumber == 0)
            {
                MessageBox.Show("没有连接的客户端！");
                return;
            }
            msg = msg.ToUpper().Replace(" ", ""); //.ToUpper将文本中的小写先转成大写              
            //string[] b = msg.Split(' ');//建一个数组以空格为界分开
            //for (int i = 0; i < b.Length; i++)
            {
                TcpClient client = getClient(IP_PORT);
                if (client == null)
                    return;
                NetworkStream sendStream = client.GetStream();//获取发送流
                // Byte[] sendBytes = Encoding.Default.GetBytes(msg);
                //msg = b[i];
                if (msg.Length % 2 != 0)//判断奇偶性
                {
                    msg = msg.Substring(0, msg.Length - 1) + "0" + msg.Substring(msg.Length - 1);
                }
                byte[] send = HEXstring_to_bytys(msg);//将字符串转换为字节数组
                sendStream.Write(send, 0, send.Length);//发送数据
                sendStream.Flush();
            }
        }
       /// <summary>
       /// 获取客户端IP&端口列表
       /// </summary>
       /// <returns></returns>
        public string[] getClientList()
        {
            string[] list = new string[clientNumber];
            for (int i = 0; i < clientNumber; i++)
            {
                list[i] = clientArray[i].TcpClient.Client.RemoteEndPoint.ToString();
            }
            return list;
        }

        /// <summary>
        /// 从客户端列表中移除
        /// </summary>
        /// <param name="client_ins"></param>
        private void remove(TcpClient client_ins)
        {
            for (int i = 0; i < clientNumber; i++)
            {
                if (clientArray[i].TcpClient.Client.RemoteEndPoint.ToString().Equals(client_ins.Client.RemoteEndPoint.ToString()))
                {
                    clientArray[i] = clientArray[clientNumber - 1];
                    clientArray[clientNumber - 1] = null;
                    clientNumber--;
                }
            }
        }

        /// <summary>
        /// 客户端建立连接
        /// </summary>
        /// <param name="ip_port"></param>
        private void ClientConnected(string ip_port)
        {
            Console.WriteLine(ip_port);//获取客户端发送用的IP和端口
            //Mainform.mainForm.frockform.preparefrock(ip_port);
           //Mainform.mainForm.frockform.LoadFrockToList();
            //Mainform.mainForm.LoadFrock();
            Mainform.mainForm.ResetCB();
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="ip_port"></param>
        private void ClientDisconnected(string ip_port)
        {
            Console.WriteLine(ip_port + "断开连接");//获取客户端发送用的IP和端口
            //Mainform.mainForm.frockform.crackFrock(ip_port);
            //Mainform.mainForm.frockform.LoadFrockToList();
            Mainform.mainForm.orderform.crackOrder(ip_port);
            Mainform.mainForm.orderform.LoadOrderToList();
            //Mainform.mainForm.LoadFrock();
            string orderno = Mainform.mainForm.orderform.getcrackOrderNO(ip_port);
            if (!orderno.Equals("null"))
            {
                Mainform.mainForm.orderform.getOrderByNO(orderno).stopThresad();
                Mainform.mainForm.ClearLV_frock(orderno);
            }
            //Mainform.mainForm.frockform.addfrockform.resetCB();
            Mainform.mainForm.ResetCB();
        }

        /// <summary>
        /// 清空指定IP&端口客户端的缓冲区
        /// </summary>
        /// <param name="frockip_port"></param>
        /// <returns></returns>
        public bool EmptyRev(string frockip_port)
        {
           // string ip_port = Mainform.mainForm.frockform.getFrockIP_PORTByFrockname(frock);
            int clientnum = -1;
            for (int i = 0; i < clientNumber; i++)
            {
                if (frockip_port.Equals(clientArray[i].ip + ":" + clientArray[i].port))
                {
                    clientnum = i;
                    clientArray[i].rev = "";
                    break;
                }
            }
            if (clientnum == -1)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 获取对应IP客户端缓冲区
        /// </summary>
        /// <param name="frockip"></param>
        /// <returns></returns>
        public string getClientRev(string frockip)
        {
            //string ip_port = Mainform.mainForm.frockform.getFrockIP_PORTByFrockname(frock);
            for (int i = 0; i < clientNumber; i++)
            {
                if (frockip.Equals(clientArray[i].ip + ":" + clientArray[i].port))
                {
                    return clientArray[i].rev;
                }
            }
            return "";
        }
        
        /// <summary>
        /// 生成校验和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        String makeChecksum(String data)
        {
            int total = 0;
            int len = data.Length;
            int num = 0;
            while (num < len)
            {
                String s = data.Substring(num, 2);
                total += Convert.ToInt32(s, 16);
                num = num + 2;
            }
            /**
             * 用256求余最大是255，即16进制的FF
             */
            int mod = total % 256;
            String hex = mod.ToString("X2");
            hex = hex.ToUpper();
            return hex;
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
