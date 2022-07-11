using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stsfld)]
        public static void Stsfld(Context context)
        {
            context.Pop($"rax");
            context.StackOperationCount -= 1;
            context.Append($"mov [{Utility.SafeFieldName(((FieldDef)context.operand).DeclaringType, (FieldDef)context.operand)}],rax");
        }
    }
}
