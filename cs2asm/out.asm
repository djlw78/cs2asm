;Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
;
;Test.Program
;
;
;
;
;
;System.Void Test.Program::Main()
system.void~test.program#main@:
;
;
push ebp
mov ebp, esp
sub esp, 32
;IL_0000: nop
;IL_0001: ldc.i4.s 65
;IL_0003: ldc.i4.0
;IL_0004: call System.Void Test.Program::PintChar(System.Char,System.Int32)
;IL_0009: nop
;IL_000a: ret
ret
;System.Void Test.Program::PintChar(System.Char,System.Int32)
system.void~test.program#pintchar@system.char$system.int32:
;
;
push ebp
mov ebp, esp
sub esp, 8
;IL_0000: nop
push 753664
;IL_0006: conv.i
;IL_0007: stloc.0
;IL_0008: ldloc.0
;IL_0009: ldarg.0
;IL_000a: conv.u1
;IL_000b: stind.i1
;IL_000c: ret
ret
;System.Void Test.Program::.ctor()
system.void~test.program#.ctor@:
;
;
push ebp
mov ebp, esp
sub esp, 32
;IL_0000: ldarg.0
;IL_0001: call System.Void System.Object::.ctor()
;IL_0006: nop
;IL_0007: ret
ret

SECTION .data
