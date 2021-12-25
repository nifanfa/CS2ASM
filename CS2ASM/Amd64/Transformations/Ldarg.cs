using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldarg)]
        public static void Ldarg(BaseArch arch, Instruction ins, MethodDef def)
        {
            var next = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];
            if(
                next.OpCode.Code == Code.Ldind_I ||
                next.OpCode.Code == Code.Ldind_I1 ||
                next.OpCode.Code == Code.Ldind_I2 ||
                next.OpCode.Code == Code.Ldind_I4 ||
                next.OpCode.Code == Code.Ldind_I8 ||

                next.OpCode.Code == Code.Ldind_R4 ||
                next.OpCode.Code == Code.Ldind_R8 ||

                next.OpCode.Code == Code.Ldind_Ref ||

                next.OpCode.Code == Code.Ldind_U1 ||
                next.OpCode.Code == Code.Ldind_U2 ||
                next.OpCode.Code == Code.Ldind_U4
                ) 
            {
                var p = def.Parameters[(int)OperandParser.Ldarg(ins)];
                
                if(!p.Type.IsPointer)
                {
                    arch.SkipNextInstruction();
                }
            }
            arch.Append($"push qword [rbp+{((ulong)def.Parameters.Count + 0 - OperandParser.Ldarg(ins)) * 8}]");
        }
    }
}
