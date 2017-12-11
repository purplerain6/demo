using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    /// <summary>
    /// 记录窗体
    /// </summary>
    public partial class Record_form : Form
    {
        private string listfilename = "Record.txt";//记录日志名称
        private int recordlistlong = 0;//记录数
        private Record[] recordlist = new Record[20000];
        static string logtime = "";
        public Record_form()
        {
            InitializeComponent();
        }

        private void Record_form_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Checked = false;
            resetText();
            LoadRecordToList();
        }

        private void resetText()
        {
            tb_person.Text = "";
            tb_orderno.Text = "";
            tb_frockno.Text = "";
            tb_frock_Firmware.Text = "";
            tb_sn.Text = "";
            tb_product_Firmware.Text = "";
            tb_errorno.Text = "";
            tb_update.Text = "";
        }

        public void LoadRecordToList()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            for (int i = 0; i < recordlistlong; i++)
            {
                showLiv(recordlist[i].time, recordlist[i].orderno, recordlist[i].person, recordlist[i].frockno,
                    recordlist[i].frock_fwno, recordlist[i].sn, recordlist[i].product_fwno, recordlist[i].errorno,
                    recordlist[i].update, recordlist[i].msg);
            }
            listView1.EndUpdate();
        }

        private void showLiv(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10)
        {
           // listView1.BeginUpdate();
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
           // listView1.EndUpdate();
        }
        /// <summary>
        /// 载入记录
        /// </summary>
        public void LoadRecordlistFromFile()
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
                recordlistlong = 0;
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fs.SetLength(0);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write("TIME\tORDERNO\tPERSON\tFROCKNO\tFROCK_FWNO\tPRO_SN\tPRO_FWNO\tPRO_ERRORNO\tUPDATE\tMSG\t#####TIME:"+
                    Mainform.mainForm.gettime()+"#####\r\n");
                sw.Close();
                fs.Close();
                return;
            }

            recordlistlong = ls.Count - 1;
            for (int i = 1; i < ls.Count; i++)
            {
                string time = "";
                string orderno = "";
                string person = "";
                string frockno = "";
                string frock_fwno = "";
                string sn = "";
                string product_fwno = "";
                string errorno = "";
                string update = "";
                string msg = "";
                for (int j = 0; j < ls[i].Length; j++)
                {

                    if (j == 0)//录入的是主键
                    {
                        time = ls[i][j];
                    }
                    if (j == 1)
                    {
                        orderno = ls[i][j];
                    }
                    if (j == 2)
                    {
                        person = ls[i][j];
                    }
                    if (j == 3)
                    {
                        frockno = ls[i][j];
                    }
                    if (j == 4)
                    {
                        frock_fwno = ls[i][j];
                    }
                    if (j == 5)
                    {
                        sn = ls[i][j];
                    }
                    if (j == 6)
                    {
                        product_fwno = ls[i][j];
                    }
                    if (j == 7)
                    {
                        errorno = ls[i][j];
                    }
                    if (j == 8)
                    {
                        update = ls[i][j];
                    }
                    if (j == 9)
                    {
                        msg = ls[i][j];
                    }
                }
                recordlist[i - 1] = new Record(time, orderno, person, frockno, frock_fwno, sn, product_fwno, errorno, update, msg);
            }
        }
        //读取文件
        public static List<String[]> ReadTxt(string filePathName)
        {
            List<String[]> ls = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            for (int i=0; strLine != null;i++ )
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
        /// <summary>
        /// 保存记录
        /// </summary>
        public void SaverecordlistToLog()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //清空文件
            fs.SetLength(0);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //清空文件
            if(logtime.Equals(""))
                 sw.Write("TIME\tORDERNO\tPERSON\tFROCKNO\tFROCK_FWNO\tPRO_SN\tPRO_FWNO\tPRO_ERRORNO\tUPDATE\tMSG\t#####TIME:" +
                    Mainform.mainForm.gettime() + "#####\r\n");
            else
                sw.Write("TIME\tORDERNO\tPERSON\tFROCKNO\tFROCK_FWNO\tPRO_SN\tPRO_FWNO\tPRO_ERRORNO\tUPDATE\tMSG\t#####TIME:" +
                   logtime + "#####\r\n");
            for (int i = 0; i < recordlistlong; i++)
            {
                // for (int j = 0; j < 2; j++)
                {
                    sw.Write(recordlist[i].time + "\t");
                    sw.Write(recordlist[i].orderno + "\t");
                    sw.Write(recordlist[i].person + "\t");
                    sw.Write(recordlist[i].frockno + "\t");
                    sw.Write(recordlist[i].frock_fwno + "\t");
                    sw.Write(recordlist[i].sn + "\t");
                    sw.Write(recordlist[i].product_fwno + "\t");
                    sw.Write(recordlist[i].errorno + "\t");
                    sw.Write(recordlist[i].update + "\t");
                    sw.Write(recordlist[i].msg + "\t");
                }
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
        }

        public void addRecoer(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string ErrorNO, string updateresult, string p8)
        {
            recordlist[recordlistlong] = new Record(p1, p2, p3, p4, p5, p6, p7, ErrorNO, updateresult,p8);
            recordlistlong++;
            //showOrderToList();
        }

        private void bt_export_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "时间\t生产订单号\t测试人员\t工装物料号\t工装固件版本号\t产品SN编码\t产品固件版本号\t产品错误编码\t是否上传成功\t接收报文\t\r\n";
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

        private void bt_reset_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Checked = false;
            resetText();
        }
        /// <summary>
        /// 记录条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_query_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            LoadRecordToList();
            if (dateTimePicker1.Checked)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Console.WriteLine(listView1.Items[i].SubItems[3].Text);
                    Console.WriteLine(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                    if (listView1.Items[i].SubItems[0].Text.IndexOf(dateTimePicker1.Value.ToString("yyyy-MM-dd")) == -1)
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
                    if (listView1.Items[i].SubItems[1].Text.IndexOf(tb_person.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_orderno.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[2].Text.IndexOf(tb_orderno.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_frockno.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[3].Text.IndexOf(tb_frockno.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_frock_Firmware.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[4].Text.IndexOf(tb_frock_Firmware.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_sn.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[5].Text.IndexOf(tb_sn.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_product_Firmware.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[6].Text.IndexOf(tb_product_Firmware.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_errorno.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[7].Text.IndexOf(tb_errorno.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }
            if (tb_update.Text != "")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[8].Text.IndexOf(tb_update.Text) == -1)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                }
            }


            listView1.EndUpdate();
        }

        public bool isLogNeedResave()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            try
            {
                StreamReader fileReader = new StreamReader(filename);
                string strLine = fileReader.ReadLine();
                int i = (strLine.IndexOf("#####TIME:"));
                fileReader.Close();
                if (i != -1)
                {

                    try
                    {
                        string lasttime = strLine.Substring(i + 10, 19);
                        //if (logtime.Equals(""))
                        //    return false;
                        //string lasttime = logtime;
                        DateTime past = Convert.ToDateTime(lasttime);
                        DateTime now = DateTime.Now;

                        TimeSpan difference = now.Subtract(past);
                        Console.WriteLine("相差:" + difference.Days.ToString() + "天");
                        int day = Convert.ToInt32(difference.Days.ToString());
                        if (day >30)
                            return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        /// <summary>
        /// 日志另存
        /// </summary>
        public void ResaveLog()
        {
            string Current = Directory.GetCurrentDirectory();//获取当前根目录
            string filename = Current + "\\" + listfilename;
            string newPath = Current + "\\LOG\\";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            string newfilename = newPath + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt";
            File.Copy(filename, newfilename, true);//允许覆盖目的地的同名文件
            File.Delete(filename);
        }
    }
}
