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
            arch.Append($"mov rax,{Util.SizeOfInStack(((TypeDef)ins.Operand).Fields)}");
            arch.Append($"push rax");
        }
    }
}
