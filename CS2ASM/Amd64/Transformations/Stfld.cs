using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stfld)]
        public static void Stfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            int index = def.DeclaringType.Fields.IndexOf((FieldDef)ins.Operand);
            arch.Append($"pop rax");
            arch.Append($"pop rdi");
            arch.Append($"add rdi,{(index + 1) * 8}");
            arch.Append($"stosq");
        }
    }
}
