using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAssistant;

namespace TestAssistant
{
    public partial class Com_form : Form
    {
        
        public Com_form()
        {
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (bt_connect.Text == "连接")
            {
                //检测ip是否合法
                string ip = tb_IP.Text;
                int ipchecknum = ipCHECK(ip);
                if (ipchecknum == 0)
                {
                    MessageBox.Show("IP地址为空！", "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ipchecknum == -1)
                {
                    MessageBox.Show("IP地址不合法！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //检测端口是否被占用(随机端口发送时不用验证)
                string port = tb_port.Text;
                //if (!checkBox3.Checked)//指定端口发送
                {
                    try
                    {
                        Convert.ToInt32(port);
                    }
                    catch
                    {
                        MessageBox.Show("端口不合法！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (IsUsedIPEndPoint(Convert.ToInt32(port), 2))
                {
                     MessageBox.Show("端口被占用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool result = pingTest(ip);
                if (!result)
                {
                    MessageBox.Show("建立服务器连接失败！请检查IP是否为本机使用IP", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //TCP Server
                try
                {
                    //绑定网络地
                    Mainform.mainForm.getserver().Bind(ip, port);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    MessageBox.Show("建立服务器连接失败！请检查IP与端口是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //状态栏显示状态
                tb_IP.Enabled = tb_port.Enabled = false;
                Mainform.mainForm.gettsl_connect().Text = "服务器IP：" + tb_IP.Text + ":" + tb_port.Text;
                bt_connect.Text = "断开";
                this.Hide();
            }
            else
            {
                Mainform.mainForm.getserver().close();
                tb_IP.Enabled = tb_port.Enabled = true;
                bt_connect.Text = "连接";
                Mainform.mainForm.gettsl_connect().Text = "未连接";
            }
        }

        private bool pingTest(string ip)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip, 120);//第一个参数为ip地址，第二个参数为ping的时间 
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        //检测ip是否合法方法
        private int ipCHECK(string p)
        {
            //检查IP是否合法
            string ip = p;
            //string ip = tbLocalIP.Text;
            if (ip.Equals(""))
            {
                //MessageBox.Show("IP地址为空！");
                return 0;
            }
            Regex rx = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            if (!rx.IsMatch(ip))
            {
                //MessageBox.Show("IP地址不合法！");
                return -1;
            }
            return 1;
        }
        /// <summary>  
        /// 判断指定的网络端点（只判断端口）是否被使用  
        /// </summary>  
        public bool IsUsedIPEndPoint(int port, int protocol)
        {
            if (protocol == 1)
            {
                foreach (IPEndPoint iep in GetUsedIPEndPoint_udp())
                {
                    if (iep.Port == port)
                    {
                        return true;
                    }
                }
                return false;
            }
            if (protocol == 2)
            {
                foreach (IPEndPoint iep in GetUsedIPEndPoint_tcpServer())
                {
                    if (iep.Port == port)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        /// <summary>  
        /// 获取本机已被使用的TCP服务器网络端点  
        /// </summary>  
        public IList<IPEndPoint> GetUsedIPEndPoint_tcpServer()
        {
            //获取一个对象，该对象提供有关本地计算机的网络连接和通信统计数据的信息。  
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            //获取有关本地计算机上的 Internet 协议版本 4 (IPV4) 传输控制协议 (TCP) 侦听器的终结点信息。  
            IPEndPoint[] ipEndPointTCP = ipGlobalProperties.GetActiveTcpListeners();
            IList<IPEndPoint> allIPEndPoint = new List<IPEndPoint>();
            foreach (IPEndPoint iep in ipEndPointTCP) allIPEndPoint.Add(iep);
            return allIPEndPoint;
        }

        /// <summary>  
        /// 获取本机已被使用的UDP网络端点  
        /// </summary>  
        public IList<IPEndPoint> GetUsedIPEndPoint_udp()
        {
            //获取一个对象，该对象提供有关本地计算机的网络连接和通信统计数据的信息。  
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            //获取有关本地计算机上的 Internet 协议版本 4 (IPv4) 用户数据报协议 (UDP) 侦听器的信息。  
            IPEndPoint[] ipEndPointUDP = ipGlobalProperties.GetActiveUdpListeners();
            IList<IPEndPoint> allIPEndPoint = new List<IPEndPoint>();
            foreach (IPEndPoint iep in ipEndPointUDP) allIPEndPoint.Add(iep);
            return allIPEndPoint;
        }
        public void sellocalIP()
        {
            tb_IP.Text = getIPAddress();
        }
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public string getIPAddress()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
        /// <summary>
        /// 设置本机IP
        /// </summary>
        /// <param name="p"></param>
    
        public void setLocolIP(string p)
        {
            tb_IP.Text = p;
        }
        public void setLocolport(string p)
        {
            tb_port.Text = p;
        }
        /// <summary>
        /// 获取本机IP框值
        /// </summary>
        /// <returns></returns>
        public string getLocolport()
        {
            return tb_port.Text;
        }

        public string getLocolIP()
        {
            return tb_IP.Text;
        }

      
    }
}
