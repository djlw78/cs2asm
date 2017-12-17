using System;

namespace Test
{
    public unsafe class Program
    {
        static void Main()
        {
            PintChar('A', 0);
        }

        static void PintChar(char c, int i)
        {
            var terminal = (byte*)0xB8000;
            terminal[0] = (byte)c;
        }
    }
}