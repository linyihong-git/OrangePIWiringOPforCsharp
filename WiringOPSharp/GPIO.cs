using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class GPIO
    {
        [DllImport("libwiringPi.so", EntryPoint = "pinMode")]
        public static extern void PinMode(int pin, int mode);

        [DllImport("libwiringPi.so", EntryPoint = "pullUpDnControl")]
        public static extern void PullUpDnControl(int pin, int pud);

        [DllImport("libwiringPi.so", EntryPoint = "digitalRead")]
        public static extern int DigitalRead(int pin);

        [DllImport("libwiringPi.so", EntryPoint = "digitalWrite")]
        public static extern void DigitalWrite(int pin, int value);

        [DllImport("libwiringPi.so", EntryPoint = "pwmWrite")]
        public static extern void PwmWrite(int pin, int value);

        [DllImport("libwiringPi.so", EntryPoint = "analogRead")]
        public static extern int AnalogRead(int pin);

        [DllImport("libwiringPi.so", EntryPoint = "analogWrite")]
        public static extern void AnalogWrite(int pin, int value);
    }
}