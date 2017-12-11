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
    public partial class Frock_form : Form
    {
        public Addfrock_form addfrockform = new Addfrock_form();
        public Frock[] frocklist = new Frock[100];
        public int frocklistlong = 0;
        public string listfilename = "Frock.txt";
        public Frock_form()
        {
            InitializeComponent();
            //loadFrocklistFromFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addfrockform.ShowDialog();
        }

        public bool addFrock(string ip, string port, string name)
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].name.Equals(name))
                {
                    MessageBox.Show("该工装名称已存在", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].ip.Equals(ip) &&
                    frocklist[i].port.Equals(port))
                {
                    MessageBox.Show("该连接对象在工装列表已存在", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            frocklist[frocklistlong] = new Frock(name, ip, port, "", "待绪");
            frocklistlong++;
            LoadFrockToList();
            Mainform.mainForm.LoadFrock();
            return true;
            //showLiv(p, ip, port, "", "");
        }
        private void showLiv(string p1, string p2, string p3, string p4, string p5)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = p1;
            lvi.SubItems.Add(p2);
            lvi.SubItems.Add(p3);
            lvi.SubItems.Add(p4);
            lvi.SubItems.Add(p5);
            this.listView1.Items.Add(lvi);
            //listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }
        private void showLiv(Frock f)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = f.name;
            lvi.SubItems.Add(f.ip);
            lvi.SubItems.Add(f.port);
            lvi.SubItems.Add(f.num);
            lvi.SubItems.Add(f.status);
            this.listView1.Items.Add(lvi);
        }
        private void bt_delete_Click(object sender, EventArgs e)
        {
            int selectCount = listView1.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                DialogResult result = MessageBox.Show("确定要删除该工装吗?\r\n删除后需工装重新在线才能添加", "删除",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    deleteFrock(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text,
                        listView1.SelectedItems[0].SubItems[2].Text);
                    int currentIndex = this.listView1.SelectedItems[0].Index;//取当前选中项的index
                    listView1.Items[currentIndex].Remove();
                    Mainform.mainForm.LoadFrock();
                }
            }
            else
            {
                MessageBox.Show("请在列表选择要删除的工装", "提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteFrock(string p1, string p2, string p3)
        {
            int deletenum = -1;
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].name.Equals(p1) && frocklist[i].ip.Equals(p2) && frocklist[i].port.Equals(p3))
                {
                    deletenum = i;
                    break;
                }
            }
            if (deletenum > -1)
            {
                for (int i = 0; i < frocklistlong - deletenum - 1; i++)
                {
                    frocklist[i + deletenum] = frocklist[i + 1 + deletenum];
                }
                frocklistlong--;
            }
        }
        private void bt_export_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "工装名称\t工装IP地址\t工装端口号\t工装物料号\t工装实时状态\t\r\n";
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
            tb_ip.Text = "";
            tb_num.Text = "";
            tb_port.Text = "";
            tb_status.Text = "";
            tb_name.Text = "";
        }

        private void bt_query_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            LoadFrockToList();
            if (tb_name.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text.IndexOf(tb_name.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_ip.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text.IndexOf(tb_ip.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_port.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[2].Text.IndexOf(tb_port.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_num.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[3].Text.IndexOf(tb_num.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_status.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[4].Text.IndexOf(tb_status.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }

            listView1.EndUpdate();
        }

        private void Frock_form_Load(object sender, EventArgs e)
        {
            LoadFrockToList();
        }
        public void LoadFrockToList()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            for (int i = 0; i < frocklistlong; i++)
            {
                showLiv(frocklist[i].name, frocklist[i].ip, frocklist[i].port, frocklist[i].num, frocklist[i].status);
            }
            listView1.EndUpdate();
        }
        public void loadFrocklistFromFile()
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
                frocklistlong = 0;
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fs.SetLength(0);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("NAME\tIP\tPORT\tNUM\tSTATUS\t\r\n");
                sw.Close();
                fs.Close();
                return;
            }
            frocklistlong = ls.Count - 1;
            for (int i = 1; i < ls.Count; i++)
            {
                string name = "";
                string ip = "";
                string port = "";
                string num = "";
                string status = "";
                for (int j = 0; j < ls[i].Length; j++)
                {

                    if (j == 0)//录入的是主键
                    {
                        name = ls[i][j];
                    }
                    if (j == 1)
                    {
                        ip = ls[i][j];
                    }
                    if (j == 2)
                    {
                        port = ls[i][j];
                    }
                    if (j == 3)
                    {
                        num = ls[i][j];
                    }
                    if (j == 4)
                    {
                        status = ls[i][j];
                    }

                }
                frocklist[i - 1] = new Frock(name, ip, port, num, status);
                //frocklistlong++;
            }
        }
        public void SavefrockListToLog()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //清空文件
            fs.SetLength(0);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //清空文件
            sw.Write("NAME\tIP\tPORT\tNUM\tSTATUS\t\r\n");
            for (int i = 0; i < frocklistlong; i++)
            {
                // for (int j = 0; j < 2; j++)
                {
                    sw.Write(frocklist[i].name + "\t");
                    sw.Write(frocklist[i].ip + "\t");
                    sw.Write(frocklist[i].port + "\t");
                    sw.Write(frocklist[i].num + "\t");
                    sw.Write(frocklist[i].status + "\t");
                }
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
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

        public string[] getPreparedfrockList()
        {
            int preparedCount = 0;
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].status.Equals("待绪"))
                    preparedCount++;
            }
            string[] list = new string[preparedCount];
            int j=0;
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].status.Equals("待绪"))
                {
                    list[j] = frocklist[i].name;
                    j++;
                }
            }
            return list;
        }

        public void setDisconnected()
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                frocklist[i].status = "未连接";
            }
        }

        public void preparefrock(string ip_port)
        {
            string ip = ip_port.Substring(0, ip_port.IndexOf(":"));
            string port = ip_port.Substring(ip_port.IndexOf(":") + 1);
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].ip.Equals(ip) && frocklist[i].port.Equals(port) && frocklist[i].status.Equals("未连接"))
                {
                    frocklist[i].status = "待绪";
                }
            }
        }
        public void stopFrock(string orderfrock)
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].name.Equals(orderfrock) && frocklist[i].status.Equals("正在测试"))
                {
                    frocklist[i].status = "待绪";
                }
            }
        }
        public void crackFrock(string ip_port)
        {
            string ip = ip_port.Substring(0, ip_port.IndexOf(":"));
            string port = ip_port.Substring(ip_port.IndexOf(":") + 1);
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].ip.Equals(ip) && frocklist[i].port.Equals(port))
                {
                    frocklist[i].status = "未连接";
                }
            }
        }
        public void startFrock(string frockname)
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].name.Equals(frockname))
                {
                    frocklist[i].status = "正在测试";
                }
            }
        }

        public string getFrockByip_port(string ip, string port)
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].ip.Equals(ip) && frocklist[i].port.Equals(port))
                {
                    return frocklist[i].name;
                }
            }
            return "";
        }
        public string getFrockIP_PORTByFrockname(string frockname)
        {
            for (int i = 0; i < frocklistlong; i++)
            {
                if (frocklist[i].name.Equals(frockname))
                {
                    return frocklist[i].ip + ":" + frocklist[i].port;
                }
            }
            return "";
        }
    }
}
