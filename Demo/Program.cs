using Demo.Example.DemoGPIO;
using Demo.Example.DemoSerial;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiringOPSharp;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //gpio
            DemoPinMode.Run();
            ////serial
            //DemoSerial.Run();
            ////serial DemoByIOPort
            //DemoByIOPort.Run();
        }
    }
}
