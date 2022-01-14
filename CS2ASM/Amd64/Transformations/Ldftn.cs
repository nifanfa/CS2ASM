using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldftn)]
        public static void Ldftn(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            if((ins.Operand is MethodDef)) 
            {
                context.Append($"mov qword rax,{Utility.SafeMethodName((MethodDef)ins.Operand, ((MethodDef)ins.Operand).MethodSig)}");
                context.Append($"push rax");
            }
            else
            {
                throw new NotImplementedException("Ldftn is not implemented");
            }
        }
    }
}
