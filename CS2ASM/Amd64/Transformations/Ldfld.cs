using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            int index = def.DeclaringType.Fields.IndexOf((FieldDef)ins.Operand);
            arch.Append("pop rsi");
            arch.Append($"add rsi,{(index + 1) * 8}");
            arch.Append("push qword [rsi+8]");
        }
    }
}
