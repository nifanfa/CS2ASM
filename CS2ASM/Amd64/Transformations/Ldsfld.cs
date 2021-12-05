using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldsfld)]
        public static void Ldsfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            //arch.Append($"push qword [{def.DeclaringType.SafeTypeName() + "_" + ((FieldDef)ins.Operand).Name}]");
            arch.Append($"push qword [{Amd64.SafeFieldName(((FieldDef)ins.Operand).DeclaringType, (FieldDef)ins.Operand)}]");
        }
    }
}