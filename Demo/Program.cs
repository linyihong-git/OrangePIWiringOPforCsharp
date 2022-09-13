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
            DemoSerial.Run();
        }
    }
}
