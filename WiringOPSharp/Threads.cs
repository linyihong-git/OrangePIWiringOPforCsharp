using System;
using System.Runtime.InteropServices;

namespace WiringOPSharp
{
    public static class Threads
    {
        [DllImport("libwiringPi.so", EntryPoint = "piThreadCreate")]
        public static extern int PiThreadCreate([MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr> method);

        [DllImport("libwiringPi.so", EntryPoint = "piLock")]
        public static extern void PiLock(int key);

        [DllImport("libwiringPi.so", EntryPoint = "piUnlock")]
        public static extern void PiUnlock(int key);
    }
}