using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldelem)]
        public static void Ldelem(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop r14"); //index
            arch.Append($"pop r15"); //ptr

            arch.Append($"xor rdx,rdx");
            arch.Append($"mov rax,8");
            arch.Append($"mul r14");
            arch.Append($"add r15,rax");
            arch.Append($"add r15,{Utility.SizeOf(def.Module,"System.Array")}");
            arch.Append($"push qword [r15]");
        }
    }
}
