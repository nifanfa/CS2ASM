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

            if(context.prevInstruction.OpCode.Code == Code.Ldstr) 
            {
                //It crashes VirtualBox but works in qemu
                //Console.WriteLine($"Warning: The string \"{prevIns.Operand}\" will be disposed automatically (call from Call.cs)");
                //context.Append("push qword [rsp]");
            }

            if (context.ins.Operand is MemberRef)
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)context.ins.Operand).DeclaringType.ScopeType, Name = ((MemberRef)context.ins.Operand).Name }, context.methodSig)}");
            else
                context.Append($"call {Utility.SafeMethodName((MethodDef)context.ins.Operand, context.methodSig)}"); 
            
            if (context.prevInstruction.OpCode.Code == Code.Ldstr)
            {
                //context.Append($"call {arch.GetCompilerMethod(Methods.Dispose)}");
            }
        }
    }
}
