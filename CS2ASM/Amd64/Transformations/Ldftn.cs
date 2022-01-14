using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldftn)]
        public static void Ldftn(Context context)
        {
            if((context.ins.Operand is MethodDef)) 
            {
                context.Append($"mov qword rax,{Utility.SafeMethodName((MethodDef)context.ins.Operand, ((MethodDef)context.ins.Operand).MethodSig)}");
                context.Append($"push rax");
            }
            else
            {
                throw new NotImplementedException("Ldftn is not implemented");
            }
        }
    }
}
