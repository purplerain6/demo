using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssistant
{
    /// <summary>
    /// 工装
    /// </summary>
    public class Frock
    {
        public string name;//工装名
        public string ip;//使用IP
        public string port;//使用端口
        public string num;//工装物料号
        public  string status;//工装状态
        public Frock(string name, string ip, string port, string num, string status)
        {
            this.name = name;
            this.ip = ip;
            this.port = port;
            this.num = num;
            this.status = status;
        }
    }
}
