using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiringOPSharp;


namespace Demo.Example.DemoSerial
{
    public class DemoSerial
    {
        public static void Run()
        {
            string device = "/dev/ttyS3";
            if (Setup.WiringPiPiSetup() < 0)
            {
                Console.WriteLine("Wringpi setup failed.");
                return;
            }
            
            int fd = Serial.SerialOpen(device, 115200);
            if (fd < 0)
            {
                Console.WriteLine("Serial ppen failed.");
                return;
            }
            

            //异步执行串口读取  
            Task readTask = Task.Run(() => SerialRead(fd));
            //发送
            while (true)
            {
                Console.Write("TX:");
                string send = Console.ReadLine();
                if (string.IsNullOrEmpty(send))
                {
                    continue;
                }
                if (send == "exit")
                {
                    break;
                }
                Serial.SerialPuts(fd, send);
            }
            Serial.SerialClose(fd);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(false);
        }

        public static void SerialRead(int fd)
        {
            while (true)
            {
                StringBuilder sb = null;
                while (Serial.SerialDataAvail(fd) > 0)
                {
                    int read = Serial.SerialGetchar(fd);
                    if (read < 0)
                    {
                        Serial.SerialFlush(fd);
                        break;
                    }
                    else
                    {
                        //Remove \r or \n
                        if (read == 10 || read == 13)
                        {
                            continue;
                        }
                        else
                        {
                            if (sb == null)
                            {
                                sb = new StringBuilder();
                            }
                            sb.Append((char)read);
                        }
                    }
                }
                if (sb != null)
                {
                    string readStr = sb.ToString();
                    if (!string.IsNullOrWhiteSpace(readStr))
                    {
                        Console.WriteLine($"RX:{sb.ToString()}");
                    }
                }
            }
        }
    }
}
