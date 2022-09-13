using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class Timing
    {
        [DllImport("libwiringPi.so", EntryPoint = "delay")]
        public static extern void Delay(uint howLong);

        [DllImport("libwiringPi.so", EntryPoint = "delayMicroseconds")]
        public static extern void DelayMicroseconds(uint howLong);

        [DllImport("libwiringPi.so", EntryPoint = "millis")]
        public static extern uint Millis();

        [DllImport("libwiringPi.so", EntryPoint = "micros")]
        public static extern uint Micros();
    }
}