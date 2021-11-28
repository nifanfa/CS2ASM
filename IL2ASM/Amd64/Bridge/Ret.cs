using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Ret)]
        public static void Ret(Arch arch, Instruction ins, MethodDef def)
        {
            if (def.Module.EntryPoint != def)
            {
                //recover
                arch.Append($"push qword [rbp+8]");
                arch.Append($"ret");
            }
            else
            {
                arch.Append($"jmp die");
            }
        }
    }
}
