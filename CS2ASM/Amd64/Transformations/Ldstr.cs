using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Text;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldstr)]
        public static void Ldstr(BaseArch arch, Instruction ins, MethodDef def)
        {
            var nextIns = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];
            if (nextIns.IsStloc())
            {
                var bytes = Encoding.Unicode.GetBytes((string)ins.Operand);
                var text = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i] + (i + 1 == bytes.Length ? "" : ",");
                }
                ulong Index = OperandParser.Stloc(nextIns) + 1;

                arch.Append($"mov qword [rbp-{Index * 8}],{Amd64.SafeMethodName(def)}.{ins.Offset:X4}.String");

                arch.Append($"jmp {Amd64.SafeMethodName(def)}.{ins.Offset:X4}");
                arch.Append($"{Amd64.SafeMethodName(def)}.{ins.Offset:X4}.String:");
                arch.Append($"dq {((string)ins.Operand).Length}");
                arch.Append($"dq $+8");
                arch.Append($"db {text}");
                arch.Append($"{Amd64.SafeMethodName(def)}.{ins.Offset:X4}:");
                arch.SkipNextInstruction();
            }
            else
            {
                if(!InlineASMStage.NewMethod(arch, ins, def, nextIns)) 
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
