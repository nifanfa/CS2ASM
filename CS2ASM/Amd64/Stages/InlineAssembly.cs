using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM.AMD64;

public static class InlineAssembly
{
    public static bool NewMethod(Context context)
    {
        if (context.nextInstruction.OpCode.Code != Code.Call || (MethodDef)context.nextInstruction.Operand !=
            context.arch.CompilerMethods[Methods.ASM]) return false;

        var comment = (string)context.operand;
        var paramCount = context.def.Parameters.Count;
        var open = comment.IndexOf('{');

        if (open != -1 && comment.IndexOf('}') != -1)
        {
            var cpy = comment[(open + 1)..];
            cpy = cpy[..cpy.IndexOf('}')];

            foreach (var v in context.def.Parameters)
            {
                if (v.Name != cpy)
                    continue;

                // ldarg
                comment = comment.Replace($"{{{cpy}}}", $"[rbp-{(paramCount - v.Index) * 8}]");
                goto End;
            }

            foreach (var v in context.def.Body.Variables)
            {
                if (v.Name != cpy)
                    continue;

                // ldloc
                comment = comment.Replace($"{{{cpy}}}", $"[rbp-{((ulong)context.def.MethodSig.Params.Count + (ulong)(context.def.MethodSig.HasThis ? 1 : 0) + (ulong)v.Index + 1) * 8}]");
                goto End;
            }

            if (comment == (string)context.operand)
                throw new Exception($"\"{cpy}\" is not a valid variable of the context");
        }

        End:
        context.Append(comment);
        context.arch.SkipNextInstruction();
        return true;
    }
}