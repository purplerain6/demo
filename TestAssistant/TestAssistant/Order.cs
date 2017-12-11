using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssistant
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        //public int timeout = 5;
        public string no;//订单名
        public string starttime;//开始时间
        public string endtime;//结束时间
        public string person;//测试人
        public string frock;//工装名
        public int count;//正常数量
        public int  count_bad;//不良数量
        public  string status;//订单状态
        public string ip_port;//工装使用IP端口
        public Thread thread;//测试线程
        public Order(string no, string starttime, string endtime, string person, string frock, int count,int count_bad, string status,string ip_port)
        {
            this.no = no;
            this.starttime = starttime;
            this.endtime = endtime;
            this.person = person;
            this.frock = frock;
            this.count = count;
            this.count_bad = count_bad;
            this.status = status;
            this.ip_port = ip_port;
        }
        public void startThresad()
        {
            thread = new Thread(new ParameterizedThreadStart(CommThread));
            thread.IsBackground = true;//线程后台运行，退出窗体结束
            thread.Start(this);
        }

        private void CommThread(object arg )
        {
            Order order = (Order)arg;
            
        }
        public void stopThresad()
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }
    }
}
