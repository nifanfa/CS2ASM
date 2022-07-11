using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stfld)]
        public static void Stfld(Context context)
        {
            context.Pop($"rax");
            context.Pop($"rdi");
            context.StackOperationCount -= 2;
            context.Append($"add rdi,{Utility.SizeOfOrIndex(context.operand is MemberRef ? (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType : ((FieldDef)context.operand).DeclaringType, context.operand is MemberRef ? ((MemberRef)context.operand).Name : ((FieldDef)context.operand).Name)}");
            switch (Utility.SizeOfShallow(context.operand is MemberRef ? ((MemberRef)context.operand).FieldSig.Type : ((FieldDef)context.operand).FieldType)) 
            {
                case 1:
                    context.Append($"stosb");
                    break;
                case 2:
                    context.Append($"stosw");
                    break;
                case 4:
                    context.Append($"stosd");
                    break;
                default:
                    context.Append($"stosq");
                    break;
            }
        }
    }
}
