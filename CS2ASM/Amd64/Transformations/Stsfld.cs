using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILTransformation(Code.Stsfld)]
        public static void Stsfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"mov [{Amd64.SafeFieldName(def.DeclaringType, (FieldDef)ins.Operand)}],rax");
        }
    }
}
