using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(Context context)
        {
            context.Pop("rax");
            context.StackOperationCount -= 1;
            context.Append($"add rax,{Utility.SizeOfOrIndex(context.operand is MemberRef ? (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType : ((FieldDef)context.operand).DeclaringType, context.operand is MemberRef ? ((MemberRef)context.operand).Name : ((FieldDef)context.operand).Name)}");
            context.Append($"xor rcx,rcx");
            switch (Utility.SizeOfShallow(context.operand is MemberRef ? ((MemberRef)context.operand).FieldSig.Type : ((FieldDef)context.operand).FieldType))
            {
                case 1:
                    context.Append($"mov cl,[rax]");
                    break;
                case 2:
                    context.Append($"mov cx,[rax]");
                    break;
                case 4:
                    context.Append($"mov ecx,[rax]");
                    break;
                default:
                    context.Append($"mov rcx,[rax]");
                    break;
            }
            context.Push("qword rcx");
            context.StackOperationCount += 1;
        }
    }
}
