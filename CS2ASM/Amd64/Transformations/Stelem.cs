using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stelem)]
        public static void Stelem(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rbx"); //value
            arch.Append($"pop rdi"); //index
            arch.Append($"pop rsi"); //ptr
            arch.Append($"xor rdx,rdx");
            arch.Append($"mov rax,8");
            arch.Append($"mul rdi");
            arch.Append($"add rsi,rax");
            arch.Append($"add rsi,{Utility.SizeOf(def.Module, "System.Array")}");
            arch.Append($"mov qword [rsi],rbx");
        }
    }
}
