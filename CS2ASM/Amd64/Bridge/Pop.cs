using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Pop)]
        public static void Pop(Arch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Pop is not implemented");
        }
    }
}
