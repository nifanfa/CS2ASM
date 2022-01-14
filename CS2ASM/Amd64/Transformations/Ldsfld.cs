using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldsfld)]
        public static void Ldsfld(Context context)
        {
            //context.Append($"push qword [{def.DeclaringType.SafeTypeName() + "_" + ((FieldDef)ins.Operand).Name}]");
            context.Append($"mov qword rax,[{Utility.SafeFieldName(((FieldDef)context.ins.Operand).DeclaringType, (FieldDef)context.ins.Operand)}]");
            context.Append($"push rax");
        }
    }
}
