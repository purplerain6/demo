using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssistant
{
    public class UploadMes
    {
        /// <summary>
        /// 上传MES
        /// </summary>
        /// <param name="message">接收的报文</param>
        /// <param name="order">所属订单</param>
        /// <param name="ip_port">接收的IP端口</param>
        public static void Upload(Message message, Order order,string ip_port)
        {
            string time = Mainform.mainForm.gettime();
            string Tester = order.person;
            string TestTime = time;
            string OrderNo = order.no;
            string FrockNo = message.getDIDnumber_01_ASC();
            string FrockFirmware = message.getDIDnumber_02_ASC();
            string SN = message.getDIDnumber_03();
            string ProductFirmware = message.getDIDnumber_04_ASC();
            string ErrorCode = message.getDIDnumber_05();
            string UpperComputerSoftware = Mainform.mainForm.UpperComputerSoftware;
            //上传MES,返回结果
            Test t = new Test();
            t.Tester = Tester;
            t.TestTime = TestTime;
            t.OrderNo = OrderNo;
            t.FrockNo = FrockNo;
            t.FrockFirmware = FrockFirmware;
            t.SN = SN;
            t.ProductFirmware = ProductFirmware;
            t.ErrorCode = ErrorCode;
            t.UpperComputerSoftware = UpperComputerSoftware;

            string jsonString = JsonHelper.JsonSerializer<Test>(t);
            string updateresult = "否";
            string result = "";
            try
            {
                result = Mainform.mainForm.myWebService.UploadFixtureTestData(jsonString);
                if (result.Equals("OK"))
                {
                    updateresult = "是";
                }
                else
                {
                    Console.WriteLine("上传MES返回错误");
                    return;
                }
            }
            catch(Exception e)
            {
                result = "上传失败";
                Console.WriteLine("上传MES失败，请检查网络:"+e.ToString());
                return;
            }
            finally
            {
                //显示测试记录
                Mainform.mainForm.ShowLvi(TestTime, order.frock, OrderNo, Tester, FrockNo,
                    FrockFirmware, SN, ProductFirmware, ErrorCode,message.message);
                //Mainform.mainForm.orderform.LoadOrderToList();
                Mainform.mainForm.gettsl_space().Text = result;
            }

            //将记录更新至Record表
            Mainform.mainForm.recordform.addRecoer(TestTime, order.no, Tester, FrockNo,
                FrockFirmware, SN, ProductFirmware, ErrorCode, updateresult,message.message);
            //Mainform.mainForm.recordform.LoadRecordToList();
            if (ErrorCode.Equals("00"))
                Mainform.mainForm.orderform.addGoodToOrder(order);
            else
            {
                Mainform.mainForm.orderform.addBadToOrder(order);
                //return;
            }


            //回复确认
            string SENDmsg = "7E13000111" + message.getDIDnumber_01();
            SENDmsg += makeChecksum(SENDmsg);
            Mainform.mainForm.TcpServer.Send(SENDmsg, ip_port);
            
        }
        /// <summary>
        /// 生成校验和
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String makeChecksum(String data)
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
