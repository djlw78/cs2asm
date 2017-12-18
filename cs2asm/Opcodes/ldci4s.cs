using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class ldci4s : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Ldc_I4_S)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            writer.Push(c.Operand.ToString());
        }
    }
}
