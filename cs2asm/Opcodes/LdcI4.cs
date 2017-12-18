using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
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

            if (c.OpCode == OpCodes.Ldc_I4_0)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            if (c.Operand != null)
            {
                writer.Push(c.Operand.ToString());
            }
            else
            {
                writer.Push(c.OpCode.Name.Split('.').Last());
            }
        }
    }
}
