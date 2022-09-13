using System;
using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class Interrupts
    {
        [DllImport("libwiringPi.so", EntryPoint = "waitForInterrupt")]
        public static extern int waitForInterrupt(int pin, int timeout);

        [DllImport("libwiringPi.so", EntryPoint = "wiringPiISR")]
        public static extern int WiringPiPiISR(int pin, int mode, Action method);
    }
}