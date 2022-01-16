using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldflda)]
        public static void Ldflda(Context context)
        {
            if (context.nextInstruction.OpCode.Code == Code.Initobj) return;

            context.Append("pop rax");
            context.Append($"add rax,{Utility.SizeOfOrIndex(context.operand is MemberRef ? (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType : ((FieldDef)context.operand).DeclaringType, context.operand is MemberRef ? ((MemberRef)context.operand).Name : ((FieldDef)context.operand).Name)}");
            context.Append("push rax");
        }
    }
}
