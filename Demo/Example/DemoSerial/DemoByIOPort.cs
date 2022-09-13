using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using static System.Net.WebRequestMethods;

namespace Demo.Example.DemoSerial
{
    public class DemoByIOPort
    {

        public static void Run()
        {
            SerialPort serial = new SerialPort("/dev/ttyS3", 9600, Parity.None, 8, StopBits.One);
            serial.Open();
            // DataReceived是串口类的一个事件，通过+=运算符订阅事件，如果串口接收到数据就触发事件，调用DataReceive_Method事件处理方法
            serial.DataReceived += new SerialDataReceivedEventHandler(DataReceive_Method);
            while (true)
            {
                //查光照度指令
                serial.Write(strToHexByte("01 03 00 02 00 02 65 CB"), 0, 8);
                Thread.Sleep(2000);
            }
        }
        /// <summary>
        /// 接收信息事件处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataReceive_Method(object sender, SerialDataReceivedEventArgs e)
        {
            //sender是事件触发对象，通过它可以获取到mySerialPort
            SerialPort serialport = (SerialPort)sender;
            int len = serialport.BytesToRead;
            byte[] recvdata = new byte[len];
            serialport.Read(recvdata, 0, len);
            var str = byteToHexStr(recvdata);
            if (str.Length > 10)
            {
                string result = str.Substring(6, 8);
                int result16 = To16Convert10(result);
                Console.WriteLine(System.DateTime.Now + " 光照强度:" + (result16 / 1000.0).ToString() + "lur");
            }
        }
        /// <summary>
        /// 字符串转16位字节
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToHexByte(string hexString)

        {

            hexString = hexString.Replace(" ", "");

            if ((hexString.Length % 2) != 0)

                hexString += " ";

            byte[] returnBytes = new byte[hexString.Length / 2];

            for (int i = 0; i < returnBytes.Length; i++)

                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return returnBytes;

        }
        /// <summary>
        /// 十六进制字符串转十进制
        /// </summary>
        /// <param name="str">十六进制字符</param>
        /// <returns></returns>
        public static int To16Convert10(string str)
        {
            int res = 0;

            try
            {
                str = str.Trim().Replace(" ", "");//移除空字符
                                                  //方法1
                res = int.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier);


            }
            catch (Exception e)
            {
                res = 0;
            }

            return res;

        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X").PadLeft(2, '0');
                }
            }
            return returnStr;
        }
    }
}

