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
push 65
push 0
call system.void~test.program#pintchar@system.char$system.int32
add esp, 8
jmp system.void~test.program#main@_ret
system.void~test.program#main@_ret:
ret
;System.Void Test.Program::PintChar(System.Char,System.Int32)
system.void~test.program#pintchar@system.char$system.int32:
;
;
push ebp
mov ebp, esp
sub esp, 8
push 753664
;IL_0006: conv.i
pop eax
mov [ebp-4], eax
;IL_0008: ldloc.0
;IL_0009: ldarg.0
;IL_000a: conv.u1
;IL_000b: stind.i1
jmp system.void~test.program#pintchar@system.char$system.int32_ret
system.void~test.program#pintchar@system.char$system.int32_ret:
ret
;System.Void Test.Program::.ctor()
system.void~test.program#.ctor@:
;
;
push ebp
mov ebp, esp
sub esp, 32
;IL_0000: ldarg.0
call system.void~system.object#.ctor@
jmp system.void~test.program#.ctor@_ret
system.void~test.program#.ctor@_ret:
ret

SECTION .data
