using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            /*
            arch.Append($"call System.Runtime.CompilerServices.Unsafe.Stackalloc");
            arch.Append($"pop rbp");
            arch.Append($"push rax");
            arch.Append($"call {Util.SafeMethodName((MethodDef)ins.Operand)}");
            arch.Append($"pop rbp");
            //arch.Append($"add rsp,8"); //This will be called by stloc so we don't need to do it here
            */
            throw new NotImplementedException();
        }
    }
}
