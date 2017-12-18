using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Mono.Cecil;

namespace cs2asm
{
    public class Compiler
    {
        public AssemblyWriter Writer = new AssemblyWriter();

        private List<Opcode> Opcodes { get; set; } = new List<Opcode>();


        public Compiler(string projectName)
        {
            ProjectName = projectName;

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType == typeof(Opcode))
                {
                    Opcodes.Add((Opcode) Activator.CreateInstance(type));
                }
            }
        }

        public string ProjectName { get; set; }

        public void Compile(string assembly)
        {
            var f = Path.GetFullPath(assembly);
            CompileAssembly(AssemblyDefinition.ReadAssembly(f));
        }

        public void CompileAssembly(AssemblyDefinition ad)
        {
            Writer.Comment(ad.FullName);
            Writer.Comment("");

            foreach (var moduleDefinition in ad.Modules)
            {
                foreach (var f in moduleDefinition.Types)
                {
                    if (f.FullName != "<Module>")
                    {
                        CompileType(f);
                    }
                }
            }
        }

        public static string NormaliseName(string s)
        {
            return s.ToLower().Replace(" ", "~").Replace("::", "#").Replace("(", "@").Replace(")", "")
                .Replace(",", "$");
        }

        public void CompileType(TypeDefinition td)
        {
            Writer.Comment(td.FullName);
            Writer.Comment("");


            foreach (var propertyDefinition in td.Properties)
            {
                Writer.Comment(propertyDefinition.FullName);
            }
            Writer.Comment("");
            Writer.Comment("");
            foreach (var fieldDefinition in td.Fields)
            {
                Writer.Comment(fieldDefinition.FullName);
            }
            Writer.Comment("");
            Writer.Comment("");
            foreach (var methodDefinition in td.Methods)
            {
                Writer.Comment(methodDefinition.FullName);
                CompileMethod(methodDefinition);
            }
        }

        public void CompileMethod(MethodDefinition md)
        {
            if(md.IsConstructor) return;

            Writer.Label(NormaliseName(md.FullName));
            Writer.Comment("");
            Writer.Comment("");

            Writer.Push("ebp");
            Writer.Mov("ebp", "esp");
            Writer.Sub("esp", md.Body.MaxStackSize * 4);


            foreach (var bodyInstruction in md.Body.Instructions)
            {
                bool found = false;
                foreach (var opcode in Opcodes)
                {
                    if (opcode.IsMe(bodyInstruction))
                    {
                        if(md.HasBody) opcode.Emit(md, bodyInstruction, Writer);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Writer.Comment(bodyInstruction.ToString());
                    Console.WriteLine($"Found Missing Opcode: {bodyInstruction.ToString()}");
                }
            }

            Writer.Label(NormaliseName(md.FullName) + "_ret");

            Writer.Ret();
        }


        public void WriteToFile(string file)
        {
            File.WriteAllText(file, Writer.ToString());
        }

        public static int CalculateNativeSize(NativeType marshalInfoNativeType)
        {

            switch (marshalInfoNativeType)
            {
                case NativeType.None:
                    return 0;
                case NativeType.Boolean:
                    return 1;
                case NativeType.I1:
                    return 1;
                case NativeType.U1:
                    return 1;
                case NativeType.I2:
                    return 2;
                case NativeType.U2:
                    return 2;
                case NativeType.I4:
                    return 4;
                case NativeType.U4:
                    return 4;
                case NativeType.I8:
                    return 8;
                case NativeType.U8:
                    return 8;
                case NativeType.R4:
                    return 4;
                case NativeType.R8:
                    return 8;
                case NativeType.LPStr:
                    return 4;
                case NativeType.Int:
                    return 4;
                case NativeType.UInt:
                    return 4;
                case NativeType.Func:
                    return 4;
                case NativeType.Array:
                    return 4;
                case NativeType.Currency:
                    break;
                case NativeType.BStr:
                    break;
                case NativeType.LPWStr:
                    break;
                case NativeType.LPTStr:
                    break;
                case NativeType.FixedSysString:
                    break;
                case NativeType.IUnknown:
                    break;
                case NativeType.IDispatch:
                    break;
                case NativeType.Struct:
                    break;
                case NativeType.IntF:
                    break;
                case NativeType.SafeArray:
                    break;
                case NativeType.FixedArray:
                    break;
                case NativeType.ByValStr:
                    break;
                case NativeType.ANSIBStr:
                    break;
                case NativeType.TBStr:
                    break;
                case NativeType.VariantBool:
                    break;
                case NativeType.ASAny:
                    break;
                case NativeType.LPStruct:
                    break;
                case NativeType.CustomMarshaler:
                    break;
                case NativeType.Error:
                    break;
                case NativeType.Max:
                    break;
            }

            return 0;
        }
    }
}