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

                //Instance
                /*
                context.Append($"mov rdi,LB_{bytes.GetHashCode():X2}");
                context.Append($"mov rsi,{((string)context.operand).Length}");
                context.Append($"call {context.arch.GetCompilerMethod(Methods.StringCtor)}");
                context.Append($"push rax");
                context.Append($"jmp LB_{context.nextInstruction.GetHashCode():X2}");
                context.Append($"LB_{bytes.GetHashCode():X2}:");
                context.Append($"db {text}");
                context.Append($"LB_{context.nextInstruction.GetHashCode():X2}:");
                */
                //Static
                context.Append($"push LB_{bytes.GetHashCode():X2}");
                context.Append($"jmp LB_{context.nextInstruction.GetHashCode():X2}");
                context.Append($"LB_{bytes.GetHashCode():X2}:");
                context.Append($"dq {Utility.SizeOf(context.def.Module,"System.String")+ (ulong)(((string)context.operand).Length*2)}");
                context.Append($"dq {((string)context.operand).Length}");
                context.Append($"dq LB_{bytes.GetHashCode():X2}+24");
                context.Append($"db {text}");
                context.Append($"LB_{context.nextInstruction.GetHashCode():X2}:");
            }
        }
    }
}
