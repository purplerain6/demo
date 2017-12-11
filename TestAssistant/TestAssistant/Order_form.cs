using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    /// <summary>
    /// 订单窗体
    /// </summary>
    public partial class Order_form : Form
    {
        private string listfilename = "Order.txt";//订单记录文件名
        private int orderlistlong = 0;//订单数
        private Order[] orderlist = new Order[5000];
        public bool select = false;
        public string selectname = "";
        static string logtime = "";
        public Order_form()
        {
            InitializeComponent();
        }
        private void Order_form_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Checked = false;
            resetText();
            LoadOrderToList();
            if (select)
            {
                SelectOrder(selectname);
                select = false;
            }
        }

        private void resetText()
        {
            tb_orderno.Text = "";
            tb_person.Text = "";
            tb_frock.Text = "";
        }
        /// <summary>
        /// 保存订单
        /// </summary>
        public void SaveoderlistToLog()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //清空文件
            fs.SetLength(0);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //清空文件
            if (logtime.Equals(""))
                sw.Write("NO\tSTARTTIME\tENDTIME\tPERSON\tFROCK\tFINISHED\tBAD\tSTATUS\tIP_PORT\t#####TIME:" +
                        Mainform.mainForm.gettime() + "#####\r\n");
            else
                sw.Write("NO\tSTARTTIME\tENDTIME\tPERSON\tFROCK\tFINISHED\tBAD\tSTATUS\tIP_PORT\t#####TIME:" +
                   logtime + "#####\r\n");
            for (int i = 0; i < orderlistlong; i++)
            {
                // for (int j = 0; j < 2; j++)
                {
                    sw.Write(orderlist[i].no + "\t");
                    sw.Write(orderlist[i].starttime + "\t");
                    sw.Write(orderlist[i].endtime + "\t");
                    sw.Write(orderlist[i].person + "\t");
                    sw.Write(orderlist[i].frock + "\t");
                    sw.Write(orderlist[i].count + "\t");
                    sw.Write(orderlist[i].count_bad + "\t");
                    sw.Write(orderlist[i].status + "\t");
                    sw.Write(orderlist[i].ip_port + "\t");
                }
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 载入订单
        /// </summary>
        public void LoadOrderlistFromFile()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            List<String[]> ls;//txt导入list
            try
            {
                ls = ReadTxt(filename);
            }
            catch
            {
                orderlistlong = 0;
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fs.SetLength(0);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                if (logtime.Equals(""))
                    sw.Write("NO\tSTARTTIME\tENDTIME\tPERSON\tFROCK\tFINISHED\tBAD\tSTATUS\tIP_PORT\t#####TIME:" +
                        Mainform.mainForm.gettime() + "#####\r\n");
                else
                    sw.Write("NO\tSTARTTIME\tENDTIME\tPERSON\tFROCK\tFINISHED\tBAD\tSTATUS\tIP_PORT\t#####TIME:" +
                    logtime + "#####\r\n");
                sw.Close();
                fs.Close();
                return;
            }
            orderlistlong = ls.Count - 1;
            for (int i = 1; i < ls.Count; i++)
            {
                string no = "";
                string starttime = "";
                string endtime = "";
                string person = "";
                string frock = "";
                int  count = 0;
                int  count_bad = 0;
                string status = "";
                string ip_port = "";
                for (int j = 0; j < ls[i].Length; j++)
                {

                    if (j == 0)//录入的是主键
                    {
                        no = ls[i][j];
                    }
                    if (j == 1)
                    {
                        starttime = ls[i][j];
                    }
                    if (j == 2)
                    {
                        endtime = ls[i][j];
                    }
                    if (j == 3)
                    {
                        person = ls[i][j];
                    }
                    if (j == 4)
                    {
                        frock = ls[i][j];
                    }
                    if (j == 5)
                    {
                        try
                        {
                            count = Convert.ToInt32(ls[i][j]);
                        }
                        catch
                        {
                            count = 0;
                        }
                    }
                    if (j == 6)
                    {
                        try
                        {
                            count_bad = Convert.ToInt32(ls[i][j]);
                        }
                        catch
                        {
                            count_bad = 0;
                        }
                    }
                    if (j == 7)
                    {
                        status = ls[i][j];
                    }
                    if (j == 8)
                    {
                        ip_port = ls[i][j];
                    }
                }
                if (status.Equals("正在测试"))
                    status = "异常终止";
                orderlist[i - 1] = new Order(no, starttime, endtime, person, frock, count, count_bad, status, ip_port);
            }
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="ordername"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="person"></param>
        /// <param name="frockname"></param>
        /// <param name="count"></param>
        /// <param name="count_bad"></param>
        /// <param name="status"></param>
        /// <param name="ip_port"></param>
        /// <returns></returns>
        public bool addOrder(string ordername, string starttime, string endtime, string person, string frockname, int count, int count_bad, string status, string ip_port)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(ordername))
                {
                    MessageBox.Show("该订单号在订单列表已存在", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            orderlist[orderlistlong] = new Order(ordername, starttime, endtime, person, frockname, count, count_bad, status, ip_port);
            orderlistlong++;
            //showOrderToList();
            return true;
        }
        public void LoadOrderToList()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            for (int i = 0; i < orderlistlong; i++)
            {
                int bad = orderlist[i].count_bad;
                int count = orderlist[i].count;
                bad *= 100;
                double result = Math.Round((bad * 1.00 / count), 2);
                showLiv(orderlist[i].no, orderlist[i].starttime, orderlist[i].endtime, orderlist[i].person,
                    orderlist[i].frock, orderlist[i].count.ToString(), orderlist[i].count_bad.ToString(), orderlist[i].status,
                    result + "%", orderlist[i].ip_port);
            }
            listView1.EndUpdate();
        }
        private void showLiv(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9,string p10)
        {
            listView1.BeginUpdate();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = p1;
            lvi.SubItems.Add(p2);
            lvi.SubItems.Add(p3);
            lvi.SubItems.Add(p4);
            lvi.SubItems.Add(p5);
            lvi.SubItems.Add(p6);
            lvi.SubItems.Add(p7);
            lvi.SubItems.Add(p8);
            lvi.SubItems.Add(p9);
            lvi.SubItems.Add(p10);
            this.listView1.Items.Add(lvi);
            listView1.EndUpdate();
            //listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            int selectCount = listView1.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                for (int i = 0; i < selectCount; i++)
                {
                    if (listView1.SelectedItems[i].SubItems[7].Text == "正在测试")
                    {
                        MessageBox.Show("存在订单正在测试中，请先结束测试", "提示",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                DialogResult result = MessageBox.Show("确定要删除选中的所有订单吗?", "删除",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < selectCount; i++)
                    {
                        deleteOrder(listView1.SelectedItems[0].SubItems[0].Text);
                        int currentIndex = this.listView1.SelectedItems[0].Index;//取当前选中项的index
                        listView1.Items[currentIndex].Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show("请在列表选择要删除的订单", "提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteOrder(string p)
        {
            int deletenum = -1;
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(p))
                {
                    deletenum = i;
                    break;
                }
            }
            if (deletenum > -1)
            {
                for (int i = 0; i < orderlistlong - deletenum - 1; i++)
                {
                    orderlist[i + deletenum] = orderlist[i + 1 + deletenum];
                }
                orderlistlong--;
            }
        }
        //读取文件
        public static List<String[]> ReadTxt(string filePathName)
        {
            List<String[]> ls = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            for (int i = 0; strLine != null;i++ )
            {
                strLine = fileReader.ReadLine();
                if (i == 0)
                {
                    int j = (strLine.IndexOf("#####TIME:"));
                    logtime = strLine.Substring(j + 10, 19);
                }
                if (strLine != null && strLine.Length > 0)
                {
                    ls.Add(strLine.Split('\t')); //换成你txt实际的分隔符
                }
            }
            fileReader.Close();
            return ls;
        }
        public string gettime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void crackOrder(string ip_port)
        {

            string ip = ip_port.Substring(0, ip_port.IndexOf(":"));
            string port = ip_port.Substring(ip_port.IndexOf(":") + 1);

            //string frockname = Mainform.mainForm.frockform.getFrockByip_port(ip,port);
            //if (frockname.Equals("null"))
            //    return;
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].ip_port.Equals(ip_port) && orderlist[i].status.Equals("正在测试"))
                {
                    orderlist[i].endtime = gettime();
                    orderlist[i].status = "异常终止";
                }
            }
        }

        public void stopOrder(string orderno)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(orderno) && orderlist[i].status.Equals("正在测试"))
                {
                    orderlist[i].endtime = gettime();
                    orderlist[i].status = "完成";
                }
            }

        }
        public void SetOrderfinished()
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试"))
                {
                    orderlist[i].endtime = gettime();
                    orderlist[i].status = "完成";
                }
            }
        }

        public string getOrderNOByFrockname(string frock)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].frock.Equals(frock))
                {
                    return orderlist[i].no;
                }
            }
            return "Error";
        }
        public string getOrderPersonByFrockname(string frock)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].frock.Equals(frock))
                {
                    return orderlist[i].person;
                }
            }
            return "Error";
        }

        public string getOrderPersonByOrdername(string ordername)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].no.Equals(ordername))
                {
                    return orderlist[i].person;
                }
            }
            return "Error";
        }
        public bool canStop(string stopordername)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].no.Equals(stopordername))
                {
                    return true;
                }
            }
            return false;
        }

        public void addGoodToOrder(Order order)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(order.no))
                {
                    orderlist[i].count++;
                }
            }
        }

        public void addBadToOrder(Order order)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(order.no))
                {
                    orderlist[i].count_bad++;
                }
            }
        }

        public string getcrackOrderNO(string ip_port)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].ip_port.Equals(ip_port))
                {
                    return orderlist[i].no;
                }
            }
            return "null";
        }

        public Order getOrderByNO(string ordername)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].no.Equals(ordername))
                {
                    return orderlist[i];
                }
            }
            return null;
        }

        public string[] getRunningIP()
        {
            string[] a = new string[50];
            int count = 0;
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试"))
                {
                    a[count] = orderlist[i].ip_port;
                    count++;
                }
            }
            string[] b = new string[count];
            for (int i = 0; i < count; i++)
            {
                b[i] = a[i];
            }
            return b;
        }

        public bool CheckIPisRun(string _object)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].ip_port.Equals(_object) && orderlist[i].status.Equals("正在测试"))
                    return false;
            }
            return true;
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "生产订单号\t任务开始时间\t任务结束时间\t测试人员\t使用工装\t生产数量\t不良数量\t状态\t工装使用地址\t\r\n";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listView1.Items[i].SubItems.Count - 1; j++)
                {
                    str += listView1.Items[i].SubItems[j].Text.Replace("\r\n", "") + "\t";
                }
                str += "\r\n";
            }
            Savelog(str);
        }
        private void Savelog(string str)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "文本文件|*.txt";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                // 创建文件，将textBox1中的内容保存到文件中
                // saveDlg.FileName 是用户指定的文件路径
                FileStream fs = File.Open(saveDlg.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                // 保存textBox4中所有内容（所有行）
                sw.WriteLine(str);
                //关闭文件
                sw.Flush();
                sw.Close();
                fs.Close();
                // 提示用户：文件保存的位置和文件名
                MessageBox.Show("文件已成功保存到" + saveDlg.FileName);
            }
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            resetText();
            dateTimePicker1.Checked = false;
        }
        /// <summary>
        /// 条件查询订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_query_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            LoadOrderToList();
            if (tb_orderno.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text.IndexOf(tb_orderno.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (dateTimePicker1.Checked)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Console.WriteLine(listView1.Items[i].SubItems[3].Text);
                    Console.WriteLine(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                    if (listView1.Items[i].SubItems[1].Text.IndexOf(dateTimePicker1.Value.ToString("yyyy-MM-dd")) == -1
                        && listView1.Items[i].SubItems[2].Text.IndexOf(dateTimePicker1.Value.ToString("yyyy-MM-dd")) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_person.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[3].Text.IndexOf(tb_person.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_frock.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[4].Text.IndexOf(tb_frock.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            listView1.EndUpdate();
        }

        public void SelectOrder(string orderno)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == orderno)
                {
                    listView1.Items[i].Selected = true;
                    listView1.Items[i].EnsureVisible();
                }
            }
        }

        public bool isRunning(string ip_port)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].ip_port.Equals(ip_port))
                {
                    return true;
                }
            }
            return false;
        }

        public Order getOrderByRunningIP(string ip_port)
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试") && orderlist[i].ip_port.Equals(ip_port))
                {
                    return orderlist[i];
                }
            }
            return null;
        }

        public bool HasRunningIP()
        {
            for (int i = 0; i < orderlistlong; i++)
            {
                if (orderlist[i].status.Equals("正在测试"))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetSelectOrder(string orderno)
        {
            selectname = orderno;
            select = true;
        }

        /// <summary>
        /// 处理接收到的报文
        /// </summary>
        /// <param name="ip_port"></param>
        /// <param name="current"></param>
        public void starthandle(string ip_port, string current)
        {
            
            if (!Mainform.mainForm.orderform.isRunning(ip_port))
            {
                Console.WriteLine("工装连接的串口服务器未在线");
                return;
            }
            current = current.ToUpper().Replace(" ", "");
            //检查报文是否以7E开头，校验是否通过
            if (!current.StartsWith("7E") || current.Length % 2 != 0 ||
                !makeChecksum(current.Substring(0, current.Length - 2)).Equals(current.Substring(current.Length - 2)))
            {
                Console.WriteLine("接收的报文不正确，请检查7E起始符，校验和");
                return;
            }
            try
            {
                Message msg = new Message(current.Replace(" ", ""));
                if (msg.getinformlen() * 2 + 8 != current.Length)
                {
                    Console.WriteLine("报文长度校验错误");
                    return;
                }
            }
            catch
            {
                //MessageBox.Show("接收的报文不合法", "提示",
                // MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine("ErrorMessage:" + current);
                return;
            }
            Mainform.mainForm.gettsl_space().Text = "";
            //生成报文类
            Message message = new Message(current.Replace(" ", ""));
            Order order = Mainform.mainForm.orderform.getOrderByRunningIP(ip_port);
            if (order == null)
            {
                Console.WriteLine("该IP未在测试列表");
                return;
            }
            
            UploadMes.Upload(message,order,ip_port);
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
    }
}
