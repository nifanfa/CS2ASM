using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Call)]
        public static void Call(Context context)
        {
            //This is for calling c/c++ code
            if(context.numberOfParams <= 6)
            {
                if (context.numberOfParams >= 1)
                {
                    context.Append($"mov rdi,[rsp+{(context.numberOfParams - 1) * 8}]");
                }
                if (context.numberOfParams >= 2)
                {
                    context.Append($"mov rsi,[rsp+{(context.numberOfParams - 2) * 8}]");
                }
                if (context.numberOfParams >= 3)
                {
                    context.Append($"mov rdx,[rsp+{(context.numberOfParams - 3) * 8}]");
                }
                if (context.numberOfParams >= 4)
                {
                    context.Append($"mov rcx,[rsp+{(context.numberOfParams - 4) * 8}]");
                }
                if (context.numberOfParams >= 5)
                {
                    context.Append($"mov r8,[rsp+{(context.numberOfParams - 5) * 8}]");
                }
                if (context.numberOfParams >= 6)
                {
                    context.Append($"mov r9,[rsp+{(context.numberOfParams - 6) * 8}]");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Too much argument");
            }

            context.StackOperationCount -= context.numberOfParams;
            int rsv = context.numberOfParams * 8;
            if (rsv != 0)
                context.Append($"add rsp,{rsv}");

            if (context.operand is MemberRef)
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType, Name = ((MemberRef)context.operand).Name }, context.methodSig)}");
            else
                context.Append($"call {Utility.SafeMethodName((MethodDef)context.operand, context.methodSig)}");
            if (context.hasReturn) 
            {
                context.Push($"rax");
                context.StackOperationCount += 1;
            }
        }
    }
}
