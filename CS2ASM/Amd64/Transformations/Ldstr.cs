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
        public static void Ldstr(Context context)
        {
            if (context.nextInstruction.Operand is MethodDef && ((MethodDef)context.nextInstruction.Operand) == context.arch.CompilerMethods[Methods.ASM])
            {
                if (!InlineAssembly.NewMethod(context))
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                var bytes = Encoding.Unicode.GetBytes((string)context.operand);
                var text = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i] + (i + 1 == bytes.Length ? "" : ",");
                }
                //Every object has its unique hash code this is why i use it
                context.Append($"mov qword rax,LB_{bytes.GetHashCode():X2}");
                context.Append($"push rax");
                context.Append($"mov qword rax,{((string)context.operand).Length}");
                context.Append($"push rax");
                context.Append($"pop rsi");
                context.Append($"pop rdi");
                context.Append($"call {context.arch.GetCompilerMethod(Methods.StringCtor)}");
                context.Append($"push rax");
                context.Append($"jmp LB_{context.nextInstruction.GetHashCode():X2}");
                context.Append($"LB_{bytes.GetHashCode():X2}:");
                context.Append($"db {text}");
                context.Append($"LB_{context.nextInstruction.GetHashCode():X2}:");
            }
        }
    }
}
