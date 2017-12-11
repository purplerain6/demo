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
    public partial class MSG_form : Form
    {
        public MSG_form()
        {
            InitializeComponent();
        }
        public void settext(string msg)
        {
            this.textBox1.Text = msg;
        }
    }
}
