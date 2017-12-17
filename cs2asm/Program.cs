using System;

namespace cs2asm
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Compiler("TestOS");
            c.Compile("..\\Test\\bin\\Debug\\netcoreapp2.0\\Test.dll");

            c.WriteToFile("out.asm");
            
        }
    }
}
