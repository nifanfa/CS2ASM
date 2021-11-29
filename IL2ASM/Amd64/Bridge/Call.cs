using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Call)]
        public static void Call(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call {((MethodDef)ins.Operand).SafeMethodName()}");
            //Ret.cs line 15
            if (((MethodDef)ins.Operand).HasReturnType) 
            {
                arch.Append($"push qword [rbp+16]");
            }
        }
    }
}
