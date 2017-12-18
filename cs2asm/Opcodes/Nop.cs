using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class Nop : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Nop)
            {
                return true;
            }
            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
           
        }
    }
}
