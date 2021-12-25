using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I)]
        public static void Ldind_I(BaseArch arch, Instruction ins, MethodDef def)
        {
            var prev = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];
            if (prev.IsLdloc())
            {
                var p = def.Body.Variables[(int)OperandParser.Ldloc(prev)];
                if (!p.Type.IsPointer)
                {
                    return;
                }
            }
            if (prev.IsLdarg())
            {
                var p = def.Parameters[(int)OperandParser.Ldarg(prev)];
                if (!p.Type.IsPointer)
                {
                    return;
                }
            }

            Debugger.Break();
            arch.Append($"pop rax");
            arch.Append($"push qword [rax]");
        }
    }
}
