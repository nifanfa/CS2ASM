using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(Context context)
        {
            int argumentNum = 0;
            if(context.operand is MemberRef) 
            {
                argumentNum = ((MemberRef)context.operand).MethodSig.Params.Count;
            }
            else 
            {
                argumentNum = ((MethodDef)context.operand).MethodSig.Params.Count;
            }
            Sizeof(new Context(context.text, new Instruction() { Operand = context.operand is MemberRef ? ((MemberRef)context.operand).DeclaringType.ScopeType : ((MethodDef)context.operand).DeclaringType }, context.def, context.arch));
            context.Append($"pop rdi");
            context.StackOperationCount -= 1;
            context.Append($"call {context.arch.GetCompilerMethod(Methods.Allocate)}");
            context.Append($"push rax");
            context.StackOperationCount += 1;

            //Get result value from System.GC.Allocate.UInt64 and make a copy for ldloc because call will pop the params
            context.Append($"pop r15");
            context.StackOperationCount -= 1;
            context.Append($"push r15");
            context.Append($"push r15");
            context.StackOperationCount += 2;

            if (argumentNum != 0) 
            {
                //Move up stack
                for(int i = 0; i < argumentNum; i++) 
                {
                    context.Append($"mov rax,[rsp+{(i+2) * 8}]");
                    context.Append($"mov [rsp+{(i) * 8}],rax");
                }

                context.Append($"mov [rsp+{(argumentNum + 0) * 8}],r15");
                //For ldloc
                context.Append($"mov [rsp+{(argumentNum + 1) * 8}],r15");
            }

            Sizeof(new Context(context.text, new Instruction() { Operand = context.operand is MemberRef ? ((MemberRef)context.operand).DeclaringType.ScopeType : ((MethodDef)context.operand).DeclaringType }, context.def, context.arch));

            //Object.Size
            context.Append($"xor rdx,rdx");
            context.Append($"pop rcx");
            context.StackOperationCount -= 1;
            context.Append($"mov [r15],rcx");


            if (context.numberOfParams <= 6)
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
            context.Append($"add rsp,{context.numberOfParams * 8}");
            if (context.operand is MemberRef)
            {
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType,Name = ((MemberRef)context.operand).Name}, ((MemberRef)context.operand).MethodSig)}");
            }
            else
            {
                context.Append($"call {Utility.SafeMethodName((MethodDef)context.operand, ((MethodDef)context.operand).MethodSig)}");
            }
            if (context.hasReturn)
            {
                context.Append($"push rax");
                context.StackOperationCount += 1;
            }
        }
    }
}
