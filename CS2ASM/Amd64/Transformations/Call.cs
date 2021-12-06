using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Call)]
        public static void Call(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"call {Amd64.SafeMethodName(((MethodDef)ins.Operand))}");
        }
    }
}
