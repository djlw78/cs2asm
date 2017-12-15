using System;

namespace Test
{
    public unsafe class Program
    {
        static void Main()
        {
            var terminal = (byte*) 0xB8000;
            terminal[0] = (byte) 'A';
        }
    }
}