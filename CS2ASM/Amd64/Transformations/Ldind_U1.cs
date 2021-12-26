using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_U1)]
        public static void Ldind_U1(BaseArch arch, Instruction ins, MethodDef def)
        {
            //This is for "this" keyword
            var prev = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];
            if (prev.IsLdarg())
            {
                var p = def.Parameters[(int)OperandParser.Ldarg(prev)];
                if (!p.Type.IsPointer)
                {
                    return;
                }
            }

            arch.Append($"pop rax");
            arch.Append($"push qword [rax]");
        }
    }
}
