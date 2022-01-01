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
        public static void Call(BaseArch arch, Instruction ins, MethodDef def)
        {
            var prevIns = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];
            if(prevIns.OpCode.Code == Code.Ldstr) 
            {
                //It crashes VirtualBox but works in qemu
                //Console.WriteLine($"Warning: The string \"{prevIns.Operand}\" will be disposed automatically (call from Call.cs)");
                //arch.Append("push qword [rsp]");
            }

            if (ins.Operand is MemberRef)
                arch.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType, Name = ((MemberRef)ins.Operand).Name }, ((MemberRef)ins.Operand).MethodSig)}");
            else
                arch.Append($"call {Utility.SafeMethodName((MethodDef)ins.Operand, ((MethodDef)ins.Operand).MethodSig)}"); 
            
            if (prevIns.OpCode.Code == Code.Ldstr)
            {
                //arch.Append("call System.GC.Dispose.Object");
            }
        }
    }
}
