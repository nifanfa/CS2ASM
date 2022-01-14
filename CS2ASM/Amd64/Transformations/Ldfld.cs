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
            context.Append("pop rax");
            context.Append($"add rax,{Utility.SizeOfOrIndex(context.ins.Operand is MemberRef ? (TypeDef)((MemberRef)context.ins.Operand).DeclaringType.ScopeType : ((FieldDef)context.ins.Operand).DeclaringType, context.ins.Operand is MemberRef ? ((MemberRef)context.ins.Operand).Name : ((FieldDef)context.ins.Operand).Name)}");
            context.Append($"xor rcx,rcx");
            switch (Utility.SizeOfShallow(context.ins.Operand is MemberRef ? ((MemberRef)context.ins.Operand).FieldSig.Type : ((FieldDef)context.ins.Operand).FieldType))
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
            context.Append("push qword rcx");
        }
    }
}
