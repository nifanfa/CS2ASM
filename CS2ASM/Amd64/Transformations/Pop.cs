using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Pop)]
        public static void Pop(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Pop is not implemented");
        }
    }
}
