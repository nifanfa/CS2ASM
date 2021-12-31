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
                Console.WriteLine($"Warning: The string \"{prevIns.Operand}\" will be disposed automatically (call from Call.cs)");
                arch.Append("push qword [rsp]");
            }
            arch.Append($"call {Utility.SafeMethodName(((MethodDef)ins.Operand))}");
            if (prevIns.OpCode.Code == Code.Ldstr)
            {
                arch.Append("call System.Object.Dispose");
            }
        }
    }
}
