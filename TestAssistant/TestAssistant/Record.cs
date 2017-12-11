using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssistant
{
    /// <summary>
    /// 记录
    /// </summary>
    public class Record
    {
        public string time;//时间
        public string orderno;//订单名
        public string person;//测试人
        public string frockno;//工装名
        public string frock_fwno;//工装固件版本
        public string sn;//产品sn
        public string product_fwno;//产品固件版本
        public string errorno;//错误编码
        public string update;//是否上传MES
        public string msg;//报文


        public Record(string time1, string orderno1, string person1, string frockno1, string frock_fwno1, string sn1, string product_fwno1, string errorno1, string update1, string msg1)
        {
            // TODO: Complete member initialization
            this.time = time1;
            this.orderno = orderno1;
            this.person = person1;
            this.frockno = frockno1;
            this.frock_fwno = frock_fwno1;
            this.sn = sn1;
            this.product_fwno = product_fwno1;
            this.errorno = errorno1;
            this.update = update1;
            this.msg = msg1;
        }
        
    }
}
