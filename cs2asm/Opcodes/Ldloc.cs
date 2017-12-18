using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class Ldloc : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Ldloc)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldloc_0)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldloc_1)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldloc_2)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldloc_3)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldloc_S)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            int num = 0;

            if (c.OpCode == OpCodes.Ldloc)
            {
                num = (int)c.Operand;
            }
            else
            {
                num = int.Parse(c.OpCode.Name.Split('.').Last());
            }

            var offset = md.Body.Variables.Count * 4;
            
            writer.Mov("eax", $"[ebp-{offset}]");
            writer.Push("eax");
        }
    }
}
