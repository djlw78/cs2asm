using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm
{
    public class Ldarg : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Ldarg)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldarg_0)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldarg_1)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldarg_2)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldarg_3)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Ldarg_S)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            int num = 0;

            if (c.OpCode == OpCodes.Ldarg)
            {
                num = (int)c.Operand;
            }
            else
            {
                num = int.Parse(c.OpCode.Name.Split('.').Last());
            }

            var offset = md.Body.Variables.Count * 4;

            writer.Mov("eax", $"[ebp+{offset + 4}]");
            writer.Push("eax");
        }
    }
}
