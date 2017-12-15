using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class LdcI4 : Opcode
    {
        public override bool IsMe(Instruction c)
        {

            if (c.OpCode == OpCodes.Ldc_I4)
            {
                return true;
            }

            return false;
        }

        public override void Emit(Instruction c, AssemblyWriter writer)
        {
            writer.Push(c.Operand.ToString());
        }
    }
}
