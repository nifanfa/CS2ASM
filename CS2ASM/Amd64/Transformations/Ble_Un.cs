using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ble_Un)]
        public static void Ble_Un(BaseArch arch, Instruction ins, MethodDef def)
        {
            throw new NotImplementedException("Ble_Un is not implemented");
        }
    }
}
