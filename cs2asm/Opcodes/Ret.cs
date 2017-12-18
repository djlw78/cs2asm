using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class Ret : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Ret)
            {
                return true;
            }
            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            writer.Jmp(Compiler.NormaliseName(md.FullName) + "_ret");
        }
    }
}
