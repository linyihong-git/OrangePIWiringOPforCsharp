using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class SoftPwm
    {
        [DllImport("libwiringPi.so", EntryPoint = "softPwmCreate")]
        public static extern int SoftPwmCreate(int pin, int value, int range);

        [DllImport("libwiringPi.so", EntryPoint = "softPwmWrite")]
        public static extern void SoftPwmWrite(int pin, int value);
    }
}