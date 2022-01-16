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
            if(context.numberOfVariable <= 6)
            {
                if (context.numberOfVariable >= 1)
                {
                    context.Append($"mov rdi,[rsp+{(context.numberOfVariable - 1) * 8}]");
                }
                if (context.numberOfVariable >= 2)
                {
                    context.Append($"mov rsi,[rsp+{(context.numberOfVariable - 2) * 8}]");
                }
                if (context.numberOfVariable >= 3)
                {
                    context.Append($"mov rdx,[rsp+{(context.numberOfVariable - 3) * 8}]");
                }
                if (context.numberOfVariable >= 4)
                {
                    context.Append($"mov rcx,[rsp+{(context.numberOfVariable - 4) * 8}]");
                }
                if (context.numberOfVariable >= 5)
                {
                    context.Append($"mov r8,[rsp+{(context.numberOfVariable - 5) * 8}]");
                }
                if (context.numberOfVariable >= 6)
                {
                    context.Append($"mov r9,[rsp+{(context.numberOfVariable - 6) * 8}]");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Too much argument");
            }
            context.Append($"add rsp,{context.numberOfVariable * 8}");

            /*
            if (context.prevInstruction.OpCode.Code == Code.Ldstr 
                && context.numberOfVariable == 1
                && !context.hasReturn) 
            {
                Console.WriteLine($"Warning: The string \"{context.prevInstruction.Operand}\" will be disposed automatically");
                context.Append("mov r15,[rsp]");
                context.Append("push r15");
            }
            */

            if (context.operand is MemberRef)
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType, Name = ((MemberRef)context.operand).Name }, context.methodSig)}");
            else
                context.Append($"call {Utility.SafeMethodName((MethodDef)context.operand, context.methodSig)}");

            /*
            if (context.prevInstruction.OpCode.Code == Code.Ldstr
                && !context.hasReturn)
            {
                context.Append($"mov rdi,[rsp]");
                context.Append($"call {context.arch.GetCompilerMethod(Methods.Dispose)}");
            }
            */
        }
    }
}
