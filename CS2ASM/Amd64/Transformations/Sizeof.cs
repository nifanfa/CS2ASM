using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Sizeof)]
        public static void Sizeof(BaseArch arch, Instruction ins, MethodDef def)
        {
            if (ins.Operand is TypeSpec)
                arch.Append($"mov rax,{arch.PointerSize}");
            else
                arch.Append($"mov rax,{Util.SizeOfInStack(((TypeDef)ins.Operand).Fields)}");
            arch.Append($"push rax");
        }
    }
}
