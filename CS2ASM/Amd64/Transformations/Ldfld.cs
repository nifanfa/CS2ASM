using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            context.Append("pop rax");
            context.Append($"add rax,{Utility.SizeOfOrIndex(ins.Operand is MemberRef ? (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType : ((FieldDef)ins.Operand).DeclaringType, ins.Operand is MemberRef ? ((MemberRef)ins.Operand).Name : ((FieldDef)ins.Operand).Name)}");
            context.Append($"xor rcx,rcx");
            switch (Utility.SizeOfShallow(ins.Operand is MemberRef ? ((MemberRef)ins.Operand).FieldSig.Type : ((FieldDef)ins.Operand).FieldType))
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
