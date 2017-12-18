using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace cs2asm.Opcodes
{
    public class Call : Opcode
    {
        public override bool IsMe(Instruction c)
        {
            if (c.OpCode == OpCodes.Call)
            {
                return true;
            }
            return false;
        }

        public override void Emit(MethodDefinition md, Instruction c, AssemblyWriter writer)
        {
            writer.Call(Compiler.NormaliseName(c.Operand.ToString()));

            var x = ((MethodReference) c.Operand).Resolve();

            if (!x.HasParameters) return;


            writer.Add("esp", ((x.Parameters.Count) * 4).ToString());
        }
    }
}