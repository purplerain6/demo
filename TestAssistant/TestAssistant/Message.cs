using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssistant
{
    public class Message
    {
        public string message { get; set; }//报文
        private string STC;//起始符
        private string informLEN;//子信息长度
        private int informLEN_data;
        private string CSUM;//算术和
        private string CSUM_data = "";

        string[] by = new string[10];
        string DIDnumber_01 = "";
        string DIDnumber_01_ASC = "";
        string DIDnumber_02 = "";
        string DIDnumber_02_ASC = "";
        string DIDnumber_03 = "";
        string DIDnumber_03_ASC = "";
        string DIDnumber_04 = "";
        string DIDnumber_04_ASC = "";
        string DIDnumber_05 = "";
        //部分占用字节
        int STC_START = 0;
        int STC_LEN = 1;
        int informLEN_START = 1;
        int informLEN_LEN = 2;
        int CODE_START = 3;
        int CSUM_LEN = 1;

        public Message(string messag)
        {
            message = messag.Replace(" ", "");
            STC = message.Substring(STC_START * 2, STC_LEN * 2);//提取起始符
            informLEN = message.Substring(informLEN_START * 2, informLEN_LEN * 2);//提取子信息长度
            CSUM = message.Substring(message.Length - CSUM_LEN * 2);//提取算术和            
            Analysis();
        }

        private void Analysis()
        {
            //子信息长度
            int informlen = Convert.ToInt32(Small_end_representation(informLEN), 16);
            informLEN_data = informlen;
            //子信息
            string msg = message.Substring(CODE_START * 2);
            for (int i = 0; i < 10; i++)
            {
                string CODE_data = msg.Substring(0, 2);
                string LEN_data = msg.Substring(2, 2);
                int len = Convert.ToInt32(LEN_data, 16);
                string DATA_data = msg.Substring(4, len * 2);
                if (CODE_data.Equals("01"))
                {
                    by[i] = DATA_data;
                    DIDnumber_01 = by[i];
                    string mm = HEXstring_to_byte(DATA_data);
                    DIDnumber_01_ASC = mm;
                }
                if (CODE_data.Equals("02"))
                {
                    by[i] = DATA_data;
                    DIDnumber_02 = by[i];
                    string mm = HEXstring_to_byte(DATA_data);
                    DIDnumber_02_ASC = mm;

                }
                if (CODE_data.Equals("03"))
                {
                    by[i] = DATA_data;
                    DIDnumber_03 = by[i];
                    string mm = HEXstring_to_byte(DATA_data);
                    DIDnumber_03_ASC = mm;
                }
                if (CODE_data.Equals("04"))
                {
                    by[i] = DATA_data;
                    DIDnumber_04 = by[i];
                    string mm = HEXstring_to_byte(DATA_data);
                    DIDnumber_04_ASC = mm;
                }
                if (CODE_data.Equals("05"))
                {
                    by[i] = DATA_data;
                    DIDnumber_05 = by[i]; ;
                }
                string mssg = msg.Substring(len * 2 + 4);
                if (mssg.Length != 2)
                {
                    msg = mssg;
                }
                else
                {
                    CSUM_data = mssg;
                    break;
                }
            }

        }
        public string getSTC()
        {
            return STC;
        }
        public int getinformlen()
        {
            return informLEN_data;
        }
        public string getDIDnumber_01()
        {
            return DIDnumber_01;
        }
        public string getDIDnumber_01_ASC()
        {
            return DIDnumber_01_ASC;
        }
        public string getDIDnumber_02()
        {
            return DIDnumber_02;
        }
        public string getDIDnumber_02_ASC()
        {
            return DIDnumber_02_ASC;
        }
        public string getDIDnumber_03()
        {
            return DIDnumber_03;
        }
        public string getDIDnumber_03_ASC()
        {
            return DIDnumber_03_ASC;
        }
        public string getDIDnumber_04()
        {
            return DIDnumber_04;
        }
        public string getDIDnumber_04_ASC()
        {
            return DIDnumber_04_ASC;
        }
        public string getDIDnumber_05()
        {
            return DIDnumber_05;
        }
        public string getCSUM_data()
        {
            return CSUM_data;
        }
        //小端表示
        private String Small_end_representation(String data)
        {
            String str = "";
            for (int i = 0; i < (data.Length / 2); i++)
                str += data.Substring(data.Length - 2 * i - 2, 2);
            return str;
        }
        //十六进制转换成bytys
        private String HEXstring_to_byte(String message)
        {
            String str = "0123456789ABCDEF";
            char[] hexs = message.ToCharArray(); // 将字符串转换为字符数组;
            byte[] bytes = new byte[message.Length / 2];
            int n;
            for (int i = 0; i < bytes.Length; i++)
            {
                n = str.IndexOf(hexs[2 * i]) * 16;
                n += str.IndexOf(hexs[2 * i + 1]);
                bytes[i] = (byte)(n & 0xff);
            }
            string str1 = System.Text.Encoding.ASCII.GetString(bytes);
            return str1;
        }
    }
}