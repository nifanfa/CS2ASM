using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldind_I8)]
        public static void Ldind_I8(BaseArch arch, Instruction ins, MethodDef def, Context context)
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

            context.Append($"pop rax");
            context.Append($"push qword [rax]");
        }
    }
}
