using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Add_Ovf)]
        public static void Add_Ovf(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Add_Ovf is not implemented");
        }
    }
}
