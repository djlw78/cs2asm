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
                    Opcodes.Add((Opcode)Activator.CreateInstance(type));
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
            Writer.Comment("");
            Writer.Comment("");
            foreach (var bodyInstruction in md.Body.Instructions)
            {
               
                bool found = false;
                foreach (var opcode in Opcodes)
                {
                    if (opcode.IsMe(bodyInstruction))
                    {
                        opcode.Emit(bodyInstruction, Writer);
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
        }


        public void WriteToFile(string file)
        {
            File.WriteAllText(file, Writer.ToString());
        }
    }
}