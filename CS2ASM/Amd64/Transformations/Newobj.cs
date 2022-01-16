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
            context.Append($"call {context.arch.GetCompilerMethod(Methods.Allocate)}");

            //Get result value from System.GC.Allocate.UInt64 and make a copy for ldloc because call will pop the params
            context.Append($"pop r15");
            context.Append($"push r15");
            context.Append($"push r15");

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
            context.Append($"mov [r15],rcx");


            if (context.numberOfVariable <= 6)
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
            if (context.operand is MemberRef)
            {
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)context.operand).DeclaringType.ScopeType,Name = ((MemberRef)context.operand).Name}, ((MemberRef)context.operand).MethodSig)}");
            }
            else
            {
                context.Append($"call {Utility.SafeMethodName((MethodDef)context.operand, ((MethodDef)context.operand).MethodSig)}");
            }
        }
    }
}
