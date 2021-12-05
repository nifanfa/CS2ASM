using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldc_I8)]
        public static void Ldc_I8(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"sub rsp,8");
            arch.Append($"mov qword rax,{OperandParser.Ldc(ins)}");
            arch.Append($"mov rdi,rsp");
            arch.Append($"stosq");
        }
    }
}
