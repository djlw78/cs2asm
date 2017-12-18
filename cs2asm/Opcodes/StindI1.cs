using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class StindI1 : Opcode
    {
        public override bool IsMe(Instruction c)
        {

            if (c.OpCode == OpCodes.Stind_I1)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            writer.Pop("eax"); // address
            writer.Pop("ebx"); // value
            writer.Mov("[eax]", "ebx");
        }
    }
}
