using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Stfld)]
        public static void Stfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"pop rax");
            arch.Append($"pop rdi");
            arch.Append($"add rdi,{Utility.IndexInStack(((FieldDef)ins.Operand).DeclaringType.Fields, (FieldDef)ins.Operand)}");
            switch (Utility.SizeInStack(((FieldDef)ins.Operand))) 
            {
                case 1:
                    arch.Append($"stosb");
                    break;
                case 2:
                    arch.Append($"stosw");
                    break;
                case 4:
                    arch.Append($"stosd");
                    break;
                default:
                    arch.Append($"stosq");
                    break;
            }
        }
    }
}
