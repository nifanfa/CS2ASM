using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;
using System.Text;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldstr)]
        public static void Ldstr(BaseArch arch, Instruction ins, MethodDef def)
        {
            var nextIns = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];

            if (nextIns.Operand is MethodDef && ((MethodDef)nextIns.Operand).FullName == "System.Void System.Runtime.Intrinsic::asm(System.String)")
            {
                if (!InlineAssembly.NewMethod(arch, ins, def, nextIns))
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                var bytes = Encoding.Unicode.GetBytes((string)ins.Operand);
                var text = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i] + (i + 1 == bytes.Length ? "" : ",");
                }
                arch.Append($"push qword {Utility.SafeMethodName(def)}.{ins.Offset:X4}.String");
                arch.Append($"push qword {((string)ins.Operand).Length}");
                arch.Append($"call System.String.Ctor.Char.UInt64");

                arch.Append($"jmp $+{bytes.Length + 2}");
                arch.Append($"{Utility.SafeMethodName(def)}.{ins.Offset:X4}.String:");
                arch.Append($"db {text}");
            }
        }
    }
}
