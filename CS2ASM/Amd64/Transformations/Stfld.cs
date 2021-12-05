using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stfld)]
        public static void Stfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            int index = ((FieldDef)ins.Operand).DeclaringType.Fields.IndexOf((FieldDef)ins.Operand);
            Debug.Assert(index != -1);
            arch.Append($"pop rax");
            arch.Append($"pop rdi");
            arch.Append($"add rdi,{(index) * 8}");
            arch.Append($"stosq");
        }
    }
}
