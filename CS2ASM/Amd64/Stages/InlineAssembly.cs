using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS2ASM.AMD64
{
    public static class InlineAssembly
    {
        public static bool NewMethod(Context context)
        {
            if (context.nextInstruction.OpCode.Code == Code.Call && ((MethodDef)context.nextInstruction.Operand) == context.arch.CompilerMethods[Methods.ASM])
            {
                string comment = (string)context.operand;
                int paramCount = context.def.Parameters.Count;

                string cpy = comment;
                if (cpy.IndexOf("{") != -1 && cpy.IndexOf("}") != -1)
                {
                    cpy = cpy.Substring(cpy.IndexOf("{") + 1);
                    cpy = cpy.Substring(0, cpy.IndexOf("}"));

                    foreach (var v in context.def.Parameters)
                    {
                        if (v.Name == cpy)
                        {
                            //ldarg
                            comment = comment.Replace($"{{{cpy}}}", $"[rbp+{(paramCount + 0 - v.Index) * 8}]");
                            goto End;
                        }
                    }

                    foreach (var v in context.def.Body.Variables)
                    {
                        if (v.Name == cpy)
                        {
                            //ldloc
                            comment = comment.Replace($"{{{cpy}}}", $"[rbp-{(v.Index + 1) * 8}]");
                            goto End;
                        }
                    }

                    if (comment == (string)context.operand)
                    {
                        throw new Exception($"\"{cpy}\" is not a valid variable of the context");
                    }
                }
            End:
                context.Append($"{comment}");
                context.arch.SkipNextInstruction();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
