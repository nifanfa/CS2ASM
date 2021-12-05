using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            int index = ((FieldDef)ins.Operand).DeclaringType.Fields.IndexOf((FieldDef)ins.Operand);
            Debug.Assert(index != -1);
            arch.Append("pop rax");
            arch.Append($"add rax,{(index) * 8}");
            arch.Append("push qword [rax]");
        }
    }
}
