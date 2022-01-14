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
        public static void Call(BaseArch arch, Instruction ins, MethodDef def, Context context)
        {
            int variCount = 0;
            if (ins.Operand is MemberRef)
                variCount = ((MemberRef)ins.Operand).MethodSig.Params.Count;
            else
                variCount = ((MethodDef)ins.Operand).MethodSig.Params.Count;
            
            //This is for calling c/c++ code
            if(variCount <= 6)
            {
                if (variCount >= 1)
                {
                    context.Append($"mov rdi,[rsp+{(variCount - 1) * 8}]");
                }
                if (variCount >= 2)
                {
                    context.Append($"mov rsi,[rsp+{(variCount - 2) * 8}]");
                }
                if (variCount >= 3)
                {
                    context.Append($"mov rdx,[rsp+{(variCount - 3) * 8}]");
                }
                if (variCount >= 4)
                {
                    context.Append($"mov rcx,[rsp+{(variCount - 4) * 8}]");
                }
                if (variCount >= 5)
                {
                    context.Append($"mov r8,[rsp+{(variCount - 5) * 8}]");
                }
                if (variCount >= 6)
                {
                    context.Append($"mov r9,[rsp+{(variCount - 6) * 8}]");
                }
            }

            var prevIns = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];
            if(prevIns.OpCode.Code == Code.Ldstr) 
            {
                //It crashes VirtualBox but works in qemu
                //Console.WriteLine($"Warning: The string \"{prevIns.Operand}\" will be disposed automatically (call from Call.cs)");
                //context.Append("push qword [rsp]");
            }

            if (ins.Operand is MemberRef)
                context.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType, Name = ((MemberRef)ins.Operand).Name }, ((MemberRef)ins.Operand).MethodSig)}");
            else
                context.Append($"call {Utility.SafeMethodName((MethodDef)ins.Operand, ((MethodDef)ins.Operand).MethodSig)}"); 
            
            if (prevIns.OpCode.Code == Code.Ldstr)
            {
                //context.Append($"call {arch.GetCompilerMethod(Methods.Dispose)}");
            }
        }
    }
}
