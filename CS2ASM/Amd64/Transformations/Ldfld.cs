using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append("pop rax");
            arch.Append($"add rax,{Utility.SizeOfOrIndex(ins.Operand is MemberRef ? (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType : ((FieldDef)ins.Operand).DeclaringType, ins.Operand is MemberRef ? ((MemberRef)ins.Operand).Name : ((FieldDef)ins.Operand).Name)}");
            arch.Append($"xor rcx,rcx");
            switch (Utility.SizeOfShallow(ins.Operand is MemberRef ? ((MemberRef)ins.Operand).FieldSig.Type : ((FieldDef)ins.Operand).FieldType))
            {
                case 1:
                    arch.Append($"mov cl,[rax]");
                    break;
                case 2:
                    arch.Append($"mov cx,[rax]");
                    break;
                case 4:
                    arch.Append($"mov ecx,[rax]");
                    break;
                default:
                    arch.Append($"mov rcx,[rax]");
                    break;
            }
            arch.Append("push qword rcx");
        }
    }
}
