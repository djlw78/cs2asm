using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs2asm
{
    public abstract class Opcode
    {
        public abstract bool IsMe(Instruction c);
        public abstract void Emit(Instruction c, AssemblyWriter writer);

    }
}
