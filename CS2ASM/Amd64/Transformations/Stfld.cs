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
            arch.Append($"pop rax");
            arch.Append($"pop rdi");
            arch.Append($"add rdi,{Utility.SizeOfOrIndex(ins.Operand is MemberRef ? (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType : ((FieldDef)ins.Operand).DeclaringType, ins.Operand is MemberRef ? ((MemberRef)ins.Operand).Name : ((FieldDef)ins.Operand).Name)}");
            switch (Utility.SizeOfShallow(ins.Operand is MemberRef ? ((MemberRef)ins.Operand).FieldSig.Type : ((FieldDef)ins.Operand).FieldType)) 
            {
                case 1:
                    arch.Append($"stosb");
                    break;
                case 2:
                    arch.Append($"stosw");
                    break;
                case 4:
                    arch.Append($"stosd");
                    break;
                default:
                    arch.Append($"stosq");
                    break;
            }
        }
    }
}
