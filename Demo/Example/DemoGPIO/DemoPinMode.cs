using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiringOPSharp;

namespace Demo.Example.DemoGPIO
{
    public class DemoPinMode
    {
        public static void Run()
        {
            Setup.WiringPiPiSetup();
            GPIO.PinMode(4, WiringPi.Output);
            while (true)
            {
                GPIO.DigitalWrite(4, WiringPi.High);
                Thread.Sleep(500);
                GPIO.DigitalWrite(4, WiringPi.Low);
                Thread.Sleep(500);
            }
        }
}
}
