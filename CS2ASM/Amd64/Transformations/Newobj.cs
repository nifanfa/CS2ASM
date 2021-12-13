using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            Sizeof(arch, new Instruction() { Operand = ((MethodDef)ins.Operand).DeclaringType }, def);
            arch.Append($"call System.Runtime.CompilerServices.Unsafe.Stackalloc.UInt64");
            arch.Append($"pop rax");
            arch.Append($"push rax");
            arch.Append($"push rax");
            arch.Append($"call {Util.SafeMethodName((MethodDef)ins.Operand)}");

            Sizeof(arch, new Instruction() { Operand = ((MethodDef)ins.Operand).DeclaringType }, def);

            //Object.Size
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rdx");
            arch.Append($"pop rax");
            arch.Append($"push rax");
            arch.Append($"add [rax],rdx");
        }
    }
}
