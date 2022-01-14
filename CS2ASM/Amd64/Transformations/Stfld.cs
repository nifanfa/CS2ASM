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
            context.Append($"pop rax");
            context.Append($"pop rdi");
            context.Append($"add rdi,{Utility.SizeOfOrIndex(context.ins.Operand is MemberRef ? (TypeDef)((MemberRef)context.ins.Operand).DeclaringType.ScopeType : ((FieldDef)context.ins.Operand).DeclaringType, context.ins.Operand is MemberRef ? ((MemberRef)context.ins.Operand).Name : ((FieldDef)context.ins.Operand).Name)}");
            switch (Utility.SizeOfShallow(context.ins.Operand is MemberRef ? ((MemberRef)context.ins.Operand).FieldSig.Type : ((FieldDef)context.ins.Operand).FieldType)) 
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
