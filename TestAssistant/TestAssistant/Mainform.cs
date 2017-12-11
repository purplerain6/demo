using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class Mainform : Form
    {
        public static Mainform mainForm;//主窗体
        public TCPServer TcpServer = new TCPServer();//TCP服务器
        public Com_form comform = new Com_form();//连接窗体
        public Frock_form frockform = new Frock_form();//工装窗体
        public Record_form recordform = new Record_form();//记录窗体
        public Order_form orderform = new Order_form();//订单窗体
        public MSG_form msgform = new MSG_form();//报文解析窗体
        public About_form aboutform = new About_form();//关于窗体
        public int threadlistlong = 0;//测试线程数量
        public ServiceReference_MES.MesFrameWorkSoapClient myWebService = new ServiceReference_MES.MesFrameWorkSoapClient();//上传MES接口
        public string UpperComputerSoftware { get; set; }//上位机软件版本
        //public Frock[] frocklist = new Frock[100];
        public Mainform()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            mainForm = this; //初始化
            //载入本机IP
            //SetlocaolIP();
            //配置文件载入
            LoadSettings();

            //显示连接窗体
            comform.ShowDialog();
            //载入日志
            //frockform.loadFrocklistFromFile();
            orderform.LoadOrderlistFromFile();
            //日志是否需要另存
            if (recordform.isLogNeedResave())
            {
                recordform.ResaveLog();
            }
            recordform.LoadRecordlistFromFile();
           
        }
        //载入配置文件
        private void LoadSettings()
        {
            UpperComputerSoftware = "v1.0";
            comform.setLocolIP(Properties.Settings.Default.IPAddress);
            comform.setLocolport(Properties.Settings.Default.LocalPort);
        }
        //保存配置文件
        private void SaveSettings()
        {
            Properties.Settings.Default.IPAddress = comform.getLocolIP();
            Properties.Settings.Default.LocalPort = comform.getLocolport();
            Properties.Settings.Default.Save();//使用Save方法保存更改
        }
        /// <summary>
        /// 设置本机IP
        /// </summary>
        private void SetlocaolIP()
        {
            comform.sellocalIP();
        }
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainform_Load(object sender, EventArgs e)
        {
            //LoadFrock();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (orderform.HasRunningIP())
            {
                DialogResult result = MessageBox.Show("有尚在进行的测试未停止，停止并退出？", "提示",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //关闭tcp 服务器
            if (TcpServer.listener != null)
            {
                TcpServer.close();
            }
            //关闭未关闭的订单
            orderform.SetOrderfinished();
            //保存配置文件
            SaveSettings();
            //保存列表
            SaveList();
        }
        private void SaveList()
        {
            //frockform.SavefrockListToLog();
            orderform.SaveoderlistToLog();
            recordform.SaverecordlistToLog();
        }

        /// <summary>
        /// 显示测试工装至列表
        /// </summary>
        public void LoadFrock()
        {
            lv_frock.BeginUpdate();
            lv_frock.Items.Clear();
            for (int i = 0; i < frockform.frocklistlong; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = frockform.frocklist[i].name;
                lvi.SubItems.Add(frockform.frocklist[i].status);
                lv_frock.Items.Add(lvi);
                //lv_frock.Items[i].SubItems[0].Text = frocklist[i].name;
                //lv_frock.Items[i].SubItems[1].Text = frocklist[i].status;
            }
            lv_frock.EndUpdate();
        }


        /// <summary>
        /// 开始测试点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_start_Click(object sender, EventArgs e)
        {
            //if (cb_frock.SelectedIndex == -1)
            if (cb_object.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个连接对象，若无对象请检查工装连接的串口服务器是否正常工作", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_person.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请输入一个测试人名称", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_frock.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请输入一个工装名称", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb_order.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请输入一个订单名称", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string _object = cb_object.SelectedItem.ToString();
            if (!orderform.CheckIPisRun(_object))
            {
                MessageBox.Show("该连接对象正在测试，请先停止测试", "提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string person = tb_person.Text;
            string frock = tb_frock.Text;
            string ordername = tb_order.Text;
            bool result = orderform.addOrder(ordername, gettime(), "", person, frock, 0, 0, "正在测试", _object);
            if (!result)
                return;
            Order current = orderform.getOrderByNO(ordername);
            // Order current = new Order(ordername, "", "", person, frock, 0, 0, "", _object);
            //startMainformfrock(frockname);
            //frockform.startFrock(frockname);
            //LoadFrock();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = frock;
            lvi.SubItems.Add(ordername);
            lvi.SubItems.Add(_object);
            lv_frock.Items.Add(lvi);
            tb_order.Text = "";
            tb_frock.Text = "";
            tb_person.Text = "";
            ResetCB();
            //current.startThresad();
        }

        /// <summary>
        /// 停止测试点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_stop_Click(object sender, EventArgs e)
        {

            int selectCount = lv_frock.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                DialogResult result = MessageBox.Show("确定要停止选中的测试吗?", "停止测试",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //if (lv_frock.SelectedItems[0].SubItems[1].Text == "正在测试")
                    //string stopfrockname=lv_frock.SelectedItems[0].SubItems[0].Text;
                    string stopodername = lv_frock.SelectedItems[0].SubItems[1].Text;
                    if (orderform.canStop(stopodername))
                    {
                        //stopMainformFrock(lv_frock.SelectedItems[0].Index);
                        orderform.stopOrder(stopodername);
                        lv_frock.Items.Remove(lv_frock.SelectedItems[0]);
                        //frockform.stopFrock(stopfrockname);
                        //LoadFrock();
                        orderform.getOrderByNO(stopodername).stopThresad();
                    }
                    else
                    {
                        MessageBox.Show("选择的工装未在进行测试", "提示",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("请在工装列表选择要停止的工装", "提示",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 重置连接对象下拉框
        /// </summary>
        public void ResetCB()
        {
            //cb_frock.SelectedIndex = -1;
            cb_object.SelectedIndex = -1;
        }

        /// <summary>
        /// 显示测试记录至列表
        /// </summary>
        /// <param name="time"></param>
        /// <param name="frock"></param>
        /// <param name="ordername"></param>
        /// <param name="orderperson"></param>
        /// <param name="did1"></param>
        /// <param name="did2"></param>
        /// <param name="did3"></param>
        /// <param name="did4"></param>
        /// <param name="ErrorNO"></param>
        /// <param name="current"></param>
        public void ShowLvi(string time, string frock, string ordername, string orderperson, string did1, string did2, string did3,
            string did4, string ErrorNO, string current)
        {
            lv_record.BeginUpdate();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = time;
            lvi.SubItems.Add(frock);
            lvi.SubItems.Add(ordername);
            lvi.SubItems.Add(orderperson);
            lvi.SubItems.Add(did1);
            lvi.SubItems.Add(did2);
            lvi.SubItems.Add(did3);
            lvi.SubItems.Add(did4);
            lvi.SubItems.Add(ErrorNO);
            lvi.SubItems.Add(current);
            lv_record.Items.Add(lvi);
            lv_record.Items[lv_record.Items.Count - 1].EnsureVisible();
            lv_record.EndUpdate();
        }

        /// <summary>
        /// 修改订单为开始测试状态
        /// </summary>
        /// <param name="frockname"></param>
        private void startMainformfrock(string frockname)
        {
            for (int i = 0; i < lv_frock.Items.Count; i++)
            {
                if (lv_frock.Items[i].SubItems[0].Text.Equals(frockname))
                    lv_frock.Items[i].SubItems[1].Text = "开始测试";
            }
        }

        //读取文件
        public static List<String[]> ReadTxt(string filePathName)
        {
            List<String[]> ls = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            while (strLine != null)
            {
                strLine = fileReader.ReadLine();
                if (strLine != null && strLine.Length > 0)
                {
                    ls.Add(strLine.Split('\t')); //换成你txt实际的分隔符
                }
            }
            fileReader.Close();
            return ls;
        }


        /// <summary>
        /// 获取当前客户端列表；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_object_DropDown(object sender, EventArgs e)
        {
            cb_object.Items.Clear();
            string[] b = Mainform.mainForm.TcpServer.getClientList();//获取当前客户端列表；
            Array.Sort(b);
            cb_object.Items.AddRange(b);
        }

        //选择已连接的工装
        //private void cb_frock_DropDown(object sender, EventArgs e)
        //{
        //    cb_frock.Items.Clear();
        //    string[] b = Mainform.mainForm.frockform.getPreparedfrockList();//获取当前客户端列表；
        //    Array.Sort(b);
        //    cb_frock.Items.AddRange(b);
        //}

        /// <summary>
        /// 清除工装列表工装
        /// </summary>
        /// <param name="orderno"></param>
        public void ClearLV_frock(string orderno)
        {
            for (int i = 0; i < lv_frock.Items.Count; i++)
            {
                if (lv_frock.Items[i].SubItems[1].Text.Equals(orderno))
                    lv_frock.Items.Remove(lv_frock.Items[i]);
            }
        }
        /// <summary>
        /// 清空正在测试记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            lv_record.Items.Clear();
        }
        /// <summary>
        /// 双击工装列表工装事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_frock_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_frock.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                string orderno = lv_frock.SelectedItems[0].SubItems[1].Text;
                orderform.SetSelectOrder(orderno);
                orderform.ShowDialog();

            }
        }

        /// <summary>
        /// 双击测试记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_record_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_record.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                string msg = lv_record.SelectedItems[0].SubItems[9].Text;
                msgform.settext(Regex.Replace(msg, @".{2}", "$0 "));
                msgform.ShowDialog();
            }
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public string gettime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void stopMainformFrock(int p)
        {
            lv_frock.Items[p].SubItems[1].Text = "待绪";
        }
        /// <summary>
        /// 工具栏图标点击事件
        /// </summary>

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frockform.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            recordform.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            orderform.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            comform.ShowDialog();
        }

        /// <summary>
        /// 显示关于窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMI_about_Click(object sender, EventArgs e)
        {
            aboutform.ShowDialog();
        }

        /// <summary>
        /// 显示系统时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tSL_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff ");
        }

        public TCPServer getserver()
        {
            return TcpServer;
        }

        public ToolStripStatusLabel gettsl_connect()
        {
            return tSL_connect;
        }
        public ToolStripStatusLabel gettsl_space()
        {
            return tSL_space;
        }

       
    }
}
