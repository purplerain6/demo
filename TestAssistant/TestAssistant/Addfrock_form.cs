using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    public partial class Addfrock_form : Form
    {
        public Addfrock_form()
        {
            InitializeComponent();
        }

        private void cB_object_DropDown(object sender, EventArgs e)
        {
            cB_object.Items.Clear();
            string[] b = Mainform.mainForm.TcpServer.getClientList();//获取当前客户端列表；
            Array.Sort(b);
            cB_object.Items.AddRange(b);
        }

        private void bt_addfrock_Click(object sender, EventArgs e)
        {
            if (tb_frock.Text.Replace(" ", "") == "")
            {
                //MessageBox.Show("请输入一个工装名称");
                MessageBox.Show("请输入一个工装名称", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cB_object.SelectedIndex != -1)
            {
                string ip_port = cB_object.SelectedItem.ToString();
                string ip = ip_port.Substring(0, ip_port.IndexOf(':'));
                string port = ip_port.Substring(ip_port.IndexOf(':') + 1);
                bool result = Mainform.mainForm.frockform.addFrock(ip, port, tb_frock.Text.Replace(" ", ""));
                if (result)
                    this.Hide();
            }
            else
            {
                MessageBox.Show("请选择一个客户主机", "提示",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void Addfrock_form_Load(object sender, EventArgs e)
        {
            tb_frock.Text = "";
            resetCB();
        }
        /// <summary>
        /// 下拉框位置重置
        /// </summary>
        public void resetCB()
        {
            cB_object.SelectedIndex = -1;
        }
    }
}
