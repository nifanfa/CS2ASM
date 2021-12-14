using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldfld)]
        public static void Ldfld(BaseArch arch, Instruction ins, MethodDef def)
        {
            arch.Append("pop rax");
            arch.Append($"add rax,{Util.SizeOfOrIndex(((FieldDef)ins.Operand).DeclaringType, (FieldDef)ins.Operand)}");
            arch.Append($"xor rcx,rcx");
            switch (Util.SizeOfShallow(((FieldDef)ins.Operand).FieldType.FullName))
            {
                case 1:
                    arch.Append($"mov cl,[rax]");
                    break;
                case 2:
                    arch.Append($"mov cx,[rax]");
                    break;
                case 4:
                    arch.Append($"mov ecx,[rax]");
                    break;
                default:
                    arch.Append($"mov rcx,[rax]");
                    break;
            }
            arch.Append("push qword rcx");
        }
    }
}
