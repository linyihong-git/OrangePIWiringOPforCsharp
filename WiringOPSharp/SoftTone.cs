using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class SoftTone
    {
        [DllImport("libwiringPi.so", EntryPoint = "softToneCreate")]
        public static extern int SoftToneCreate(int pi);

        [DllImport("libwiringPi.so", EntryPoint = "softToneWrite")]
        public static extern void SoftToneWrite(int pin, int frewq);
    }
}