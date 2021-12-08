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
            if (
                ((FieldDef)ins.Operand).FieldType.FullName == "System.Byte" ||
                ((FieldDef)ins.Operand).FieldType.FullName == "System.SByte"
                )
            {
                arch.Append($"stosb");
            }
            else if (
                ((FieldDef)ins.Operand).FieldType.FullName == "System.Char" ||
                ((FieldDef)ins.Operand).FieldType.FullName == "System.Int16" ||
                ((FieldDef)ins.Operand).FieldType.FullName == "System.UInt16"
                )
            {
                arch.Append($"stosw");
            }
            else if (
               ((FieldDef)ins.Operand).FieldType.FullName == "System.Int32" ||
               ((FieldDef)ins.Operand).FieldType.FullName == "System.UInt32"
               )
            {
                arch.Append($"stosd");
            }
            else
            {
                arch.Append($"stosq");
            }
        }
    }
}
