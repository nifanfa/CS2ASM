﻿using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public static unsafe partial class Amd64Bridge
    {
        [ILBridge(Code.Br_S)]
        public static void Br_S(Arch arch, Instruction ins, MethodDef def)
        {
            arch.Append($"jmp {def.SafeName()}_IL_{((Instruction)(ins.Operand)).Offset:X4}");
        }
    }
}