using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS2ASM.AMD64
{
    public static class InlineAssembly
    {
        public static bool NewMethod(BaseArch arch, Instruction ins, MethodDef def, Instruction nextIns)
        {
            if (nextIns.OpCode.Code == Code.Call && ((MethodDef)nextIns.Operand).FullName == "System.Void System.Runtime.Intrinsic::asm(System.String)")
            {
                string comment = (string)ins.Operand;
                int paramCount = def.Parameters.Count;

                string cpy = comment;
                if (cpy.IndexOf("{") != -1 && cpy.IndexOf("}") != -1)
                {
                    cpy = cpy.Substring(cpy.IndexOf("{") + 1);
                    cpy = cpy.Substring(0, cpy.IndexOf("}"));

                    foreach (var v in def.Parameters)
                    {
                        if (v.Name == cpy)
                        {
                            //ldarg
                            comment = comment.Replace($"{{{cpy}}}", $"[rbp+{(paramCount + 0 - v.Index) * 8}]");
                            goto End;
                        }
                    }

                    foreach (var v in def.Body.Variables)
                    {
                        if (v.Name == cpy)
                        {
                            //ldloc
                            comment = comment.Replace($"{{{cpy}}}", $"[rbp-{(v.Index + 1) * 8}]");
                            goto End;
                        }
                    }

                    if (comment == (string)ins.Operand)
                    {
                        throw new Exception($"\"{cpy}\" is not a valid variable of the context");
                    }
                }
            End:
                arch.Append($"{comment}");
                arch.SkipNextInstruction();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
