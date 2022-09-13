using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class SPI
    {
        [DllImport("libwiringPi.so", EntryPoint = "wiringPiSPIGetFd")]
        public static extern int WiringPiPiSPIGetFd(int channel);

        [DllImport("libwiringPi.so", EntryPoint = "wiringPiSPIDataRW")]
        public static extern int WiringPiPiSPIDataRW(int channel, HandleRef handle);

        [DllImport("libwiringPi.so", EntryPoint = "wiringPiSPISetup")]
        public static extern int WiringPiPiSPISetup(int channel, int speed);
    }
}