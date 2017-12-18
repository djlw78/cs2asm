using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class Stloc : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Stloc)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Stloc_0)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Stloc_1)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Stloc_2)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Stloc_3)
            {
                return true;
            }

            if (c.OpCode == OpCodes.Stloc_S)
            {
                return true;
            }

            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            int num = 0;

            if (c.OpCode == OpCodes.Stloc)
            {
                num = (int) c.Operand;
            }
            else
            {
                num = int.Parse(c.OpCode.Name.Split('.').Last());
            }

            var offset = 0;
            /*
            for (int i = 0; i < num + 1; i++)
            {
                offset += Marshal.SizeOf(Type.GetType(md.Body.Variables[i].VariableType.FullName));
            }*/
            offset = md.Body.Variables.Count * 4;

            writer.Pop("eax");
            writer.Mov($"[ebp-{offset}]", "eax");
        }
    }
}